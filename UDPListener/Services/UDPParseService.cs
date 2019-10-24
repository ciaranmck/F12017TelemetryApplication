using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UDPListener.Models;

namespace UDPListener.Services
{
    public class UDPParseService
    {
        private Listener udp = new Listener(20777, 1289);

        public void GetUDPStream()
        {
            udp.StartListener();
        }

        public F12017DataPacket GetF12017Data(byte[] data) // F12017 specific config should be pulled out of this file.
        {
            F12017DataPacket Data = new F12017DataPacket { };
            PropertyInfo[] DatapacketProperties = Data.GetType().GetProperties();

            int byteIndex = 0;
            var expectedType = typeof(float);

            foreach (var item in DatapacketProperties)
            {
                if (item.PropertyType == expectedType)
                {
                    item.SetValue(Data, ConvertBytesToFloat(data, byteIndex));
                    byteIndex = byteIndex += 4;

                } else if (item.PropertyType.IsArray)
                {
                    if (expectedType.IsAssignableFrom(item.PropertyType.GetElementType()))
                    {
                        foreach (float floatPoint in (float[])item.GetValue(item)) // need to enter float[] and loop through it x times 
                        {
                            floatPoint = ConvertBytesToFloat(data, byteIndex);
                            item.SetValue(item, ConvertBytesToFloat(data, byteIndex));
                            byteIndex = byteIndex += 4;
                        }
                    }

                } else if (item.GetType() == typeof(byte))
                {
                    item.SetValue(Data, byteIndex);
                    byteIndex = byteIndex += 1;
                }
            }
            return Data;
        }

        private static float ConvertBytesToFloat(byte[] bytes, int index) 
        {
            return BitConverter.ToSingle(bytes, index);
        }
    }
}