using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using XBeeLibrary.Core;
using XBeeLibrary.Core.Models;

namespace GCS_5895
{
    public class Packets
    {
        public int UAV_ID { get; private set; }
        public FrameType Frame_type { get; private set; }
        public int Battery { get; private set; }
        public Armed Armed { get; private set; }
        public Mode Mode { get; private set; }
        public Message_ID Mission { get; private set; }
        public double E { get; private set; }
        public double N { get; private set; }
        public double U { get; private set; }
        public double UAV_timestamp { get; private set; }
        public double GCS_timestamp { get; private set; }
        public double Speed { get; private set; }
        public double Roll { get; private set; }
        public double Pitch { get; private set; }
        public double Yaw { get; private set; }
        public double Heading { get; private set; }
        public double Lat { get; private set; }
        public double Lng { get; private set; }
        public double Alt { get; private set; }
        public string Info { get; private set; }

        public CoordinateTransform Coordinate;

        public Packets(CoordinateTransform coordinate, int uav_id)
        {
            this.Coordinate = coordinate;
            UAV_ID = uav_id;
        }

        public Packets(CoordinateTransform coordinate, int uav_id, double E, double N, double U, double heading, string info, FrameType frameType)
        {
            this.Coordinate = coordinate;
            UAV_ID = uav_id;
            this.E = E;
            this.N = N;
            this.U = U;
            this.Heading = heading;
            this.Info = info;
            Mode = Mode.Guided;
            var lla = coordinate.enu2llh(E, N, U);
            Lat = lla[0];
            Lng = lla[1];
            Alt = lla[2];
            this.Frame_type = frameType;
        }

        public void unpack_packet(byte[] packet, double GCS_timestamp)
        {
            Mission = (Message_ID)packet[0];
            switch (Mission)
            {
                case Message_ID.Default:
                case Message_ID.Waypoints:
                case Message_ID.SEAD_mission:
                    Frame_type = (FrameType)packet[2];
                    Mode = (Mode)packet[3];
                    Armed = (Armed)packet[4];
                    Battery = packet[5];
                    UAV_timestamp = Math.Round(BitConverter.ToDouble(packet, 6), 6, MidpointRounding.AwayFromZero); 
                    E = Math.Round(BitConverter.ToInt32(packet, 14) * 1e-3, 3, MidpointRounding.AwayFromZero);
                    N = Math.Round(BitConverter.ToInt32(packet, 18) * 1e-3, 3, MidpointRounding.AwayFromZero);
                    U = Math.Round(BitConverter.ToInt32(packet, 22) * 1e-3, 3, MidpointRounding.AwayFromZero);
                    var llh = Coordinate.enu2llh(E, N, U);
                    Lat = llh[0];
                    Lng = llh[1];
                    Alt = llh[2];
                    Roll = Math.Round(BitConverter.ToInt32(packet, 26) * 1e-6 * 180 / Math.PI, 2, MidpointRounding.AwayFromZero);
                    Pitch = Math.Round(BitConverter.ToInt32(packet, 30) * 1e-6 * 180 / Math.PI, 2, MidpointRounding.AwayFromZero);
                    Yaw = Math.Round(BitConverter.ToInt32(packet, 34) * 1e-6 * 180 / Math.PI, 2, MidpointRounding.AwayFromZero);
                    Heading = Yaw;
                    attitudeENUtoNED();
                    Speed = Math.Round(BitConverter.ToInt32(packet, 38) * 1e-3, 3, MidpointRounding.AwayFromZero);
                    this.GCS_timestamp = Math.Round(GCS_timestamp, 6, MidpointRounding.AwayFromZero);
                    Info = "(´-ω-)b";
                    break;
                case Message_ID.Time_Syncronize:
                    break;
                case Message_ID.info:
                    Info = Encoding.UTF8.GetString(packet, 3, packet[2]);
                    break;
                case Message_ID.Record_Time:
                    UAV_timestamp = BitConverter.ToDouble(packet, 2);
                    Info = Encoding.UTF8.GetString(packet, 11, packet[10]);
                    break;
                case Message_ID.SEAD:
                    break;
            }
        }

        private void attitudeENUtoNED()
        {
            Roll = Roll;
            Pitch = -Pitch;
            Yaw = 90 - Yaw;
            if (Yaw > 180) { Yaw -= 360; }
            else if (Yaw < -180) { Yaw += 360; }
        }

        public byte[] pack_time_synchronize_packet(double receive_time)
        {
            byte[] packet = new byte[18];
            packet[0] = (byte)Message_ID.Time_Syncronize;
            packet[1] = (byte)UAV_ID;
            BitConverter.GetBytes(Convert.ToDouble(receive_time)).CopyTo(packet, 2);
            double return_time = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            BitConverter.GetBytes(Convert.ToDouble(return_time)).CopyTo(packet, 10);
            return packet;
        }

