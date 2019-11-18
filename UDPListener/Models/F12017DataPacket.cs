using UDPListener.Interfaces;

namespace UDPListener.Models
{
    public class F12017DataPacket : IDataPacket
    {
        public int Id { get; set; }
        public float Time { get; set; }
        public float LapTime { get; set; }
        public float LapDistance { get; set; }
        public float TotalDistance { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Speed { get; set; }
        public float XVelocity { get; set; }
        public float YVelocity { get; set; }
        public float ZVelocity { get; set; }
        public float XRight { get; set; }
        public float YRight { get; set; }
        public float ZRight { get; set; }
        public float XForward { get; set; }
        public float YForward { get; set; }
        public float ZForward { get; set; }
        //public float[] SuspPosition { get; set; } = new float[4];
        //public float[] SuspVelocity { get; set; } = new float[4];
        //public float[] WheelSpeed { get; set; } = new float[4];
        //public float Throttle { get; set; }
        //public float Steer { get; set; }
        //public float Brake { get; set; }
        //public float Clutch { get; set; }
        //public float Gear { get; set; }
        //public float GForceLat { get; set; }
        //public float GForceLong { get; set; }
        //public float Lap { get; set; }
        //public float EngineRate { get; set; }
        //public float SliProNativeSupport { get; set; }
        //public float CarPosition { get; set; }
        //public float KersLEvel { get; set; }
        //public float KersMaxLevel { get; set; }
        //public float DRS { get; set; }
        //public float TractionControl { get; set; }
        //public float AntiLockBrakes { get; set; }
        //public float FuelInTank { get; set; }
        //public float FuelCapacity { get; set; }
        //public float InPits { get; set; }
        //public float Sector { get; set; }
        //public float Sector1Time { get; set; }
        //public float Sector2Time { get; set; }
        //public float[] BrakesTemp { get; set; } = new float[4];
        //public float[] TyrePressures { get; set; } = new float[4];
        //public float TeamInfo { get; set; }
        //public float TotalLaps { get; set; }
        //public float TrackSize { get; set; }
        //public float LastLapTime { get; set; }
        //public float MaxRpm { get; set; }
        //public float IdleRpm { get; set; }
        //public float MaxGears { get; set; }
        //public float SessionType { get; set; }
        //public float DRSAllowed { get; set; }
        //public float TrackNumber { get; set; }
        //public float VehicleFIAFlags { get; set; }
        //public float Era { get; set; }
        //public float EngineTemp { get; set; }
        //public float GForceVert { get; set; }
        //public float AngleVelX { get; set; }
        //public float AngleVelY { get; set; }
        //public float AngleVelZ { get; set; }
        //public byte[] TyreTemps { get; set; } = new byte[4];
        //public byte[] TyreWear { get; set; } = new byte[4];
        //public byte TyreCompound { get; set; }
        //public byte FrontBrakeBias { get; set; }
        //public byte FuelMix { get; set; }
        //public byte CurrentLapInvalid { get; set; }
        //public byte[] TyreDamage { get; set; } = new byte[4];
        //public byte FrontWingLeftDamage { get; set; }
        //public byte FrontWingRightDamage { get; set; }
        //public byte RearWingDamage { get; set; }
        //public byte EngineDamage { get; set; }
        //public byte GearboxDamage { get; set; }
        //public byte ExhaustDamage { get; set; }
        //public byte PitLimiterStatus { get; set; }
        //public byte PitSpeedLimit { get; set; }
        //public float SessionTimeLeft { get; set; }
        //public byte RevLightsPercentage { get; set; }
        //public byte IsSpectating { get; set; }
        //public byte SpectatorCarIndex { get; set; }
        //public byte NumCars { get; set; }
        //public byte PlayerCarIndex { get; set; }
        ////public CarUDPData[] CarData { get; set; } = new CarUDPData[20];   // data for all cars on track
        //public float Yaw { get; set; }
        //public float Pitch { get; set; }
        //public float Roll { get; set; }
        //public float XLocalVelocity { get; set; }
        //public float YLocalVelocity { get; set; }
        //public float ZLocalVelocity { get; set; }
        //public float[] SuspAcceleration { get; set; } = new float[4];
        //public float AngAccX { get; set; }
        //public float AngAccY { get; set; }
        //public float AngAccZ { get; set; }
    }
}