﻿using System;
using NatNetML;
using PingPong.Devices.KUKA;

namespace PingPong.Devices.OptiTrack {
    class OptiTrackSystem : IDevice {

        public enum ConnetionType : int {
            Multicast = 0,
            Unicast = 1
        }

        private bool isInitialized = false;

        private readonly NatNetClientML natNetClient;

        private readonly ServerDescription serverDescription;

        public InputFrame LastReceivedFrame { get; private set; }

        public event InitializeEventHandler OnInitialize;

        public event FrameReceivedEventHandler OnFrameReceived;

        public delegate void InitializeEventHandler();

        public delegate void FrameReceivedEventHandler(InputFrame receivedFrame);

        public OptiTrackSystem(ConnetionType connetionType = ConnetionType.Multicast) {
            natNetClient = new NatNetClientML((int) connetionType);
            serverDescription = new ServerDescription();
        }

        public void Calibrate(KUKARobot robot, E6POS startPosition, E6POS endPosition) {
            if (!isInitialized || !robot.IsInitialized()) {
                throw new Exception("Optitrack and KUKA robot must be initialized");
            }

            //TODO: kalibracja z wykorzystaniem ZAINICJALIZOWANEGO robota
            //TODO: gdzie trzymac wyznaczone macierze rotacji i wekt translacji ? w kuce czy w optitracku ?
        }

        public void Initialize() {
            if(isInitialized) {
                return;
            }

            int status = natNetClient.Initialize("127.0.0.1", "127.0.0.1");

            if(status != 0) {
                throw new Exception("Optitrack initialization failed. Is Motive application running?");
            }

            status = natNetClient.GetServerDescription(serverDescription);

            if(status != 0) {
                throw new Exception("Optitrack connection failed. Is Motive application running?");
            }

            object synchronizeLock = new object();

            natNetClient.OnFrameReady += (data, client) => {
                lock (synchronizeLock) {
                    LastReceivedFrame = new InputFrame(data);
                    OnFrameReceived?.Invoke(LastReceivedFrame);
                }
            };

            isInitialized = true;
            OnInitialize?.Invoke();
        }

        public bool IsInitialized() {
            return isInitialized;
        }

        public void Uninitialize() {
            isInitialized = false;
            natNetClient.Uninitialize();
        }

    }
}
