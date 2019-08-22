using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UDPListener.Services;

namespace UDPListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            UDPParseService DataParser = new UDPParseService();

            DataParser.GetF12017Data();
        }
    }
}