        public byte[] pack_time_synchronize_request_packet()
        {
            byte[] packet = new byte[2];
            packet[0] = (byte)Message_ID.Time_Syncronize;
            packet[1] = (byte)UAV_ID;
            return packet;
        }

        public byte[] pack_origin_correction_packet(string originName)
        {
            byte[] packet = new byte[3];
            packet[0] = (byte)Message_ID.Origin_Correction;
            packet[1] = (byte)UAV_ID;
            switch (originName)
            {
                case "沙崙草皮捲":
                    packet[2] = 0;
                    break;
                case "西瓜皮空地":
                    packet[2] = 1;
                    break;
            }
            return packet;
        }

        public byte[] pack_command_packet(string command)
        {
            byte[] packet = new byte[3];
            switch (command)
            {
                case "Arm":
                    packet[0] = (byte)Message_ID.Arm;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Armed.armed;
                    return packet;
                case "Disarm":
                    packet[0] = (byte)Message_ID.Arm;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Armed.disarmed;
                    return packet;
                case "Guided":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.Guided;
                    return packet;
                case "RTL":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.RTL;
                    return packet;
                case "Stabilize":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.Stabilize;
                    return packet;
                case "position":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.position;
                    return packet;
                case "POSHOLD":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.POSHOLD;
                    return packet;
                case "Land":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.Land;
                    return packet;
                case "Loiter":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.Loiter;
                    return packet;
                case "Auto":
                    packet[0] = (byte)Message_ID.Mode_Change;
                    packet[1] = (byte)UAV_ID;
                    packet[2] = (byte)Mode.Auto;
                    return packet;
            }
            return packet;
        }

        public byte[] pack_takeoff_packet(int height)
        {
            byte[] packet = new byte[3];
            packet[0] = (byte)Message_ID.Takeoff;
            packet[1] = (byte)UAV_ID;
            packet[2] = (byte)height;
            return packet;
        }

        public byte[] pack_guide_mission_packet(double E, double N, double U, int waypointRadius)
        {
            byte[] packet = new byte[16];
            packet[0] = (byte)Message_ID.Waypoints;
            packet[1] = (byte)UAV_ID;
            packet[2] = (byte)WaypointMissionMethod.guide_waypoint;
            packet[3] = (byte)waypointRadius;
            BitConverter.GetBytes(Convert.ToInt32(E * 1e3)).CopyTo(packet, 4);
            BitConverter.GetBytes(Convert.ToInt32(N * 1e3)).CopyTo(packet, 8);
            BitConverter.GetBytes(Convert.ToInt32(U * 1e3)).CopyTo(packet, 12);
            return packet;
        }

        public byte[] pack_guide_WPwithHeading_packet(double E, double N, double U, double heading, int waypointRadius)
        {
            byte[] packet = new byte[20];
            packet[0] = (byte)Message_ID.Waypoints;
            packet[1] = (byte)UAV_ID;
            packet[2] = (byte)WaypointMissionMethod.guide_WPwithHeading;
            packet[3] = (byte)waypointRadius;
            BitConverter.GetBytes(Convert.ToInt32(E * 1e3)).CopyTo(packet, 4);
            BitConverter.GetBytes(Convert.ToInt32(N * 1e3)).CopyTo(packet, 8);
            BitConverter.GetBytes(Convert.ToInt32(U * 1e3)).CopyTo(packet, 12);
            BitConverter.GetBytes(Convert.ToInt32(heading * 1e3)).CopyTo(packet, 16);
            return packet;
        }

        public byte[] pack_missionAbort_cmd()
        {
            byte[] packet = new byte[3];
            packet[0] = (byte)Message_ID.Mission_Abort;
            packet[1] = (byte)UAV_ID;
            return packet;
        }

