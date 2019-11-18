using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Configuration;
using UDPListener.Services;
using UDPListener.Interfaces;
using UDPListener.ModelsEFContexts;
using Microsoft.EntityFrameworkCore;
using log4net;
using System.Data.SqlClient;

namespace UDPListener
{
    public class Listener
    {
        List<IDataPacket> ByteStack = new List<IDataPacket>();
        UDPParseService parser = new UDPParseService();

        private static int ListenPort { get; set; }
        private static int BufferSize { get; set; }
        private static byte[] Bytes { get; set; }

        public Listener(int listenPort, int bufferSize)
        {
            ListenPort = listenPort;
            BufferSize = bufferSize;
            Bytes = new byte[BufferSize];
        }

        public void StartListener(string packetType)
        {
            // beginning of log4net implementation.

            //log4net.Config.BasicConfigurator.Configure();
            //ILog log = log4net.LogManager.GetLogger(typeof(Listener));
            //log.Info("Starting");

            UdpClient listener = new UdpClient(ListenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Any, ListenPort);
            listener.Client.ReceiveBufferSize = BufferSize;


            var optionsBuilder = new DbContextOptionsBuilder<F12017DataPacketContext>();
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["F12017DbConnection"].ConnectionString);

            try
            {
                while (true)
                {
                    Bytes = listener.Receive(ref groupEP);

                    var parsedData = parser.ParseObject(Bytes, packetType);
                    ByteStack.Add(parsedData);

                    using (var db = new F12017DataPacketContext(optionsBuilder.Options)) // create a service/factory here that handles which context file to return
                    {

                        ByteStack.ForEach(dataPacket =>
                        {
                            db.Add(dataPacket);
                        });

                        db.SaveChanges();
                    }
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
