using System;
using System.Collections;
using System.Reflection;
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
                        var floatList = (IList)Array.CreateInstance(item.PropertyType.GetElementType(), 4);

                        for (var i = 0; i < floatList.Count; i++) // need to enter float[] and loop through it x times 
                        {
                            floatList[i] =  ConvertBytesToFloat(data, byteIndex);
                            byteIndex = byteIndex += 4;
                        }
                        item.SetValue(item, (Array)floatList);
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