        public byte[] pack_pathFollowing_mission_packet(Waypoints mission_info)
        {
            int WPs_num = mission_info.waypoints.Count();
            byte[] packet = new byte[0];
            int i = 5;  // 開始包航點資訊之位置
            switch (mission_info.Type)
            {
                case WaypointMissionMethod.CraigReynolds_Path_Following:
                    int j = 3;  // 是否包航向資訊 (3: [x, y, z], 4: [x, y, z, yaw])
                    switch (mission_info.pathFollowing_method)
                    {
                        case pathFollowingMethod.path_following_position:
                        case pathFollowingMethod.path_following_position_yaw:
                        case pathFollowingMethod.path_following_velocityLocal:
                            i = 15;
                            packet = new byte[i + j * 4 * WPs_num];
                            break;
                        case pathFollowingMethod.path_following_velocityBody_PID:
                            i = 23;
                            packet = new byte[i + j * 4 * WPs_num];
                            BitConverter.GetBytes(Convert.ToInt32(mission_info.Kp * 1e3)).CopyTo(packet, 15);
                            BitConverter.GetBytes(Convert.ToInt32(mission_info.Kd * 1e3)).CopyTo(packet, 19);
                            break;
                        case pathFollowingMethod.dubinsPath_following_velocity_PID:
                            i = 23;
                            j = 4;
                            packet = new byte[i + j * 4 * WPs_num];
                            BitConverter.GetBytes(Convert.ToInt32(mission_info.Kp * 1e3)).CopyTo(packet, 15);
                            BitConverter.GetBytes(Convert.ToInt32(mission_info.Kd * 1e3)).CopyTo(packet, 19);
                            break;
                    }
                    packet[5] = (byte)mission_info.pathFollowing_method;
                    packet[6] = (byte)mission_info.recedingHorizon;
                    BitConverter.GetBytes(Convert.ToInt32(mission_info.V * 1e3)).CopyTo(packet, 7);
                    BitConverter.GetBytes(Convert.ToInt32(mission_info.Rmin * 1e3)).CopyTo(packet, 11);
                    break;
                case WaypointMissionMethod.guide_waypoints:
                    packet = new byte[i + 3 * 4 * WPs_num];
                    break;
            }
            packet[0] = (byte)Message_ID.Waypoints;
            packet[1] = (byte)UAV_ID;
            packet[2] = (byte)mission_info.Type;
            packet[3] = (byte)mission_info.waypointRadius;
            packet[4] = (byte)WPs_num;
            foreach (double[] wp in mission_info.waypoints)
            {
                foreach (double point in wp)
                {
                    var target = BitConverter.GetBytes(Convert.ToInt32(point * 1e3));
                    target.CopyTo(packet, i);
                    i += 4;
                }
            }
            return packet;
        }

        public byte[] pack_SEADmission_packet(SEAD_mission missionConfig)
        {
            byte[] packet = new byte[38 + 8 * missionConfig.Target_set.Count() + 8 * missionConfig.unknownTarget_set.Count()];
            packet[0] = (byte)Message_ID.SEAD_mission;
            packet[36] = (byte)missionConfig.Target_set.Count();
            packet[37] = (byte)missionConfig.unknownTarget_set.Count();
            var uav = missionConfig.UAV_set.Find(u => u.ID == UAV_ID);
            packet[1] = (byte)uav.ID;
            packet[2] = (byte)uav.type_id;
            BitConverter.GetBytes(Convert.ToInt32(uav.cruise_speed * 1e3)).CopyTo(packet, 3);
            BitConverter.GetBytes(Convert.ToInt32(uav.Rmin * 1e3)).CopyTo(packet, 7);
            packet[11] = (byte)missionConfig.waypointRadius;
            int i = 12;
            foreach (var p in uav.initial_pos)
            {
                BitConverter.GetBytes(Convert.ToInt32(p * 1e3)).CopyTo(packet, i);
                i += 4;
            }
            foreach (var p in uav.base_pos)
            {
                BitConverter.GetBytes(Convert.ToInt32(p * 1e3)).CopyTo(packet, i);
                i += 4;
            }
            i = 38;
            foreach (var target in missionConfig.Target_set)
            {
                BitConverter.GetBytes(Convert.ToInt32(target[0] * 1e3)).CopyTo(packet, i);
                i += 4;
                BitConverter.GetBytes(Convert.ToInt32(target[1] * 1e3)).CopyTo(packet, i);
                i += 4;
            }
            foreach (var target in missionConfig.unknownTarget_set)
            {
                BitConverter.GetBytes(Convert.ToInt32(target[0] * 1e3)).CopyTo(packet, i);
                i += 4;
                BitConverter.GetBytes(Convert.ToInt32(target[1] * 1e3)).CopyTo(packet, i);
                i += 4;
            }
            return packet;
        }

        public byte[] pack_commFreqAdjust_packet(string Case, double frequency)
        {
            byte[] packet = new byte[0];
            switch (Case)
            {
                case "U2G":
                    packet = new byte[6];
                    packet[0] = (byte)Message_ID.Comm_u2gFreq;
                    packet[1] = (byte)UAV_ID;
                    var Freq = BitConverter.GetBytes(Convert.ToInt32(frequency * 1e2));
                    Freq.CopyTo(packet, 2);
                    return packet;
            }
            return packet;
        }
    }

    public enum Message_ID
    {
        Default = 0,
        Mode_Change = 1,
        Arm = 2,
        Takeoff = 3,
        Time_Syncronize = 4,
        Waypoints = 5,
        Comm_u2gFreq = 6,
        Record_Time = 7,
        Mission_Abort = 8,
        Origin_Correction = 9,
        info = 44,
        SEAD = 17,
        SEAD_mission = 18,
    }

