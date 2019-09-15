using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using UDPListener.Models;

namespace UDPListener.Services
{
    public class Listener
    {
        private int _listenPort;
        private int _bufferSize;
        private byte[] _bytes;
        private List<F12017DataPacket> ByteStack = new List<F12017DataPacket>() { };

        public Listener(int listenPort, int bufferSize)
        {
            ListenPort = listenPort;
            BufferSize = bufferSize;
            byte[] Bytes = new byte[BufferSize];
            OpenThreadAndStartListener();
        }

        public int ListenPort { get => _listenPort; set => _listenPort = value; }
        public int BufferSize { get => _bufferSize; set => _bufferSize = value; }
        public byte[] Bytes { get => _bytes; set => _bytes = value; }

        public void StartListener()
        {
            UdpClient listener = new UdpClient(ListenPort);
            listener.Client.ReceiveBufferSize = BufferSize;
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);

            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    Bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($" {Encoding.ASCII.GetString(Bytes, 0, Bytes.Length)}");

                    UDPParseService parser = new UDPParseService();

                    var parsedData = parser.GetF12017Data(Bytes);
                    ByteStack.Add(parsedData);
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

        private void OpenThreadAndStartListener()
        {
            Thread t1 = new Thread(new ThreadStart(StartListener));
        }
    }
}
