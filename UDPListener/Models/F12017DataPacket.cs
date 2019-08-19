using System;
using System.Collections.Generic;
using System.Text;

namespace UDPListener.Models
{
    public class F12017DataPacket
    {
        public float m_time { get; set; }

        public float m_lapTime { get; set; }

        public float m_lapDistance { get; set; }

        public float m_totalDistance { get; set; }

        public float m_x { get; set; }  // World space position

        public float m_y { get; set; }  // World space position

        public float m_z { get; set; }  // World space position

        public float m_speed { get; set; }  // Speed of car in MPH

        public float m_xv { get; set; } // Velocity in world space

        public float m_yv { get; set; } // Velocity in world space

        public float m_zv { get; set; } // Velocity in world space

        public float m_xr { get; set; } // World space right direction

        public float m_yr { get; set; } // World space right direction

        public float m_zr { get; set; } // World space right direction

        public float m_xd { get; set; } // World space forward direction

        public float m_yd { get; set; } // World space forward direction

        public float m_zd { get; set; } // World space forward direction

        public float[] m_susp_pos = new float[4];    // Note: All wheel arrays have the order:

        public float[] m_susp_vel = new float[4];    // RL, RR, FL, FR

        public float[] m_wheel_speed = new float[4];

        public float m_throttle { get; set; }

        public float m_steer { get; set; }

        public float m_brake { get; set; }

        public float m_clutch { get; set; }

        public float m_gear { get; set; }

        public float m_gforce_lat { get; set; }

        public float m_gforce_lon { get; set; }

        public float m_lap { get; set; }

        public float m_engineRate { get; set; }

        public float m_sli_pro_native_support { get; set; } // SLI Pro support

        public float m_car_position { get; set; }   // car race position

        public float m_kers_level { get; set; } // kers energy left

        public float m_kers_max_level { get; set; } // kers maximum energy

        public float m_drs { get; set; }    // 0 = off, 1 = on

        public float m_traction_control { get; set; }   // 0 (off) - 2 (high)

        public float m_anti_lock_brakes { get; set; }   // 0 (off) - 1 (on)

        public float m_fuel_in_tank { get; set; }   // current fuel mass

        public float m_fuel_capacity { get; set; }  // fuel capacity

        public float m_in_pits { get; set; }    // 0 = none, 1 = pitting, 2 = in pit area

        public float m_sector { get; set; } // 0 = sector1, 1 = sector2, 2 = sector3

        public float m_sector1_time { get; set; }   // time of sector1 (or 0)

        public float m_sector2_time { get; set; }   // time of sector2 (or 0)

        public float[] m_brakes_temp = new float[4]; // brakes temperature (centigrade)

        public float[] m_tyres_pressure = new float[4];  // tyres pressure PSI

        public float m_team_info { get; set; }  // team ID 

        public float m_total_laps { get; set; } // total number of laps in this race

        public float m_track_size { get; set; } // track size meters

        public float m_last_lap_time { get; set; }  // last lap time

        public float m_max_rpm { get; set; }    // cars max RPM, at which point the rev limiter will kick in

        public float m_idle_rpm { get; set; }   // cars idle RPM

        public float m_max_gears { get; set; }  // maximum number of gears

        public float m_sessionType { get; set; }    // 0 = unknown, 1 = practice, 2 = qualifying, 3 = race

        public float m_drsAllowed { get; set; } // 0 = not allowed, 1 = allowed, -1 = invalid / unknown

        public float m_track_number { get; set; }   // -1 for unknown, 0-21 for tracks

        public float m_vehicleFIAFlags { get; set; }    // -1 = invalid/unknown, 0 = none, 1 = green, 2 = blue, 3 = yellow, 4 = red

        public float m_era { get; set; }                        // era, 2017 (modern) or 1980 (classic)

        public float m_engine_temperature { get; set; }     // engine temperature (centigrade)

        public float m_gforce_vert { get; set; }    // vertical g-force component

        public float m_ang_vel_x { get; set; }  // angular velocity x-component

        public float m_ang_vel_y { get; set; }  // angular velocity y-component

