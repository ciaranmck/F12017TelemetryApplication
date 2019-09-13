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
        public static void Main(string[] args)
        {
            Listener listener = new Listener(20777, 1289);

            listener.StartListener();
            //UDPParseService DataParser = new UDPParseService();
            //F12017DataPacket Data = DataParser.GetF12017Data();

            //Console.WriteLine(Data);
        }
    }
}