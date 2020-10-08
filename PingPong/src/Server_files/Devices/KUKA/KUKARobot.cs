﻿using System.Threading.Tasks;

namespace PingPong.Devices {

    class KUKARobot : IDevice {

        private bool isInitialized = false;

        private readonly RSIAdapter rsiAdapter;

        public event InitializeEventHandler OnInitialize;

        public event FrameReceivedEventHandler OnFrameReceived;

        public event FrameSentEventHandler OnFrameSent;

        public InputFrame LastInputFrame { get; private set; }

        public OutputFrame LastOutputFrame { get; private set; }

        public E6POS TargetPosition { get; set; }

        public E6POS CurrentPosition {
            get {
                return LastInputFrame.Position;
            }
        }

        public KUKARobot(int port) {
            rsiAdapter = new RSIAdapter(port);
        }

        /// <summary>
        /// Receives data from the robot, raises OnFrameReceived event
        /// </summary>
        public async Task ReceiveDataAsync() {
            LastInputFrame = await rsiAdapter.ReceiveDataAsync();
            OnFrameReceived?.Invoke(LastInputFrame);
        }

        /// <summary>
        /// Move robot to TargetPosition, raises OnFrameSent event
        /// </summary>
        public void MoveToTargetPosition() {
            //TODO: Sprawdzenie czy pozycja jest dozwolona (nie wykracza poza dopuszczany zakres ruchu)

            LastOutputFrame = new OutputFrame() {
                IPOC = LastInputFrame.IPOC,
                Position = TargetPosition
            };

            rsiAdapter.SendData(LastOutputFrame);
            OnFrameSent?.Invoke(LastOutputFrame);
        }

        /// <summary>
        /// Stops the robot program execution, raises OnFrameSent event
        /// </summary>
        public void SendError(string errorMessage) {
            LastOutputFrame = new OutputFrame() {
                Message = $"Error: {errorMessage}",
                Position = CurrentPosition,
                IPOC = LastInputFrame.IPOC
            };

            rsiAdapter.SendData(LastOutputFrame);
            OnFrameSent?.Invoke(LastOutputFrame);
        }

        /// <summary>
        /// Establish connection with the robot, raises OnInitialize and OnFrameReceived events
        /// </summary>
        public void Initialize() {
            if(isInitialized) {
                return;
            }

            Task.Run(async () => {
                LastInputFrame = await rsiAdapter.Connect();
                TargetPosition = new E6POS(); //TODO: dla pozycji absolutnej TargetPosition = (E6POS) CurrentPosition.Clone()
                isInitialized = true;

                // Send response (prevent connection timeout)
                rsiAdapter.SendData(new OutputFrame() {
                    IPOC = LastInputFrame.IPOC,
                    Position = TargetPosition
                });

                OnInitialize?.Invoke();
                OnFrameReceived?.Invoke(LastInputFrame);
            });
        }

        public bool IsInitialized() {
            return isInitialized;
        }

        public void Disconnect() {
            rsiAdapter.Disconnect();
        }

        public delegate void InitializeEventHandler();

        public delegate void FrameReceivedEventHandler(InputFrame inputFrame);

        public delegate void FrameSentEventHandler(OutputFrame outputFrame);

    }
}
