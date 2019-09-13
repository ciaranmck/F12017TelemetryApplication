using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace UDPListener.Services
{
    public class Listener
    {
        private int _listenPort;
        private int _bufferSize;
        private byte[] _bytes;

        public Listener(int listenPort, int bufferSize)
        {
            _listenPort = listenPort;
            _bufferSize = bufferSize;
            byte[] _bytes = new byte[_bufferSize];
        }

        public void StartListener()
        {
            UdpClient listener = new UdpClient(_listenPort);
            listener.Client.ReceiveBufferSize = _bufferSize;
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, _listenPort);
 
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    _bytes = listener.Receive(ref groupEP);
                    string returnData = Encoding.ASCII.GetString(_bytes);

                    Console.WriteLine($"Received data:  {returnData} :");
                    Console.WriteLine($" {Encoding.ASCII.GetString(_bytes, 0, _bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
