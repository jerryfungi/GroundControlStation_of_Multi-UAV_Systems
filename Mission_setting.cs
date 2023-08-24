using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS_5895
{
    class Mission_setting
    {
        public static Dictionary<string, Waypoints> path_mission = new Dictionary<string, Waypoints>
        {
            {"Default mission 1", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -14.858, 5.198, 10, 210},  new double[] { -52.277, -5.575, 10, 135}, new double[] { -57.314, 41.584, 10, 25}, 
                    new double[] { -26.44, 32.207, 10, 270 } }, 3, 10, 10, 5, 5, 20) },
            {"Default mission 2", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -25.863, 2.189, 10, 200}, new double[] { -77.589, 12.858, 10, 40}, new double[] { -77.589, 12.858, 10, 40 }, 
                    new double[] { -33.842, 41.584, 10, 315} }, 5, 15, 15, 5, 3, 7) },
            {"Default mission 3", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -25.863, 2.189, 10, 200}, new double[] { -77.589, 12.858, 10, 40}, new double[] { -77.589, 12.858, 10, 40 },
                    new double[] { -77.589, 12.858, 10, 130 }, new double[] { -33.842, 41.584, 10, 315} }, 4, 12.5, 15, 5, 3, 7) },
            {"Default mission 4", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -305.949, 324.736, 10, 180},  new double[] { -374.733, 311.606, 10, 225}, new double[] { -342.819, 261.815, 10, 340},
                    new double[] { -288.341, 276.587, 10, 90 } }, 4, 12, 15, 5, 3, 7) },
            {"Default mission 5", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -305.949, 324.736, 10, 180}, new double[] { -343.918, 295.465, 10, 340}, 
                    new double[] { -343.918, 295.465, 10, 340},
                    new double[] { -288.341, 276.587, 10, 50 } }, 3, 9, 15, 5, 3, 7) },
            {"200x200 test", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() {new double[] { -37.969, 1.368, 10, 210}, new double[] { -199.753, -62.648, 10, 180}, new double[] { -277.89, 98.217, 10, 20 },
                    new double[] { -95.198, 147.458, 10, 290}, new double[] { -62.181, 78.517, 10, 315} }, 5, 15, 10, 5, 5, 20) },
            {"Ranger test", new Waypoints(WaypointMissionMethod.CraigReynolds_Path_Following,
                pathFollowingMethod.dubinsPath_following_velocity_PID,
                new List<double[]>() { new double[] { -71, 9, 60 , 190 }, new double[] { -200, 10, 60, 130}, new double[] { -200, 10, 60, 130 }, new double[] { -150, 160, 60,  320} }, 13, 50, 15, 20, 3, 7) },
            {"Custom mission", new Waypoints(new List<double[]>()) }
        };

        public static Dictionary<string, WaypointMissionMethod> WaypointMissionMethod_name = new Dictionary<string, WaypointMissionMethod>
        {
            {"Go to waypoints", WaypointMissionMethod.guide_waypoints },
            {"CraigReynold's Path Following", WaypointMissionMethod.CraigReynolds_Path_Following }
        };

        public static Dictionary<string, pathFollowingMethod> pathFollowingMethod_name = new Dictionary<string, pathFollowingMethod>
        {
            {"Position control (Px, Py)", pathFollowingMethod.path_following_position },
            {"Position control (Px, Py, Yaw)", pathFollowingMethod.path_following_position_yaw },
            {"Velocity control (Vx, Vy)", pathFollowingMethod.path_following_velocityLocal },
            {"PID control (V, Yaw rate)", pathFollowingMethod.path_following_velocityBody_PID },
            {"PID control on Dubin's Path", pathFollowingMethod.dubinsPath_following_velocity_PID }
        };

        public static Dictionary<string, SEAD_mission> SEAD_mission = new Dictionary<string, SEAD_mission>
        {
            {"Simulation", new SEAD_mission(new List<agents>(){
                new agents(1, 2, 5, 15, new double[] { -25, 40, 180}, new double[] { -25, 40, 0 }) },
                new List<double[]>(){ new double[] { -80, 80 }, new double[] { -110, 0} },
                new List<double[]>() { new double[] { -130, 35 }}, 5) },
            {"Case1: 2UAV", new SEAD_mission(new List<agents>(){
                new agents(2, 2, 4, 12, new double[] { -25, 40, 200}, new double[] { -25, 40, 20 }),
                new agents(3, 1, 5, 15, new double[] { -20, 0, 200}, new double[] { -20, 0, 20 }) },
                new List<double[]>(){ new double[] { -80, 100}, new double[] { -160, 35 } }, 5) },
            {"Case1: T3U3", new SEAD_mission(new List<agents>(){
                new agents(1, 2, 4, 12, new double[] { -25, 40, 200}, new double[] { -25, 40, 20 }),
                new agents(2, 3, 3, 9, new double[] { -30, 20, 200}, new double[] {-30, 20, 20 }),
                new agents(3, 1, 5, 15, new double[] { -20, 0, 200}, new double[] { -20, 0, 20 }) },
                new List<double[]>(){ new double[] { -80, 100}, new double[] { -160, 35 }, new double[] { -110, 0 } }, 5) },
            {"Case2: T3U3UnT1", new SEAD_mission(new List<agents>(){
                new agents(1, 2, 4, 12, new double[] { -25, 40, 200}, new double[] { -25, 40, 20 }),
                new agents(2, 3, 3, 9, new double[] { -30, 20, 200}, new double[] {-30, 20, 20 }),
                new agents(3, 1, 5, 15, new double[] { -20, 0, 200}, new double[] { -20, 0, 20 }) },
                new List<double[]>(){ new double[] { -80, 100}, new double[] { -160, 70 }, new double[] { -110, -20 } },
                new List<double[]>() { new double[] { -90, 50} }, 5) },
            {"Case4: Fixed-wing ", new SEAD_mission(new List<agents>(){
                new agents(1, 2, 18, 70, new double[] { -25, 40, 200}, new double[] { -25, 40, 20 }),
                new agents(3, 1, 15, 60, new double[] { -30, 20, 200}, new double[] {-30, 20, 20 }),
                new agents(4, 3, 13, 50, new double[] { -20, 0, 200}, new double[] { -20, 0, 20 }) },
                new List<double[]>(){ new double[] { -200, 10}, new double[] { -180, 150 }}, 20) }
        };
    }
    public class Waypoints
    {
        public int UAV_ID { get; set; }
        public List<double[]> waypoints { get; set; } = new List<double[]>();
        public double[] start_position { get; set; } = new double[] { 0, 0, 0};
        public double V { get; set; } = 5;             // (m/s)
        public double Rmin { get; set; } = 15;         // (m)
        public int waypointRadius { get; set; } = 5;   // (m)
        public int recedingHorizon { get; set; } = 10; // (ds)
        public WaypointMissionMethod Type { get; set; }
        public pathFollowingMethod pathFollowing_method { get; set; } = pathFollowingMethod.path_following_position;
        public double Kp { get; set; } = 3;
        public double Kd { get; set; } = 10;
        public List<int> targetID_List { get; set; } = new List<int>() { };

        public Waypoints(int uav_id, double[] waypoint, WaypointMissionMethod type)
        {
            UAV_ID = uav_id;
            waypoints.Add(waypoint);
            Type = type;
        }

        public Waypoints(int uav_id, WaypointMissionMethod type)
        {
            UAV_ID = uav_id;
            Type = type;
        }

        public Waypoints(int uav_id, List<double[]> waypoints, WaypointMissionMethod type, pathFollowingMethod method, double[] start_position)
        {
            UAV_ID = uav_id;
            this.waypoints = new List<double[]>(waypoints);
            Type = type;
            pathFollowing_method = method;
            this.start_position = start_position;
        }

        public Waypoints(WaypointMissionMethod type, pathFollowingMethod method, List<double[]> waypoints)
        {
            Type = type;
            pathFollowing_method = method;
            this.waypoints = new List<double[]>(waypoints);
        }

        public Waypoints(WaypointMissionMethod type, pathFollowingMethod method, List<double[]> waypoints,
            double V, double Rmin, int recedingHorizon, int waypointRadius, double Kp, double Kd)
        {
            Type = type;
            pathFollowing_method = method;
            this.waypoints = new List<double[]>(waypoints);
            this.V = V;
            this.Rmin = Rmin;
            this.recedingHorizon = recedingHorizon;
            this.waypointRadius = waypointRadius;
            this.Kp = Kp;
            this.Kd = Kd;
        }

        public Waypoints(List<double[]> waypoints)
        {
            this.waypoints = new List<double[]>(waypoints);
        }

        public Waypoints(int uav_id, WaypointMissionMethod type, double[] start_position)
        {
            UAV_ID = uav_id;
            Type = type;
            this.start_position = start_position;
        }

        public Waypoints() { }

        public Waypoints Deepcopy()
        {
            Waypoints new_wps = new Waypoints();
            new_wps.UAV_ID = UAV_ID;
            new_wps.start_position = new double[start_position.Count()];
            start_position.CopyTo(new_wps.start_position, 0);
            new_wps.waypoints = new List<double[]>(waypoints);
            new_wps.Type = Type;
            new_wps.pathFollowing_method = pathFollowing_method;
            new_wps.recedingHorizon = recedingHorizon;
            new_wps.waypointRadius = waypointRadius;
            new_wps.Kp = Kp;
            new_wps.Kd = Kd;
            new_wps.V = V;
            new_wps.Rmin = Rmin;
            return new_wps;
        }
    }

    public class SEAD_mission
    {
        
        public List<agents> UAV_set = new List<agents>();
        public List<double[]> Target_set = new List<double[]>();
        public List<double[]> unknownTarget_set = new List<double[]>();
        public int waypointRadius = 5;
        public SEAD_mission(List<agents> UAV_set, List<double[]> Target_set, int waypointRadius)
        {
            this.UAV_set = UAV_set;
            this.Target_set = Target_set;
            this.unknownTarget_set = new List<double[]>() { };
            this.waypointRadius = waypointRadius;
        }
        public SEAD_mission(List<agents> UAV_set, List<double[]> Target_set, List<double[]> unknownTarget_set, int waypointRadius)
        {
            this.UAV_set = UAV_set;
            this.Target_set = Target_set;
            this.unknownTarget_set = unknownTarget_set;
            this.waypointRadius = waypointRadius;
        }
    }
    public struct agents
    {
        public int ID;
        public int type_id;
        public double cruise_speed;
        public double Rmin;
        public string Type
        {
            get
            {
                if (type_id == 1)
                    return "Surveillance";
                else if (type_id == 2)
                    return "Combat";
                else if (type_id == 3)
                    return "Munition";
                else
                    return "None type";
            }
            set
            {
                if (value == "Surveillance")
                    type_id = 1;
                else if (value == "Combat")
                    type_id = 2;
                else if (value == "Munition")
                    type_id = 3;
                else
                    type_id = 0;
            }
        }
        public double[] initial_pos;
        public double[] base_pos;
        public agents(int ID, int type_id, double cruise_speed, double Rmin, double[] initial_pos, double[] base_pos)
        {
            this.ID = ID;
            this.type_id = type_id;
            this.cruise_speed = cruise_speed;
            this.Rmin = Rmin;
            this.initial_pos = initial_pos;
            this.base_pos = base_pos;
        }
        public agents(int ID, double[] location)
        { // for VRP
            this.ID = ID;
            type_id = 0;
            this.cruise_speed = 0;
            this.Rmin = 0;
            this.initial_pos = location;
            this.base_pos = location;
        }
    }
}
