using System;
using System.Collections.Generic;
using System.Text;

namespace UDPListener.Models
{
    public class CarUDPData
    {
        public float[] WorldPosition { get; set; } = new float[3]; // world co-ordinates of vehicle
        public float LastLapTime { get; set; }
        public float CurrentLapTime { get; set; }
        public float BestLapTime { get; set; }
        public float SectorTime { get; set; }
        public float Sector2Time { get; set; }
        public float LapDistance { get; set; }
        public byte DriverId { get; set; }
        public byte TeamId { get; set; }
        public byte CarPosition { get; set; }     // UPDATED: track positions of vehicle
        public byte CurrentLapNumber { get; set; }
        public byte TyreCompound { get; set; }    // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet
        public byte InPits { get; set; }           // 0 = none, 1 = pitting, 2 = in pit area
        public byte Sector { get; set; }           // 0 = sector1, 1 = sector2, 2 = sector3
        public byte CurrentLapInvalid { get; set; } // current lap invalid - 0 = valid, 1 = invalid
        public byte Penalties { get; set; }  // NEW: accumulated time penalties in seconds to be added
    }
}
