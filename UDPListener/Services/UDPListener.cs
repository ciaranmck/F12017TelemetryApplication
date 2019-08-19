using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace UDPListener.Services
{
    public class UDPListener
    {
        private const int listenPort = 20777; // create a port/ip address config class.

        public byte[] StartListener()
        {
            UdpClient listener = new UdpClient(listenPort);
            listener.Client.ReceiveBufferSize = 1289; // config

            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, listenPort);
 
            try
            {
                while (true)
                {
                    Console.WriteLine("Waiting for broadcast");
                    byte[] bytes = listener.Receive(ref groupEP);

                    return bytes;
                    //Console.WriteLine($"Received broadcast from {groupEP} :");
                    //Console.WriteLine($" {Encoding.ASCII.GetString(bytes, 0, bytes.Length)}");
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine(e);

                byte[] bytes= new byte[0];

                return bytes;
            }
            finally
            {
                listener.Close();
            }
        }
    }
}
