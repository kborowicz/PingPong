using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.KUKA {
    /// <summary>
    /// Provides methods for receiving and sending data to the KUKA robot
    /// with RSI (Robot Sensor Interface) installed
    /// </summary>
    public class RSIAdapter {

        private readonly UdpClient client;

        private IPEndPoint remoteEndPoint;

        /// <summary>
        /// Remote endpoint Ip (RSI ip)
        /// </summary>
        public string Ip {
            get {
                return remoteEndPoint.Address.ToString();
            }
        }

        public RSIAdapter(int port) {
            client = new UdpClient(new IPEndPoint(IPAddress.Any, port));
        }

        /// <summary>
        /// Connects to robot and returns the first received frame
        /// </summary>
        /// <returns>First received frame</returns>
        public async Task<InputFrame> Connect() {
            UdpReceiveResult result = await client.ReceiveAsync();
            remoteEndPoint = result.RemoteEndPoint;
            byte[] receivedBytes = result.Buffer;

            return new InputFrame(Encoding.ASCII.GetString(receivedBytes, 0, receivedBytes.Length));
        }

        /// <summary>
        /// Close connection
        /// </summary>
        public void Disconnect() {
            client.Close();
            remoteEndPoint = null;
        }

        /// <summary>
        /// Receives data from the remoteEndPoint (KUKA robot) asynchronously
        /// </summary>
        /// <returns>Parsed data as InputFrame</returns>
        public async Task<InputFrame> ReceiveDataAsync() {
            UdpReceiveResult result = await client.ReceiveAsync();
            byte[] receivedBytes = result.Buffer;

            return new InputFrame(Encoding.ASCII.GetString(receivedBytes, 0, receivedBytes.Length));
        }

        /// <summary>
        /// Sends data to the remoteEndPoint (KUKA robot) 
        /// </summary>
        /// <param name="data">data to sent</param>
        public void SendData(OutputFrame data) {
            byte[] bytes = Encoding.ASCII.GetBytes(data.ToString());
            client.Send(bytes, bytes.Length, remoteEndPoint);
        }

    }
}