    public enum Mode
    {
        Stabilize = 0,
        Alt_Hod = 2,
        Auto = 3,
        Guided = 4,
        Loiter = 5,
        RTL = 6,
        position = 8,
        Land = 9,
        POSHOLD = 16
    }

    public enum Armed
    {
        armed = 1,
        disarmed = 0
    }

    public enum FrameType
    {
        Quad = 0,
        Fixed_wing = 1
    }

    public enum WaypointMissionMethod
    {
        guide_waypoint = 0,
        guide_waypoints = 1,
        CraigReynolds_Path_Following = 2,
        guide_WPwithHeading = 3
    }

    public enum pathFollowingMethod
    {
        path_following_position = 0,                // Px, Py, Pz
        path_following_position_yaw = 1,            // Px, Py, Pz, Yaw
        path_following_velocityLocal = 2,           // Vx, Vy, Vz
        path_following_velocityBody_PID = 3,        // V(body) + Yaw rate
        dubinsPath_following_velocity_PID = 4       // V(body) + Yaw rate
    }

    class XBee_addr
    {
        public Dictionary<int, RemoteDigiMeshDevice> G2U_points { get; private set; }
        
        public XBee_addr(DigiMeshDevice XBee)
        {   // XBee PRO S3B
            G2U_points = new Dictionary<int, RemoteDigiMeshDevice> {
                                {1, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040D8DCD5")) },
                                {2, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040F5C61B")) },
                                {3, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040D8DCE4")) },
                                {4, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040F5C5E5")) },
                                {5, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040F5C5CA")) },
                                {6, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040F5C5DB")) },
                                {7, new RemoteDigiMeshDevice(XBee, new XBee64BitAddress("0013A20040C19B66")) }
                            };
        }
    }

    public class SortableBindingList<T> : BindingList<T>
    {
        private readonly Dictionary<Type, PropertyComparer<T>> comparers;
        private bool isSorted;
        private ListSortDirection listSortDirection;
        private PropertyDescriptor propertyDescriptor;

        public SortableBindingList()
            : base(new List<T>())
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        public SortableBindingList(IEnumerable<T> enumeration)
            : base(new List<T>(enumeration))
        {
            this.comparers = new Dictionary<Type, PropertyComparer<T>>();
        }

        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        protected override bool IsSortedCore
        {
            get { return this.isSorted; }
        }

        protected override PropertyDescriptor SortPropertyCore
        {
            get { return this.propertyDescriptor; }
        }

        protected override ListSortDirection SortDirectionCore
        {
            get { return this.listSortDirection; }
        }

        protected override bool SupportsSearchingCore
        {
            get { return true; }
        }

        protected override void ApplySortCore(PropertyDescriptor property, ListSortDirection direction)
        {
            List<T> itemsList = (List<T>)this.Items;

            Type propertyType = property.PropertyType;
            PropertyComparer<T> comparer;
            if (!this.comparers.TryGetValue(propertyType, out comparer))
            {
                comparer = new PropertyComparer<T>(property, direction);
                this.comparers.Add(propertyType, comparer);
            }

            comparer.SetPropertyAndDirection(property, direction);
            itemsList.Sort(comparer);

            this.propertyDescriptor = property;
            this.listSortDirection = direction;
            this.isSorted = true;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            this.isSorted = false;
            this.propertyDescriptor = base.SortPropertyCore;
            this.listSortDirection = base.SortDirectionCore;

            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override int FindCore(PropertyDescriptor property, object key)
        {
            int count = this.Count;
            for (int i = 0; i < count; ++i)
            {
                T element = this[i];
                if (property.GetValue(element).Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }
    }

    public class PropertyComparer<T> : IComparer<T>
    {
        private readonly IComparer comparer;
        private PropertyDescriptor propertyDescriptor;
        private int reverse;

        public PropertyComparer(PropertyDescriptor property, ListSortDirection direction)
        {
            this.propertyDescriptor = property;
            Type comparerForPropertyType = typeof(Comparer<>).MakeGenericType(property.PropertyType);
            this.comparer = (IComparer)comparerForPropertyType.InvokeMember("Default", BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.Public, null, null, null);
            this.SetListSortDirection(direction);
        }

        #region IComparer<T> Members

        public int Compare(T x, T y)
        {
            return this.reverse * this.comparer.Compare(this.propertyDescriptor.GetValue(x), this.propertyDescriptor.GetValue(y));
        }

        #endregion

        private void SetPropertyDescriptor(PropertyDescriptor descriptor)
        {
            this.propertyDescriptor = descriptor;
        }

        private void SetListSortDirection(ListSortDirection direction)
        {
            this.reverse = direction == ListSortDirection.Ascending ? 1 : -1;
        }

        public void SetPropertyAndDirection(PropertyDescriptor descriptor, ListSortDirection direction)
        {
            this.SetPropertyDescriptor(descriptor);
            this.SetListSortDirection(direction);
        }
    }
}
