using System;
using System.Collections;
using System.Reflection;
using UDPListener.Interfaces;
using UDPListener.Models;

namespace UDPListener.Services
{
    public class UDPParseService
    {
        public IDataPacket GetDataPacket(byte[] rawDataPacket, IDataPacket objectToParse) // F12017 specific config should be pulled out of this file.
        {
            PropertyInfo[] DatapacketProperties = objectToParse.GetType().GetProperties();

            int byteIndex = 0;
            var expectedTypeIsFloat = typeof(float);
            var expectedTypeIsByte = typeof(byte);

            foreach (var item in DatapacketProperties)
            {
                if (item.PropertyType == expectedTypeIsFloat)
                {
                    item.SetValue(objectToParse, ConvertBytesToFloat(rawDataPacket, byteIndex));
                    byteIndex = byteIndex += 4;

                }
                else if (item.GetType() == typeof(byte))
                {
                    item.SetValue(objectToParse, byteIndex);
                    byteIndex = byteIndex += 1;
                }
                else if (item.PropertyType.IsArray)
                {
                    if (expectedTypeIsFloat.IsAssignableFrom(item.PropertyType.GetElementType()))
                    {
                        var values = (Array)item.GetValue(objectToParse);
                        var floatList = (IList)values;

                        for (var i = 0; i < values.Length; i++) 
                        {
                            floatList[i] =  ConvertBytesToFloat(rawDataPacket, byteIndex);
                            byteIndex = byteIndex += 4;
                        }
                        item.SetValue(objectToParse, (Array)floatList);
                    }
                    else if (expectedTypeIsByte.IsAssignableFrom(item.PropertyType.GetElementType()))
                    {
                        var values = (Array)item.GetValue(objectToParse);
                        var floatList = (IList)values;

                        for (var i = 0; i < values.Length; i++) 
                        {
                            floatList[i] = rawDataPacket[byteIndex];
                            byteIndex = byteIndex += 1;
                        }
                        item.SetValue(objectToParse, (Array)floatList);
                    }
                } 
            }
            return objectToParse;
        }

        private static float ConvertBytesToFloat(byte[] bytes, int index) 
        {
            return BitConverter.ToSingle(bytes, index);
        }
    }
}