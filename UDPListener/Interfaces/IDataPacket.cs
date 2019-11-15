using UDPListener.Models;

namespace UDPListener.Interfaces
{
    public interface IDataPacket
    {
        IDataPacket ParseObject(byte[] bytes, IDataPacket thing);
        float ConvertBytesToFloat(byte[] bytes, int index);
        //float Time { get; set; }
        //float LapTime { get; set; }
        //float LapDistance { get; set; }
        //float TotalDistance { get; set; }
        //float X { get; set; }  // World space position
        //float Y { get; set; }  // World space position
        //float Z { get; set; }  // World space position
        //float Speed { get; set; }  // Speed of car in MPH
        //float XVelocity { get; set; } // Velocity in world space
        //float YVelocity { get; set; } // Velocity in world space
        //float ZVelocity { get; set; } // Velocity in world space
        //float XRight { get; set; } // World space right direction
        //float YRight { get; set; } // World space right direction
        //float ZRight { get; set; } // World space right direction
        //float XForward { get; set; } // World space forward direction
        //float YForward { get; set; } // World space forward direction
        //float ZForward { get; set; } // World space forward direction
        //float[] SuspPosition { get; set; }   // Note: All wheel arrays have the order:
        //float[] SuspVelocity { get; set; } // RL, RR, FL, FR
        //float[] WheelSpeed { get; set; }
        //float Throttle { get; set; }
        //float Steer { get; set; }
        //float Brake { get; set; }
        //float Clutch { get; set; }
        //float Gear { get; set; }
        //float GForceLat { get; set; }
        //float GForceLong { get; set; }
        //float Lap { get; set; }
        //float EngineRate { get; set; }
        //float SliProNativeSupport { get; set; } // SLI Pro support
        //float CarPosition { get; set; }   // car race position
        //float KersLEvel { get; set; } // kers energy left
        //float KersMaxLevel { get; set; } // kers maximum energy
        //float DRS { get; set; }    // 0 = off, 1 = on
        //float TractionControl { get; set; }   // 0 (off) - 2 (high)
        //float AntiLockBrakes { get; set; }   // 0 (off) - 1 (on)
        //float FuelInTank { get; set; }   // current fuel mass
        //float FuelCapacity { get; set; }  // fuel capacity
        //float InPits { get; set; }    // 0 = none, 1 = pitting, 2 = in pit area
        //float Sector { get; set; } // 0 = sector1, 1 = sector2, 2 = sector3
        //float Sector1Time { get; set; }   // time of sector1 (or 0)
        //float Sector2Time { get; set; }   // time of sector2 (or 0)
        //float[] BrakesTemp { get; set; } // brakes temperature (centigrade)
        //float[] TyrePressures { get; set; }  // tyres pressure PSI
        //float TeamInfo { get; set; }  // team ID 
        //float TotalLaps { get; set; } // total number of laps in this race
        //float TrackSize { get; set; } // track size meters
        //float LastLapTime { get; set; }  // last lap time
        //float MaxRpm { get; set; }    // cars max RPM, at which point the rev limiter will kick in
        //float IdleRpm { get; set; }   // cars idle RPM
        //float MaxGears { get; set; }  // maximum number of gears
        //float SessionType { get; set; }    // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race
        //float DRSAllowed { get; set; } // 0 = not allowed, 1 = allowed, -1 = invalid / unknown
        //float TrackNumber { get; set; }   // -1 for unknown, 0-21 for tracks
        //float VehicleFIAFlags { get; set; }    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red
        //float Era { get; set; }                        // era, 2017 (modern) or 1980 (classic)
        //float EngineTemp { get; set; }     // engine temperature (centigrade)
        //float GForceVert { get; set; }    // vertical g-force component
        //float AngleVelX { get; set; }  // angular velocity x-component
        //float AngleVelY { get; set; }  // angular velocity y-component
        //float AngleVelZ { get; set; }  // angular velocity z-component
        //byte[] TyreTemps { get; set; }    // tyres temperature (centigrade)
        //byte[] TyreWear { get; set; }   // tyre wear percentage
        //byte TyreCompound { get; set; }   // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet
        //byte FrontBrakeBias { get; set; }         // front brake bias (percentage)
        //byte FuelMix { get; set; }                // fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max
        //byte CurrentLapInvalid { get; set; }       // current lap invalid - 0 = valid, 1 = invalid
        //byte[] TyreDamage { get; set; } // tyre damage (percentage)
        //byte FrontWingLeftDamage { get; set; }  // front left wing damage (percentage)
        //byte FrontWingRightDamage { get; set; } // front right wing damage (percentage)
        //byte RearWingDamage { get; set; }    // rear wing damage (percentage)
        //byte EngineDamage { get; set; }   // engine damage (percentage)
        //byte GearboxDamage { get; set; } // gear box damage (percentage)
        //byte ExhaustDamage { get; set; }  // exhaust damage (percentage)
        //byte PitLimiterStatus { get; set; }  // pit limiter status – 0 = off, 1 = on
        //byte PitSpeedLimit { get; set; } // pit speed limit in mph
        //float SessionTimeLeft { get; set; }  // NEW: time left in session in seconds 
        //byte RevLightsPercentage { get; set; }  // NEW: rev lights indicator (percentage)
        //byte IsSpectating { get; set; }  // NEW: whether the player is spectating
        //byte SpectatorCarIndex { get; set; }  // NEW: index of the car being spectated
        //// Car data
        //byte NumCars { get; set; }                // number of cars in data
        //byte PlayerCarIndex { get; set; }            // index of player's car in the array
        //CarUDPData[] CarData { get; set; }
        //float Yaw { get; set; }  // NEW (v1.8)
        //float Pitch { get; set; }  // NEW (v1.8)
        //float Roll { get; set; }  // NEW (v1.8)
        //float XLocalVelocity { get; set; }          // NEW (v1.8) Velocity in local space
        //float YLocalVelocity { get; set; }          // NEW (v1.8) Velocity in local space
        //float ZLocalVelocity { get; set; }          // NEW (v1.8) Velocity in local space
        //float[] SuspAcceleration { get; set; }   // NEW (v1.8) RL, RR, FL, FR
        //float AngAccX { get; set; }                 // NEW (v1.8) angular acceleration x-component
        //float AngAccY { get; set; }                 // NEW (v1.8) angular acceleration y-component
        //float AngAccZ { get; set; }                 // NEW (v1.8) angular acceleration z-component
    };
}
