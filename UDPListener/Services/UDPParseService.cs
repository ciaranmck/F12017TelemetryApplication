using System;
using System.Collections.Generic;
using System.Text;
using UDPListener.Models;

namespace UDPListener.Services
{
    class UDPParseService
    {
        private UDPListener udp;

        private byte[] GetUDPStream()
        {
            return udp.StartListener();
        }

        private F12017DataPacket GetF12017Data()
        {
            var data = GetUDPStream(); //psuedo code

            F12017DataPacket Data = new F12017DataPacket
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
