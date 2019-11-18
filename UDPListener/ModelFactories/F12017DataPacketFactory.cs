using UDPListener.Interfaces;
using UDPListener.Models;

namespace UDPListener.ModelFactories
{
    class F12017DataPacketFactory : F1TelemetryDataPacketFactory
    {
        public F12017DataPacketFactory()
        {

        }

        public override IDataPacket GetDataPacket()
        {
            return new F12017DataPacket();
        }
    }
}