        public float m_ang_vel_z { get; set; }  // angular velocity z-component

        public byte[] m_tyres_temperature = new byte[4];    // tyres temperature (centigrade)

        public byte[] m_tyres_wear = new byte[4];   // tyre wear percentage

        public byte m_tyre_compound { get; set; }   // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet

        public byte m_front_brake_bias { get; set; }         // front brake bias (percentage)

        public byte m_fuel_mix { get; set; }                // fuel mix - 0 = lean, 1 = standard, 2 = rich, 3 = max

        public byte m_currentLapInvalid { get; set; }       // current lap invalid - 0 = valid, 1 = invalid

        public byte[] m_tyres_damage = new byte[4]; // tyre damage (percentage)

        public byte m_front_left_wing_damage { get; set; }  // front left wing damage (percentage)

        public byte m_front_right_wing_damage { get; set; } // front right wing damage (percentage)

        public byte m_rear_wing_damage { get; set; }    // rear wing damage (percentage)

        public byte m_engine_damage { get; set; }   // engine damage (percentage)

        public byte m_gear_box_damage { get; set; } // gear box damage (percentage)

        public byte m_exhaust_damage { get; set; }  // exhaust damage (percentage)

        public byte m_pit_limiter_status { get; set; }  // pit limiter status – 0 = off, 1 = on

        public byte m_pit_speed_limit { get; set; } // pit speed limit in mph

        public float m_session_time_left { get; set; }  // NEW: time left in session in seconds 

        public byte m_rev_lights_percent { get; set; }  // NEW: rev lights indicator (percentage)

        public byte m_is_spectating { get; set; }  // NEW: whether the player is spectating

        public byte m_spectator_car_index { get; set; }  // NEW: index of the car being spectated



        // Car data

        public byte m_num_cars { get; set; }                // number of cars in data

        public byte m_player_car_index { get; set; }            // index of player's car in the array

        public CarUDPData[] m_car_data = new CarUDPData[20];   // data for all cars on track



        public float m_yaw { get; set; }  // NEW (v1.8)

        public float m_pitch { get; set; }  // NEW (v1.8)

        public float m_roll { get; set; }  // NEW (v1.8)

        public float m_x_local_velocity { get; set; }          // NEW (v1.8) Velocity in local space

        public float m_y_local_velocity { get; set; }          // NEW (v1.8) Velocity in local space

        public float m_z_local_velocity { get; set; }          // NEW (v1.8) Velocity in local space

        public float[] m_susp_acceleration = new float[4];   // NEW (v1.8) RL, RR, FL, FR

        public float m_ang_acc_x { get; set; }                 // NEW (v1.8) angular acceleration x-component

        public float m_ang_acc_y { get; set; }                 // NEW (v1.8) angular acceleration y-component

        public float m_ang_acc_z { get; set; }                 // NEW (v1.8) angular acceleration z-component
    };

    public class CarUDPData
    {
        public float[] m_worldPosition = new float[3]; // world co-ordinates of vehicle

        public float m_lastLapTime { get; set; }

        public float m_currentLapTime { get; set; }

        public float m_bestLapTime { get; set; }

        public float m_sector1Time { get; set; }

        public float m_sector2Time { get; set; }

        public float m_lapDistance { get; set; }

        public byte m_driverId { get; set; }

        public byte m_teamId { get; set; }

        public byte m_carPosition { get; set; }     // UPDATED: track positions of vehicle

        public byte m_currentLapNum { get; set; }

        public byte m_tyreCompound { get; set; }    // compound of tyre – 0 = ultra soft, 1 = super soft, 2 = soft, 3 = medium, 4 = hard, 5 = inter, 6 = wet

        public byte m_inPits { get; set; }           // 0 = none, 1 = pitting, 2 = in pit area

        public byte m_sector { get; set; }           // 0 = sector1, 1 = sector2, 2 = sector3

        public byte m_currentLapInvalid { get; set; } // current lap invalid - 0 = valid, 1 = invalid

        public byte m_penalties { get; set; }  // NEW: accumulated time penalties in seconds to be added
    }
}
