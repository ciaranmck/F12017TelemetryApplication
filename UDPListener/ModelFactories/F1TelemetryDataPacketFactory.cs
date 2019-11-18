using UDPListener.Interfaces;

namespace UDPListener.ModelFactories
{
    abstract class F1TelemetryDataPacketFactory
    {
        public abstract IDataPacket GetDataPacket();
    }
}
