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
        private List<F12017DataPacket> ByteStack = new List<F12017DataPacket>() { };

        public Listener(int listenPort, int bufferSize)
        {
            ListenPort = listenPort;
            BufferSize = bufferSize;
            Bytes = new byte[BufferSize];
            OpenThreadAndStartListener();
        }

        public int ListenPort { get; set; }
        public int BufferSize { get; set; }
        public byte[] Bytes { get; set; }

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
