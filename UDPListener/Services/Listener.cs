using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using UDPListener.Models;
using UDPListener.Interfaces;

namespace UDPListener.Services
{
    public class Listener
    {
        private static List<IDataPacket> ByteStack = new List<IDataPacket>();
        private static UDPParseService parser = new UDPParseService();
        private static UdpClient listener = new UdpClient(ListenPort);
        private static IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);

        
        public Listener(int listenPort, int bufferSize)
        {
            ListenPort = listenPort;
            BufferSize = bufferSize;
            Bytes = new byte[BufferSize];
            // OpenThreadAndStartListener();
        }

        private static int ListenPort { get; set; }
        private static int BufferSize { get; set; }
        private static byte[] Bytes { get; set; }

        public void StartListener(IDataPacket objectToParse)
        {
            listener.Client.ReceiveBufferSize = BufferSize;
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    Bytes = listener.Receive(ref groupEP);

                    Console.WriteLine($" {Encoding.ASCII.GetString(Bytes, 0, Bytes.Length)}");

                    var parsedData = parser.GetDataPacket(Bytes, objectToParse);
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

        // Do we want to use threads in this application? Is there any benefit?

        // private void OpenThreadAndStartListener()
        // {
        //    Thread t1 = new Thread(new ThreadStart(StartListener));
        // }
    }
}
