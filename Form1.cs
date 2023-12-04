using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO.Ports;
using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET;
using MySql.Data.MySqlClient;
using XBeeLibrary.Core;
using XBeeLibrary.Core.Models;
using System.Drawing.Drawing2D;
using System.Threading;
using CCWin;
using System.Numerics;
using IWshRuntimeLibrary;
using System.Reflection;

namespace GCS_5895
{
    public partial class GCS_5895 : CCSkinMain
    {
        private float x;//定義當前窗體的寬度
        private float y;//定義當前窗體的高度
        public int default_UAVnumbers = 10; //預設無人機數量
        public Dictionary<string, CoordinateTransform> Origin = new Dictionary<string, CoordinateTransform>()
        {
            {"沙崙草皮捲", new CoordinateTransform(22.9242595824972, 120.310152769089, 26.0, new PointLatLng(22.9246251967135, 120.309573411942))},
            {"西瓜皮空地", new CoordinateTransform(22.9105162191694, 120.312446057796, 26.0, new PointLatLng(22.9105162191694, 120.312446057796))}
        };
        public List<int> existing_UAVs = new List<int>();
        // 定義通訊管道
        public static Socket client;
        public bool client_connect;
        // X2 ConnectPort (gateway)
        public EndPoint connectPort = new IPEndPoint(IPAddress.Parse("169.254.219.218"), 14500); 
        public static int port_number = 14500;
        public static XBeeLibrary.Windows.DigiMeshDevice XBee;
        public string[] baudRate = new string[] { "Baud: 9600", "Baud: 115200" };
        public Dictionary<int, RemoteDigiMeshDevice> G2U_points;

        // 定義MySQL資料庫
        MySqlConnection timelist_conn = new MySqlConnection("data source=127.0.0.1;;port=3306;user id=root;password=ncku5895;database=timelist" +
            ";pooling=true;charset=utf8;");  //紀錄任務開始時間
        public List<MySqlConnection> UAVs_flightData_conn = new List<MySqlConnection>(); // 紀錄無人機飛行數據

        // 定義座標系
        CoordinateTransform coordinate;

        // 定義google map
        public List<GMapOverlay> markers_main = new List<GMapOverlay>();
        public List<GMapRoute> marker_of_uavRoute = new List<GMapRoute>(); // 動態航線marker
        public List<Color> color_of_uavs = new List<Color> { Color.DarkSeaGreen, Color.LightBlue, Color.RosyBrown, Color.Thistle,
                        Color.DarkGray, Color.LightSteelBlue, Color.DarkKhaki, Color.MediumTurquoise, Color.LightPink, Color.DarkSalmon}; // 無人機路徑及標籤顏色
        public List<GMapOverlay> waypoints_pin = new List<GMapOverlay>();
        public bool lockMap = false;
        public bool isChooseWP = false;
        public GMapMarker currentMarker;

        // 定義路線軌跡儲存空間                                    
        public SortableBindingList<Packets> Buffers = new SortableBindingList<Packets>();
        public List<List<PointLatLng>> routesBuffer = new List<List<PointLatLng>>();
        public double u2gFreq, route_seconds;
        public int displayPoint;
        public bool allRouteCheck = false;

        // WP命令設定
        public List<Waypoints> waypoints = new List<Waypoints>();

