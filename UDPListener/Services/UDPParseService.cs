using System;
using System.Collections;
using System.Reflection;
using UDPListener.Interfaces;
using UDPListener.ModelFactories;

namespace UDPListener.Services
{
    public class UDPParseService
    {
        private readonly F12017DataPacketFactory F12017Factory;

        private const string _F12017DATA = "F12017";

        public UDPParseService()
        {
            F12017Factory = new F12017DataPacketFactory(); //  import a factory service instead of each individual factory into the constructor.
        }

        public IDataPacket ParseObject(byte[] rawDataPacket, string packetType)
        {
            IDataPacket objectToParse = CheckPacketType(packetType);
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

        private IDataPacket CheckPacketType(string packetType) // this can go into a factory service class
        {
            F1TelemetryDataPacketFactory factory = null;

            switch (packetType)
            {
                case _F12017DATA:
                    factory = new F12017DataPacketFactory();

                    break;
            }
            IDataPacket dataPacket = factory.GetDataPacket();

            return dataPacket;
        }
    }
}