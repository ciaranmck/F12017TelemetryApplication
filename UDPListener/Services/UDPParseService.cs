using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UDPListener.Models;

namespace UDPListener.Services
{
    class UDPParseService
    {
        private UDPListener udp = new UDPListener();

        private byte[] GetUDPStream()
        {
            return udp.StartListener();
        }

        public F12017DataPacket GetF12017Data()
        {
            F12017DataPacket Data = new F12017DataPacket { };
            PropertyInfo[] DatapacketProperties = Data.GetType().GetProperties();

            var data = GetUDPStream(); //psuedo code

            int floatSize = 4;

            foreach (var item in DatapacketProperties)
            {
                Data[item.Name] = ConvertBytesToFLoat(data, floatSize);
            }

            Data = new F12017DataPacket
            {
                m_time = ConvertBytesToFLoat(data, 0), // methods like these should maybe make up the parser service, with this method being abstracted out.
                m_lapTime = ConvertBytesToFLoat(data, 4),
            };

            return Data;
        }

        private float ConvertBytesToFLoat(byte[] bytes, int index)
        {
            return BitConverter.ToSingle(bytes, index);
        }
    }
}