        [Obsolete]
        public GCS_5895()
        {
            InitializeComponent();
            x = this.Width;
            y = this.Height;
            setTag(this);
            // 座標系
            coordinate = Origin["西瓜皮空地"];  //預設圓點
            comboBox_origin.Items.AddRange(Origin.Keys.ToArray());
            comboBox_origin.Text = "西瓜皮空地";
            comboBox_mapCenter.Items.AddRange(Origin.Keys.ToArray());
            comboBox_mapCenter.Text = "西瓜皮空地";

            /* GMap 初始參數 */
            // 離線地圖
            GMaps.Instance.Mode = AccessMode.CacheOnly;
            string mapPath = Application.StartupPath + "\\bingmap.gmdb";
            GMaps.Instance.ImportFromGMDB(mapPath);

            gMapControl_main.DragButton = MouseButtons.Left;
            gMapControl_main.MapProvider = GMapProviders.GoogleMap;
            gMapControl_main.Position = coordinate.mapCenter;
            gMapControl_main.MaxZoom = 24;
            gMapControl_main.MinZoom = 3;
            gMapControl_main.Zoom = 20;
            gMapControl_main.ShowCenter = false;
            gMapControl_main.Manager.Mode = AccessMode.ServerAndCache;

            // default parameters
            u2gFreq = 1;
            route_seconds = 5;
            displayPoint = (int)Math.Round(u2gFreq * route_seconds, 0, MidpointRounding.AwayFromZero);
            comboBox_u2gFreq.Items.AddRange(new string[] { "1", "2", "3", "5", "10"});
            comboBox_u2gFreq.Text = $"{u2gFreq}";
            comboBox_routeDisplay.Items.AddRange(new string[] { "2", "5", "10", "15", "20", "All Routes" });
            comboBox_routeDisplay.Text = $"{route_seconds}";

            // definre List
            for (int i = 0; i < default_UAVnumbers; i++)
            {
                markers_main.Add(new GMapOverlay("markers" + (i + 1))); // 定義每台無人機的markers
                marker_of_uavRoute.Add(new GMapRoute(Name = "route" + (i + 1))); // 定義每台無人機的Gmap路線
                routesBuffer.Add(new List<PointLatLng>()); // 定義每台無人機的軌跡路線空間
                waypoints_pin.Add(new GMapOverlay("waypoints" + (i + 1)));  // 定義每台無人機的WPs markers
                gMapControl_main.Overlays.Add(waypoints_pin[i]);
                gMapControl_main.Overlays.Add(markers_main[i]);
                // 定義飛行數據之資料庫管道並開啟通道
                UAVs_flightData_conn.Add(new MySqlConnection($"data source=127.0.0.1;;port=3306;user id=root;password=ncku5895;database=uav{i + 1};pooling=true;charset=utf8;"));
                if (UAVs_flightData_conn[i].State != ConnectionState.Open)
                    UAVs_flightData_conn[i].Open();
            }
            if (timelist_conn.State != ConnectionState.Open)
                timelist_conn.Open();

            dataGridView_flghtData.DataSource = Buffers;
            string[] command = new string[] { "Arm", "Disarm", "Guided", "RTL", "Stabilize", "POSHOLD", "position", "Land", "Loiter", "Alt_Hod", "Auto" };
            comboBox_Command.Items.AddRange(command);
            dataGridView_flghtData.ForeColor = Color.Black;
            dataGridView_mission.ForeColor = Color.Black;
            
            // 任務設定
            skinComboBox_SEAD.Items.AddRange(Mission_setting.SEAD_mission.Keys.ToArray());
        }
        public void setTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    setTag(con);
                }
            }
        }
        public void setControls(float newx, float newy, Control cons)
        {
            //遍歷窗體中的控制元件，重新設定控制元件的值
            foreach (Control con in cons.Controls)
            {
                //獲取控制元件的Tag屬性值，並分割後儲存字串陣列
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ';' });
                    //根據窗體縮放的比例確定控制元件的值
                    con.Width = Convert.ToInt32(Convert.ToSingle(mytag[0]) * newx);//寬度
                    con.Height = Convert.ToInt32(Convert.ToSingle(mytag[1]) * newy);//高度
                    con.Left = Convert.ToInt32(Convert.ToSingle(mytag[2]) * newx);//左邊距
                    con.Top = Convert.ToInt32(Convert.ToSingle(mytag[3]) * newy);//頂邊距

                    // Single currentSize = Convert.ToSingle(mytag[4]) * newy; //字型大小
                    // con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);//字型大小

                    if (con.Controls.Count > 0)
                    {
                        setControls(newx, newy, con);
                    }
                }
            }
        }

        private void GCS_5895_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                gMapControl_main.Height -= 34;
            }
            float newx = (this.Width) / x;
            float newy = (this.Height) / y;
            setControls(newx, newy, this);
            if (this.WindowState == FormWindowState.Maximized)
            {
                gMapControl_main.Height += 34;
            }
        }

        private void GCS_5895_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show(this, "確定退出？", "退出視窗通知٩(✿∂‿∂✿)۶", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        public static void CreateShortcut(string shortcutName, string shortcutPath, string targetFileLocation)
        {
            string shortcutLocation = System.IO.Path.Combine(shortcutPath, shortcutName + ".lnk");
            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutLocation);

            shortcut.Description = "My shortcut description";   // The description of the shortcut
            shortcut.IconLocation = @"C:\Users\user\source\repos\GCS_5895\bin\Debug\GCS icon.ico";           // The icon of the shortcut
            shortcut.TargetPath = targetFileLocation;                 // The path of the file that will launch when the shortcut is run
            shortcut.Save();                                    // Save the shortcut
        }

        [Obsolete]
        private void button_Connect_Click(object sender, EventArgs e)
        {
            switch (button_Connect.Text)
            {
                case "Connect":
                    if (String.IsNullOrEmpty(comboBox_connectOption.Text) || String.IsNullOrEmpty(comboBox_PortOrBaud.Text))
                    {
                        MessageBox.Show("Please select a connect method (ʘ言ʘ╬)");
                    }
                    else if (comboBox_connectOption.Text == "UDP")
                    {
                        try
                        {
                            var myHost = Dns.GetHostByName(Dns.GetHostName());
                            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                            client.Bind(new IPEndPoint(IPAddress.Parse(myHost.AddressList[0].ToString()), Int32.Parse(comboBox_PortOrBaud.Text.Remove(0, 6))));
                            client_connect = true;
                            // 連線成功後開啟背景執行接收訊息
                            BackgroundWorker bgw = new BackgroundWorker();
                            bgw.DoWork += backgroundReceiver;
                            bgw.RunWorkerAsync();
                            // 控件開啟
                            button_Publish.Enabled = true;
                            button_takeoff.Enabled = true;
                            button_FreqConfirm.Enabled = true;
                            skinButton_RTL.Enabled = true;
                            skinButton_HOLD.Enabled = true;
                            skinButton_loiter.Enabled = true;
                            skinButton_land.Enabled = true;
                            skinButton_arm.Enabled = true;
                            skinButton_disarm.Enabled = true;
                            skinButton_abort.Enabled = true;
                            button_Connect.Text = "Disconnect";
                            comboBox_connectOption.Enabled = false;
                            comboBox_PortOrBaud.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (comboBox_connectOption.Text.Contains("COM"))
                    {
                        try
                        {
                            XBee = new XBeeLibrary.Windows.DigiMeshDevice(comboBox_connectOption.Text, Int32.Parse(comboBox_PortOrBaud.Text.Remove(0, 6)));
                            XBee.Open(); //讀串口
                            G2U_points = new XBee_addr(XBee).G2U_points;
                            
                            BackgroundWorker bgw = new BackgroundWorker();
                            bgw.DoWork += backgroundReceiver;
                            bgw.RunWorkerAsync();

                            button_Connect.Text = "Disconnect";
                            comboBox_connectOption.Enabled = false;
                            comboBox_PortOrBaud.Enabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    break;
                case "Disconnect":
                    try
                    {
                        // 關閉串口通道
                        if (comboBox_connectOption.Text == "UDP")
                        {
                            client.Close();
                            client_connect = false;
                        }
                        else
                        {
                            XBee.Close();
                        }
                        // 初始化地圖
                        for (int i = 0; i < default_UAVnumbers; i++)
                        {
                            markers_main[i].Clear();
                            routesBuffer[i].Clear();
                            waypoints_pin[i].Clear();
                            waypoints.Clear();
                        }
                        gMapControl_main.Position = coordinate.mapCenter;
                        gMapControl_main.Zoom = 20;
                        // 初始化連線設定
                        comboBox_PortOrBaud.Text = string.Empty;
                        comboBox_PortOrBaud.Items.Clear();
                        comboBox_connectOption.Text = string.Empty;
                        button_Connect.Text = "Connect";
                        comboBox_connectOption.Enabled = true;
                        comboBox_PortOrBaud.Enabled = true;
                        // 初始化儲存空間
                        Buffers.Clear();
                        existing_UAVs.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    break;
            }
        }
        // 背景執行訊息接收
        void backgroundReceiver(object sender, EventArgs e)
        {
            string connectMethod = "";
            this.Invoke(new Action(() =>
            {
                connectMethod = comboBox_connectOption.Text;
            }));
            if (connectMethod == "UDP")
            {
                EndPoint point = new IPEndPoint(IPAddress.Any, 0);
                byte[] packet;
                int UDPDate = 0;
                double time_received;
                while (client_connect)
                {
                    try
                    {
                        packet = new byte[1024];
                        UDPDate = client.ReceiveFrom(packet, ref point); //接收數據
                        time_received = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                        Packet_Processing(packet, time_received);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            else
            {
                XBeeMessage xbee_message;
                double time_received;
                byte[] packet;
                while (XBee.IsOpen)
                {
                    try
                    {
                        xbee_message = XBee.ReadData();
                        time_received = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;

                        if (xbee_message != null)
                        {
                            packet = xbee_message.Data;
                            Packet_Processing(packet, time_received);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }

        private string UAV_ID_text(int uav_id)
        {
            string name;
            if (uav_id < 10)
            {
                name = $"UAV0{uav_id}";
            }
            else
            {
                name = $"UAV{uav_id}";
            }
            return name;
        }

        private void Packet_Processing(byte[] packet, double receive_time)
        {
            int uav_id = packet[1];
            this.Invoke(new Action(() =>
            {
            // 查看是否有新無人機
            if (!existing_UAVs.Contains(uav_id))
            {
                existing_UAVs.Add(uav_id);
                existing_UAVs.Sort();
                Buffers.Add(new Packets(coordinate, uav_id));
                dataGridView_flghtData.Sort(dataGridView_flghtData.Columns["UAV_ID"], ListSortDirection.Ascending);
                comboBox_mapCenter.Items.Add(UAV_ID_text(uav_id));
                checkBoxComboBox_UAVselect.Items.Add(UAV_ID_text(uav_id));
            }
            // 解封包
            int select_index = existing_UAVs.IndexOf(uav_id);
            Buffers[select_index].unpack_packet(packet, receive_time);
            dataGridView_flghtData.InvalidateRow(select_index);

            // 訊息種類
            switch (Buffers[select_index].Mission)
            {
                case Message_ID.Default:
                case Message_ID.Waypoints:
                case Message_ID.SEAD_mission:
                    // 清除該無人機markers
                    markers_main[uav_id - 1].Clear();

                    // plot uav on map
                    switch (Buffers[select_index].Frame_type)
                    {
                        case FrameType.Quad:
                            markers_main[uav_id - 1].Markers.Add(Planes.AddQuadrotor(Buffers[select_index].Lat, Buffers[select_index].Lng, UAV_ID_text(uav_id), Buffers[select_index].get_ENU_yawAngle(),
                                new SolidBrush(color_of_uavs[uav_id - 1])));
                            break;
                        case FrameType.Fixed_wing:
                            markers_main[uav_id - 1].Markers.Add(Planes.AddPlane(Buffers[select_index].Lat, Buffers[select_index].Lng, UAV_ID_text(uav_id), Buffers[select_index].get_ENU_yawAngle(), 
                                new SolidBrush(color_of_uavs[uav_id - 1])));
                            break;
                    }

                    // follow UAV
                    if (lockMap)
                    {
                        if (comboBox_mapCenter.Text.Contains("UAV")  && existing_UAVs.IndexOf(Int32.Parse(comboBox_mapCenter.Text.Remove(0, 3))) == select_index)
                            {
                                gMapControl_main.Position = new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng);
                            }
                    }

                    // plot route
                    routesBuffer[uav_id - 1].Add(new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng));
                    if (routesBuffer[uav_id - 1].Count > displayPoint && !allRouteCheck)
                    {
                        routesBuffer[uav_id - 1] = routesBuffer[uav_id - 1].GetRange(routesBuffer[uav_id - 1].Count - displayPoint, displayPoint);
                    }
                    marker_of_uavRoute[uav_id - 1] = new GMapRoute(routesBuffer[uav_id - 1], marker_of_uavRoute[uav_id - 1].Name);

                    marker_of_uavRoute[uav_id - 1].Stroke = new Pen(color_of_uavs[uav_id - 1], 2);
                    markers_main[uav_id - 1].Routes.Add(marker_of_uavRoute[uav_id - 1]);
                    // 存進資料庫
                    DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddHours(8).AddSeconds(Buffers[select_index].GCS_timestamp);
                    string flightdata_sql = $@"insert into `flight_data` values 
                            ('{Buffers[select_index].UAV_timestamp}', '{dateTime}', '{Buffers[select_index].Mode}', '{Buffers[select_index].Mission}', 
                                '{Buffers[select_index].E}', '{Buffers[select_index].N}', '{Buffers[select_index].U}', '{Buffers[select_index].Speed}', 
                                '{Buffers[select_index].Roll}', '{Buffers[select_index].Pitch}', '{Buffers[select_index].Yaw}');";
                    MySqlCommand cmd = new MySqlCommand(flightdata_sql, UAVs_flightData_conn[uav_id - 1]);
                    int index = cmd.ExecuteNonQuery();
                    break;
                case Message_ID.Time_Syncronize: // 時間同步校正
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        client.SendTo(Buffers[select_index].pack_time_synchronize_packet(receive_time), connectPort);
                    }
                    else
                    {
                        XBee.SendData(G2U_points[uav_id], Buffers[select_index].pack_time_synchronize_packet(receive_time));
                    }
                    break;
                case Message_ID.info: // 顯示無人機回傳訊息
                    textBox_info.SelectionColor = Color.Red;
                    textBox_info.AppendText($"UAV{uav_id}  ");
                    textBox_info.SelectionColor = Color.Black;
                    textBox_info.AppendText(Buffers[select_index].Info + Environment.NewLine);
                    break;
                case Message_ID.Record_Time: // 紀錄時間並顯示資訊
                    dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddHours(8).AddSeconds(Buffers[select_index].GCS_timestamp);
                    string timeline_sql = $@"insert into `timeline` (`Mission`, `Status`, `UAV Timestamp`, `GCS Timestamp`, `Datatime`) 
                                                values('{Buffers[select_index].Mission}', 
                                                'UAV{uav_id} {Buffers[select_index].Info}', 
                                                {Buffers[select_index].UAV_timestamp}, {receive_time}, '{dateTime}');";
                    cmd = new MySqlCommand(timeline_sql, timelist_conn);
                    index = cmd.ExecuteNonQuery();
                    textBox_info.SelectionColor = Color.MediumSlateBlue;
                    textBox_info.AppendText($"UAV{uav_id}  ");
                    textBox_info.SelectionColor = Color.Black;
                    textBox_info.AppendText($"{Buffers[select_index].Info} --- " +
                        $"{Math.Round(Buffers[select_index].UAV_timestamp, 3, MidpointRounding.AwayFromZero)}, " +
                        $"{Math.Round(receive_time, 3, MidpointRounding.AwayFromZero)}" + Environment.NewLine);
                    break;
                }
            }));
        }
        // 更換地圖中心
        private void comboBox_mapCenter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_mapCenter.Text.Contains("UAV"))
            {
                var select_uav_center = existing_UAVs.IndexOf(Int32.Parse(comboBox_mapCenter.Text.Remove(0, 3)));
                gMapControl_main.Position = new PointLatLng(Buffers[select_uav_center].Lat, Buffers[select_uav_center].Lng);
            }
            else
            {
                gMapControl_main.Position = Origin[comboBox_mapCenter.Text].mapCenter;
                gMapControl_main.Zoom = 20;
            }
        }
        // read existing COM ports
        private void comboBox_connectOption_DropDown(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            Array.Sort(port);
            comboBox_connectOption.Items.Clear();
            comboBox_connectOption.Items.Add("UDP");
            comboBox_connectOption.Items.AddRange(port);
        }
        // choose (COM: Baud) or (UDP: port)
        private void comboBox_connectOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_connectOption.Text == "UDP")
            {
                comboBox_PortOrBaud.Text = string.Empty;
                comboBox_PortOrBaud.Items.Clear();
                comboBox_PortOrBaud.Items.Add($"Port: {port_number}");
            }
            else if (comboBox_connectOption.Text != "UDP" && !String.IsNullOrEmpty(comboBox_connectOption.Text))
            {
                comboBox_PortOrBaud.Text = string.Empty;
                comboBox_PortOrBaud.Items.Clear();
                comboBox_PortOrBaud.Items.AddRange(baudRate);
            }
        }
        

        private void checkBox_allUAVselect_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_allUAVselect.Checked)
            {
                if (existing_UAVs.Any())
                {
                    checkBoxComboBox_UAVselect.Enabled = false;
                }
                else
                {
                    checkBox_allUAVselect.Checked = false;
                    MessageBox.Show("No existing UAV ༼つ ͡◕_ ͡◕ ༽つ");
                }
            }
            else
            {
                checkBoxComboBox_UAVselect.Enabled = true;
            }
        }

        private void button_Publish_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(checkBoxComboBox_UAVselect.Text) || checkBox_allUAVselect.Checked) && !string.IsNullOrEmpty(comboBox_Command.Text))
            {
                commandsTransmit(comboBox_Command.Text);
            }
            else
            {
                MessageBox.Show("Please fil in the command or UAV ༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void button_guideClear_Click(object sender, EventArgs e)
        {
            textBox_wpE.Text = string.Empty;
            textBox_wpN.Text = string.Empty;
            textBox_wpU.Text = string.Empty;
            if (!String.IsNullOrEmpty(comboBox_guideWP.Text))
            {
                int uav_id = Int32.Parse(comboBox_guideWP.Text.Remove(0, 3));
                waypoints_pin[uav_id - 1].Clear();
                waypoints.RemoveAll(p => p.UAV_ID == uav_id && p.Type == WaypointMissionMethod.guide_waypoint);
                comboBox_guideWP.Text = string.Empty;
            }
            if (!waypoints.Any(p => p.Type == WaypointMissionMethod.guide_waypoint))
            {
                skinButton_pubWP.Enabled = false;
                skinButton_clearWPs.Enabled = false;
            }
            textBox_WPguided.Text = string.Empty;
            foreach (Waypoints wp in waypoints)
            {
                if (wp.Type == WaypointMissionMethod.guide_waypoint)
                {
                    textBox_WPguided.AppendText($"UAV{wp.UAV_ID}: " +
                        $"[{wp.waypoints[0][0]}, {wp.waypoints[0][1]}, {wp.waypoints[0][2]}]" + Environment.NewLine);
                }
            }
        }

        private void comboBox_routeDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_routeDisplay.Text == "All Routes")
            {
                allRouteCheck = true; // 顯示所有動態路線之變數
            }
            else
            {
                route_seconds = Int32.Parse(comboBox_routeDisplay.Text); // 顯示(route_seconds)秒前的軌跡
                displayPoint = (int)Math.Round(u2gFreq * route_seconds, 0, MidpointRounding.AwayFromZero);
                allRouteCheck = false;
            } 
        }

        private void button_FreqConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(checkBoxComboBox_UAVselect.Text) || checkBox_allUAVselect.Checked)
            {
                u2gFreq = Convert.ToDouble(comboBox_u2gFreq.Text);
                foreach (Packets uav in Buffers)
                {
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        client.SendTo(uav.pack_commFreqAdjust_packet("U2G", u2gFreq), connectPort);
                    }
                    else
                    {
                        XBee.SendData(G2U_points[uav.UAV_ID], uav.pack_commFreqAdjust_packet("U2G", u2gFreq));
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fil in the UAV ༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void button_WPconfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox_guideWP.Text) && !string.IsNullOrEmpty(textBox_wpE.Text) 
                && !string.IsNullOrEmpty(textBox_wpN.Text) && !string.IsNullOrEmpty(textBox_wpU.Text))
            {
                int uav_id = Int32.Parse(comboBox_guideWP.Text.Remove(0, 3));
                double[] enu;
                if (string.IsNullOrEmpty(textBox_wpYaw.Text))
                {
                    enu = new double[] { Double.Parse(textBox_wpE.Text), Double.Parse(textBox_wpN.Text), Double.Parse(textBox_wpU.Text) };
                }
                else
                {
                    enu = new double[] { Double.Parse(textBox_wpE.Text), Double.Parse(textBox_wpN.Text), Double.Parse(textBox_wpU.Text), 
                        Double.Parse(textBox_wpYaw.Text)};
                }
                var lla = coordinate.enu2llh(enu[0], enu[1], enu[2]);
                waypoints_pin[uav_id - 1].Clear();
                GMarkerGoogle target = new GMarkerGoogle(new PointLatLng(lla[0], lla[1]), GMarkerGoogleType.blue);
                waypoints_pin[uav_id - 1].Markers.Add(target);
                int select_index = existing_UAVs.IndexOf(uav_id);
                List<PointLatLng> route = new List<PointLatLng>() { 
                    new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng), new PointLatLng(lla[0], lla[1]) };
                GMapRoute wp_route = new GMapRoute(route, $"UAV{uav_id} wp")
                {
                    Stroke = new Pen(Color.DarkGray, 2)
                };
                wp_route.Stroke.DashStyle = DashStyle.Dash;
                waypoints_pin[uav_id - 1].Routes.Add(wp_route);
                var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type == WaypointMissionMethod.guide_waypoint);
                if (matches != null)
                {
                    matches.waypoints.Clear();
                    matches.waypoints.Add(enu);
                }
                else
                {
                    waypoints.Add(new Waypoints(uav_id, enu, WaypointMissionMethod.guide_waypoint));
                }
                comboBox_guideWP.Text = string.Empty;
                textBox_wpE.Text = string.Empty;
                textBox_wpN.Text = string.Empty;
                skinButton_pubWP.Enabled = true;
                skinButton_clearWPs.Enabled = true;
                textBox_WPguided.Text = string.Empty;
                foreach (Waypoints wp in waypoints)
                {
                    if (wp.Type == WaypointMissionMethod.guide_waypoint)
                    {
                        if (wp.waypoints[0].Count() == 3)
                        {
                            textBox_WPguided.AppendText($"UAV{wp.UAV_ID}→" +
                            $"({wp.waypoints[0][0]}, {wp.waypoints[0][1]}, {wp.waypoints[0][2]})" + Environment.NewLine);
                        }
                        else
                        {
                            textBox_WPguided.AppendText($"UAV{wp.UAV_ID}→" +
                            $"({wp.waypoints[0][0]}, {wp.waypoints[0][1]}, {wp.waypoints[0][2]}) with {wp.waypoints[0][3]}(deg)" + Environment.NewLine);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in waypoint or UAV.༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            double timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddHours(8).AddSeconds(timestamp);
            Console.WriteLine(dateTime);

            textBox_info.SelectionColor = Color.MediumSlateBlue;
            textBox_info.AppendText($"UAV--------  ");
            var arr = new int[3];
            arr[0] = 1;
            arr[1] = 2;
            arr[2] = 3;
            foreach(var num in arr) { Console.WriteLine(num); }
            Array.Clear(arr, 0, arr.Count());
            foreach (var num in arr) { Console.WriteLine(num); }
            double c = -22.2222;
            var a = BitConverter.GetBytes(Convert.ToInt32(c * 1e4));
            var d = BitConverter.ToInt32(a, 0) * 1e-4;
            Console.WriteLine(d);
            Buffers.Add(new Packets(coordinate, 1, -30, 20, 0, -180, "ddd", FrameType.Quad));
            Buffers.Add(new Packets(coordinate, 2, -15, 30, 0, 90, "test message~~", FrameType.Quad));
            Buffers.Add(new Packets(coordinate, 3, 50, -10, 0, -130, "yoooooo", FrameType.Quad));
            Buffers.Add(new Packets(coordinate, 4, 10, 10, 0, 90, "test message~~", FrameType.Fixed_wing));
            //Buffers.Add(new Packets(coordinate, 5, 50, -10, 0, -180, "yoooooo", FrameType.Fixed_wing));
            //Buffers.Add(new Packets(coordinate, 6, -50, 0, 0, -180, "ddd", FrameType.Fixed_wing));
            //Buffers.Add(new Packets(coordinate, 7, -30, 20, 0, -180, "ddd", FrameType.Quad));
            //Buffers.Add(new Packets(coordinate, 8, 10, 10, 0, 90, "test message~~", FrameType.Quad));
            //Buffers.Add(new Packets(coordinate, 9, 50, -10, 0, -180, "yoooooo", FrameType.Fixed_wing));
            //Buffers.Add(new Packets(coordinate, 10, -50, 0, 0, -180, "ddd", FrameType.Fixed_wing));
            existing_UAVs.AddRange(Enumerable.Range(1, 4).ToList());
            // existing_UAVs.Sort();
            dataGridView_flghtData.Sort(dataGridView_flghtData.Columns["UAV_ID"], ListSortDirection.Ascending);
            var marker_of_uav = Planes.AddQuadrotor(Buffers[0].Lat, Buffers[0].Lng, "UAV0" + Buffers[0].UAV_ID, Buffers[0].Yaw,
                    new SolidBrush(color_of_uavs[Buffers[0].UAV_ID - 1]));
            var marker_of = Planes.AddPlane(Buffers[1].Lat, Buffers[1].Lng, "UAV0" + Buffers[1].UAV_ID, Buffers[1].Yaw,
                   new SolidBrush(color_of_uavs[Buffers[1].UAV_ID - 1]));
            markers_main[Buffers[0].UAV_ID - 1].Markers.Add(marker_of_uav);
            markers_main[Buffers[1].UAV_ID - 1].Markers.Add(marker_of);
            string uav_text = UAV_ID_text(3);
            comboBox_mapCenter.Items.Add(uav_text);
            checkBoxComboBox_UAVselect.Items.Add(uav_text);
            uav_text = UAV_ID_text(2);
            comboBox_mapCenter.Items.Add(uav_text);
            checkBoxComboBox_UAVselect.Items.Add(uav_text);
            textBox_info.SelectionColor = Color.Red;
            textBox_info.AppendText($"UAV{2}  ");
            textBox_info.SelectionColor = Color.Black;
            textBox_info.AppendText(Buffers[0].Info + Environment.NewLine);

            if (tabControl_action.SelectedTab.Text == "Command")
            {
                textBox_info.AppendText("Guide" + Environment.NewLine);
            }
            else
            {
                textBox_info.AppendText("nnn" + Environment.NewLine);
            }

            // CreateShortcut("5895GCS", Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Assembly.GetExecutingAssembly().Location);
        }

        private void gMapControl_main_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                PointLatLng pin = gMapControl_main.FromLocalToLatLng(e.X, e.Y);
                Console.WriteLine($"{pin.Lat}, {pin.Lng}");
            }
            if (e.Button == MouseButtons.Right && tabControl_action.SelectedTab.Text == "Guide" && !String.IsNullOrEmpty(comboBox_guideWP.Text))
            {
                int uav_id = Int32.Parse(comboBox_guideWP.Text.Remove(0, 3));
                PointLatLng pin = gMapControl_main.FromLocalToLatLng(e.X, e.Y);
                var lla = new double[] { pin.Lat, pin.Lng, 0 };
                var enu = coordinate.llh2enu(lla[0], lla[1], lla[2]);
                textBox_wpE.Text = Math.Round(enu[0], 3, MidpointRounding.AwayFromZero).ToString();
                textBox_wpN.Text = Math.Round(enu[1], 3, MidpointRounding.AwayFromZero).ToString();
                waypoints_pin[uav_id - 1].Clear();
                GMarkerGoogle target = new GMarkerGoogle(new PointLatLng(lla[0], lla[1]), GMarkerGoogleType.blue);
                waypoints_pin[uav_id - 1].Markers.Add(target);
                int select_index = existing_UAVs.IndexOf(uav_id);
                List<PointLatLng> route = new List<PointLatLng>() {
                    new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng), new PointLatLng(lla[0], lla[1]) };
                GMapRoute wp_route = new GMapRoute(route, $"UAV{uav_id} wp")
                {
                    Stroke = new Pen(Color.DarkGray, 2)
                };
                wp_route.Stroke.DashStyle = DashStyle.Dash;
                waypoints_pin[uav_id - 1].Routes.Add(wp_route);
                waypoints.RemoveAll(p => p.UAV_ID == uav_id && p.Type == WaypointMissionMethod.guide_waypoint);
                if (!waypoints.Any(p => p.Type == WaypointMissionMethod.guide_waypoint))
                {
                    skinButton_pubWP.Enabled = false;
                    skinButton_clearWPs.Enabled = false;
                }
            }
            else if (e.Button == MouseButtons.Right && tabControl_action.SelectedTab.Text != "Guide" && !String.IsNullOrEmpty(comboBox_guideWP.Text))
            {
                int uav_id = Int32.Parse(comboBox_guideWP.Text.Remove(0, 3));
                PointLatLng pin = gMapControl_main.FromLocalToLatLng(e.X, e.Y);
                var lla = new double[] { pin.Lat, pin.Lng, 0 };
                var enu = coordinate.llh2enu(lla[0], lla[1], lla[2]);
                waypoints_pin[uav_id - 1].Clear();
                GMarkerGoogle target = new GMarkerGoogle(new PointLatLng(lla[0], lla[1]), GMarkerGoogleType.blue);
                waypoints_pin[uav_id - 1].Markers.Add(target);
                int select_index = existing_UAVs.IndexOf(uav_id);
                List<PointLatLng> route = new List<PointLatLng>() {
                    new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng), new PointLatLng(lla[0], lla[1]) };
                GMapRoute wp_route = new GMapRoute(route, $"UAV{uav_id} wp")
                {
                    Stroke = new Pen(Color.DarkGray, 2)
                };
                wp_route.Stroke.DashStyle = DashStyle.Dash;
                waypoints_pin[uav_id - 1].Routes.Add(wp_route);
                DialogResult go_wp = MessageBox.Show(this, "確定至該航點？", "導航確認通知٩(✿∂‿∂✿)۶", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (go_wp == DialogResult.Yes)
                {
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        var t = new Thread(() => client.SendTo(Buffers[select_index].pack_guide_mission_packet(enu[0], enu[1], 0, 5), connectPort));
                        t.Start();
                    }
                    else if (comboBox_connectOption.Text.Contains("COM"))
                    {
                        var t = new Thread(() => XBee.SendData(G2U_points[uav_id], Buffers[select_index].pack_guide_mission_packet(enu[0], enu[1], 0, 5)));
                        t.Start();
                    }
                }
                else
                {
                    waypoints_pin[uav_id - 1].Clear();
                }
            }
        }

        private void gMapControl_main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                lockMap = false;
            }    
        }

        private void button_sortDataGrid_Click(object sender, EventArgs e)
        {
            // 刷新並調整顯示表格
            dataGridView_flghtData.AutoResizeColumns();
        }

        private void comboBox_missionUAV_DropDown(object sender, EventArgs e)
        {
            comboBox_missionUAV.Items.Clear();
            foreach (int uav_id in existing_UAVs)
            {
                comboBox_missionUAV.Items.Add(UAV_ID_text(uav_id));
            }
        }

        private void button_missionPrepare_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox_missionUAV.Text) && !string.IsNullOrEmpty(comboBox_missionTypeMission.Text) &&
                !string.IsNullOrEmpty(comboBox_missionMethod.Text))
            {
                int uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                int select_index = existing_UAVs.IndexOf(uav_id);
                waypoints.RemoveAll(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                var start_pos = new double[] { Buffers[select_index].E, Buffers[select_index].N, Buffers[select_index].U, 
                    Buffers[select_index].get_ENU_yawAngle()};

                var mission = Mission_setting.path_mission[comboBox_missionTypeMission.Text].Deepcopy();
                mission.UAV_ID = uav_id;
                mission.Type = Mission_setting.WaypointMissionMethod_name[comboBox_missionMethod.Text];
                mission.start_position = start_pos;
                waypoints.Add(mission);
                var matches = waypoints.Last();
                // plot on map (preplan)
                try
                {
                    var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                    overlay.Markers.Clear();
                    overlay.Routes.Clear();
                }
                catch
                {
                    gMapControl_WPs.Overlays.Add(new GMapOverlay($"preplan {UAV_ID_text(uav_id)}"));
                }
                finally
                {
                    List<PointLatLng> wps;
                    var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                    if (matches.Type == WaypointMissionMethod.CraigReynolds_Path_Following)
                    {
                        wps = new List<PointLatLng>() { };
                    }
                    else
                    {
                        wps = new List<PointLatLng>() { new PointLatLng(Buffers[select_index].Lat, Buffers[select_index].Lng) };
                    }
                    
                    // add wps (default mission)
                    dataGridView_mission.Rows.Clear();
                    if (matches.waypoints.Count != 0)
                    {
                        dataGridView_mission.Rows.Add(matches.waypoints.Count);
                    }

                    var dubins = new DubinsPath();
                    for (int i = 0; i < matches.waypoints.Count; i++)
                    {
                        var wp = matches.waypoints[i];
                        var lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                        overlay.Markers.Add(Planes.AddWaypoint(lla[0], lla[1], i + 1, GMarkerGoogleType.green));
                        if (matches.Type == WaypointMissionMethod.CraigReynolds_Path_Following && 
                            matches.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                        {
                            try
                            {
                                var path = dubins.Dubins_shortestPath(new double[] { wp[0], wp[1], wp[3]}, 
                                    new double[] { matches.waypoints[i + 1][0], matches.waypoints[i + 1][1], matches.waypoints[i + 1][3] }, matches.Rmin);
                                foreach (Vector3 point in path)
                                {
                                    lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                                    wps.Add(new PointLatLng(lla[0], lla[1]));
                                }
                            }
                            catch { }
                        }
                        else
                        {
                            wps.Add(new PointLatLng(lla[0], lla[1]));
                        }
                        dataGridView_mission.Rows[i].Cells["order"].Value = i + 1;
                        dataGridView_mission.Rows[i].Cells["E"].Value = wp[0];
                        dataGridView_mission.Rows[i].Cells["N"].Value = wp[1];
                        dataGridView_mission.Rows[i].Cells["U"].Value = wp[2];
                        try { dataGridView_mission.Rows[i].Cells["heading"].Value = wp[3]; }
                        catch { }
                        dataGridView_mission.Rows[i].Cells["up"].Value = "▲";
                        dataGridView_mission.Rows[i].Cells["down"].Value = "▼";
                        dataGridView_mission.Rows[i].Cells["delete"].Value = "X";
                    }
                    dataGridView_mission.AutoResizeColumns();

                    GMapRoute ref_route = new GMapRoute(wps, $"preplan {UAV_ID_text(uav_id)}")
                    {
                        Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                    };
                    overlay.Routes.Add(ref_route);
                    switch (Buffers[select_index].Frame_type)
                    {
                        case FrameType.Quad:
                            overlay.Markers.Add(Planes.AddQuadrotor(Buffers[select_index].Lat, Buffers[select_index].Lng, UAV_ID_text(uav_id), Buffers[select_index].get_ENU_yawAngle(),
                                        new SolidBrush(color_of_uavs[uav_id - 1])));
                            break;
                        case FrameType.Fixed_wing:
                            overlay.Markers.Add(Planes.AddPlane(Buffers[select_index].Lat, Buffers[select_index].Lng, UAV_ID_text(uav_id), Buffers[select_index].get_ENU_yawAngle(),
                                        new SolidBrush(color_of_uavs[uav_id - 1])));
                            break;
                    }
                    button_missionConfirm.Enabled = true;
                    button_missionClear.Enabled = true;
                }
            }
            else
            {
                MessageBox.Show("Mission inputs are missing ~");
            }
        }

        private void button_startMission_Click(object sender, EventArgs e)
        {
            gMapControl_WPs.DragButton = MouseButtons.Left;
            gMapControl_WPs.MapProvider = GMapProviders.GoogleMap;
            gMapControl_WPs.Position = coordinate.mapCenter;
            gMapControl_WPs.MaxZoom = 24;
            gMapControl_WPs.MinZoom = 3;
            gMapControl_WPs.Zoom = 19;
            gMapControl_WPs.ShowCenter = false;
            gMapControl_WPs.Manager.Mode = AccessMode.ServerAndCache;

            comboBox_missionTypeMission.Enabled = true;
            comboBox_missionUAV.Enabled = true;
            comboBox_missionMethod.Enabled = true;
            button_missionPrepare.Enabled = true;
            button_missionCancel.Enabled = true;

            // mission setting
            comboBox_missionTypeMission.Items.Clear();
            comboBox_missionTypeMission.Items.AddRange(Mission_setting.path_mission.Keys.ToArray());
            comboBox_missionMethod.Items.Clear();
            comboBox_missionMethod.Items.AddRange(Mission_setting.WaypointMissionMethod_name.Keys.ToArray());
        }

        private void button_missionCancel_Click(object sender, EventArgs e)
        {
            dataGridView_mission.Rows.Clear();
            if (!String.IsNullOrEmpty(comboBox_missionUAV.Text))
            {
                var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                waypoints.RemoveAll(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                try
                {
                    var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                    overlay.Markers.Clear();
                    overlay.Routes.Clear();
                }
                catch { }
            }
            if (waypoints.Find(p => p.Type != WaypointMissionMethod.guide_waypoint) == null)
            {
                skinComboBox_PubMission.Items.Remove("Waypoints mission");
            }
            comboBox_missionTypeMission.Text = string.Empty;
            comboBox_missionUAV.Text = string.Empty;
            comboBox_missionMethod.Text = string.Empty;
        }

        private void gMapControl_mission_MouseClick(object sender, MouseEventArgs e)
        {
            if (!skinButton_adjustMission.Enabled && e.Button == MouseButtons.Right && !String.IsNullOrEmpty(comboBox_missionUAV.Text) && !String.IsNullOrEmpty(comboBox_missionTypeMission.Text))
            {
                int uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                PointLatLng pin = gMapControl_WPs.FromLocalToLatLng(e.X, e.Y);
                var lla = new double[] { pin.Lat, pin.Lng, 0 };
                var enu = coordinate.llh2enu(lla[0], lla[1], lla[2]);
                enu[2] = double.Parse(textBox_missionHeight.Text);
                try
                {
                    var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                    overlay.Markers.Insert(overlay.Markers.Count - 1, Planes.AddWaypoint(pin.Lat, pin.Lng, overlay.Markers.Count, GMarkerGoogleType.green));

                    var wp_corresponding = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                    var new_wps = wp_corresponding.Deepcopy();
                    
                    waypoints.Remove(wp_corresponding);

                    dataGridView_mission.Rows.Add(1);
                    int index = dataGridView_mission.RowCount - 1;
                    dataGridView_mission.Rows[index].Cells["order"].Value = index + 1;
                    dataGridView_mission.Rows[index].Cells["E"].Value = Math.Round(enu[0], 3, MidpointRounding.AwayFromZero);
                    dataGridView_mission.Rows[index].Cells["N"].Value = Math.Round(enu[1], 3, MidpointRounding.AwayFromZero);
                    dataGridView_mission.Rows[index].Cells["U"].Value = Math.Round(enu[2], 3, MidpointRounding.AwayFromZero);
                    if (new_wps.Type == WaypointMissionMethod.CraigReynolds_Path_Following)
                    {
                        if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                        {
                            var heading = double.Parse(textBox_missionHeading.Text);
                            dataGridView_mission.Rows[index].Cells["heading"].Value = Math.Round(heading, 3, MidpointRounding.AwayFromZero);
                            enu = new double[4] { enu[0], enu[1], enu[2], heading};
                        }
                    }
                    dataGridView_mission.Rows[index].Cells["up"].Value = "▲";
                    dataGridView_mission.Rows[index].Cells["down"].Value = "▼";
                    dataGridView_mission.Rows[index].Cells["delete"].Value = "X";

                    new_wps.waypoints.Add(enu);
                    waypoints.Add(new_wps);
                    var route_wps = overlay.Routes[0].Points;
                    overlay.Routes.Clear();
                    if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                    {
                        var dubins = new DubinsPath();
                        var start_config = new_wps.waypoints[new_wps.waypoints.Count()-2];
                        var path = dubins.Dubins_shortestPath(new double[] { start_config[0], start_config[1], start_config[3] },
                                    new double[] { enu[0], enu[1], enu[3] }, new_wps.Rmin);
                        foreach (Vector3 point in path)
                        {
                            lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                            route_wps.Add(new PointLatLng(lla[0], lla[1]));
                        }
                    }
                    else
                    {
                        route_wps.Add(new PointLatLng(lla[0], lla[1]));
                    }
                    GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                    {
                        Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                    };
                    overlay.Routes.Add(ref_route);
                    dataGridView_mission.AutoResizeColumns();
                }
                catch { }
            }
        }

        private void dataGridView_mission_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!skinButton_adjustMission.Enabled)
            {
                switch (dataGridView_mission.Columns[e.ColumnIndex].Name)
                {
                    case "up":
                        if (e.RowIndex != 0)
                        {
                            List<object> select_row = new List<object>();
                            for (int i = 1; i < dataGridView_mission.Columns.Count; i++)
                            {
                                select_row.Add(dataGridView_mission.Rows[e.RowIndex].Cells[i].Value);
                            }
                            for (int i = 1; i < dataGridView_mission.Columns.Count; i++)
                            {
                                dataGridView_mission.Rows[e.RowIndex].Cells[i].Value =
                                    dataGridView_mission.Rows[e.RowIndex - 1].Cells[i].Value;
                                dataGridView_mission.Rows[e.RowIndex - 1].Cells[i].Value = select_row[i - 1];
                            }
                            var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                            var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                            var new_wps = matches.Deepcopy();
                            waypoints.Remove(matches);
                            var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                            List<PointLatLng> route_wps = overlay.Routes[0].Points;
                            var marker_list = overlay.Markers.ToList();
                            overlay.Markers.Clear();
                            overlay.Routes.Clear();
                            // 修改儲存航點空間
                            var select_wp = new_wps.waypoints[e.RowIndex];
                            new_wps.waypoints[e.RowIndex] = new_wps.waypoints[e.RowIndex - 1];
                            new_wps.waypoints[e.RowIndex - 1] = select_wp;
                            // 修改地圖航點
                            var select_pin = marker_list.Find(p => p.ToolTipText == $"{e.RowIndex + 1}");
                            var switch_pin = marker_list.Find(p => p.ToolTipText == $"{e.RowIndex}");
                            select_pin.ToolTipText = $"{e.RowIndex}";
                            switch_pin.ToolTipText = $"{e.RowIndex + 1}";
                            foreach (GMapMarker marker in marker_list)
                            {
                                overlay.Markers.Add(marker);
                            }
                            // 修改地圖路線順序
                            if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                            {
                                route_wps.Clear();
                                var dubins = new DubinsPath();
                                for (int i = 0; i < new_wps.waypoints.Count; i++)
                                {
                                    var wp = new_wps.waypoints[i];
                                    var lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                    try
                                    {
                                        var path = dubins.Dubins_shortestPath(new double[] { wp[0], wp[1], wp[3] },
                                            new double[] { new_wps.waypoints[i + 1][0], new_wps.waypoints[i + 1][1], new_wps.waypoints[i + 1][3] }, new_wps.Rmin);
                                        foreach (Vector3 point in path)
                                        {
                                            lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                                            route_wps.Add(new PointLatLng(lla[0], lla[1]));
                                        }
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                var route_wp = route_wps[e.RowIndex + 1];
                                route_wps[e.RowIndex + 1] = route_wps[e.RowIndex];
                                route_wps[e.RowIndex] = route_wp;
                            }
                            
                            GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                            {
                                Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                            };
                            overlay.Routes.Add(ref_route);
                            waypoints.Add(new_wps);
                        }
                        break;
                    case "down":
                        if (e.RowIndex != dataGridView_mission.RowCount - 1)
                        {
                            List<object> select_row = new List<object>();
                            for (int i = 1; i < dataGridView_mission.Columns.Count; i++)
                            {
                                select_row.Add(dataGridView_mission.Rows[e.RowIndex].Cells[i].Value);
                            }
                            for (int i = 1; i < dataGridView_mission.Columns.Count; i++)
                            {
                                dataGridView_mission.Rows[e.RowIndex].Cells[i].Value =
                                    dataGridView_mission.Rows[e.RowIndex + 1].Cells[i].Value;
                                dataGridView_mission.Rows[e.RowIndex + 1].Cells[i].Value = select_row[i - 1];
                            }
                            var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                            var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                            var new_wps = matches.Deepcopy();
                            waypoints.Remove(matches);
                            var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                            List<PointLatLng> route_wps = overlay.Routes[0].Points;
                            var marker_list = overlay.Markers.ToList();
                            overlay.Markers.Clear();
                            overlay.Routes.Clear();
                            // 修改儲存航點空間
                            var select_wp = new_wps.waypoints[e.RowIndex];
                            new_wps.waypoints[e.RowIndex] = new_wps.waypoints[e.RowIndex + 1];
                            new_wps.waypoints[e.RowIndex + 1] = select_wp;
                            // 修改地圖航點
                            var select_pin = marker_list.Find(p => p.ToolTipText == $"{e.RowIndex + 1}");
                            var switch_pin = marker_list.Find(p => p.ToolTipText == $"{e.RowIndex + 2}");
                            select_pin.ToolTipText = $"{e.RowIndex + 2}";
                            switch_pin.ToolTipText = $"{e.RowIndex + 1}";
                            foreach (GMapMarker marker in marker_list)
                            {
                                overlay.Markers.Add(marker);
                            }
                            // 修改地圖路線順序
                            if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                            {
                                route_wps.Clear();
                                var dubins = new DubinsPath();
                                for (int i = 0; i < new_wps.waypoints.Count; i++)
                                {
                                    var wp = new_wps.waypoints[i];
                                    var lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                    try
                                    {
                                        var path = dubins.Dubins_shortestPath(new double[] { wp[0], wp[1], wp[3] },
                                            new double[] { new_wps.waypoints[i + 1][0], new_wps.waypoints[i + 1][1], new_wps.waypoints[i + 1][3] }, new_wps.Rmin);
                                        foreach (Vector3 point in path)
                                        {
                                            lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                                            route_wps.Add(new PointLatLng(lla[0], lla[1]));
                                        }
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                var route_wp = route_wps[e.RowIndex + 1];
                                route_wps[e.RowIndex + 1] = route_wps[e.RowIndex + 2];
                                route_wps[e.RowIndex + 2] = route_wp;
                            }
                            
                            GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                            {
                                Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                            };
                            overlay.Routes.Add(ref_route);

                            waypoints.Add(new_wps);
                        }
                        break;
                    case "delete":
                        if (dataGridView_mission.RowCount > 1)
                        {
                            dataGridView_mission.Rows.Remove(dataGridView_mission.Rows[e.RowIndex]);
                            var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                            var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                            var new_wps = matches.Deepcopy();
                            waypoints.Remove(matches);
                            var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                            List<PointLatLng> route_wps = overlay.Routes[0].Points;
                            var marker_list = overlay.Markers.ToList();
                            overlay.Markers.Clear();
                            overlay.Routes.Clear();
                            new_wps.waypoints.RemoveAt(e.RowIndex);

                            marker_list.RemoveAll(p => p.ToolTipText == $"{e.RowIndex + 1}");
                            foreach (GMapMarker marker in marker_list)
                            {
                                if (!marker.ToolTipText.Contains("UAV"))
                                {
                                    int wp_num = Int32.Parse(marker.ToolTipText);
                                    if (wp_num > e.RowIndex + 1)
                                    {
                                        marker.ToolTipText = $"{wp_num - 1}";
                                    }
                                }
                                overlay.Markers.Add(marker);
                            }
                            if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                            {
                                route_wps.Clear();
                                var dubins = new DubinsPath();
                                for (int i = 0; i < new_wps.waypoints.Count; i++)
                                {
                                    var wp = new_wps.waypoints[i];
                                    var lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                    try
                                    {
                                        var path = dubins.Dubins_shortestPath(new double[] { wp[0], wp[1], wp[3] },
                                            new double[] { new_wps.waypoints[i + 1][0], new_wps.waypoints[i + 1][1], new_wps.waypoints[i + 1][3] }, new_wps.Rmin);
                                        foreach (Vector3 point in path)
                                        {
                                            lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                                            route_wps.Add(new PointLatLng(lla[0], lla[1]));
                                        }
                                    }
                                    catch { }
                                }
                            }
                            else
                            {
                                route_wps.RemoveAt(e.RowIndex + 1);
                            }
                            
                            GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                            {
                                Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                            };
                            overlay.Routes.Add(ref_route);
                            // 改刪除航點後之順序
                            for (int j = e.RowIndex; j < dataGridView_mission.Rows.Count; j++)
                            {
                                dataGridView_mission.Rows[j].Cells["order"].Value = j + 1;
                            }

                            waypoints.Add(new_wps);
                        }
                        else
                        {
                            dataGridView_mission.Rows.Clear();
                            var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                            var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                            var new_wps = matches.Deepcopy();
                            new_wps.waypoints.Clear();
                            waypoints.Remove(matches);
                            var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                            var plane = overlay.Markers.ToList();
                            var route_wps = overlay.Routes[0].Points;
                            overlay.Markers.Clear();
                            overlay.Routes.Clear();
                            overlay.Markers.Add(plane.Last());
                            waypoints.Add(new_wps);
                            route_wps.RemoveAt(e.RowIndex + 1);
                            GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                            {
                                Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                            };
                            overlay.Routes.Add(ref_route);
                        }
                        break;
                    }
                }
        }

        private void button_missionConfirm_Click(object sender, EventArgs e)
        {
            if (!skinComboBox_PubMission.Items.Contains("Waypoints mission"))
            {
                skinComboBox_PubMission.Items.Add("Waypoints mission");
            }
            skinButton_adjustMission.Enabled = true;
            comboBox_missionUAV.Enabled = false;
            comboBox_missionUAV.Text = string.Empty;
            comboBox_missionTypeMission.Enabled = false;
            comboBox_missionTypeMission.Text = string.Empty;
            comboBox_missionMethod.Enabled = false;
            comboBox_missionMethod.Text = string.Empty;
            button_missionCancel.Enabled = false;
            button_missionClear.Enabled = false;
            button_missionConfirm.Enabled = false;
            button_missionPrepare.Enabled = false;
            dataGridView_mission.Rows.Clear();
            button_startMission.Enabled = false;
            // 情除waypoint guided航點命令
            waypoints.RemoveAll(p => p.Type == WaypointMissionMethod.guide_waypoint);
        }

        private void button_missionClear_Click(object sender, EventArgs e)
        {
            waypoints.RemoveAll(p => p.Type != WaypointMissionMethod.guide_waypoint);
            foreach (GMapOverlay overlay in gMapControl_WPs.Overlays)
            {
                overlay.Markers.Clear();
                overlay.Routes.Clear();
            }
            gMapControl_WPs.Overlays.Clear();
            dataGridView_mission.Rows.Clear();
            button_missionConfirm.Enabled = false;
            button_missionClear.Enabled = false;
            if (skinComboBox_PubMission.Items.Contains("Waypoints mission"))
            {
                skinComboBox_PubMission.Items.Remove("Waypoints mission");
            }
        }

        private void gMapControl_mission_MouseDown(object sender, MouseEventArgs e)
        {
            if (currentMarker != null && !skinButton_adjustMission.Enabled)
            {
                if (currentMarker.IsMouseOver && e.Button == MouseButtons.Left && !currentMarker.ToolTipText.Contains("UAV")
                    && currentMarker.Overlay.Id == $"preplan {comboBox_missionUAV.Text}")
                {
                    isChooseWP = true;
                }
            }
        }

        private void gMapControl_mission_MouseMove(object sender, MouseEventArgs e)
        {
            if (isChooseWP)
            {
                PointLatLng pin = gMapControl_WPs.FromLocalToLatLng(e.X, e.Y);
                var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                var overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(uav_id)}");
                var wp_num = Int32.Parse(currentMarker.ToolTipText);
                overlay.Markers.Remove(currentMarker);
                currentMarker = Planes.AddWaypoint(pin.Lat, pin.Lng, wp_num, GMarkerGoogleType.green);
                overlay.Markers.Add(currentMarker);
                var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                if (comboBox_missionMethod.Text == "CraigReynold's Path Following" &&
                    matches.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                {
                    overlay.Routes.Clear();
                    List<PointLatLng> wps = new List<PointLatLng>() { };
                    var dubins = new DubinsPath();
                    var new_wps = matches.waypoints;
                    var height = new_wps[wp_num-1][2];
                    var heading = new_wps[wp_num-1][3];
                    var enu = coordinate.llh2enu(pin.Lat, pin.Lng, 0);
                    new_wps.RemoveAt(wp_num-1);
                    new_wps.Insert(wp_num-1, new double[] { enu[0], enu[1], height, heading });
                    for (int i = 0; i < new_wps.Count()-1; i++)
                    {
                        foreach (var a in new_wps[i]) { Console.WriteLine(a); };
                        var path = dubins.Dubins_shortestPath(new double[] { new_wps[i][0], new_wps[i][1], new_wps[i][3] },
                                new double[] { new_wps[i + 1][0], new_wps[i + 1][1], new_wps[i + 1][3] }, matches.Rmin);
                        foreach (Vector3 point in path)
                        {
                            var lla = coordinate.enu2llh(point.X, point.Y, point.Z);
                            wps.Add(new PointLatLng(lla[0], lla[1]));
                        }
                    }
                    GMapRoute ref_route = new GMapRoute(wps, $"preplan {UAV_ID_text(uav_id)}")
                    {
                        Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                    };
                    overlay.Routes.Add(ref_route);
                }
                else
                {
                    List<PointLatLng> route_wps = overlay.Routes[0].Points;
                    overlay.Routes.Clear();
                    route_wps.RemoveAt(wp_num);
                    route_wps.Insert(wp_num, new PointLatLng(pin.Lat, pin.Lng));
                    GMapRoute ref_route = new GMapRoute(route_wps, $"preplan {UAV_ID_text(uav_id)}")
                    {
                        Stroke = new Pen(color_of_uavs[uav_id - 1], 4)
                    };
                    overlay.Routes.Add(ref_route);
                }    
            }
        }

        private void gMapControl_mission_MouseUp(object sender, MouseEventArgs e)
        {
            if (isChooseWP)
            {
                isChooseWP = false;
                var uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                var new_wps = matches.Deepcopy();
                var wp_num = Int32.Parse(currentMarker.ToolTipText);
                double[] enu = coordinate.llh2enu(currentMarker.Position.Lat, currentMarker.Position.Lng, 0);
                enu[2] = double.Parse(textBox_missionHeight.Text);
                if (comboBox_missionMethod.Text == "CraigReynold's Path Following" &&
                    matches.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID) { }
                else
                {
                    waypoints.Remove(matches);
                    new_wps.waypoints.RemoveAt(wp_num - 1);
                    new_wps.waypoints.Insert(wp_num - 1, enu);
                    waypoints.Add(new_wps);
                }
                
                dataGridView_mission.Rows[wp_num - 1].Cells["order"].Value = wp_num;
                dataGridView_mission.Rows[wp_num - 1].Cells["E"].Value = Math.Round(enu[0], 3, MidpointRounding.AwayFromZero);
                dataGridView_mission.Rows[wp_num - 1].Cells["N"].Value = Math.Round(enu[1], 3, MidpointRounding.AwayFromZero);
                dataGridView_mission.Rows[wp_num - 1].Cells["U"].Value = Math.Round(enu[2], 3, MidpointRounding.AwayFromZero);
                if (new_wps.Type == WaypointMissionMethod.CraigReynolds_Path_Following)
                {
                    if (new_wps.pathFollowing_method == pathFollowingMethod.dubinsPath_following_velocity_PID)
                    {
                        dataGridView_mission.Rows[wp_num - 1].Cells["heading"].Value = Math.Round(double.Parse(textBox_missionHeading.Text), 3, MidpointRounding.AwayFromZero);
                    }
                }
                dataGridView_mission.Rows[wp_num - 1].Cells["up"].Value = "▲";
                dataGridView_mission.Rows[wp_num - 1].Cells["down"].Value = "▼";
                dataGridView_mission.Rows[wp_num - 1].Cells["delete"].Value = "X";
                dataGridView_mission.AutoResizeColumns();
            }
        }

        private void gMapControl_mission_OnMarkerEnter(GMapMarker item)
        {
            if (!isChooseWP)
            {
                currentMarker = item;
            }
        }

        private void gMapControl_main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                lockMap = true;
                if (!comboBox_mapCenter.Text.Contains("UAV"))
                {
                    gMapControl_main.Position = Origin[comboBox_mapCenter.Text].mapCenter;
                    gMapControl_main.Zoom = 20;
                }
                else
                {
                    var select_uav_center = existing_UAVs.IndexOf(Int32.Parse(comboBox_mapCenter.Text.Remove(0, 3)));
                    gMapControl_main.Position = new PointLatLng(Buffers[select_uav_center].Lat, Buffers[select_uav_center].Lng);
                }
            }
        }

        private void skinButton_adjustMission_Click(object sender, EventArgs e)
        {
            skinButton_adjustMission.Enabled = false;
            comboBox_missionUAV.Enabled = true;
            comboBox_missionTypeMission.Enabled = true;
            comboBox_missionMethod.Enabled = true;
            button_missionCancel.Enabled = true;
            button_missionClear.Enabled = true;
            button_missionConfirm.Enabled = true;
            button_missionPrepare.Enabled = true;
            button_startMission.Enabled = true;
            if (skinComboBox_PubMission.Items.Contains("Waypoints mission"))
            {
                skinComboBox_PubMission.Items.Remove("Waypoints mission");
            }
        }

        private void skinComboBox_PubMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (skinComboBox_PubMission.Text)
            {
                case "Waypoints mission":
                    // plot the mission on GmapControl_main
                    GMapOverlay overlay;
                    double[] wp, lla;
                    foreach (Waypoints task in waypoints)
                    {
                        if (task.Type != WaypointMissionMethod.guide_waypoint)
                        {
                            waypoints_pin[task.UAV_ID - 1].Clear();
                            overlay = gMapControl_WPs.Overlays.First(p => p.Id == $"preplan {UAV_ID_text(task.UAV_ID)}");
                            List<PointLatLng> route_wps = overlay.Routes[0].Points;
                            if (task.Type != WaypointMissionMethod.CraigReynolds_Path_Following)
                            {
                                wp = task.start_position;
                                lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                waypoints_pin[task.UAV_ID - 1].Markers.Add(Planes.AddWaypoint(lla[0], lla[1], 0, GMarkerGoogleType.blue));
                            }
                            for (int i = 0; i < task.waypoints.Count; i++)
                            {
                                wp = task.waypoints[i];
                                lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                waypoints_pin[task.UAV_ID - 1].Markers.Add(Planes.AddWaypoint(lla[0], lla[1], i + 1, GMarkerGoogleType.blue));
                            }
                            GMapRoute ref_route = new GMapRoute(route_wps, $"preplan UAV{task.UAV_ID}")
                            {
                                Stroke = new Pen(Color.DarkGray, 3)
                            };
                            waypoints_pin[task.UAV_ID - 1].Routes.Add(ref_route);
                        }
                    }
                    skinButton_missionStart.Enabled = true;
                    break;
                case "VRP mission":
                    var targets_overlay = gMapControl_VRP.Overlays.First(p => p.Id == "target set");
                    foreach (Waypoints task in waypoints)
                    {
                        if (task.Type == WaypointMissionMethod.guide_waypoints)
                        {
                            waypoints_pin[task.UAV_ID - 1].Clear();
                            overlay = gMapControl_VRP.Overlays.First(p => p.Id == $"VRP_{UAV_ID_text(task.UAV_ID)}");
                            List<PointLatLng> route_wps = overlay.Routes[0].Points;
                            for (int i = 0; i < task.targetID_List.Count(); i++)
                            {
                                wp = task.waypoints[i];
                                lla = coordinate.enu2llh(wp[0], wp[1], wp[2]);
                                waypoints_pin[task.UAV_ID - 1].Markers.Add(Planes.AddWaypoint(lla[0], lla[1], task.targetID_List[i], GMarkerGoogleType.blue));
                            }
                            GMapRoute ref_route = new GMapRoute(route_wps, $"VRP_{task.UAV_ID}")
                            {
                                Stroke = new Pen(Color.DarkGray, 3)
                            };
                            waypoints_pin[task.UAV_ID - 1].Routes.Add(ref_route);
                        }
                    }
                    skinButton_missionStart.Enabled = true;
                    break;
                case "SEAD mission":
                    if (!String.IsNullOrEmpty(skinComboBox_SEAD.Text))
                    {
                        foreach (var wps in waypoints_pin) { wps.Clear(); }
                        overlay = gMapControl_SEAD.Overlays.First(p => p.Id == $"SEAD mission");
                        var mission = Mission_setting.SEAD_mission[skinComboBox_SEAD.Text];
                        var marker_list = overlay.Markers.ToList();
                        foreach (GMapMarker marker in marker_list)
                        {
                            waypoints_pin[0].Markers.Add(marker);
                        }

                        skinButton_goToInitPos.Enabled = true;
                    }
                    break;
            }
        }

        private void skinButton_missionStart_Click(object sender, EventArgs e)
        {
            // 清除先前儲存之路線
            foreach (List<PointLatLng> route in routesBuffer)
            {
                route.Clear();
            }
            double timestamp = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds; 
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0).AddHours(8).AddSeconds(timestamp);
            switch (skinComboBox_PubMission.Text)
            {
                case "Waypoints mission":
                    // 存任務開始時間
                    string timeline_sql = $@"insert into `timeline` (`Mission`, `Status`, `UAV Timestamp`, `GCS Timestamp`, `Datatime`) 
                                                    values('{Message_ID.Waypoints}', 'Waypoints mission start', {timestamp}, {timestamp}, '{dateTime}');";
                    MySqlCommand cmd = new MySqlCommand(timeline_sql, timelist_conn);
                    var index = cmd.ExecuteNonQuery();
                    // 發布任務命令
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        foreach (Waypoints task in waypoints)
                        {
                            int select_index = existing_UAVs.IndexOf(task.UAV_ID);
                            var t = new Thread(() => client.SendTo(Buffers[select_index].pack_pathFollowing_mission_packet(task), connectPort));
                            t.Start();
                        }
                    }
                    else if (comboBox_connectOption.Text.Contains("COM"))
                    {
                        foreach (Waypoints task in waypoints)
                        {
                            int select_index = existing_UAVs.IndexOf(task.UAV_ID);
                            var t = new Thread(() => XBee.SendData(G2U_points[task.UAV_ID], Buffers[select_index].pack_pathFollowing_mission_packet(task)));
                            t.Start();
                        }
                    }
                    break;
                case "VRP mission":
                    // 發布任務命令
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        foreach (Waypoints task in waypoints)
                        {
                            if (task.Type == WaypointMissionMethod.guide_waypoints)
                            {
                                int select_index = existing_UAVs.IndexOf(task.UAV_ID);
                                var t = new Thread(() => client.SendTo(Buffers[select_index].pack_pathFollowing_mission_packet(task), connectPort));
                                t.Start();
                            }
                        }
                    }
                    else if (comboBox_connectOption.Text.Contains("COM"))
                    {
                        foreach (Waypoints task in waypoints)
                        {
                            if (task.Type == WaypointMissionMethod.guide_waypoints)
                            {
                                int select_index = existing_UAVs.IndexOf(task.UAV_ID);
                                var t = new Thread(() => XBee.SendData(G2U_points[task.UAV_ID], Buffers[select_index].pack_pathFollowing_mission_packet(task)));
                                t.Start();
                            }
                        }
                    }
                    break;
                case "SEAD mission":
                    if (!String.IsNullOrEmpty(skinComboBox_SEAD.Text))
                    {
                        // 存任務開始時間
                        timeline_sql = $@"insert into `timeline` (`Mission`, `Status`, `UAV Timestamp`, `GCS Timestamp`, `Datatime`) 
                                                    values('{Message_ID.SEAD_mission}', '{skinComboBox_SEAD.Text} start', {timestamp}, {timestamp}, '{dateTime}');";
                        cmd = new MySqlCommand(timeline_sql, timelist_conn);
                        index = cmd.ExecuteNonQuery();

                        skinButton_goToInitPos.Enabled = false;
                        var mission = Mission_setting.SEAD_mission[skinComboBox_SEAD.Text];
                        // 發布命令
                        if (comboBox_connectOption.Text == "UDP")
                        {
                            foreach (var UAV in mission.UAV_set)
                            {
                                int select_index = existing_UAVs.IndexOf(UAV.ID);
                                client.SendTo(Buffers[select_index].pack_SEADmission_packet(mission), connectPort);
                            }
                        }
                        else if (comboBox_connectOption.Text.Contains("COM"))
                        {
                            foreach (var UAV in mission.UAV_set)
                            {
                                int select_index = existing_UAVs.IndexOf(UAV.ID);
                                XBee.SendData(G2U_points[UAV.ID], Buffers[select_index].pack_SEADmission_packet(mission));
                            }
                        }
                    }
                    break;
            }
        }

        private void gMapControl_mission_DoubleClick(object sender, EventArgs e)
        {
            // 查看無人機規劃之任務 (雙點擊無人機圖像)
            if (currentMarker.ToolTipText.Contains("UAV"))
            {
                var uav_id = Int32.Parse(currentMarker.ToolTipText.Remove(0, 3));
                comboBox_missionUAV.Text = currentMarker.ToolTipText;
                var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                comboBox_missionTypeMission.Text = string.Empty;
                comboBox_missionMethod.Text = Mission_setting.WaypointMissionMethod_name.FirstOrDefault(m => m.Value == matches.Type).Key;

                dataGridView_mission.Rows.Clear();
                if (matches.waypoints.Count() > 0)
                {
                    dataGridView_mission.Rows.Add(matches.waypoints.Count());
                    for (int i = 0; i < matches.waypoints.Count(); i++)
                    {
                        dataGridView_mission.Rows[i].Cells["order"].Value = i + 1;
                        dataGridView_mission.Rows[i].Cells["E"].Value = matches.waypoints[i][0];
                        dataGridView_mission.Rows[i].Cells["N"].Value = matches.waypoints[i][1];
                        dataGridView_mission.Rows[i].Cells["U"].Value = matches.waypoints[i][2];
                        try { dataGridView_mission.Rows[i].Cells["heading"].Value = matches.waypoints[i][3]; }
                        catch { }
                        dataGridView_mission.Rows[i].Cells["up"].Value = "▲";
                        dataGridView_mission.Rows[i].Cells["down"].Value = "▼";
                        dataGridView_mission.Rows[i].Cells["delete"].Value = "X";
                    }
                    dataGridView_mission.AutoResizeColumns();
                }
            }
        }

        private void linkLabel_missionConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int uav_id = Int32.Parse(comboBox_missionUAV.Text.Remove(0, 3));
                var matches = waypoints.Find(p => p.UAV_ID == uav_id && p.Type != WaypointMissionMethod.guide_waypoint);
                if (matches != null)
                {
                    Form ControlForm = new waypointsMissionConfig(matches);
                    ControlForm.ShowDialog();
                }
            }
            catch { }
        }

        private void button_takeoff_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(checkBoxComboBox_UAVselect.Text) || checkBox_allUAVselect.Checked)
            {
                if (comboBox_connectOption.Text == "UDP")
                {
                    if (checkBox_allUAVselect.Checked)
                    {
                        int takeoff_height = 10;
                        foreach (Packets uav in Buffers)
                        {
                            var packet = uav.pack_takeoff_packet(takeoff_height);
                            var t = new Thread(() => client.SendTo(packet, connectPort));
                            t.Start();
                            takeoff_height += 5;
                        }
                    }
                    else
                    {
                        foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                        {
                            if (uav.Checked)
                            {
                                var select_index = existing_UAVs.IndexOf(Int32.Parse(uav.Text.Remove(0, 3)));
                                var packet = Buffers[select_index].pack_takeoff_packet((int)colorSlider_takeoff.Value);
                                var t = new Thread(() => client.SendTo(packet, connectPort));
                                t.Start();
                            }
                        }
                    }
                }
                else
                {
                    if (checkBox_allUAVselect.Checked)
                    {
                        int takeoff_height = 5;
                        foreach (Packets uav in Buffers)
                        {
                            var packet = uav.pack_takeoff_packet(takeoff_height);
                            var t = new Thread(() => XBee.SendData(G2U_points[uav.UAV_ID], packet));
                            t.Start();
                            takeoff_height += 5;
                        }
                    }
                    else
                    {
                        foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                        {
                            if (uav.Checked)
                            {
                                int uav_id = Int32.Parse(uav.Text.Remove(0, 3));
                                int select_index = existing_UAVs.IndexOf(uav_id);
                                var packet = Buffers[select_index].pack_takeoff_packet((int)colorSlider_takeoff.Value);
                                var t = new Thread(() => XBee.SendData(G2U_points[uav_id], packet));
                                t.Start();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fil in the UAV ༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void comboBox_missionTypeMission_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { comboBox_missionMethod.Text = Mission_setting.WaypointMissionMethod_name.First(p => p.Value == Mission_setting.path_mission[comboBox_missionTypeMission.Text].Type).Key; }
            catch { comboBox_missionMethod.Text = string.Empty; }
        }

        public void commandsTransmit(string command)
        {
            if (comboBox_connectOption.Text == "UDP")
            {
                if (checkBox_allUAVselect.Checked)
                {
                    foreach (Packets uav in Buffers)
                    {
                        var packet = uav.pack_command_packet(command);
                        var t = new Thread(() => client.SendTo(packet, connectPort));
                        t.Start();
                    }
                }
                else
                {
                    foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                    {
                        if (uav.Checked)
                        {
                            var select_index = existing_UAVs.IndexOf(Int32.Parse(uav.Text.Remove(0, 3)));
                            var packet = Buffers[select_index].pack_command_packet(command);
                            var t = new Thread(() => client.SendTo(packet, connectPort));
                            t.Start();
                        }
                    }
                }
            }
            else
            {
                if (checkBox_allUAVselect.Checked)
                {
                    foreach (Packets uav in Buffers)
                    {
                        var packet = uav.pack_command_packet(command);
                        var t = new Thread(() => XBee.SendData(G2U_points[uav.UAV_ID], packet));
                        t.Start();
                    }
                }
                else
                {
                    foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                    {
                        if (uav.Checked)
                        {
                            int uav_id = Int32.Parse(uav.Text.Remove(0, 3));
                            int select_index = existing_UAVs.IndexOf(uav_id);
                            var packet = Buffers[select_index].pack_command_packet(command);
                            var t = new Thread(() => XBee.SendData(G2U_points[uav_id], packet));
                            t.Start();
                        }
                    }
                }
            }
        }

        private void skinButton_RTL_Click(object sender, EventArgs e)
        {
            commandsTransmit(Mode.RTL.ToString());
        }

        private void skinButton_HOLD_Click(object sender, EventArgs e)
        {
            commandsTransmit(Mode.POSHOLD.ToString());
        }

        private void skinButton_loiter_Click(object sender, EventArgs e)
        {
            commandsTransmit(Mode.Loiter.ToString());
        }

        private void gMapControl_main_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            if (item.ToolTipText != null)
            {
                if (item.ToolTipText.Contains("UAV") && e.Button == MouseButtons.Left)
                {
                    foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                    {
                        if (uav.Text == item.ToolTipText)
                        {
                            uav.Checked = true;
                        }
                        else { uav.Checked = false; }
                    }
                    comboBox_guideWP.Text = item.ToolTipText;
                }
            }
        }

        private void skinButton_seadMissionConfirm_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(skinComboBox_SEAD.Text))
            {
                gMapControl_SEAD.DragButton = MouseButtons.Left;
                gMapControl_SEAD.MapProvider = GMapProviders.GoogleMap;
                gMapControl_SEAD.Position = coordinate.mapCenter;
                gMapControl_SEAD.MaxZoom = 24;
                gMapControl_SEAD.MinZoom = 3;
                gMapControl_SEAD.Zoom = 19;
                gMapControl_SEAD.ShowCenter = false;
                gMapControl_SEAD.Manager.Mode = AccessMode.ServerAndCache;
                dataGridView_seadAgents.ForeColor = Color.Black;
                dataGridView_seadTargets.ForeColor = Color.Black;
                // UAVs
                dataGridView_seadAgents.Rows.Clear();
                gMapControl_SEAD.Overlays.Clear();
                gMapControl_SEAD.Overlays.Add(new GMapOverlay("SEAD mission"));
                int i;
                if (Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].UAV_set.Count() != 0)
                {
                    dataGridView_seadAgents.Rows.Add(Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].UAV_set.Count());
                    i = 0;
                    foreach (var uav in Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].UAV_set)
                    {
                        dataGridView_seadAgents.Rows[i].Cells["UAV_ID"].Value = uav.ID;
                        dataGridView_seadAgents.Rows[i].Cells["type"].Value = uav.Type;
                        dataGridView_seadAgents.Rows[i].Cells["cruise_speed"].Value = uav.cruise_speed;
                        dataGridView_seadAgents.Rows[i].Cells["Rmin"].Value = uav.Rmin;
                        dataGridView_seadAgents.Rows[i].Cells["initial_pos"].Value = $"({uav.initial_pos[0]},{uav.initial_pos[1]})";
                        dataGridView_seadAgents.Rows[i].Cells["base_pos"].Value = $"({uav.base_pos[0]},{uav.base_pos[1]})";
                        var lla = coordinate.enu2llh(uav.initial_pos[0], uav.initial_pos[1], 0);
                        gMapControl_SEAD.Overlays[0].Markers.Add(Planes.AddHelipad(lla[0], lla[1], UAV_ID_text(uav.ID), uav.initial_pos[2], new SolidBrush(color_of_uavs[uav.ID - 1])));
                        i++;
                    }
                    dataGridView_seadAgents.AutoResizeColumns();
                }

                // targets
                int targets_num = Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].Target_set.Count() + Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].unknownTarget_set.Count();
                dataGridView_seadTargets.Rows.Clear();
                i = 0;
                if (targets_num != 0)
                {
                    dataGridView_seadTargets.Rows.Add(targets_num);
                    foreach (var T in Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].Target_set)
                    {
                        dataGridView_seadTargets.Rows[i].Cells["Target_ID"].Value = i + 1;
                        dataGridView_seadTargets.Rows[i].Cells["coordinates"].Value = $"({T[0]},{T[1]})";
                        dataGridView_seadTargets.Rows[i].Cells["known_target"].Value = "Known";
                        var lla = coordinate.enu2llh(T[0], T[1], 0);
                        gMapControl_SEAD.Overlays[0].Markers.Add(Planes.AddWaypoint(lla[0], lla[1], i + 1, GMarkerGoogleType.yellow));
                        i++;
                    }
                    foreach (var T in Mission_setting.SEAD_mission[skinComboBox_SEAD.Text].unknownTarget_set)
                    {
                        dataGridView_seadTargets.Rows[i].Cells["Target_ID"].Value = i + 1;
                        dataGridView_seadTargets.Rows[i].Cells["coordinates"].Value = $"({T[0]},{T[1]})";
                        dataGridView_seadTargets.Rows[i].Cells["known_target"].Value = "Unknown";
                        var lla = coordinate.enu2llh(T[0], T[1], 0);
                        gMapControl_SEAD.Overlays[0].Markers.Add(Planes.AddWaypoint(lla[0], lla[1], i + 1, GMarkerGoogleType.blue));
                        i++;
                    }
                    dataGridView_seadTargets.AutoResizeColumns();
                }
                textBox_SEADu2u.Text = "2";
                textBox_SEADpopSize.Text = "100";
                if (!skinComboBox_PubMission.Items.Contains("SEAD mission"))
                {
                    skinComboBox_PubMission.Items.Add("SEAD mission");
                }
            }
            else
            {
                MessageBox.Show("Please select a mission.");
            }
        }

        private void skinButton_goToInitPos_Click(object sender, EventArgs e)
        {
            var mission = Mission_setting.SEAD_mission[skinComboBox_SEAD.Text];
            if (comboBox_connectOption.Text == "UDP")
            {
                foreach (var UAV in mission.UAV_set)
                {
                    int select_index = existing_UAVs.IndexOf(UAV.ID);
                    var t = new Thread(() => client.SendTo(Buffers[select_index].pack_guide_WPwithHeading_packet(UAV.initial_pos[0], UAV.initial_pos[1], 0, UAV.initial_pos[2], 5), connectPort));
                    t.Start();
                }
            }
            else if (comboBox_connectOption.Text.Contains("COM"))
            {
                foreach (var UAV in mission.UAV_set)
                {
                    int select_index = existing_UAVs.IndexOf(UAV.ID);
                    var t = new Thread(() => XBee.SendData(G2U_points[UAV.ID], Buffers[select_index].pack_guide_WPwithHeading_packet(UAV.initial_pos[0], UAV.initial_pos[1], 0, UAV.initial_pos[2], 5)));
                    t.Start();
                }
            }
        }

        private void skinButton_land_Click(object sender, EventArgs e)
        {
            commandsTransmit(Mode.Land.ToString());
        }

        private void skinButton_arm_Click(object sender, EventArgs e)
        {
            commandsTransmit("Arm");
        }

        private void skinButton_disarm_Click(object sender, EventArgs e)
        {
            commandsTransmit("Disarm");
        }

        private void button_tineRecalibrate_Click(object sender, EventArgs e)
        {
            if (comboBox_connectOption.Text == "UDP")
            {
                foreach (Packets uav in Buffers)
                {
                    client.SendTo(uav.pack_time_synchronize_request_packet(), connectPort);
                }
            }
            else if (comboBox_connectOption.Text.Contains("COM"))
            {
                foreach (Packets uav in Buffers)
                {
                    XBee.SendData(G2U_points[uav.UAV_ID], uav.pack_time_synchronize_request_packet());
                }
            }
        }

        private void pulseButton_cancel_Click(object sender, EventArgs e)
        {
            foreach (GMapOverlay overlay in waypoints_pin)
            {
                overlay.Clear();
            }
            skinComboBox_PubMission.Text = string.Empty;
            skinButton_goToInitPos.Enabled = false;
        }

        private void pulseButton_clear_Click(object sender, EventArgs e)
        {
            foreach (List<PointLatLng> route in routesBuffer)
            {
                route.Clear();
            }
        }

        private void skinButton_pubWP_Click(object sender, EventArgs e)
        {
            if (waypoints.Any(p => p.Type == WaypointMissionMethod.guide_waypoint))
            {
                waypoints.RemoveAll(p => p.Type != WaypointMissionMethod.guide_waypoint);
                if (comboBox_connectOption.Text == "UDP")
                {
                    foreach (Waypoints wp in waypoints)
                    {
                        int select_index = existing_UAVs.IndexOf(wp.UAV_ID);
                        if (wp.waypoints[0].Count() == 3)
                        {
                            var t = new Thread(() => client.SendTo(Buffers[select_index].pack_guide_mission_packet(wp.waypoints[0][0],
                            wp.waypoints[0][1], wp.waypoints[0][2], wp.waypointRadius), connectPort));
                            t.Start();
                        }
                        else
                        {
                            var t = new Thread(() => client.SendTo(Buffers[select_index].pack_guide_WPwithHeading_packet(wp.waypoints[0][0],
                            wp.waypoints[0][1], wp.waypoints[0][2], wp.waypoints[0][3], wp.waypointRadius), connectPort));
                            t.Start();
                        }
                    }
                }
                else
                {
                    foreach (Waypoints wp in waypoints)
                    {
                        int select_index = existing_UAVs.IndexOf(wp.UAV_ID);
                        if (wp.waypoints[0].Count() == 3)
                        {
                            var t = new Thread(() => XBee.SendData(G2U_points[wp.UAV_ID], Buffers[select_index].pack_guide_mission_packet(
                            wp.waypoints[0][0], wp.waypoints[0][1], wp.waypoints[0][2], wp.waypointRadius)));
                            t.Start();
                        }
                        else
                        {
                            var t = new Thread(() => XBee.SendData(G2U_points[wp.UAV_ID], Buffers[select_index].pack_guide_WPwithHeading_packet(
                            wp.waypoints[0][0], wp.waypoints[0][1], wp.waypoints[0][2], wp.waypoints[0][3], wp.waypointRadius)));
                            t.Start();
                        }    
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill in UAV.༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void skinButton_clearWPs_Click(object sender, EventArgs e)
        {
            waypoints.RemoveAll(p => p.Type == WaypointMissionMethod.guide_waypoint);
            foreach (GMapOverlay overlay in waypoints_pin)
            {
                overlay.Clear();
            }
            skinButton_pubWP.Enabled = false;
            skinButton_clearWPs.Enabled = false;
            textBox_wpE.Text = string.Empty;
            textBox_wpN.Text = string.Empty;
            textBox_wpU.Text = string.Empty;
            if (!string.IsNullOrEmpty(comboBox_guideWP.Text))
            {
                comboBox_guideWP.Text = string.Empty;
            }
            textBox_WPguided.Text = string.Empty;
            foreach (Waypoints wp in waypoints)
            {
                if (wp.Type == WaypointMissionMethod.guide_waypoint)
                {
                    textBox_WPguided.AppendText($"UAV{wp.UAV_ID}: " +
                        $"[{wp.waypoints[0][0]}, {wp.waypoints[0][1]}, {wp.waypoints[0][2]}]" + Environment.NewLine);
                }
            }
        }

        private void skinButton_abort_Click(object sender, EventArgs e)
        {
            if (comboBox_connectOption.Text == "UDP")
            {
                if (checkBox_allUAVselect.Checked)
                {
                    foreach (Packets uav in Buffers)
                    {
                        var packet = uav.pack_missionAbort_cmd();
                        var t = new Thread(() => client.SendTo(packet, connectPort));
                        t.Start();
                    }
                }
                else
                {
                    foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                    {
                        if (uav.Checked)
                        {
                            var select_index = existing_UAVs.IndexOf(Int32.Parse(uav.Text.Remove(0, 3)));
                            var packet = Buffers[select_index].pack_missionAbort_cmd();
                            var t = new Thread(() => client.SendTo(packet, connectPort));
                            t.Start();
                        }
                    }
                }
            }
            else
            {
                if (checkBox_allUAVselect.Checked)
                {
                    foreach (Packets uav in Buffers)
                    {
                        var packet = uav.pack_missionAbort_cmd();
                        var t = new Thread(() => XBee.SendData(G2U_points[uav.UAV_ID], packet));
                        t.Start();
                    }
                }
                else
                {
                    foreach (var uav in checkBoxComboBox_UAVselect.CheckBoxItems)
                    {
                        if (uav.Checked)
                        {
                            int uav_id = Int32.Parse(uav.Text.Remove(0, 3));
                            int select_index = existing_UAVs.IndexOf(uav_id);
                            var packet = Buffers[select_index].pack_missionAbort_cmd();
                            var t = new Thread(() => XBee.SendData(G2U_points[uav_id], packet));
                            t.Start();
                        }
                    }
                }
            }
        }

        private void button_clearDataGrid_Click(object sender, EventArgs e)
        {
            // 初始化儲存空間
            Buffers.Clear();
            existing_UAVs.Clear();
            // 初始化相關控件
            checkBoxComboBox_UAVselect.Items.Clear();
            comboBox_mapCenter.Items.Clear();
            comboBox_mapCenter.Items.AddRange(Origin.Keys.ToArray());
            // 初始化地圖
            for (int i = 0; i < default_UAVnumbers; i++)
            {
                markers_main[i].Clear();
                routesBuffer[i].Clear();
                waypoints_pin[i].Clear();
                waypoints.Clear();
            }
        }

        private void skinButton_startPlanVRP_Click(object sender, EventArgs e)
        {
            if (Buffers.Any())
            {
                // 開啟地圖
                gMapControl_VRP.DragButton = MouseButtons.Left;
                gMapControl_VRP.MapProvider = GMapProviders.GoogleMap;
                gMapControl_VRP.Position = coordinate.mapCenter;
                gMapControl_VRP.MaxZoom = 24;
                gMapControl_VRP.MinZoom = 3;
                gMapControl_VRP.Zoom = 19;
                gMapControl_VRP.ShowCenter = false;
                gMapControl_VRP.Manager.Mode = AccessMode.ServerAndCache;
                gMapControl_VRP.Overlays.Clear();
                // 加入無人機
                richTextBox_VRP.SelectionColor = Color.Black;
                richTextBox_VRP.AppendText($"initiate ... {Buffers.Count()} UAVs are avialable." + Environment.NewLine);
                dataGridView_VRPagents.Rows.Clear();
                dataGridView_VRPagents.Rows.Add(Buffers.Count());
                int index = 0;
                foreach (var uav in Buffers)
                {
                    gMapControl_VRP.Overlays.Add(new GMapOverlay($"VRP_{UAV_ID_text(uav.UAV_ID)}"));
                    var overlay = gMapControl_VRP.Overlays.First(p => p.Id == $"VRP_{UAV_ID_text(uav.UAV_ID)}");
                    dataGridView_VRPagents.Rows[index].Cells["ID_uav_VRP"].Value = uav.UAV_ID;
                    dataGridView_VRPagents.Rows[index].Cells["East_uav_VRP"].Value = Math.Round(uav.E, 3, MidpointRounding.AwayFromZero);
                    dataGridView_VRPagents.Rows[index].Cells["North_uav_VRP"].Value = Math.Round(uav.N, 3, MidpointRounding.AwayFromZero);
                    index++;
                    richTextBox_VRP.SelectionColor = Color.Blue;
                    richTextBox_VRP.AppendText($"UAV{uav.UAV_ID} ");
                    richTextBox_VRP.SelectionColor = Color.Black;
                    richTextBox_VRP.AppendText($"at ({uav.E}, {uav.N}) m" + Environment.NewLine);
                    switch (uav.Frame_type)
                    {
                        case FrameType.Quad:
                            overlay.Markers.Add(Planes.AddQuadrotor(uav.Lat, uav.Lng, UAV_ID_text(uav.UAV_ID), uav.Yaw,
                                        new SolidBrush(color_of_uavs[uav.UAV_ID - 1])));
                            break;
                        case FrameType.Fixed_wing:
                            overlay.Markers.Add(Planes.AddPlane(uav.Lat, uav.Lng, UAV_ID_text(uav.UAV_ID), uav.Yaw,
                                        new SolidBrush(color_of_uavs[uav.UAV_ID - 1])));
                            break;
                    }
                }
                dataGridView_VRPagents.AutoResizeColumns();
                // 清除表格
                dataGridView_VRPtarget.Rows.Clear();
                dataGridView_VRPtarget.ForeColor = Color.Black;
                dataGridView_VRPagents.ForeColor = Color.Black;
                // 開啟控鍵
                dataGridView_VRPtarget.Enabled = true;
                gMapControl_VRP.Enabled = true;
                skinButton_optimizeVRP.Enabled = true;
                skinButton_outputVRP.Enabled = true;
                richTextBox_VRP.AppendText($"You can start assigning targets." + Environment.NewLine);
            }
            else
            {
                MessageBox.Show("No existing UAV ༼つ ͡◕_ ͡◕ ༽つ");
            }
        }

        private void gMapControl_VRP_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                PointLatLng pin = gMapControl_VRP.FromLocalToLatLng(e.X, e.Y);
                var enu = coordinate.llh2enu(pin.Lat, pin.Lng, 0);
                if (!gMapControl_VRP.Overlays.Contains(new GMapOverlay($"target set")))
                {
                    gMapControl_VRP.Overlays.Add(new GMapOverlay($"target set"));
                }
                var overlay = gMapControl_VRP.Overlays.First(p => p.Id == "target set");
                // 加入航點至地圖
                overlay.Markers.Add(Planes.AddWaypoint(pin.Lat, pin.Lng, overlay.Markers.Count + 1, GMarkerGoogleType.yellow));
                // 更新targets表格
                dataGridView_VRPtarget.Rows.Add(1);
                int index = dataGridView_VRPtarget.RowCount - 1;
                dataGridView_VRPtarget.Rows[index].Cells["target_ID_VRP"].Value = index + 1;
                dataGridView_VRPtarget.Rows[index].Cells["East_VRP"].Value = Math.Round(enu[0], 3, MidpointRounding.AwayFromZero);
                dataGridView_VRPtarget.Rows[index].Cells["North_VRP"].Value = Math.Round(enu[1], 3, MidpointRounding.AwayFromZero);
                dataGridView_VRPtarget.Rows[index].Cells["delete_VRP"].Value = "X";
                dataGridView_VRPtarget.AutoResizeColumns();
            }
        }

        private void dataGridView_VRPtarget_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_VRPtarget.Columns[e.ColumnIndex].Name == "delete_VRP")
            {
                dataGridView_VRPtarget.Rows.Remove(dataGridView_VRPtarget.Rows[e.RowIndex]);
                for (int i = e.RowIndex; i < dataGridView_VRPtarget.RowCount; i++)
                {
                    dataGridView_VRPtarget.Rows[i].Cells["target_ID_VRP"].Value = i + 1;
                }
                var overlay = gMapControl_VRP.Overlays.First(p => p.Id == "target set");
                overlay.Markers.RemoveAt(e.RowIndex);
                var marker_list = overlay.Markers.ToList();
                overlay.Markers.Clear();
                for (int i = 0; i < dataGridView_VRPtarget.RowCount; i++)
                {
                    var pin = marker_list[i].Position;
                    overlay.Markers.Add(Planes.AddWaypoint(pin.Lat, pin.Lng, i + 1, GMarkerGoogleType.yellow));
                }
            }
        }

        private void skinButton_optimizeVRP_Click(object sender, EventArgs e)
        {
            if (dataGridView_VRPtarget.RowCount == 0)
            {
                MessageBox.Show("No targets to assign ...");
            }
            else
            {
                BackgroundWorker bgw = new BackgroundWorker();
                bgw.DoWork += VRP_solver;
                bgw.RunWorkerAsync();
            }
        }

        void VRP_solver(object sender, EventArgs e)
        {
            var targets_locations = new List<double[]>() { };
            var UAV_set = new List<agents>() { };
            this.Invoke(new Action(() =>
            {
                for (int i = 0; i < dataGridView_VRPtarget.RowCount; i++)
                {
                    var target_location = new double[] { (double)dataGridView_VRPtarget.Rows[i].Cells["East_VRP"].Value,
                    (double)dataGridView_VRPtarget.Rows[i].Cells["North_VRP"].Value };
                    targets_locations.Add(target_location);
                }
                for (int i = 0; i < dataGridView_VRPagents.RowCount; i++)
                {
                    var uav = new agents((int)dataGridView_VRPagents.Rows[i].Cells["ID_uav_VRP"].Value,
                        new double[] { (double)dataGridView_VRPagents.Rows[i].Cells["East_uav_VRP"].Value,
                        (double)dataGridView_VRPagents.Rows[i].Cells["North_uav_VRP"].Value});
                    UAV_set.Add(uav);
                }
            }));
            // run GA
            var ga = new GA_VRP(targets_locations, UAV_set);
            var solution = ga.main_program(1000);
            var routes = new List<string>() { };
            var gmap_routes = new List<List<PointLatLng>>();
            // plot result on map and update the Waypoints list
            waypoints.RemoveAll(p => p.Type == WaypointMissionMethod.guide_waypoints);
            this.Invoke(new Action(() =>
            {
                richTextBox_VRP.SelectionColor = Color.Black;
                richTextBox_VRP.AppendText(Environment.NewLine);
                richTextBox_VRP.AppendText($"=> routes: " + Environment.NewLine);
                for (int i = 0; i < UAV_set.Count(); i++)
                {
                    routes.Add("");
                    var llh = coordinate.enu2llh(UAV_set[i].initial_pos[0], UAV_set[i].initial_pos[1], 0);
                    gmap_routes.Add(new List<PointLatLng>() { new PointLatLng(llh[0], llh[1]), new PointLatLng(llh[0], llh[1]) });
                    waypoints.Add(new Waypoints(UAV_set[i].ID, WaypointMissionMethod.guide_waypoints));
                }
                Waypoints targets;
                for (int i = 0; i < solution.genes[0].Count(); i++)
                {
                    var assign_uav_index = UAV_set.IndexOf(UAV_set.First(u => u.ID == solution.genes[1][i]));
                    routes[assign_uav_index] += $" → {solution.genes[0][i]}";
                    var llh = coordinate.enu2llh(targets_locations[solution.genes[0][i] - 1][0],
                        targets_locations[solution.genes[0][i] - 1][1], 0);
                    gmap_routes[assign_uav_index].Insert(1, new PointLatLng(llh[0], llh[1]));

                    targets = waypoints.First(p => p.UAV_ID == solution.genes[1][i] && p.Type == WaypointMissionMethod.guide_waypoints);
                    targets.waypoints.Add(new double[] { targets_locations[solution.genes[0][i] - 1][0],
                        targets_locations[solution.genes[0][i] - 1][1], 0});
                    targets.targetID_List.Add(solution.genes[0][i]);
                }
                for (int i = 0; i < UAV_set.Count(); i++)
                {
                    targets = waypoints.First(p => p.UAV_ID == solution.genes[1][i] && p.Type == WaypointMissionMethod.guide_waypoints);
                    targets.waypoints.Add(new double[] { UAV_set[i].initial_pos[0], UAV_set[i].initial_pos[1], 0 });

                    var overlay = gMapControl_VRP.Overlays.First(p => p.Id == $"VRP_{UAV_ID_text(UAV_set[i].ID)}");
                    overlay.Routes.Clear();
                    GMapRoute ref_route = new GMapRoute(gmap_routes[i], $"VRP route UAV{UAV_set[i].ID}")
                    {
                        Stroke = new Pen(color_of_uavs[UAV_set[i].ID - 1], 3)
                    };
                    overlay.Routes.Add(ref_route);
                    richTextBox_VRP.SelectionColor = Color.Blue;
                    richTextBox_VRP.AppendText($"UAV{UAV_set[i].ID}");
                    richTextBox_VRP.SelectionColor = Color.Black;
                    richTextBox_VRP.AppendText(routes[i] + Environment.NewLine);
                }
                waypoints.RemoveAll(p => p.Type == WaypointMissionMethod.guide_waypoints && p.waypoints.Count() <= 1);
                richTextBox_VRP.AppendText(Environment.NewLine);
            }));
        }

        private void skinButton_outputVRP_Click(object sender, EventArgs e)
        {
            if (!skinComboBox_PubMission.Items.Contains("VRP mission"))
            {
                skinComboBox_PubMission.Items.Add("VRP mission");
            }
            dataGridView_VRPtarget.Enabled = false;
            gMapControl_VRP.Enabled = false;
            skinButton_optimizeVRP.Enabled = false;
            skinButton_outputVRP.Enabled = false;
            richTextBox_VRP.AppendText($"VRP mission is ready." + Environment.NewLine);
            skinButton_VRPadjust.Enabled = true;
        }

        private void button_originConfirm_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(comboBox_origin.Text))
            {
                DialogResult confirm = MessageBox.Show(this, "確定更改原點？", "原點更改確認٩(✿∂‿∂✿)۶", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    var originName = comboBox_origin.Text;
                    coordinate = Origin[originName];
                    if (comboBox_connectOption.Text == "UDP")
                    {
                        foreach (var uav in Buffers)
                        {
                            uav.Coordinate = coordinate;
                            var t = new Thread(() => client.SendTo(uav.pack_origin_correction_packet(originName), connectPort));
                            t.Start();
                        }
                    }
                    else
                    {
                        foreach (var uav in Buffers)
                        {
                            uav.Coordinate = coordinate;
                            var t = new Thread(() => XBee.SendData(G2U_points[uav.UAV_ID], uav.pack_origin_correction_packet(originName)));
                            t.Start();
                        }
                    }
                }
                try { comboBox_origin.Text = Origin.FirstOrDefault(o => o.Value == coordinate).Key; }
                catch { }
            }
        }

        private void skinButton_VRPadjust_Click(object sender, EventArgs e)
        {
            dataGridView_VRPtarget.Enabled = true;
            gMapControl_VRP.Enabled = true;
            skinButton_optimizeVRP.Enabled = true;
            skinButton_outputVRP.Enabled = true;
            richTextBox_VRP.AppendText($"VRP mission is ready." + Environment.NewLine);
            skinButton_VRPadjust.Enabled = false;
        }

        private void comboBox_guideWP_DropDown(object sender, EventArgs e)
        {
            comboBox_guideWP.Items.Clear();
            foreach (int uav_id in existing_UAVs)
            {
                comboBox_guideWP.Items.Add(UAV_ID_text(uav_id));
            }
        }
    }
}
