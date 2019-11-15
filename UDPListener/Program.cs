using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPListener.Models;
using UDPListener.Services;

namespace UDPListener
{
    public class Program
    {
        public static void Main()
        {
            F12017DataPacket objectToParse = new F12017DataPacket();

            Listener listener = new Listener(20777, 1289);

            listener.StartListener(objectToParse);
        }
    }
}