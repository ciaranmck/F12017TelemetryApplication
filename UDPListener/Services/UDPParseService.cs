using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UDPListener.Models;

namespace UDPListener.Services
{
    class UDPParseService
    {
        private Listener udp = new Listener(20777, 1289);

        public void GetUDPStream()
        {
            udp.StartListener();
        }

        public F12017DataPacket GetF12017Data(byte[] data)
        {
            F12017DataPacket Data = new F12017DataPacket { };
            PropertyInfo[] DatapacketProperties = Data.GetType().GetProperties();

            int floatIndex = 0;

            foreach (var item in DatapacketProperties)
            {
                if (item.PropertyType == typeof(float))
                {
                    item.SetValue(Data, ConvertBytesToFLoat(data, floatIndex));
                    floatIndex = floatIndex + 4;

                } else if (item.GetType() == typeof(float[]))
                {
                    //foreach (float floatNumber in (float[])item.GetValue(item)) // need to enter float[] and loop through it x times 
                    //{
                    //    item.SetValue(item, ConvertBytesToFloat(data[floatIndex]));
                    //    floatIndex = floatIndex + 4;
                    //}
                } else if (item.GetType() == typeof(byte))
                {
                    floatIndex = floatIndex + 1;
                }
            }
            return Data;
        }

        private float ConvertBytesToFLoat(byte[] bytes, int index) 
        {
            return BitConverter.ToSingle(bytes, index);
        }
    }
}