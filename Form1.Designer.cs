
namespace GCS_5895
{
    partial class GCS_5895
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        [System.Obsolete]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GCS_5895));
            this.tabControl_main = new CCWin.SkinControl.SkinTabControl();
            this.tabPage_GCS = new CCWin.SkinControl.SkinTabPage();
            this.button_test = new System.Windows.Forms.Button();
            this.button_Connect = new System.Windows.Forms.Button();
            this.gMapControl_main = new GMap.NET.WindowsForms.GMapControl();
            this.comboBox_mapCenter = new System.Windows.Forms.ComboBox();
            this.comboBox_connectOption = new System.Windows.Forms.ComboBox();
            this.comboBox_PortOrBaud = new System.Windows.Forms.ComboBox();
            this.comboBox_routeDisplay = new System.Windows.Forms.ComboBox();
            this.skinGroupBox4 = new CCWin.SkinControl.SkinGroupBox();
            this.button_clearDataGrid = new System.Windows.Forms.Button();
            this.button_sortDataGrid = new System.Windows.Forms.Button();
            this.dataGridView_flghtData = new System.Windows.Forms.DataGridView();
            this.skinPanel1 = new CCWin.SkinControl.SkinPanel();
            this.skinGroupBox2 = new CCWin.SkinControl.SkinGroupBox();
            this.textBox_info = new System.Windows.Forms.RichTextBox();
            this.tabControl_action = new System.Windows.Forms.TabControl();
            this.tabPage_command = new System.Windows.Forms.TabPage();
            this.skinGroupBox7 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton_abort = new CCWin.SkinControl.SkinButton();
            this.skinButton_disarm = new CCWin.SkinControl.SkinButton();
            this.skinButton_arm = new CCWin.SkinControl.SkinButton();
            this.skinButton_land = new CCWin.SkinControl.SkinButton();
            this.skinButton_loiter = new CCWin.SkinControl.SkinButton();
            this.skinButton_HOLD = new CCWin.SkinControl.SkinButton();
            this.skinButton_RTL = new CCWin.SkinControl.SkinButton();
            this.comboBox_Command = new System.Windows.Forms.ComboBox();
            this.colorSlider_takeoff = new ColorSlider.ColorSlider();
            this.button_takeoff = new System.Windows.Forms.Button();
            this.button_Publish = new System.Windows.Forms.Button();
            this.skinGroupBox6 = new CCWin.SkinControl.SkinGroupBox();
            this.checkBox_allUAVselect = new System.Windows.Forms.CheckBox();
            this.checkBoxComboBox_UAVselect = new PresentationControls.CheckBoxComboBox();
            this.skinPictureBox2 = new CCWin.SkinControl.SkinPictureBox();
            this.tabPage_guide = new System.Windows.Forms.TabPage();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton_pubWP = new CCWin.SkinControl.SkinButton();
            this.skinButton_clearWPs = new CCWin.SkinControl.SkinButton();
            this.Plan = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_wpYaw = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_guideClear = new System.Windows.Forms.Button();
            this.button_WPconfirm = new System.Windows.Forms.Button();
            this.textBox_wpE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_wpN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_wpU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_guideWP = new System.Windows.Forms.ComboBox();
            this.textBox_WPguided = new System.Windows.Forms.TextBox();
            this.tabPage_missionStart = new System.Windows.Forms.TabPage();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinGroupBox11 = new CCWin.SkinControl.SkinGroupBox();
            this.pulseButton_clear = new PulseButton.PulseButton();
            this.pulseButton_cancel = new PulseButton.PulseButton();
            this.skinButton_missionStart = new CCWin.SkinControl.SkinButton();
            this.skinButton_goToInitPos = new CCWin.SkinControl.SkinButton();
            this.skinComboBox_PubMission = new CCWin.SkinControl.SkinComboBox();
            this.tabPage_setting = new System.Windows.Forms.TabPage();
            this.skinGroupBox15 = new CCWin.SkinControl.SkinGroupBox();
            this.comboBox_origin = new System.Windows.Forms.ComboBox();
            this.button_originConfirm = new System.Windows.Forms.Button();
            this.skinGroupBox9 = new CCWin.SkinControl.SkinGroupBox();
            this.button_tineRecalibrate = new System.Windows.Forms.Button();
            this.skinGroupBox5 = new CCWin.SkinControl.SkinGroupBox();
            this.comboBox_u2gFreq = new System.Windows.Forms.ComboBox();
            this.button_FreqConfirm = new System.Windows.Forms.Button();
            this.tabPage_FlightPlan = new CCWin.SkinControl.SkinTabPage();
            this.tabControl_mission = new System.Windows.Forms.TabControl();
            this.tabPage_WPs = new System.Windows.Forms.TabPage();
            this.skinGroupBox10 = new CCWin.SkinControl.SkinGroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_missionHeading = new System.Windows.Forms.TextBox();
            this.button_startMission = new System.Windows.Forms.Button();
            this.skinButton_adjustMission = new CCWin.SkinControl.SkinButton();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_missionUAV = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_missionTypeMission = new System.Windows.Forms.ComboBox();
            this.textBox_missionHeight = new System.Windows.Forms.TextBox();
            this.label_HorYaw = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_missionMethod = new System.Windows.Forms.ComboBox();
            this.linkLabel_missionConfig = new System.Windows.Forms.LinkLabel();
            this.button_missionConfirm = new System.Windows.Forms.Button();
            this.button_missionCancel = new System.Windows.Forms.Button();
            this.button_missionClear = new System.Windows.Forms.Button();
            this.button_missionPrepare = new System.Windows.Forms.Button();
            this.skinGroupBox3 = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridView_mission = new System.Windows.Forms.DataGridView();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.N = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.U = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heading = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.down = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gMapControl_WPs = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage_VRP = new System.Windows.Forms.TabPage();
            this.skinGroupBox13 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton_VRPadjust = new CCWin.SkinControl.SkinButton();
            this.richTextBox_VRP = new System.Windows.Forms.RichTextBox();
            this.skinButton_outputVRP = new CCWin.SkinControl.SkinButton();
            this.skinButton_optimizeVRP = new CCWin.SkinControl.SkinButton();
            this.skinButton_startPlanVRP = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox12 = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridView_VRPtarget = new System.Windows.Forms.DataGridView();
            this.target_ID_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.East_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.North_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete_VRP = new System.Windows.Forms.DataGridViewButtonColumn();
            this.skinGroupBox14 = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridView_VRPagents = new System.Windows.Forms.DataGridView();
            this.ID_uav_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.East_uav_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.North_uav_VRP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMapControl_VRP = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage_SEAD = new System.Windows.Forms.TabPage();
            this.skinGroupBox_SEADpara = new CCWin.SkinControl.SkinGroupBox();
            this.textBox_SEADpopSize = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_SEADu2u = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.skinComboBox_SEAD = new CCWin.SkinControl.SkinComboBox();
            this.skinButton_seadMissionConfirm = new CCWin.SkinControl.SkinButton();
            this.skinGroupBox8 = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridView_seadTargets = new System.Windows.Forms.DataGridView();
            this.Target_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordinates = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.known_target = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skinGroupBox_SEADagents = new CCWin.SkinControl.SkinGroupBox();
            this.dataGridView_seadAgents = new System.Windows.Forms.DataGridView();
            this.UAV_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cruise_speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rmin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initial_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.base_pos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gMapControl_SEAD = new GMap.NET.WindowsForms.GMapControl();
            this.tabPage_Simulator = new CCWin.SkinControl.SkinTabPage();
            this.tabControl_main.SuspendLayout();
            this.tabPage_GCS.SuspendLayout();
            this.skinGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_flghtData)).BeginInit();
            this.skinPanel1.SuspendLayout();
            this.skinGroupBox2.SuspendLayout();
            this.tabControl_action.SuspendLayout();
            this.tabPage_command.SuspendLayout();
            this.skinGroupBox7.SuspendLayout();
            this.skinGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).BeginInit();
            this.tabPage_guide.SuspendLayout();
            this.skinGroupBox1.SuspendLayout();
            this.Plan.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage_missionStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.skinGroupBox11.SuspendLayout();
            this.tabPage_setting.SuspendLayout();
            this.skinGroupBox15.SuspendLayout();
            this.skinGroupBox9.SuspendLayout();
            this.skinGroupBox5.SuspendLayout();
            this.tabPage_FlightPlan.SuspendLayout();
            this.tabControl_mission.SuspendLayout();
            this.tabPage_WPs.SuspendLayout();
            this.skinGroupBox10.SuspendLayout();
            this.skinGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mission)).BeginInit();
            this.tabPage_VRP.SuspendLayout();
            this.skinGroupBox13.SuspendLayout();
            this.skinGroupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VRPtarget)).BeginInit();
            this.skinGroupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VRPagents)).BeginInit();
            this.tabPage_SEAD.SuspendLayout();
            this.skinGroupBox_SEADpara.SuspendLayout();
            this.skinGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_seadTargets)).BeginInit();
            this.skinGroupBox_SEADagents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_seadAgents)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.AnimatorType = CCWin.SkinControl.AnimationType.HorizSlide;
            this.tabControl_main.CloseRect = new System.Drawing.Rectangle(2, 2, 12, 12);
            this.tabControl_main.Controls.Add(this.tabPage_GCS);
            this.tabControl_main.Controls.Add(this.tabPage_FlightPlan);
            this.tabControl_main.Controls.Add(this.tabPage_Simulator);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.DrawType = CCWin.SkinControl.DrawStyle.Draw;
            this.tabControl_main.HeadBack = null;
            this.tabControl_main.ImgTxtOffset = new System.Drawing.Point(0, 0);
            this.tabControl_main.ItemSize = new System.Drawing.Size(120, 40);
            this.tabControl_main.Location = new System.Drawing.Point(4, 28);
            this.tabControl_main.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.PageArrowDown = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageArrowDown")));
            this.tabControl_main.PageArrowHover = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageArrowHover")));
            this.tabControl_main.PageCloseHover = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageCloseHover")));
            this.tabControl_main.PageCloseNormal = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageCloseNormal")));
            this.tabControl_main.PageDown = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageDown")));
            this.tabControl_main.PageHover = ((System.Drawing.Image)(resources.GetObject("tabControl_main.PageHover")));
            this.tabControl_main.PageImagePosition = CCWin.SkinControl.SkinTabControl.ePageImagePosition.Left;
            this.tabControl_main.PageNorml = null;
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1360, 764);
            this.tabControl_main.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_GCS
            // 
            this.tabPage_GCS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_GCS.BorderColor = System.Drawing.Color.DimGray;
            this.tabPage_GCS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_GCS.Controls.Add(this.button_test);
            this.tabPage_GCS.Controls.Add(this.button_Connect);
            this.tabPage_GCS.Controls.Add(this.gMapControl_main);
            this.tabPage_GCS.Controls.Add(this.comboBox_mapCenter);
            this.tabPage_GCS.Controls.Add(this.comboBox_connectOption);
            this.tabPage_GCS.Controls.Add(this.comboBox_PortOrBaud);
            this.tabPage_GCS.Controls.Add(this.comboBox_routeDisplay);
            this.tabPage_GCS.Controls.Add(this.skinGroupBox4);
            this.tabPage_GCS.Controls.Add(this.skinPanel1);
            this.tabPage_GCS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_GCS.Location = new System.Drawing.Point(0, 40);
            this.tabPage_GCS.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_GCS.Name = "tabPage_GCS";
            this.tabPage_GCS.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_GCS.Size = new System.Drawing.Size(1360, 724);
            this.tabPage_GCS.TabIndex = 0;
            this.tabPage_GCS.TabItemImage = null;
            this.tabPage_GCS.Text = "GCS";
            // 
            // button_test
            // 
            this.button_test.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_test.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_test.ForeColor = System.Drawing.Color.Black;
            this.button_test.Location = new System.Drawing.Point(324, 3);
            this.button_test.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_test.Name = "button_test";
            this.button_test.Size = new System.Drawing.Size(87, 39);
            this.button_test.TabIndex = 15;
            this.button_test.Text = "test";
            this.button_test.UseVisualStyleBackColor = false;
            this.button_test.Click += new System.EventHandler(this.button_test_Click);
            // 
            // button_Connect
            // 
            this.button_Connect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_Connect.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_Connect.ForeColor = System.Drawing.Color.Black;
            this.button_Connect.Location = new System.Drawing.Point(1244, 3);
            this.button_Connect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(112, 39);
            this.button_Connect.TabIndex = 1;
            this.button_Connect.Text = "Connect";
            this.button_Connect.UseVisualStyleBackColor = false;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // gMapControl_main
            // 
            this.gMapControl_main.AutoScroll = true;
            this.gMapControl_main.BackColor = System.Drawing.Color.White;
            this.gMapControl_main.Bearing = 0F;
            this.gMapControl_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl_main.CanDragMap = true;
            this.gMapControl_main.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gMapControl_main.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl_main.GrayScaleMode = false;
            this.gMapControl_main.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl_main.LevelsKeepInMemory = 5;
            this.gMapControl_main.Location = new System.Drawing.Point(324, 42);
            this.gMapControl_main.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gMapControl_main.MarkersEnabled = true;
            this.gMapControl_main.MaxZoom = 2;
            this.gMapControl_main.MinZoom = 2;
            this.gMapControl_main.MouseWheelZoomEnabled = true;
            this.gMapControl_main.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl_main.Name = "gMapControl_main";
            this.gMapControl_main.NegativeMode = false;
            this.gMapControl_main.PolygonsEnabled = true;
            this.gMapControl_main.RetryLoadTile = 0;
            this.gMapControl_main.RoutesEnabled = true;
            this.gMapControl_main.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl_main.SelectedAreaFillColor = System.Drawing.Color.LightGray;
            this.gMapControl_main.ShowTileGridLines = false;
            this.gMapControl_main.Size = new System.Drawing.Size(1032, 503);
            this.gMapControl_main.TabIndex = 17;
            this.gMapControl_main.Zoom = 0D;
            this.gMapControl_main.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.gMapControl_main_OnMarkerClick);
            this.gMapControl_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gMapControl_main_KeyDown);
            this.gMapControl_main.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gMapControl_main_KeyUp);
            this.gMapControl_main.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_main_MouseClick);
            // 
            // comboBox_mapCenter
            // 
            this.comboBox_mapCenter.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_mapCenter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_mapCenter.FormattingEnabled = true;
            this.comboBox_mapCenter.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_mapCenter.Location = new System.Drawing.Point(827, 8);
            this.comboBox_mapCenter.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_mapCenter.Name = "comboBox_mapCenter";
            this.comboBox_mapCenter.Size = new System.Drawing.Size(134, 28);
            this.comboBox_mapCenter.Sorted = true;
            this.comboBox_mapCenter.TabIndex = 8;
            this.comboBox_mapCenter.SelectedIndexChanged += new System.EventHandler(this.comboBox_mapCenter_SelectedIndexChanged);
            // 
            // comboBox_connectOption
            // 
            this.comboBox_connectOption.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_connectOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_connectOption.FormattingEnabled = true;
            this.comboBox_connectOption.Location = new System.Drawing.Point(965, 8);
            this.comboBox_connectOption.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_connectOption.Name = "comboBox_connectOption";
            this.comboBox_connectOption.Size = new System.Drawing.Size(134, 28);
            this.comboBox_connectOption.TabIndex = 3;
            this.comboBox_connectOption.SelectedIndexChanged += new System.EventHandler(this.comboBox_connectOption_SelectedIndexChanged);
            this.comboBox_connectOption.Click += new System.EventHandler(this.comboBox_connectOption_DropDown);
            // 
            // comboBox_PortOrBaud
            // 
            this.comboBox_PortOrBaud.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_PortOrBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortOrBaud.FormattingEnabled = true;
            this.comboBox_PortOrBaud.Location = new System.Drawing.Point(1103, 8);
            this.comboBox_PortOrBaud.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_PortOrBaud.Name = "comboBox_PortOrBaud";
            this.comboBox_PortOrBaud.Size = new System.Drawing.Size(134, 28);
            this.comboBox_PortOrBaud.TabIndex = 2;
            // 
            // comboBox_routeDisplay
            // 
            this.comboBox_routeDisplay.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_routeDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_routeDisplay.FormattingEnabled = true;
            this.comboBox_routeDisplay.Location = new System.Drawing.Point(689, 8);
            this.comboBox_routeDisplay.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_routeDisplay.Name = "comboBox_routeDisplay";
            this.comboBox_routeDisplay.Size = new System.Drawing.Size(134, 28);
            this.comboBox_routeDisplay.TabIndex = 13;
            this.comboBox_routeDisplay.SelectedIndexChanged += new System.EventHandler(this.comboBox_routeDisplay_SelectedIndexChanged);
            // 
            // skinGroupBox4
            // 
            this.skinGroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox4.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox4.Controls.Add(this.button_clearDataGrid);
            this.skinGroupBox4.Controls.Add(this.button_sortDataGrid);
            this.skinGroupBox4.Controls.Add(this.dataGridView_flghtData);
            this.skinGroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinGroupBox4.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox4.Location = new System.Drawing.Point(324, 545);
            this.skinGroupBox4.Name = "skinGroupBox4";
            this.skinGroupBox4.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox4.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox4.Size = new System.Drawing.Size(1032, 174);
            this.skinGroupBox4.TabIndex = 15;
            this.skinGroupBox4.TabStop = false;
            this.skinGroupBox4.Text = "Flight Data";
            this.skinGroupBox4.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox4.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox4.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // button_clearDataGrid
            // 
            this.button_clearDataGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_clearDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_clearDataGrid.ForeColor = System.Drawing.Color.Black;
            this.button_clearDataGrid.Location = new System.Drawing.Point(1008, 129);
            this.button_clearDataGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_clearDataGrid.Name = "button_clearDataGrid";
            this.button_clearDataGrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button_clearDataGrid.Size = new System.Drawing.Size(21, 42);
            this.button_clearDataGrid.TabIndex = 18;
            this.button_clearDataGrid.Text = "x";
            this.button_clearDataGrid.UseVisualStyleBackColor = false;
            this.button_clearDataGrid.Click += new System.EventHandler(this.button_clearDataGrid_Click);
            // 
            // button_sortDataGrid
            // 
            this.button_sortDataGrid.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_sortDataGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_sortDataGrid.ForeColor = System.Drawing.Color.Black;
            this.button_sortDataGrid.Location = new System.Drawing.Point(1008, 24);
            this.button_sortDataGrid.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_sortDataGrid.Name = "button_sortDataGrid";
            this.button_sortDataGrid.Size = new System.Drawing.Size(21, 105);
            this.button_sortDataGrid.TabIndex = 2;
            this.button_sortDataGrid.Text = "~";
            this.button_sortDataGrid.UseVisualStyleBackColor = false;
            this.button_sortDataGrid.Click += new System.EventHandler(this.button_sortDataGrid_Click);
            // 
            // dataGridView_flghtData
            // 
            this.dataGridView_flghtData.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_flghtData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_flghtData.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_flghtData.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView_flghtData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_flghtData.GridColor = System.Drawing.Color.DarkGray;
            this.dataGridView_flghtData.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_flghtData.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_flghtData.Name = "dataGridView_flghtData";
            this.dataGridView_flghtData.ReadOnly = true;
            this.dataGridView_flghtData.RowHeadersWidth = 62;
            this.dataGridView_flghtData.RowTemplate.Height = 24;
            this.dataGridView_flghtData.Size = new System.Drawing.Size(1005, 147);
            this.dataGridView_flghtData.TabIndex = 1;
            // 
            // skinPanel1
            // 
            this.skinPanel1.BackColor = System.Drawing.Color.Transparent;
            this.skinPanel1.Controls.Add(this.skinGroupBox2);
            this.skinPanel1.Controls.Add(this.tabControl_action);
            this.skinPanel1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinPanel1.DownBack = null;
            this.skinPanel1.Location = new System.Drawing.Point(2, 3);
            this.skinPanel1.MouseBack = null;
            this.skinPanel1.Name = "skinPanel1";
            this.skinPanel1.NormlBack = null;
            this.skinPanel1.Size = new System.Drawing.Size(322, 716);
            this.skinPanel1.TabIndex = 16;
            // 
            // skinGroupBox2
            // 
            this.skinGroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox2.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox2.Controls.Add(this.textBox_info);
            this.skinGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox2.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox2.Location = new System.Drawing.Point(0, 394);
            this.skinGroupBox2.Name = "skinGroupBox2";
            this.skinGroupBox2.RectBackColor = System.Drawing.Color.White;
            this.skinGroupBox2.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox2.Size = new System.Drawing.Size(322, 322);
            this.skinGroupBox2.TabIndex = 14;
            this.skinGroupBox2.TabStop = false;
            this.skinGroupBox2.Text = "Information";
            this.skinGroupBox2.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox2.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox2.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // textBox_info
            // 
            this.textBox_info.BackColor = System.Drawing.Color.White;
            this.textBox_info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_info.Location = new System.Drawing.Point(3, 24);
            this.textBox_info.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(316, 295);
            this.textBox_info.TabIndex = 6;
            this.textBox_info.Text = "";
            this.textBox_info.WordWrap = false;
            // 
            // tabControl_action
            // 
            this.tabControl_action.Controls.Add(this.tabPage_command);
            this.tabControl_action.Controls.Add(this.tabPage_guide);
            this.tabControl_action.Controls.Add(this.tabPage_missionStart);
            this.tabControl_action.Controls.Add(this.tabPage_setting);
            this.tabControl_action.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl_action.ItemSize = new System.Drawing.Size(87, 35);
            this.tabControl_action.Location = new System.Drawing.Point(0, 0);
            this.tabControl_action.Name = "tabControl_action";
            this.tabControl_action.SelectedIndex = 0;
            this.tabControl_action.Size = new System.Drawing.Size(322, 394);
            this.tabControl_action.TabIndex = 0;
            // 
            // tabPage_command
            // 
            this.tabPage_command.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_command.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_command.Controls.Add(this.skinGroupBox7);
            this.tabPage_command.Controls.Add(this.skinGroupBox6);
            this.tabPage_command.Controls.Add(this.skinPictureBox2);
            this.tabPage_command.Location = new System.Drawing.Point(4, 39);
            this.tabPage_command.Name = "tabPage_command";
            this.tabPage_command.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_command.Size = new System.Drawing.Size(314, 351);
            this.tabPage_command.TabIndex = 0;
            this.tabPage_command.Text = "Command";
            // 
            // skinGroupBox7
            // 
            this.skinGroupBox7.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox7.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox7.Controls.Add(this.skinButton_abort);
            this.skinGroupBox7.Controls.Add(this.skinButton_disarm);
            this.skinGroupBox7.Controls.Add(this.skinButton_arm);
            this.skinGroupBox7.Controls.Add(this.skinButton_land);
            this.skinGroupBox7.Controls.Add(this.skinButton_loiter);
            this.skinGroupBox7.Controls.Add(this.skinButton_HOLD);
            this.skinGroupBox7.Controls.Add(this.skinButton_RTL);
            this.skinGroupBox7.Controls.Add(this.comboBox_Command);
            this.skinGroupBox7.Controls.Add(this.colorSlider_takeoff);
            this.skinGroupBox7.Controls.Add(this.button_takeoff);
            this.skinGroupBox7.Controls.Add(this.button_Publish);
            this.skinGroupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox7.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox7.Location = new System.Drawing.Point(3, 89);
            this.skinGroupBox7.Name = "skinGroupBox7";
            this.skinGroupBox7.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox7.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox7.Size = new System.Drawing.Size(306, 198);
            this.skinGroupBox7.TabIndex = 19;
            this.skinGroupBox7.TabStop = false;
            this.skinGroupBox7.Text = "Mode";
            this.skinGroupBox7.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox7.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox7.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinButton_abort
            // 
            this.skinButton_abort.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_abort.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_abort.BorderColor = System.Drawing.Color.DarkGray;
            this.skinButton_abort.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_abort.DownBack = null;
            this.skinButton_abort.DownBaseColor = System.Drawing.Color.Silver;
            this.skinButton_abort.Enabled = false;
            this.skinButton_abort.Font = new System.Drawing.Font("Ink Free", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_abort.ForeColor = System.Drawing.Color.Black;
            this.skinButton_abort.GlowColor = System.Drawing.Color.LightCoral;
            this.skinButton_abort.InnerBorderColor = System.Drawing.Color.DimGray;
            this.skinButton_abort.Location = new System.Drawing.Point(229, 113);
            this.skinButton_abort.MouseBack = null;
            this.skinButton_abort.MouseBaseColor = System.Drawing.Color.Silver;
            this.skinButton_abort.Name = "skinButton_abort";
            this.skinButton_abort.NormlBack = null;
            this.skinButton_abort.Radius = 20;
            this.skinButton_abort.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_abort.Size = new System.Drawing.Size(71, 78);
            this.skinButton_abort.TabIndex = 25;
            this.skinButton_abort.Text = "Mission\r\nAbort";
            this.skinButton_abort.UseVisualStyleBackColor = false;
            this.skinButton_abort.Click += new System.EventHandler(this.skinButton_abort_Click);
            // 
            // skinButton_disarm
            // 
            this.skinButton_disarm.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_disarm.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_disarm.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_disarm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_disarm.DownBack = null;
            this.skinButton_disarm.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_disarm.Enabled = false;
            this.skinButton_disarm.Font = new System.Drawing.Font("Ink Free", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_disarm.ForeColor = System.Drawing.Color.Black;
            this.skinButton_disarm.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_disarm.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_disarm.Location = new System.Drawing.Point(155, 156);
            this.skinButton_disarm.MouseBack = null;
            this.skinButton_disarm.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_disarm.Name = "skinButton_disarm";
            this.skinButton_disarm.NormlBack = null;
            this.skinButton_disarm.Radius = 25;
            this.skinButton_disarm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_disarm.Size = new System.Drawing.Size(71, 36);
            this.skinButton_disarm.TabIndex = 24;
            this.skinButton_disarm.Text = "Disarn";
            this.skinButton_disarm.UseVisualStyleBackColor = false;
            this.skinButton_disarm.Click += new System.EventHandler(this.skinButton_disarm_Click);
            // 
            // skinButton_arm
            // 
            this.skinButton_arm.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_arm.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_arm.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_arm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_arm.DownBack = null;
            this.skinButton_arm.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_arm.Enabled = false;
            this.skinButton_arm.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_arm.ForeColor = System.Drawing.Color.Black;
            this.skinButton_arm.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_arm.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_arm.Location = new System.Drawing.Point(155, 113);
            this.skinButton_arm.MouseBack = null;
            this.skinButton_arm.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_arm.Name = "skinButton_arm";
            this.skinButton_arm.NormlBack = null;
            this.skinButton_arm.Radius = 25;
            this.skinButton_arm.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_arm.Size = new System.Drawing.Size(71, 36);
            this.skinButton_arm.TabIndex = 23;
            this.skinButton_arm.Text = "Arm";
            this.skinButton_arm.UseVisualStyleBackColor = false;
            this.skinButton_arm.Click += new System.EventHandler(this.skinButton_arm_Click);
            // 
            // skinButton_land
            // 
            this.skinButton_land.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_land.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_land.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_land.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_land.DownBack = null;
            this.skinButton_land.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_land.Enabled = false;
            this.skinButton_land.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_land.ForeColor = System.Drawing.Color.Black;
            this.skinButton_land.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_land.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_land.Location = new System.Drawing.Point(7, 155);
            this.skinButton_land.MouseBack = null;
            this.skinButton_land.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_land.Name = "skinButton_land";
            this.skinButton_land.NormlBack = null;
            this.skinButton_land.Radius = 25;
            this.skinButton_land.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_land.Size = new System.Drawing.Size(71, 36);
            this.skinButton_land.TabIndex = 22;
            this.skinButton_land.Text = "Land";
            this.skinButton_land.UseVisualStyleBackColor = false;
            this.skinButton_land.Click += new System.EventHandler(this.skinButton_land_Click);
            // 
            // skinButton_loiter
            // 
            this.skinButton_loiter.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_loiter.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_loiter.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_loiter.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_loiter.DownBack = null;
            this.skinButton_loiter.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_loiter.Enabled = false;
            this.skinButton_loiter.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_loiter.ForeColor = System.Drawing.Color.Black;
            this.skinButton_loiter.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_loiter.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_loiter.Location = new System.Drawing.Point(81, 155);
            this.skinButton_loiter.MouseBack = null;
            this.skinButton_loiter.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_loiter.Name = "skinButton_loiter";
            this.skinButton_loiter.NormlBack = null;
            this.skinButton_loiter.Radius = 25;
            this.skinButton_loiter.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_loiter.Size = new System.Drawing.Size(71, 36);
            this.skinButton_loiter.TabIndex = 21;
            this.skinButton_loiter.Text = "Loiter";
            this.skinButton_loiter.UseVisualStyleBackColor = false;
            this.skinButton_loiter.Click += new System.EventHandler(this.skinButton_loiter_Click);
            // 
            // skinButton_HOLD
            // 
            this.skinButton_HOLD.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_HOLD.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_HOLD.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_HOLD.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_HOLD.DownBack = null;
            this.skinButton_HOLD.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_HOLD.Enabled = false;
            this.skinButton_HOLD.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_HOLD.ForeColor = System.Drawing.Color.Black;
            this.skinButton_HOLD.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_HOLD.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_HOLD.Location = new System.Drawing.Point(81, 113);
            this.skinButton_HOLD.MouseBack = null;
            this.skinButton_HOLD.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_HOLD.Name = "skinButton_HOLD";
            this.skinButton_HOLD.NormlBack = null;
            this.skinButton_HOLD.Radius = 25;
            this.skinButton_HOLD.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_HOLD.Size = new System.Drawing.Size(71, 36);
            this.skinButton_HOLD.TabIndex = 20;
            this.skinButton_HOLD.Text = "Hold";
            this.skinButton_HOLD.UseVisualStyleBackColor = false;
            this.skinButton_HOLD.Click += new System.EventHandler(this.skinButton_HOLD_Click);
            // 
            // skinButton_RTL
            // 
            this.skinButton_RTL.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_RTL.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_RTL.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_RTL.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_RTL.DownBack = null;
            this.skinButton_RTL.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_RTL.Enabled = false;
            this.skinButton_RTL.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_RTL.ForeColor = System.Drawing.Color.Black;
            this.skinButton_RTL.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_RTL.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_RTL.Location = new System.Drawing.Point(7, 113);
            this.skinButton_RTL.MouseBack = null;
            this.skinButton_RTL.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_RTL.Name = "skinButton_RTL";
            this.skinButton_RTL.NormlBack = null;
            this.skinButton_RTL.Radius = 25;
            this.skinButton_RTL.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_RTL.Size = new System.Drawing.Size(71, 36);
            this.skinButton_RTL.TabIndex = 18;
            this.skinButton_RTL.Text = "RTL";
            this.skinButton_RTL.UseVisualStyleBackColor = false;
            this.skinButton_RTL.Click += new System.EventHandler(this.skinButton_RTL_Click);
            // 
            // comboBox_Command
            // 
            this.comboBox_Command.FormattingEnabled = true;
            this.comboBox_Command.Location = new System.Drawing.Point(7, 27);
            this.comboBox_Command.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_Command.Name = "comboBox_Command";
            this.comboBox_Command.Size = new System.Drawing.Size(193, 28);
            this.comboBox_Command.TabIndex = 11;
            // 
            // colorSlider_takeoff
            // 
            this.colorSlider_takeoff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.colorSlider_takeoff.BarInnerColor = System.Drawing.Color.Gray;
            this.colorSlider_takeoff.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.colorSlider_takeoff.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.colorSlider_takeoff.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.colorSlider_takeoff.ElapsedInnerColor = System.Drawing.Color.SteelBlue;
            this.colorSlider_takeoff.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.colorSlider_takeoff.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.colorSlider_takeoff.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.colorSlider_takeoff.ForeColor = System.Drawing.Color.Black;
            this.colorSlider_takeoff.LargeChange = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider_takeoff.Location = new System.Drawing.Point(7, 40);
            this.colorSlider_takeoff.Maximum = new decimal(new int[] {
            55,
            0,
            0,
            0});
            this.colorSlider_takeoff.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider_takeoff.Name = "colorSlider_takeoff";
            this.colorSlider_takeoff.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.colorSlider_takeoff.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.colorSlider_takeoff.ShowDivisionsText = true;
            this.colorSlider_takeoff.ShowSmallScale = false;
            this.colorSlider_takeoff.Size = new System.Drawing.Size(193, 67);
            this.colorSlider_takeoff.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.colorSlider_takeoff.TabIndex = 18;
            this.colorSlider_takeoff.ThumbInnerColor = System.Drawing.Color.CornflowerBlue;
            this.colorSlider_takeoff.ThumbPenColor = System.Drawing.Color.Black;
            this.colorSlider_takeoff.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.colorSlider_takeoff.ThumbSize = new System.Drawing.Size(16, 16);
            this.colorSlider_takeoff.TickAdd = 0F;
            this.colorSlider_takeoff.TickColor = System.Drawing.Color.Black;
            this.colorSlider_takeoff.TickDivide = 0F;
            this.colorSlider_takeoff.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.colorSlider_takeoff.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // button_takeoff
            // 
            this.button_takeoff.BackColor = System.Drawing.Color.White;
            this.button_takeoff.Enabled = false;
            this.button_takeoff.ForeColor = System.Drawing.Color.Black;
            this.button_takeoff.Location = new System.Drawing.Point(205, 61);
            this.button_takeoff.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_takeoff.Name = "button_takeoff";
            this.button_takeoff.Size = new System.Drawing.Size(90, 28);
            this.button_takeoff.TabIndex = 19;
            this.button_takeoff.Text = "Takeoff";
            this.button_takeoff.UseVisualStyleBackColor = false;
            this.button_takeoff.Click += new System.EventHandler(this.button_takeoff_Click);
            // 
            // button_Publish
            // 
            this.button_Publish.BackColor = System.Drawing.Color.White;
            this.button_Publish.Enabled = false;
            this.button_Publish.ForeColor = System.Drawing.Color.Black;
            this.button_Publish.Location = new System.Drawing.Point(205, 27);
            this.button_Publish.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_Publish.Name = "button_Publish";
            this.button_Publish.Size = new System.Drawing.Size(90, 28);
            this.button_Publish.TabIndex = 12;
            this.button_Publish.Text = "Publish";
            this.button_Publish.UseVisualStyleBackColor = false;
            this.button_Publish.Click += new System.EventHandler(this.button_Publish_Click);
            // 
            // skinGroupBox6
            // 
            this.skinGroupBox6.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox6.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox6.Controls.Add(this.checkBox_allUAVselect);
            this.skinGroupBox6.Controls.Add(this.checkBoxComboBox_UAVselect);
            this.skinGroupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox6.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox6.Location = new System.Drawing.Point(3, 3);
            this.skinGroupBox6.Name = "skinGroupBox6";
            this.skinGroupBox6.RectBackColor = System.Drawing.Color.LightGray;
            this.skinGroupBox6.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox6.Size = new System.Drawing.Size(306, 86);
            this.skinGroupBox6.TabIndex = 18;
            this.skinGroupBox6.TabStop = false;
            this.skinGroupBox6.Text = "UAV";
            this.skinGroupBox6.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox6.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox6.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // checkBox_allUAVselect
            // 
            this.checkBox_allUAVselect.AutoSize = true;
            this.checkBox_allUAVselect.Dock = System.Windows.Forms.DockStyle.Right;
            this.checkBox_allUAVselect.ForeColor = System.Drawing.Color.Black;
            this.checkBox_allUAVselect.Location = new System.Drawing.Point(157, 52);
            this.checkBox_allUAVselect.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBox_allUAVselect.Name = "checkBox_allUAVselect";
            this.checkBox_allUAVselect.Size = new System.Drawing.Size(146, 31);
            this.checkBox_allUAVselect.TabIndex = 9;
            this.checkBox_allUAVselect.Text = "Select all UAVs";
            this.checkBox_allUAVselect.UseVisualStyleBackColor = true;
            this.checkBox_allUAVselect.CheckedChanged += new System.EventHandler(this.checkBox_allUAVselect_CheckedChanged);
            // 
            // checkBoxComboBox_UAVselect
            // 
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxComboBox_UAVselect.CheckBoxProperties = checkBoxProperties1;
            this.checkBoxComboBox_UAVselect.DisplayMemberSingleItem = "";
            this.checkBoxComboBox_UAVselect.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBoxComboBox_UAVselect.FormattingEnabled = true;
            this.checkBoxComboBox_UAVselect.Location = new System.Drawing.Point(3, 24);
            this.checkBoxComboBox_UAVselect.Name = "checkBoxComboBox_UAVselect";
            this.checkBoxComboBox_UAVselect.Size = new System.Drawing.Size(300, 28);
            this.checkBoxComboBox_UAVselect.Sorted = true;
            this.checkBoxComboBox_UAVselect.TabIndex = 1;
            // 
            // skinPictureBox2
            // 
            this.skinPictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.skinPictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox2.Image")));
            this.skinPictureBox2.Location = new System.Drawing.Point(3, 287);
            this.skinPictureBox2.Name = "skinPictureBox2";
            this.skinPictureBox2.Size = new System.Drawing.Size(306, 59);
            this.skinPictureBox2.TabIndex = 18;
            this.skinPictureBox2.TabStop = false;
            // 
            // tabPage_guide
            // 
            this.tabPage_guide.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_guide.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_guide.Controls.Add(this.skinGroupBox1);
            this.tabPage_guide.Location = new System.Drawing.Point(4, 39);
            this.tabPage_guide.Name = "tabPage_guide";
            this.tabPage_guide.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_guide.Size = new System.Drawing.Size(314, 351);
            this.tabPage_guide.TabIndex = 1;
            this.tabPage_guide.Text = "Guide";
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox1.Controls.Add(this.skinButton_pubWP);
            this.skinGroupBox1.Controls.Add(this.skinButton_clearWPs);
            this.skinGroupBox1.Controls.Add(this.Plan);
            this.skinGroupBox1.Controls.Add(this.textBox_WPguided);
            this.skinGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox1.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(306, 343);
            this.skinGroupBox1.TabIndex = 19;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.Text = "Waypoint";
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinButton_pubWP
            // 
            this.skinButton_pubWP.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_pubWP.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_pubWP.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_pubWP.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_pubWP.DownBack = null;
            this.skinButton_pubWP.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_pubWP.Enabled = false;
            this.skinButton_pubWP.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_pubWP.ForeColor = System.Drawing.Color.Black;
            this.skinButton_pubWP.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_pubWP.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_pubWP.Location = new System.Drawing.Point(213, 178);
            this.skinButton_pubWP.MouseBack = null;
            this.skinButton_pubWP.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_pubWP.Name = "skinButton_pubWP";
            this.skinButton_pubWP.NormlBack = null;
            this.skinButton_pubWP.Radius = 25;
            this.skinButton_pubWP.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_pubWP.Size = new System.Drawing.Size(87, 36);
            this.skinButton_pubWP.TabIndex = 20;
            this.skinButton_pubWP.Text = "Publish";
            this.skinButton_pubWP.UseVisualStyleBackColor = false;
            this.skinButton_pubWP.Click += new System.EventHandler(this.skinButton_pubWP_Click);
            // 
            // skinButton_clearWPs
            // 
            this.skinButton_clearWPs.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_clearWPs.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_clearWPs.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_clearWPs.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_clearWPs.DownBack = null;
            this.skinButton_clearWPs.DownBaseColor = System.Drawing.Color.Thistle;
            this.skinButton_clearWPs.Enabled = false;
            this.skinButton_clearWPs.Font = new System.Drawing.Font("Ink Free", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_clearWPs.ForeColor = System.Drawing.Color.Black;
            this.skinButton_clearWPs.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_clearWPs.InnerBorderColor = System.Drawing.Color.Silver;
            this.skinButton_clearWPs.Location = new System.Drawing.Point(213, 217);
            this.skinButton_clearWPs.MouseBack = null;
            this.skinButton_clearWPs.MouseBaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.skinButton_clearWPs.Name = "skinButton_clearWPs";
            this.skinButton_clearWPs.NormlBack = null;
            this.skinButton_clearWPs.Radius = 25;
            this.skinButton_clearWPs.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_clearWPs.Size = new System.Drawing.Size(87, 36);
            this.skinButton_clearWPs.TabIndex = 19;
            this.skinButton_clearWPs.Text = "Clear all";
            this.skinButton_clearWPs.UseVisualStyleBackColor = false;
            this.skinButton_clearWPs.Click += new System.EventHandler(this.skinButton_clearWPs_Click);
            // 
            // Plan
            // 
            this.Plan.Controls.Add(this.label1);
            this.Plan.Controls.Add(this.textBox_wpYaw);
            this.Plan.Controls.Add(this.panel2);
            this.Plan.Controls.Add(this.textBox_wpE);
            this.Plan.Controls.Add(this.label7);
            this.Plan.Controls.Add(this.textBox_wpN);
            this.Plan.Controls.Add(this.label6);
            this.Plan.Controls.Add(this.textBox_wpU);
            this.Plan.Controls.Add(this.label5);
            this.Plan.Controls.Add(this.label3);
            this.Plan.Controls.Add(this.comboBox_guideWP);
            this.Plan.Dock = System.Windows.Forms.DockStyle.Left;
            this.Plan.Location = new System.Drawing.Point(3, 24);
            this.Plan.Name = "Plan";
            this.Plan.Size = new System.Drawing.Size(204, 235);
            this.Plan.TabIndex = 16;
            this.Plan.TabStop = false;
            this.Plan.Text = "Plan";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(14, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Yaw :";
            // 
            // textBox_wpYaw
            // 
            this.textBox_wpYaw.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_wpYaw.Location = new System.Drawing.Point(69, 162);
            this.textBox_wpYaw.Name = "textBox_wpYaw";
            this.textBox_wpYaw.Size = new System.Drawing.Size(117, 28);
            this.textBox_wpYaw.TabIndex = 31;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_guideClear);
            this.panel2.Controls.Add(this.button_WPconfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 201);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 31);
            this.panel2.TabIndex = 18;
            // 
            // button_guideClear
            // 
            this.button_guideClear.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_guideClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_guideClear.ForeColor = System.Drawing.Color.Black;
            this.button_guideClear.Location = new System.Drawing.Point(101, 0);
            this.button_guideClear.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_guideClear.Name = "button_guideClear";
            this.button_guideClear.Size = new System.Drawing.Size(97, 31);
            this.button_guideClear.TabIndex = 22;
            this.button_guideClear.Text = "Clear";
            this.button_guideClear.UseVisualStyleBackColor = false;
            // 
            // button_WPconfirm
            // 
            this.button_WPconfirm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_WPconfirm.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_WPconfirm.ForeColor = System.Drawing.Color.Black;
            this.button_WPconfirm.Location = new System.Drawing.Point(0, 0);
            this.button_WPconfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_WPconfirm.Name = "button_WPconfirm";
            this.button_WPconfirm.Size = new System.Drawing.Size(101, 31);
            this.button_WPconfirm.TabIndex = 27;
            this.button_WPconfirm.Text = "Confirm";
            this.button_WPconfirm.UseVisualStyleBackColor = false;
            this.button_WPconfirm.Click += new System.EventHandler(this.button_WPconfirm_Click);
            // 
            // textBox_wpE
            // 
            this.textBox_wpE.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_wpE.Location = new System.Drawing.Point(69, 59);
            this.textBox_wpE.Name = "textBox_wpE";
            this.textBox_wpE.Size = new System.Drawing.Size(117, 28);
            this.textBox_wpE.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(33, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "U :";
            // 
            // textBox_wpN
            // 
            this.textBox_wpN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_wpN.Location = new System.Drawing.Point(70, 93);
            this.textBox_wpN.Name = "textBox_wpN";
            this.textBox_wpN.Size = new System.Drawing.Size(116, 28);
            this.textBox_wpN.TabIndex = 26;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(33, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 20);
            this.label6.TabIndex = 29;
            this.label6.Text = "N :";
            // 
            // textBox_wpU
            // 
            this.textBox_wpU.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox_wpU.Location = new System.Drawing.Point(69, 128);
            this.textBox_wpU.Name = "textBox_wpU";
            this.textBox_wpU.Size = new System.Drawing.Size(117, 28);
            this.textBox_wpU.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(35, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "E :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(11, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 23;
            this.label3.Text = "UAV :";
            // 
            // comboBox_guideWP
            // 
            this.comboBox_guideWP.FormattingEnabled = true;
            this.comboBox_guideWP.Location = new System.Drawing.Point(69, 25);
            this.comboBox_guideWP.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_guideWP.Name = "comboBox_guideWP";
            this.comboBox_guideWP.Size = new System.Drawing.Size(117, 28);
            this.comboBox_guideWP.Sorted = true;
            this.comboBox_guideWP.TabIndex = 21;
            this.comboBox_guideWP.DropDown += new System.EventHandler(this.comboBox_guideWP_DropDown);
            // 
            // textBox_WPguided
            // 
            this.textBox_WPguided.BackColor = System.Drawing.Color.White;
            this.textBox_WPguided.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_WPguided.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_WPguided.Location = new System.Drawing.Point(3, 259);
            this.textBox_WPguided.Multiline = true;
            this.textBox_WPguided.Name = "textBox_WPguided";
            this.textBox_WPguided.ReadOnly = true;
            this.textBox_WPguided.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_WPguided.Size = new System.Drawing.Size(300, 81);
            this.textBox_WPguided.TabIndex = 18;
            // 
            // tabPage_missionStart
            // 
            this.tabPage_missionStart.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_missionStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_missionStart.Controls.Add(this.skinPictureBox1);
            this.tabPage_missionStart.Controls.Add(this.skinGroupBox11);
            this.tabPage_missionStart.Location = new System.Drawing.Point(4, 39);
            this.tabPage_missionStart.Name = "tabPage_missionStart";
            this.tabPage_missionStart.Size = new System.Drawing.Size(314, 351);
            this.tabPage_missionStart.TabIndex = 3;
            this.tabPage_missionStart.Text = "Mission";
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("skinPictureBox1.Image")));
            this.skinPictureBox1.Location = new System.Drawing.Point(0, 151);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(312, 59);
            this.skinPictureBox1.TabIndex = 23;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinGroupBox11
            // 
            this.skinGroupBox11.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox11.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox11.Controls.Add(this.pulseButton_clear);
            this.skinGroupBox11.Controls.Add(this.pulseButton_cancel);
            this.skinGroupBox11.Controls.Add(this.skinButton_missionStart);
            this.skinGroupBox11.Controls.Add(this.skinButton_goToInitPos);
            this.skinGroupBox11.Controls.Add(this.skinComboBox_PubMission);
            this.skinGroupBox11.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox11.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox11.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox11.Name = "skinGroupBox11";
            this.skinGroupBox11.RectBackColor = System.Drawing.Color.LightGray;
            this.skinGroupBox11.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox11.Size = new System.Drawing.Size(312, 151);
            this.skinGroupBox11.TabIndex = 20;
            this.skinGroupBox11.TabStop = false;
            this.skinGroupBox11.Text = "Mission";
            this.skinGroupBox11.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox11.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox11.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // pulseButton_clear
            // 
            this.pulseButton_clear.ButtonColorBottom = System.Drawing.Color.SlateGray;
            this.pulseButton_clear.ButtonColorTop = System.Drawing.Color.AliceBlue;
            this.pulseButton_clear.FocusColor = System.Drawing.Color.SteelBlue;
            this.pulseButton_clear.ForeColor = System.Drawing.Color.Black;
            this.pulseButton_clear.Location = new System.Drawing.Point(32, 101);
            this.pulseButton_clear.Name = "pulseButton_clear";
            this.pulseButton_clear.NumberOfPulses = 2;
            this.pulseButton_clear.PulseSpeed = 0.3F;
            this.pulseButton_clear.PulseWidth = 6;
            this.pulseButton_clear.Size = new System.Drawing.Size(77, 36);
            this.pulseButton_clear.TabIndex = 20;
            this.pulseButton_clear.Text = "clear";
            this.pulseButton_clear.UseVisualStyleBackColor = true;
            this.pulseButton_clear.Click += new System.EventHandler(this.pulseButton_clear_Click);
            // 
            // pulseButton_cancel
            // 
            this.pulseButton_cancel.ButtonColorBottom = System.Drawing.Color.SlateGray;
            this.pulseButton_cancel.ButtonColorTop = System.Drawing.Color.AliceBlue;
            this.pulseButton_cancel.FocusColor = System.Drawing.Color.SteelBlue;
            this.pulseButton_cancel.ForeColor = System.Drawing.Color.Black;
            this.pulseButton_cancel.Location = new System.Drawing.Point(32, 59);
            this.pulseButton_cancel.Name = "pulseButton_cancel";
            this.pulseButton_cancel.NumberOfPulses = 2;
            this.pulseButton_cancel.PulseSpeed = 0.3F;
            this.pulseButton_cancel.PulseWidth = 6;
            this.pulseButton_cancel.Size = new System.Drawing.Size(77, 36);
            this.pulseButton_cancel.TabIndex = 18;
            this.pulseButton_cancel.Text = "cancel";
            this.pulseButton_cancel.UseVisualStyleBackColor = true;
            this.pulseButton_cancel.Click += new System.EventHandler(this.pulseButton_cancel_Click);
            // 
            // skinButton_missionStart
            // 
            this.skinButton_missionStart.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_missionStart.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_missionStart.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_missionStart.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_missionStart.DownBack = null;
            this.skinButton_missionStart.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_missionStart.ForeColor = System.Drawing.Color.Black;
            this.skinButton_missionStart.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_missionStart.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_missionStart.Location = new System.Drawing.Point(115, 101);
            this.skinButton_missionStart.MouseBack = null;
            this.skinButton_missionStart.MouseBaseColor = System.Drawing.Color.SteelBlue;
            this.skinButton_missionStart.Name = "skinButton_missionStart";
            this.skinButton_missionStart.NormlBack = null;
            this.skinButton_missionStart.Radius = 20;
            this.skinButton_missionStart.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_missionStart.Size = new System.Drawing.Size(191, 36);
            this.skinButton_missionStart.TabIndex = 5;
            this.skinButton_missionStart.Text = "Mission start";
            this.skinButton_missionStart.UseVisualStyleBackColor = false;
            this.skinButton_missionStart.Click += new System.EventHandler(this.skinButton_missionStart_Click);
            // 
            // skinButton_goToInitPos
            // 
            this.skinButton_goToInitPos.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_goToInitPos.BaseColor = System.Drawing.Color.WhiteSmoke;
            this.skinButton_goToInitPos.BorderColor = System.Drawing.Color.DarkGray;
            this.skinButton_goToInitPos.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_goToInitPos.DownBack = null;
            this.skinButton_goToInitPos.DownBaseColor = System.Drawing.Color.Silver;
            this.skinButton_goToInitPos.Enabled = false;
            this.skinButton_goToInitPos.Font = new System.Drawing.Font("Ink Free", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skinButton_goToInitPos.ForeColor = System.Drawing.Color.Black;
            this.skinButton_goToInitPos.GlowColor = System.Drawing.Color.LightCoral;
            this.skinButton_goToInitPos.InnerBorderColor = System.Drawing.Color.DimGray;
            this.skinButton_goToInitPos.Location = new System.Drawing.Point(115, 59);
            this.skinButton_goToInitPos.MouseBack = null;
            this.skinButton_goToInitPos.MouseBaseColor = System.Drawing.Color.Silver;
            this.skinButton_goToInitPos.Name = "skinButton_goToInitPos";
            this.skinButton_goToInitPos.NormlBack = null;
            this.skinButton_goToInitPos.Radius = 20;
            this.skinButton_goToInitPos.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_goToInitPos.Size = new System.Drawing.Size(191, 36);
            this.skinButton_goToInitPos.TabIndex = 19;
            this.skinButton_goToInitPos.Text = "To init position";
            this.skinButton_goToInitPos.UseVisualStyleBackColor = false;
            this.skinButton_goToInitPos.Click += new System.EventHandler(this.skinButton_goToInitPos_Click);
            // 
            // skinComboBox_PubMission
            // 
            this.skinComboBox_PubMission.ArrowColor = System.Drawing.Color.Black;
            this.skinComboBox_PubMission.BackColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_PubMission.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_PubMission.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinComboBox_PubMission.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinComboBox_PubMission.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_PubMission.DropBackColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_PubMission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_PubMission.FormattingEnabled = true;
            this.skinComboBox_PubMission.ItemBorderColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_PubMission.ItemHoverForeColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_PubMission.Location = new System.Drawing.Point(3, 24);
            this.skinComboBox_PubMission.Name = "skinComboBox_PubMission";
            this.skinComboBox_PubMission.Size = new System.Drawing.Size(306, 29);
            this.skinComboBox_PubMission.TabIndex = 4;
            this.skinComboBox_PubMission.WaterText = "";
            this.skinComboBox_PubMission.SelectedIndexChanged += new System.EventHandler(this.skinComboBox_PubMission_SelectedIndexChanged);
            // 
            // tabPage_setting
            // 
            this.tabPage_setting.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_setting.Controls.Add(this.skinGroupBox15);
            this.tabPage_setting.Controls.Add(this.skinGroupBox9);
            this.tabPage_setting.Controls.Add(this.skinGroupBox5);
            this.tabPage_setting.Location = new System.Drawing.Point(4, 39);
            this.tabPage_setting.Name = "tabPage_setting";
            this.tabPage_setting.Size = new System.Drawing.Size(314, 351);
            this.tabPage_setting.TabIndex = 4;
            this.tabPage_setting.Text = "Setting";
            // 
            // skinGroupBox15
            // 
            this.skinGroupBox15.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox15.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox15.Controls.Add(this.comboBox_origin);
            this.skinGroupBox15.Controls.Add(this.button_originConfirm);
            this.skinGroupBox15.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox15.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox15.Location = new System.Drawing.Point(0, 137);
            this.skinGroupBox15.Name = "skinGroupBox15";
            this.skinGroupBox15.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox15.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox15.Size = new System.Drawing.Size(314, 75);
            this.skinGroupBox15.TabIndex = 20;
            this.skinGroupBox15.TabStop = false;
            this.skinGroupBox15.Text = "Origin";
            this.skinGroupBox15.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox15.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox15.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // comboBox_origin
            // 
            this.comboBox_origin.FormattingEnabled = true;
            this.comboBox_origin.Location = new System.Drawing.Point(5, 24);
            this.comboBox_origin.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_origin.Name = "comboBox_origin";
            this.comboBox_origin.Size = new System.Drawing.Size(193, 28);
            this.comboBox_origin.TabIndex = 18;
            // 
            // button_originConfirm
            // 
            this.button_originConfirm.BackColor = System.Drawing.Color.White;
            this.button_originConfirm.ForeColor = System.Drawing.Color.Black;
            this.button_originConfirm.Location = new System.Drawing.Point(218, 24);
            this.button_originConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_originConfirm.Name = "button_originConfirm";
            this.button_originConfirm.Size = new System.Drawing.Size(90, 28);
            this.button_originConfirm.TabIndex = 17;
            this.button_originConfirm.Text = "Confirm";
            this.button_originConfirm.UseVisualStyleBackColor = false;
            this.button_originConfirm.Click += new System.EventHandler(this.button_originConfirm_Click);
            // 
            // skinGroupBox9
            // 
            this.skinGroupBox9.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox9.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox9.Controls.Add(this.button_tineRecalibrate);
            this.skinGroupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox9.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox9.Location = new System.Drawing.Point(0, 75);
            this.skinGroupBox9.Name = "skinGroupBox9";
            this.skinGroupBox9.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox9.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox9.Size = new System.Drawing.Size(314, 62);
            this.skinGroupBox9.TabIndex = 19;
            this.skinGroupBox9.TabStop = false;
            this.skinGroupBox9.Text = "Time sync";
            this.skinGroupBox9.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox9.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox9.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // button_tineRecalibrate
            // 
            this.button_tineRecalibrate.BackColor = System.Drawing.Color.White;
            this.button_tineRecalibrate.ForeColor = System.Drawing.Color.Black;
            this.button_tineRecalibrate.Location = new System.Drawing.Point(218, 23);
            this.button_tineRecalibrate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_tineRecalibrate.Name = "button_tineRecalibrate";
            this.button_tineRecalibrate.Size = new System.Drawing.Size(91, 28);
            this.button_tineRecalibrate.TabIndex = 17;
            this.button_tineRecalibrate.Text = "Calibrate";
            this.button_tineRecalibrate.UseVisualStyleBackColor = false;
            this.button_tineRecalibrate.Click += new System.EventHandler(this.button_tineRecalibrate_Click);
            // 
            // skinGroupBox5
            // 
            this.skinGroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox5.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox5.Controls.Add(this.comboBox_u2gFreq);
            this.skinGroupBox5.Controls.Add(this.button_FreqConfirm);
            this.skinGroupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox5.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox5.Location = new System.Drawing.Point(0, 0);
            this.skinGroupBox5.Name = "skinGroupBox5";
            this.skinGroupBox5.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox5.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox5.Size = new System.Drawing.Size(314, 75);
            this.skinGroupBox5.TabIndex = 18;
            this.skinGroupBox5.TabStop = false;
            this.skinGroupBox5.Text = "U2G freq";
            this.skinGroupBox5.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox5.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox5.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // comboBox_u2gFreq
            // 
            this.comboBox_u2gFreq.FormattingEnabled = true;
            this.comboBox_u2gFreq.Location = new System.Drawing.Point(5, 24);
            this.comboBox_u2gFreq.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox_u2gFreq.Name = "comboBox_u2gFreq";
            this.comboBox_u2gFreq.Size = new System.Drawing.Size(193, 28);
            this.comboBox_u2gFreq.TabIndex = 18;
            // 
            // button_FreqConfirm
            // 
            this.button_FreqConfirm.BackColor = System.Drawing.Color.White;
            this.button_FreqConfirm.Enabled = false;
            this.button_FreqConfirm.ForeColor = System.Drawing.Color.Black;
            this.button_FreqConfirm.Location = new System.Drawing.Point(218, 24);
            this.button_FreqConfirm.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button_FreqConfirm.Name = "button_FreqConfirm";
            this.button_FreqConfirm.Size = new System.Drawing.Size(90, 28);
            this.button_FreqConfirm.TabIndex = 17;
            this.button_FreqConfirm.Text = "Confirm";
            this.button_FreqConfirm.UseVisualStyleBackColor = false;
            this.button_FreqConfirm.Click += new System.EventHandler(this.button_FreqConfirm_Click);
            // 
            // tabPage_FlightPlan
            // 
            this.tabPage_FlightPlan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_FlightPlan.BorderColor = System.Drawing.Color.DimGray;
            this.tabPage_FlightPlan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_FlightPlan.Controls.Add(this.tabControl_mission);
            this.tabPage_FlightPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_FlightPlan.Location = new System.Drawing.Point(0, 40);
            this.tabPage_FlightPlan.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_FlightPlan.Name = "tabPage_FlightPlan";
            this.tabPage_FlightPlan.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_FlightPlan.Size = new System.Drawing.Size(1360, 724);
            this.tabPage_FlightPlan.TabIndex = 1;
            this.tabPage_FlightPlan.TabItemImage = null;
            this.tabPage_FlightPlan.Text = "Flight Plan";
            // 
            // tabControl_mission
            // 
            this.tabControl_mission.Controls.Add(this.tabPage_WPs);
            this.tabControl_mission.Controls.Add(this.tabPage_VRP);
            this.tabControl_mission.Controls.Add(this.tabPage_SEAD);
            this.tabControl_mission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_mission.ItemSize = new System.Drawing.Size(52, 30);
            this.tabControl_mission.Location = new System.Drawing.Point(2, 3);
            this.tabControl_mission.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabControl_mission.Name = "tabControl_mission";
            this.tabControl_mission.SelectedIndex = 0;
            this.tabControl_mission.Size = new System.Drawing.Size(1354, 716);
            this.tabControl_mission.TabIndex = 0;
            // 
            // tabPage_WPs
            // 
            this.tabPage_WPs.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_WPs.Controls.Add(this.skinGroupBox10);
            this.tabPage_WPs.Controls.Add(this.skinGroupBox3);
            this.tabPage_WPs.Controls.Add(this.gMapControl_WPs);
            this.tabPage_WPs.Location = new System.Drawing.Point(4, 34);
            this.tabPage_WPs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_WPs.Name = "tabPage_WPs";
            this.tabPage_WPs.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_WPs.Size = new System.Drawing.Size(1346, 678);
            this.tabPage_WPs.TabIndex = 0;
            this.tabPage_WPs.Text = "WPs";
            // 
            // skinGroupBox10
            // 
            this.skinGroupBox10.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox10.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox10.Controls.Add(this.label4);
            this.skinGroupBox10.Controls.Add(this.textBox_missionHeading);
            this.skinGroupBox10.Controls.Add(this.button_startMission);
            this.skinGroupBox10.Controls.Add(this.skinButton_adjustMission);
            this.skinGroupBox10.Controls.Add(this.label12);
            this.skinGroupBox10.Controls.Add(this.comboBox_missionUAV);
            this.skinGroupBox10.Controls.Add(this.label11);
            this.skinGroupBox10.Controls.Add(this.comboBox_missionTypeMission);
            this.skinGroupBox10.Controls.Add(this.textBox_missionHeight);
            this.skinGroupBox10.Controls.Add(this.label_HorYaw);
            this.skinGroupBox10.Controls.Add(this.label2);
            this.skinGroupBox10.Controls.Add(this.comboBox_missionMethod);
            this.skinGroupBox10.Controls.Add(this.linkLabel_missionConfig);
            this.skinGroupBox10.Controls.Add(this.button_missionConfirm);
            this.skinGroupBox10.Controls.Add(this.button_missionCancel);
            this.skinGroupBox10.Controls.Add(this.button_missionClear);
            this.skinGroupBox10.Controls.Add(this.button_missionPrepare);
            this.skinGroupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox10.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox10.Location = new System.Drawing.Point(704, 436);
            this.skinGroupBox10.Name = "skinGroupBox10";
            this.skinGroupBox10.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox10.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox10.Size = new System.Drawing.Size(640, 239);
            this.skinGroupBox10.TabIndex = 31;
            this.skinGroupBox10.TabStop = false;
            this.skinGroupBox10.Text = "Settings";
            this.skinGroupBox10.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox10.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox10.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(446, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "Heading :";
            // 
            // textBox_missionHeading
            // 
            this.textBox_missionHeading.Location = new System.Drawing.Point(450, 125);
            this.textBox_missionHeading.Name = "textBox_missionHeading";
            this.textBox_missionHeading.Size = new System.Drawing.Size(87, 28);
            this.textBox_missionHeading.TabIndex = 29;
            this.textBox_missionHeading.Text = "0";
            this.textBox_missionHeading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // button_startMission
            // 
            this.button_startMission.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_startMission.ForeColor = System.Drawing.Color.Black;
            this.button_startMission.Location = new System.Drawing.Point(583, 19);
            this.button_startMission.Name = "button_startMission";
            this.button_startMission.Size = new System.Drawing.Size(51, 31);
            this.button_startMission.TabIndex = 18;
            this.button_startMission.Text = "Start";
            this.button_startMission.UseVisualStyleBackColor = false;
            this.button_startMission.Click += new System.EventHandler(this.button_startMission_Click);
            // 
            // skinButton_adjustMission
            // 
            this.skinButton_adjustMission.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_adjustMission.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_adjustMission.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_adjustMission.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_adjustMission.DownBack = null;
            this.skinButton_adjustMission.Enabled = false;
            this.skinButton_adjustMission.ForeColor = System.Drawing.Color.Black;
            this.skinButton_adjustMission.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_adjustMission.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_adjustMission.Location = new System.Drawing.Point(450, 159);
            this.skinButton_adjustMission.MouseBack = null;
            this.skinButton_adjustMission.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_adjustMission.Name = "skinButton_adjustMission";
            this.skinButton_adjustMission.NormlBack = null;
            this.skinButton_adjustMission.Size = new System.Drawing.Size(87, 31);
            this.skinButton_adjustMission.TabIndex = 19;
            this.skinButton_adjustMission.Text = "Adjust";
            this.skinButton_adjustMission.UseVisualStyleBackColor = false;
            this.skinButton_adjustMission.Click += new System.EventHandler(this.skinButton_adjustMission_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "UAV :";
            // 
            // comboBox_missionUAV
            // 
            this.comboBox_missionUAV.Enabled = false;
            this.comboBox_missionUAV.FormattingEnabled = true;
            this.comboBox_missionUAV.Location = new System.Drawing.Point(10, 47);
            this.comboBox_missionUAV.Name = "comboBox_missionUAV";
            this.comboBox_missionUAV.Size = new System.Drawing.Size(297, 28);
            this.comboBox_missionUAV.TabIndex = 13;
            this.comboBox_missionUAV.DropDown += new System.EventHandler(this.comboBox_missionUAV_DropDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(6, 79);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 20);
            this.label11.TabIndex = 7;
            this.label11.Text = "Mission :";
            // 
            // comboBox_missionTypeMission
            // 
            this.comboBox_missionTypeMission.Enabled = false;
            this.comboBox_missionTypeMission.FormattingEnabled = true;
            this.comboBox_missionTypeMission.Location = new System.Drawing.Point(10, 102);
            this.comboBox_missionTypeMission.Name = "comboBox_missionTypeMission";
            this.comboBox_missionTypeMission.Size = new System.Drawing.Size(297, 28);
            this.comboBox_missionTypeMission.TabIndex = 6;
            this.comboBox_missionTypeMission.SelectedIndexChanged += new System.EventHandler(this.comboBox_missionTypeMission_SelectedIndexChanged);
            // 
            // textBox_missionHeight
            // 
            this.textBox_missionHeight.Location = new System.Drawing.Point(450, 68);
            this.textBox_missionHeight.Name = "textBox_missionHeight";
            this.textBox_missionHeight.Size = new System.Drawing.Size(87, 28);
            this.textBox_missionHeight.TabIndex = 26;
            this.textBox_missionHeight.Text = "5";
            this.textBox_missionHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_HorYaw
            // 
            this.label_HorYaw.AutoSize = true;
            this.label_HorYaw.ForeColor = System.Drawing.Color.Black;
            this.label_HorYaw.Location = new System.Drawing.Point(446, 45);
            this.label_HorYaw.Name = "label_HorYaw";
            this.label_HorYaw.Size = new System.Drawing.Size(96, 20);
            this.label_HorYaw.TabIndex = 27;
            this.label_HorYaw.Text = "Height (m) :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "Method :";
            // 
            // comboBox_missionMethod
            // 
            this.comboBox_missionMethod.Enabled = false;
            this.comboBox_missionMethod.FormattingEnabled = true;
            this.comboBox_missionMethod.Location = new System.Drawing.Point(10, 156);
            this.comboBox_missionMethod.Name = "comboBox_missionMethod";
            this.comboBox_missionMethod.Size = new System.Drawing.Size(297, 28);
            this.comboBox_missionMethod.TabIndex = 24;
            // 
            // linkLabel_missionConfig
            // 
            this.linkLabel_missionConfig.ActiveLinkColor = System.Drawing.Color.MediumSeaGreen;
            this.linkLabel_missionConfig.AutoSize = true;
            this.linkLabel_missionConfig.LinkColor = System.Drawing.Color.CornflowerBlue;
            this.linkLabel_missionConfig.Location = new System.Drawing.Point(254, 133);
            this.linkLabel_missionConfig.Name = "linkLabel_missionConfig";
            this.linkLabel_missionConfig.Size = new System.Drawing.Size(53, 20);
            this.linkLabel_missionConfig.TabIndex = 23;
            this.linkLabel_missionConfig.TabStop = true;
            this.linkLabel_missionConfig.Text = "config";
            this.linkLabel_missionConfig.VisitedLinkColor = System.Drawing.Color.MediumSeaGreen;
            this.linkLabel_missionConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_missionConfig_LinkClicked);
            // 
            // button_missionConfirm
            // 
            this.button_missionConfirm.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.button_missionConfirm.Enabled = false;
            this.button_missionConfirm.ForeColor = System.Drawing.Color.Black;
            this.button_missionConfirm.Location = new System.Drawing.Point(323, 122);
            this.button_missionConfirm.Name = "button_missionConfirm";
            this.button_missionConfirm.Size = new System.Drawing.Size(109, 31);
            this.button_missionConfirm.TabIndex = 15;
            this.button_missionConfirm.Text = "Confirm";
            this.button_missionConfirm.UseVisualStyleBackColor = false;
            this.button_missionConfirm.Click += new System.EventHandler(this.button_missionConfirm_Click);
            // 
            // button_missionCancel
            // 
            this.button_missionCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_missionCancel.Enabled = false;
            this.button_missionCancel.ForeColor = System.Drawing.Color.Black;
            this.button_missionCancel.Location = new System.Drawing.Point(323, 85);
            this.button_missionCancel.Name = "button_missionCancel";
            this.button_missionCancel.Size = new System.Drawing.Size(109, 31);
            this.button_missionCancel.TabIndex = 14;
            this.button_missionCancel.Text = "Cancel";
            this.button_missionCancel.UseVisualStyleBackColor = false;
            this.button_missionCancel.Click += new System.EventHandler(this.button_missionCancel_Click);
            // 
            // button_missionClear
            // 
            this.button_missionClear.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.button_missionClear.Enabled = false;
            this.button_missionClear.ForeColor = System.Drawing.Color.Black;
            this.button_missionClear.Location = new System.Drawing.Point(323, 159);
            this.button_missionClear.Name = "button_missionClear";
            this.button_missionClear.Size = new System.Drawing.Size(109, 31);
            this.button_missionClear.TabIndex = 17;
            this.button_missionClear.Text = "Clear all";
            this.button_missionClear.UseVisualStyleBackColor = false;
            this.button_missionClear.Click += new System.EventHandler(this.button_missionClear_Click);
            // 
            // button_missionPrepare
            // 
            this.button_missionPrepare.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_missionPrepare.Enabled = false;
            this.button_missionPrepare.ForeColor = System.Drawing.Color.Black;
            this.button_missionPrepare.Location = new System.Drawing.Point(323, 48);
            this.button_missionPrepare.Name = "button_missionPrepare";
            this.button_missionPrepare.Size = new System.Drawing.Size(109, 31);
            this.button_missionPrepare.TabIndex = 8;
            this.button_missionPrepare.Text = "Prepare";
            this.button_missionPrepare.UseVisualStyleBackColor = false;
            this.button_missionPrepare.Click += new System.EventHandler(this.button_missionPrepare_Click);
            // 
            // skinGroupBox3
            // 
            this.skinGroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox3.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox3.Controls.Add(this.dataGridView_mission);
            this.skinGroupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.skinGroupBox3.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox3.Location = new System.Drawing.Point(704, 3);
            this.skinGroupBox3.Name = "skinGroupBox3";
            this.skinGroupBox3.RectBackColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox3.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox3.Size = new System.Drawing.Size(640, 433);
            this.skinGroupBox3.TabIndex = 28;
            this.skinGroupBox3.TabStop = false;
            this.skinGroupBox3.Text = "Waypoints";
            this.skinGroupBox3.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox3.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox3.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridView_mission
            // 
            this.dataGridView_mission.AllowDrop = true;
            this.dataGridView_mission.AllowUserToAddRows = false;
            this.dataGridView_mission.AllowUserToResizeRows = false;
            this.dataGridView_mission.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_mission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_mission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.E,
            this.N,
            this.U,
            this.heading,
            this.up,
            this.down,
            this.delete});
            this.dataGridView_mission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_mission.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_mission.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_mission.Name = "dataGridView_mission";
            this.dataGridView_mission.RowHeadersWidth = 62;
            this.dataGridView_mission.RowTemplate.Height = 24;
            this.dataGridView_mission.Size = new System.Drawing.Size(634, 406);
            this.dataGridView_mission.TabIndex = 3;
            this.dataGridView_mission.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_mission_CellContentClick);
            // 
            // order
            // 
            this.order.HeaderText = "order";
            this.order.MinimumWidth = 8;
            this.order.Name = "order";
            this.order.Width = 150;
            // 
            // E
            // 
            this.E.HeaderText = "E";
            this.E.MinimumWidth = 8;
            this.E.Name = "E";
            this.E.Width = 150;
            // 
            // N
            // 
            this.N.HeaderText = "N";
            this.N.MinimumWidth = 8;
            this.N.Name = "N";
            this.N.Width = 150;
            // 
            // U
            // 
            this.U.HeaderText = "U";
            this.U.MinimumWidth = 8;
            this.U.Name = "U";
            this.U.Width = 150;
            // 
            // heading
            // 
            this.heading.HeaderText = "heading";
            this.heading.MinimumWidth = 8;
            this.heading.Name = "heading";
            this.heading.ReadOnly = true;
            this.heading.Width = 150;
            // 
            // up
            // 
            this.up.HeaderText = "up";
            this.up.MinimumWidth = 8;
            this.up.Name = "up";
            this.up.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.up.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.up.Text = "▲";
            this.up.ToolTipText = "up";
            this.up.Width = 150;
            // 
            // down
            // 
            this.down.HeaderText = "down";
            this.down.MinimumWidth = 8;
            this.down.Name = "down";
            this.down.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.down.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.down.Text = "▼";
            this.down.ToolTipText = "down";
            this.down.Width = 150;
            // 
            // delete
            // 
            this.delete.HeaderText = "delete";
            this.delete.MinimumWidth = 8;
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete.Text = "X";
            this.delete.ToolTipText = "delete";
            this.delete.Width = 150;
            // 
            // gMapControl_WPs
            // 
            this.gMapControl_WPs.Bearing = 0F;
            this.gMapControl_WPs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl_WPs.CanDragMap = true;
            this.gMapControl_WPs.Dock = System.Windows.Forms.DockStyle.Left;
            this.gMapControl_WPs.EmptyTileColor = System.Drawing.Color.Lavender;
            this.gMapControl_WPs.GrayScaleMode = false;
            this.gMapControl_WPs.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl_WPs.LevelsKeepInMemory = 5;
            this.gMapControl_WPs.Location = new System.Drawing.Point(2, 3);
            this.gMapControl_WPs.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gMapControl_WPs.MarkersEnabled = true;
            this.gMapControl_WPs.MaxZoom = 2;
            this.gMapControl_WPs.MinZoom = 2;
            this.gMapControl_WPs.MouseWheelZoomEnabled = true;
            this.gMapControl_WPs.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl_WPs.Name = "gMapControl_WPs";
            this.gMapControl_WPs.NegativeMode = false;
            this.gMapControl_WPs.PolygonsEnabled = true;
            this.gMapControl_WPs.RetryLoadTile = 0;
            this.gMapControl_WPs.RoutesEnabled = true;
            this.gMapControl_WPs.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl_WPs.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl_WPs.ShowTileGridLines = false;
            this.gMapControl_WPs.Size = new System.Drawing.Size(702, 672);
            this.gMapControl_WPs.TabIndex = 1;
            this.gMapControl_WPs.Zoom = 0D;
            this.gMapControl_WPs.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.gMapControl_mission_OnMarkerEnter);
            this.gMapControl_WPs.DoubleClick += new System.EventHandler(this.gMapControl_mission_DoubleClick);
            this.gMapControl_WPs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_mission_MouseClick);
            this.gMapControl_WPs.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl_mission_MouseDown);
            this.gMapControl_WPs.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gMapControl_mission_MouseMove);
            this.gMapControl_WPs.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl_mission_MouseUp);
            // 
            // tabPage_VRP
            // 
            this.tabPage_VRP.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_VRP.Controls.Add(this.skinGroupBox13);
            this.tabPage_VRP.Controls.Add(this.skinGroupBox12);
            this.tabPage_VRP.Controls.Add(this.skinGroupBox14);
            this.tabPage_VRP.Controls.Add(this.gMapControl_VRP);
            this.tabPage_VRP.Location = new System.Drawing.Point(4, 34);
            this.tabPage_VRP.Name = "tabPage_VRP";
            this.tabPage_VRP.Size = new System.Drawing.Size(1346, 678);
            this.tabPage_VRP.TabIndex = 3;
            this.tabPage_VRP.Text = "VRP";
            // 
            // skinGroupBox13
            // 
            this.skinGroupBox13.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox13.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox13.Controls.Add(this.skinButton_VRPadjust);
            this.skinGroupBox13.Controls.Add(this.richTextBox_VRP);
            this.skinGroupBox13.Controls.Add(this.skinButton_outputVRP);
            this.skinGroupBox13.Controls.Add(this.skinButton_optimizeVRP);
            this.skinGroupBox13.Controls.Add(this.skinButton_startPlanVRP);
            this.skinGroupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.skinGroupBox13.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox13.Location = new System.Drawing.Point(796, 446);
            this.skinGroupBox13.Name = "skinGroupBox13";
            this.skinGroupBox13.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox13.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox13.Size = new System.Drawing.Size(550, 232);
            this.skinGroupBox13.TabIndex = 30;
            this.skinGroupBox13.TabStop = false;
            this.skinGroupBox13.Text = "Planning";
            this.skinGroupBox13.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox13.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox13.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinButton_VRPadjust
            // 
            this.skinButton_VRPadjust.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_VRPadjust.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_VRPadjust.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_VRPadjust.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_VRPadjust.DownBack = null;
            this.skinButton_VRPadjust.Enabled = false;
            this.skinButton_VRPadjust.ForeColor = System.Drawing.Color.Black;
            this.skinButton_VRPadjust.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_VRPadjust.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_VRPadjust.Location = new System.Drawing.Point(21, 148);
            this.skinButton_VRPadjust.MouseBack = null;
            this.skinButton_VRPadjust.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_VRPadjust.Name = "skinButton_VRPadjust";
            this.skinButton_VRPadjust.NormlBack = null;
            this.skinButton_VRPadjust.Radius = 30;
            this.skinButton_VRPadjust.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_VRPadjust.Size = new System.Drawing.Size(95, 33);
            this.skinButton_VRPadjust.TabIndex = 36;
            this.skinButton_VRPadjust.Text = "Adjust";
            this.skinButton_VRPadjust.UseVisualStyleBackColor = false;
            this.skinButton_VRPadjust.Click += new System.EventHandler(this.skinButton_VRPadjust_Click);
            // 
            // richTextBox_VRP
            // 
            this.richTextBox_VRP.Dock = System.Windows.Forms.DockStyle.Right;
            this.richTextBox_VRP.Location = new System.Drawing.Point(159, 24);
            this.richTextBox_VRP.Name = "richTextBox_VRP";
            this.richTextBox_VRP.Size = new System.Drawing.Size(388, 205);
            this.richTextBox_VRP.TabIndex = 35;
            this.richTextBox_VRP.Text = "";
            // 
            // skinButton_outputVRP
            // 
            this.skinButton_outputVRP.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_outputVRP.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_outputVRP.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_outputVRP.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_outputVRP.DownBack = null;
            this.skinButton_outputVRP.Enabled = false;
            this.skinButton_outputVRP.ForeColor = System.Drawing.Color.Black;
            this.skinButton_outputVRP.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_outputVRP.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_outputVRP.Location = new System.Drawing.Point(21, 109);
            this.skinButton_outputVRP.MouseBack = null;
            this.skinButton_outputVRP.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_outputVRP.Name = "skinButton_outputVRP";
            this.skinButton_outputVRP.NormlBack = null;
            this.skinButton_outputVRP.Radius = 30;
            this.skinButton_outputVRP.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_outputVRP.Size = new System.Drawing.Size(95, 33);
            this.skinButton_outputVRP.TabIndex = 34;
            this.skinButton_outputVRP.Text = "Finish";
            this.skinButton_outputVRP.UseVisualStyleBackColor = false;
            this.skinButton_outputVRP.Click += new System.EventHandler(this.skinButton_outputVRP_Click);
            // 
            // skinButton_optimizeVRP
            // 
            this.skinButton_optimizeVRP.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_optimizeVRP.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_optimizeVRP.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_optimizeVRP.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_optimizeVRP.DownBack = null;
            this.skinButton_optimizeVRP.Enabled = false;
            this.skinButton_optimizeVRP.ForeColor = System.Drawing.Color.Black;
            this.skinButton_optimizeVRP.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_optimizeVRP.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_optimizeVRP.Location = new System.Drawing.Point(21, 70);
            this.skinButton_optimizeVRP.MouseBack = null;
            this.skinButton_optimizeVRP.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_optimizeVRP.Name = "skinButton_optimizeVRP";
            this.skinButton_optimizeVRP.NormlBack = null;
            this.skinButton_optimizeVRP.Radius = 30;
            this.skinButton_optimizeVRP.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_optimizeVRP.Size = new System.Drawing.Size(95, 33);
            this.skinButton_optimizeVRP.TabIndex = 33;
            this.skinButton_optimizeVRP.Text = "Optimize";
            this.skinButton_optimizeVRP.UseVisualStyleBackColor = false;
            this.skinButton_optimizeVRP.Click += new System.EventHandler(this.skinButton_optimizeVRP_Click);
            // 
            // skinButton_startPlanVRP
            // 
            this.skinButton_startPlanVRP.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_startPlanVRP.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_startPlanVRP.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_startPlanVRP.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_startPlanVRP.DownBack = null;
            this.skinButton_startPlanVRP.ForeColor = System.Drawing.Color.Black;
            this.skinButton_startPlanVRP.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_startPlanVRP.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_startPlanVRP.Location = new System.Drawing.Point(21, 31);
            this.skinButton_startPlanVRP.MouseBack = null;
            this.skinButton_startPlanVRP.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_startPlanVRP.Name = "skinButton_startPlanVRP";
            this.skinButton_startPlanVRP.NormlBack = null;
            this.skinButton_startPlanVRP.Radius = 30;
            this.skinButton_startPlanVRP.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinButton_startPlanVRP.Size = new System.Drawing.Size(95, 33);
            this.skinButton_startPlanVRP.TabIndex = 32;
            this.skinButton_startPlanVRP.Text = "Initiate";
            this.skinButton_startPlanVRP.UseVisualStyleBackColor = false;
            this.skinButton_startPlanVRP.Click += new System.EventHandler(this.skinButton_startPlanVRP_Click);
            // 
            // skinGroupBox12
            // 
            this.skinGroupBox12.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox12.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox12.Controls.Add(this.dataGridView_VRPtarget);
            this.skinGroupBox12.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinGroupBox12.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox12.Location = new System.Drawing.Point(388, 446);
            this.skinGroupBox12.Name = "skinGroupBox12";
            this.skinGroupBox12.RectBackColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox12.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox12.Size = new System.Drawing.Size(408, 232);
            this.skinGroupBox12.TabIndex = 29;
            this.skinGroupBox12.TabStop = false;
            this.skinGroupBox12.Text = "Targets";
            this.skinGroupBox12.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox12.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox12.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridView_VRPtarget
            // 
            this.dataGridView_VRPtarget.AllowDrop = true;
            this.dataGridView_VRPtarget.AllowUserToAddRows = false;
            this.dataGridView_VRPtarget.AllowUserToResizeRows = false;
            this.dataGridView_VRPtarget.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_VRPtarget.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VRPtarget.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.target_ID_VRP,
            this.East_VRP,
            this.North_VRP,
            this.delete_VRP});
            this.dataGridView_VRPtarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_VRPtarget.Enabled = false;
            this.dataGridView_VRPtarget.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_VRPtarget.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_VRPtarget.Name = "dataGridView_VRPtarget";
            this.dataGridView_VRPtarget.RowHeadersWidth = 62;
            this.dataGridView_VRPtarget.RowTemplate.Height = 24;
            this.dataGridView_VRPtarget.Size = new System.Drawing.Size(402, 205);
            this.dataGridView_VRPtarget.TabIndex = 3;
            this.dataGridView_VRPtarget.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_VRPtarget_CellContentClick);
            // 
            // target_ID_VRP
            // 
            this.target_ID_VRP.HeaderText = "target ID";
            this.target_ID_VRP.MinimumWidth = 8;
            this.target_ID_VRP.Name = "target_ID_VRP";
            this.target_ID_VRP.Width = 150;
            // 
            // East_VRP
            // 
            this.East_VRP.HeaderText = "East, x";
            this.East_VRP.MinimumWidth = 8;
            this.East_VRP.Name = "East_VRP";
            this.East_VRP.Width = 150;
            // 
            // North_VRP
            // 
            this.North_VRP.HeaderText = "North, y";
            this.North_VRP.MinimumWidth = 8;
            this.North_VRP.Name = "North_VRP";
            this.North_VRP.Width = 150;
            // 
            // delete_VRP
            // 
            this.delete_VRP.HeaderText = "delete";
            this.delete_VRP.MinimumWidth = 8;
            this.delete_VRP.Name = "delete_VRP";
            this.delete_VRP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete_VRP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.delete_VRP.Text = "X";
            this.delete_VRP.ToolTipText = "delete";
            this.delete_VRP.Width = 150;
            // 
            // skinGroupBox14
            // 
            this.skinGroupBox14.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox14.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox14.Controls.Add(this.dataGridView_VRPagents);
            this.skinGroupBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinGroupBox14.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox14.Location = new System.Drawing.Point(0, 446);
            this.skinGroupBox14.Name = "skinGroupBox14";
            this.skinGroupBox14.RectBackColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox14.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox14.Size = new System.Drawing.Size(388, 232);
            this.skinGroupBox14.TabIndex = 31;
            this.skinGroupBox14.TabStop = false;
            this.skinGroupBox14.Text = "UAVs";
            this.skinGroupBox14.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox14.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox14.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridView_VRPagents
            // 
            this.dataGridView_VRPagents.AllowDrop = true;
            this.dataGridView_VRPagents.AllowUserToAddRows = false;
            this.dataGridView_VRPagents.AllowUserToResizeRows = false;
            this.dataGridView_VRPagents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_VRPagents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_VRPagents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID_uav_VRP,
            this.East_uav_VRP,
            this.North_uav_VRP});
            this.dataGridView_VRPagents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_VRPagents.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_VRPagents.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_VRPagents.Name = "dataGridView_VRPagents";
            this.dataGridView_VRPagents.RowHeadersWidth = 62;
            this.dataGridView_VRPagents.RowTemplate.Height = 24;
            this.dataGridView_VRPagents.Size = new System.Drawing.Size(382, 205);
            this.dataGridView_VRPagents.TabIndex = 3;
            // 
            // ID_uav_VRP
            // 
            this.ID_uav_VRP.HeaderText = "UAV ID";
            this.ID_uav_VRP.MinimumWidth = 8;
            this.ID_uav_VRP.Name = "ID_uav_VRP";
            this.ID_uav_VRP.Width = 150;
            // 
            // East_uav_VRP
            // 
            this.East_uav_VRP.HeaderText = "East, x";
            this.East_uav_VRP.MinimumWidth = 8;
            this.East_uav_VRP.Name = "East_uav_VRP";
            this.East_uav_VRP.Width = 150;
            // 
            // North_uav_VRP
            // 
            this.North_uav_VRP.HeaderText = "North, y";
            this.North_uav_VRP.MinimumWidth = 8;
            this.North_uav_VRP.Name = "North_uav_VRP";
            this.North_uav_VRP.Width = 150;
            // 
            // gMapControl_VRP
            // 
            this.gMapControl_VRP.Bearing = 0F;
            this.gMapControl_VRP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl_VRP.CanDragMap = true;
            this.gMapControl_VRP.Dock = System.Windows.Forms.DockStyle.Top;
            this.gMapControl_VRP.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl_VRP.Enabled = false;
            this.gMapControl_VRP.GrayScaleMode = false;
            this.gMapControl_VRP.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl_VRP.LevelsKeepInMemory = 5;
            this.gMapControl_VRP.Location = new System.Drawing.Point(0, 0);
            this.gMapControl_VRP.MarkersEnabled = true;
            this.gMapControl_VRP.MaxZoom = 2;
            this.gMapControl_VRP.MinZoom = 2;
            this.gMapControl_VRP.MouseWheelZoomEnabled = true;
            this.gMapControl_VRP.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl_VRP.Name = "gMapControl_VRP";
            this.gMapControl_VRP.NegativeMode = false;
            this.gMapControl_VRP.PolygonsEnabled = true;
            this.gMapControl_VRP.RetryLoadTile = 0;
            this.gMapControl_VRP.RoutesEnabled = true;
            this.gMapControl_VRP.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl_VRP.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl_VRP.ShowTileGridLines = false;
            this.gMapControl_VRP.Size = new System.Drawing.Size(1346, 446);
            this.gMapControl_VRP.TabIndex = 0;
            this.gMapControl_VRP.Zoom = 0D;
            this.gMapControl_VRP.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_VRP_MouseClick);
            // 
            // tabPage_SEAD
            // 
            this.tabPage_SEAD.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage_SEAD.Controls.Add(this.skinGroupBox_SEADpara);
            this.tabPage_SEAD.Controls.Add(this.label8);
            this.tabPage_SEAD.Controls.Add(this.skinComboBox_SEAD);
            this.tabPage_SEAD.Controls.Add(this.skinButton_seadMissionConfirm);
            this.tabPage_SEAD.Controls.Add(this.skinGroupBox8);
            this.tabPage_SEAD.Controls.Add(this.skinGroupBox_SEADagents);
            this.tabPage_SEAD.Controls.Add(this.gMapControl_SEAD);
            this.tabPage_SEAD.Location = new System.Drawing.Point(4, 34);
            this.tabPage_SEAD.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_SEAD.Name = "tabPage_SEAD";
            this.tabPage_SEAD.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_SEAD.Size = new System.Drawing.Size(1346, 678);
            this.tabPage_SEAD.TabIndex = 1;
            this.tabPage_SEAD.Text = "SEAD";
            // 
            // skinGroupBox_SEADpara
            // 
            this.skinGroupBox_SEADpara.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox_SEADpara.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox_SEADpara.Controls.Add(this.textBox_SEADpopSize);
            this.skinGroupBox_SEADpara.Controls.Add(this.label13);
            this.skinGroupBox_SEADpara.Controls.Add(this.textBox_SEADu2u);
            this.skinGroupBox_SEADpara.Controls.Add(this.label9);
            this.skinGroupBox_SEADpara.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox_SEADpara.Location = new System.Drawing.Point(1023, 561);
            this.skinGroupBox_SEADpara.Name = "skinGroupBox_SEADpara";
            this.skinGroupBox_SEADpara.RectBackColor = System.Drawing.Color.WhiteSmoke;
            this.skinGroupBox_SEADpara.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox_SEADpara.Size = new System.Drawing.Size(288, 100);
            this.skinGroupBox_SEADpara.TabIndex = 34;
            this.skinGroupBox_SEADpara.TabStop = false;
            this.skinGroupBox_SEADpara.Text = "Parameters";
            this.skinGroupBox_SEADpara.TitleBorderColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox_SEADpara.TitleRectBackColor = System.Drawing.Color.CornflowerBlue;
            this.skinGroupBox_SEADpara.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // textBox_SEADpopSize
            // 
            this.textBox_SEADpopSize.Location = new System.Drawing.Point(134, 58);
            this.textBox_SEADpopSize.Name = "textBox_SEADpopSize";
            this.textBox_SEADpopSize.Size = new System.Drawing.Size(135, 28);
            this.textBox_SEADpopSize.TabIndex = 22;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(51, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 20);
            this.label13.TabIndex = 21;
            this.label13.Text = "pop size :\r\n";
            // 
            // textBox_SEADu2u
            // 
            this.textBox_SEADu2u.Location = new System.Drawing.Point(134, 24);
            this.textBox_SEADu2u.Name = "textBox_SEADu2u";
            this.textBox_SEADu2u.Size = new System.Drawing.Size(135, 28);
            this.textBox_SEADu2u.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(17, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "U2U interval :\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1019, 447);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 33;
            this.label8.Text = "Mission :";
            // 
            // skinComboBox_SEAD
            // 
            this.skinComboBox_SEAD.ArrowColor = System.Drawing.Color.Black;
            this.skinComboBox_SEAD.BackColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_SEAD.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_SEAD.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinComboBox_SEAD.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox_SEAD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.skinComboBox_SEAD.FormattingEnabled = true;
            this.skinComboBox_SEAD.ItemBorderColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_SEAD.ItemHoverForeColor = System.Drawing.Color.AliceBlue;
            this.skinComboBox_SEAD.Location = new System.Drawing.Point(1023, 470);
            this.skinComboBox_SEAD.Name = "skinComboBox_SEAD";
            this.skinComboBox_SEAD.Size = new System.Drawing.Size(198, 29);
            this.skinComboBox_SEAD.TabIndex = 32;
            this.skinComboBox_SEAD.WaterText = "";
            // 
            // skinButton_seadMissionConfirm
            // 
            this.skinButton_seadMissionConfirm.BackColor = System.Drawing.Color.Transparent;
            this.skinButton_seadMissionConfirm.BaseColor = System.Drawing.Color.AliceBlue;
            this.skinButton_seadMissionConfirm.BorderColor = System.Drawing.Color.SteelBlue;
            this.skinButton_seadMissionConfirm.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton_seadMissionConfirm.DownBack = null;
            this.skinButton_seadMissionConfirm.ForeColor = System.Drawing.Color.Black;
            this.skinButton_seadMissionConfirm.GlowColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_seadMissionConfirm.InnerBorderColor = System.Drawing.Color.Gray;
            this.skinButton_seadMissionConfirm.Location = new System.Drawing.Point(1242, 470);
            this.skinButton_seadMissionConfirm.MouseBack = null;
            this.skinButton_seadMissionConfirm.MouseBaseColor = System.Drawing.Color.CornflowerBlue;
            this.skinButton_seadMissionConfirm.Name = "skinButton_seadMissionConfirm";
            this.skinButton_seadMissionConfirm.NormlBack = null;
            this.skinButton_seadMissionConfirm.Size = new System.Drawing.Size(90, 29);
            this.skinButton_seadMissionConfirm.TabIndex = 31;
            this.skinButton_seadMissionConfirm.Text = "confirm";
            this.skinButton_seadMissionConfirm.UseVisualStyleBackColor = false;
            this.skinButton_seadMissionConfirm.Click += new System.EventHandler(this.skinButton_seadMissionConfirm_Click);
            // 
            // skinGroupBox8
            // 
            this.skinGroupBox8.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox8.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox8.Controls.Add(this.dataGridView_seadTargets);
            this.skinGroupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinGroupBox8.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox8.Location = new System.Drawing.Point(597, 433);
            this.skinGroupBox8.Name = "skinGroupBox8";
            this.skinGroupBox8.RectBackColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox8.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox8.Size = new System.Drawing.Size(397, 242);
            this.skinGroupBox8.TabIndex = 30;
            this.skinGroupBox8.TabStop = false;
            this.skinGroupBox8.Text = "Targets";
            this.skinGroupBox8.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox8.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox8.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridView_seadTargets
            // 
            this.dataGridView_seadTargets.AllowDrop = true;
            this.dataGridView_seadTargets.AllowUserToAddRows = false;
            this.dataGridView_seadTargets.AllowUserToResizeRows = false;
            this.dataGridView_seadTargets.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_seadTargets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_seadTargets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Target_ID,
            this.coordinates,
            this.known_target});
            this.dataGridView_seadTargets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_seadTargets.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_seadTargets.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_seadTargets.Name = "dataGridView_seadTargets";
            this.dataGridView_seadTargets.RowHeadersWidth = 62;
            this.dataGridView_seadTargets.RowTemplate.Height = 24;
            this.dataGridView_seadTargets.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView_seadTargets.Size = new System.Drawing.Size(391, 215);
            this.dataGridView_seadTargets.TabIndex = 3;
            // 
            // Target_ID
            // 
            this.Target_ID.HeaderText = "Target ID";
            this.Target_ID.MinimumWidth = 8;
            this.Target_ID.Name = "Target_ID";
            this.Target_ID.Width = 120;
            // 
            // coordinates
            // 
            this.coordinates.HeaderText = "Coordinates";
            this.coordinates.MinimumWidth = 8;
            this.coordinates.Name = "coordinates";
            this.coordinates.Width = 150;
            // 
            // known_target
            // 
            this.known_target.HeaderText = "Type";
            this.known_target.MinimumWidth = 8;
            this.known_target.Name = "known_target";
            this.known_target.Width = 150;
            // 
            // skinGroupBox_SEADagents
            // 
            this.skinGroupBox_SEADagents.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox_SEADagents.BorderColor = System.Drawing.Color.Black;
            this.skinGroupBox_SEADagents.Controls.Add(this.dataGridView_seadAgents);
            this.skinGroupBox_SEADagents.Dock = System.Windows.Forms.DockStyle.Left;
            this.skinGroupBox_SEADagents.ForeColor = System.Drawing.Color.White;
            this.skinGroupBox_SEADagents.Location = new System.Drawing.Point(2, 433);
            this.skinGroupBox_SEADagents.Name = "skinGroupBox_SEADagents";
            this.skinGroupBox_SEADagents.RectBackColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox_SEADagents.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox_SEADagents.Size = new System.Drawing.Size(595, 242);
            this.skinGroupBox_SEADagents.TabIndex = 29;
            this.skinGroupBox_SEADagents.TabStop = false;
            this.skinGroupBox_SEADagents.Text = "Agents";
            this.skinGroupBox_SEADagents.TitleBorderColor = System.Drawing.Color.Black;
            this.skinGroupBox_SEADagents.TitleRectBackColor = System.Drawing.Color.Gray;
            this.skinGroupBox_SEADagents.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // dataGridView_seadAgents
            // 
            this.dataGridView_seadAgents.AllowDrop = true;
            this.dataGridView_seadAgents.AllowUserToAddRows = false;
            this.dataGridView_seadAgents.AllowUserToResizeRows = false;
            this.dataGridView_seadAgents.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_seadAgents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_seadAgents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UAV_ID,
            this.type,
            this.cruise_speed,
            this.Rmin,
            this.initial_pos,
            this.base_pos});
            this.dataGridView_seadAgents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_seadAgents.Location = new System.Drawing.Point(3, 24);
            this.dataGridView_seadAgents.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridView_seadAgents.Name = "dataGridView_seadAgents";
            this.dataGridView_seadAgents.RowHeadersWidth = 62;
            this.dataGridView_seadAgents.RowTemplate.Height = 24;
            this.dataGridView_seadAgents.Size = new System.Drawing.Size(589, 215);
            this.dataGridView_seadAgents.TabIndex = 3;
            // 
            // UAV_ID
            // 
            this.UAV_ID.HeaderText = "UAV ID";
            this.UAV_ID.MinimumWidth = 8;
            this.UAV_ID.Name = "UAV_ID";
            this.UAV_ID.Width = 150;
            // 
            // type
            // 
            this.type.HeaderText = "Type";
            this.type.MinimumWidth = 8;
            this.type.Name = "type";
            this.type.Width = 150;
            // 
            // cruise_speed
            // 
            this.cruise_speed.HeaderText = "Cruise speed";
            this.cruise_speed.MinimumWidth = 8;
            this.cruise_speed.Name = "cruise_speed";
            this.cruise_speed.Width = 150;
            // 
            // Rmin
            // 
            this.Rmin.HeaderText = "Rmin";
            this.Rmin.MinimumWidth = 8;
            this.Rmin.Name = "Rmin";
            this.Rmin.Width = 150;
            // 
            // initial_pos
            // 
            this.initial_pos.HeaderText = "initial position";
            this.initial_pos.MinimumWidth = 8;
            this.initial_pos.Name = "initial_pos";
            this.initial_pos.Width = 150;
            // 
            // base_pos
            // 
            this.base_pos.HeaderText = "base";
            this.base_pos.MinimumWidth = 8;
            this.base_pos.Name = "base_pos";
            this.base_pos.Width = 150;
            // 
            // gMapControl_SEAD
            // 
            this.gMapControl_SEAD.Bearing = 0F;
            this.gMapControl_SEAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gMapControl_SEAD.CanDragMap = true;
            this.gMapControl_SEAD.Dock = System.Windows.Forms.DockStyle.Top;
            this.gMapControl_SEAD.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl_SEAD.GrayScaleMode = false;
            this.gMapControl_SEAD.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl_SEAD.LevelsKeepInMemory = 5;
            this.gMapControl_SEAD.Location = new System.Drawing.Point(2, 3);
            this.gMapControl_SEAD.MarkersEnabled = true;
            this.gMapControl_SEAD.MaxZoom = 2;
            this.gMapControl_SEAD.MinZoom = 2;
            this.gMapControl_SEAD.MouseWheelZoomEnabled = true;
            this.gMapControl_SEAD.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl_SEAD.Name = "gMapControl_SEAD";
            this.gMapControl_SEAD.NegativeMode = false;
            this.gMapControl_SEAD.PolygonsEnabled = true;
            this.gMapControl_SEAD.RetryLoadTile = 0;
            this.gMapControl_SEAD.RoutesEnabled = true;
            this.gMapControl_SEAD.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl_SEAD.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl_SEAD.ShowTileGridLines = false;
            this.gMapControl_SEAD.Size = new System.Drawing.Size(1342, 430);
            this.gMapControl_SEAD.TabIndex = 0;
            this.gMapControl_SEAD.Zoom = 0D;
            // 
            // tabPage_Simulator
            // 
            this.tabPage_Simulator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tabPage_Simulator.BorderColor = System.Drawing.Color.DimGray;
            this.tabPage_Simulator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage_Simulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPage_Simulator.Location = new System.Drawing.Point(0, 40);
            this.tabPage_Simulator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage_Simulator.Name = "tabPage_Simulator";
            this.tabPage_Simulator.Size = new System.Drawing.Size(1360, 724);
            this.tabPage_Simulator.TabIndex = 2;
            this.tabPage_Simulator.TabItemImage = null;
            this.tabPage_Simulator.Text = "Simulator";
            // 
            // GCS_5895
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Back = ((System.Drawing.Image)(resources.GetObject("$this.Back")));
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackToColor = false;
            this.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1368, 796);
            this.Controls.Add(this.tabControl_main);
            this.Font = new System.Drawing.Font("Times New Roman", 9F);
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MdiBorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "GCS_5895";
            this.Text = "GCS_5895";
            this.TitleSuitColor = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GCS_5895_FormClosing);
            this.Resize += new System.EventHandler(this.GCS_5895_Resize);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_GCS.ResumeLayout(false);
            this.skinGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_flghtData)).EndInit();
            this.skinPanel1.ResumeLayout(false);
            this.skinGroupBox2.ResumeLayout(false);
            this.tabControl_action.ResumeLayout(false);
            this.tabPage_command.ResumeLayout(false);
            this.skinGroupBox7.ResumeLayout(false);
            this.skinGroupBox6.ResumeLayout(false);
            this.skinGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox2)).EndInit();
            this.tabPage_guide.ResumeLayout(false);
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.Plan.ResumeLayout(false);
            this.Plan.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabPage_missionStart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.skinGroupBox11.ResumeLayout(false);
            this.tabPage_setting.ResumeLayout(false);
            this.skinGroupBox15.ResumeLayout(false);
            this.skinGroupBox9.ResumeLayout(false);
            this.skinGroupBox5.ResumeLayout(false);
            this.tabPage_FlightPlan.ResumeLayout(false);
            this.tabControl_mission.ResumeLayout(false);
            this.tabPage_WPs.ResumeLayout(false);
            this.skinGroupBox10.ResumeLayout(false);
            this.skinGroupBox10.PerformLayout();
            this.skinGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_mission)).EndInit();
            this.tabPage_VRP.ResumeLayout(false);
            this.skinGroupBox13.ResumeLayout(false);
            this.skinGroupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VRPtarget)).EndInit();
            this.skinGroupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_VRPagents)).EndInit();
            this.tabPage_SEAD.ResumeLayout(false);
            this.tabPage_SEAD.PerformLayout();
            this.skinGroupBox_SEADpara.ResumeLayout(false);
            this.skinGroupBox_SEADpara.PerformLayout();
            this.skinGroupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_seadTargets)).EndInit();
            this.skinGroupBox_SEADagents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_seadAgents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private CCWin.SkinControl.SkinTabPage tabPage_GCS;
        private CCWin.SkinControl.SkinTabPage tabPage_FlightPlan;
        private CCWin.SkinControl.SkinTabPage tabPage_Simulator;
        private System.Windows.Forms.RichTextBox textBox_info;
        private System.Windows.Forms.TabControl tabControl_mission;
        private System.Windows.Forms.TabPage tabPage_WPs;
        private System.Windows.Forms.DataGridView dataGridView_mission;
        private GMap.NET.WindowsForms.GMapControl gMapControl_WPs;
        private System.Windows.Forms.TabPage tabPage_SEAD;
        private System.Windows.Forms.TabControl tabControl_action;
        private System.Windows.Forms.TabPage tabPage_command;
        private System.Windows.Forms.Button button_Publish;
        private System.Windows.Forms.ComboBox comboBox_Command;
        private System.Windows.Forms.CheckBox checkBox_allUAVselect;
        private System.Windows.Forms.TabPage tabPage_guide;
        private System.Windows.Forms.TabPage tabPage_missionStart;
        private System.Windows.Forms.Button button_missionPrepare;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_missionTypeMission;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_missionUAV;
        private System.Windows.Forms.Button button_missionClear;
        private System.Windows.Forms.Button button_missionConfirm;
        private System.Windows.Forms.Button button_missionCancel;
        private System.Windows.Forms.Button button_startMission;
        private PresentationControls.CheckBoxComboBox checkBoxComboBox_UAVselect;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinButton skinButton_adjustMission;
        private CCWin.SkinControl.SkinComboBox skinComboBox_PubMission;
        private System.Windows.Forms.TextBox textBox_WPguided;
        private System.Windows.Forms.LinkLabel linkLabel_missionConfig;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_missionMethod;
        private CCWin.SkinControl.SkinButton skinButton_missionStart;
        private CCWin.SkinControl.SkinTabControl tabControl_main;
        private System.Windows.Forms.Label label_HorYaw;
        private System.Windows.Forms.TextBox textBox_missionHeight;
        private GMap.NET.WindowsForms.GMapControl gMapControl_SEAD;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox2;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox3;
        private System.Windows.Forms.Button button_guideClear;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_WPconfirm;
        private System.Windows.Forms.ComboBox comboBox_guideWP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_wpU;
        private System.Windows.Forms.TextBox textBox_wpN;
        private System.Windows.Forms.TextBox textBox_wpE;
        private System.Windows.Forms.GroupBox Plan;
        private CCWin.SkinControl.SkinPanel skinPanel1;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.ComboBox comboBox_PortOrBaud;
        private System.Windows.Forms.ComboBox comboBox_connectOption;
        private System.Windows.Forms.ComboBox comboBox_mapCenter;
        private System.Windows.Forms.ComboBox comboBox_routeDisplay;
        private GMap.NET.WindowsForms.GMapControl gMapControl_main;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox4;
        private System.Windows.Forms.DataGridView dataGridView_flghtData;
        private System.Windows.Forms.Button button_sortDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_FreqConfirm;
        private System.Windows.Forms.ComboBox comboBox_u2gFreq;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox5;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox7;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox6;
        private System.Windows.Forms.Button button_takeoff;
        private ColorSlider.ColorSlider colorSlider_takeoff;
        private CCWin.SkinControl.SkinButton skinButton_RTL;
        private CCWin.SkinControl.SkinButton skinButton_HOLD;
        private System.Windows.Forms.TabPage tabPage_VRP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_missionHeading;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn E;
        private System.Windows.Forms.DataGridViewTextBoxColumn N;
        private System.Windows.Forms.DataGridViewTextBoxColumn U;
        private System.Windows.Forms.DataGridViewTextBoxColumn heading;
        private System.Windows.Forms.DataGridViewButtonColumn up;
        private System.Windows.Forms.DataGridViewButtonColumn down;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private CCWin.SkinControl.SkinButton skinButton_loiter;
        private System.Windows.Forms.Label label8;
        private CCWin.SkinControl.SkinComboBox skinComboBox_SEAD;
        private CCWin.SkinControl.SkinButton skinButton_seadMissionConfirm;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox8;
        private System.Windows.Forms.DataGridView dataGridView_seadTargets;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox_SEADagents;
        private System.Windows.Forms.DataGridView dataGridView_seadAgents;
        private System.Windows.Forms.DataGridViewTextBoxColumn UAV_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn cruise_speed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rmin;
        private System.Windows.Forms.DataGridViewTextBoxColumn initial_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn base_pos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Target_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordinates;
        private System.Windows.Forms.DataGridViewTextBoxColumn known_target;
        private CCWin.SkinControl.SkinButton skinButton_goToInitPos;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox2;
        private System.Windows.Forms.Button button_test;
        private CCWin.SkinControl.SkinButton skinButton_land;
        private System.Windows.Forms.TabPage tabPage_setting;
        private CCWin.SkinControl.SkinButton skinButton_disarm;
        private CCWin.SkinControl.SkinButton skinButton_arm;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox9;
        private System.Windows.Forms.Button button_tineRecalibrate;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox10;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox11;
        private PulseButton.PulseButton pulseButton_clear;
        private PulseButton.PulseButton pulseButton_cancel;
        private CCWin.SkinControl.SkinButton skinButton_pubWP;
        private CCWin.SkinControl.SkinButton skinButton_clearWPs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_wpYaw;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinButton skinButton_abort;
        private System.Windows.Forms.Button button_clearDataGrid;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox13;
        private CCWin.SkinControl.SkinButton skinButton_outputVRP;
        private CCWin.SkinControl.SkinButton skinButton_optimizeVRP;
        private CCWin.SkinControl.SkinButton skinButton_startPlanVRP;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox12;
        private System.Windows.Forms.DataGridView dataGridView_VRPtarget;
        private GMap.NET.WindowsForms.GMapControl gMapControl_VRP;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox_SEADpara;
        private System.Windows.Forms.TextBox textBox_SEADpopSize;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_SEADu2u;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox_VRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_ID_VRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn East_VRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn North_VRP;
        private System.Windows.Forms.DataGridViewButtonColumn delete_VRP;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox14;
        private System.Windows.Forms.DataGridView dataGridView_VRPagents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID_uav_VRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn East_uav_VRP;
        private System.Windows.Forms.DataGridViewTextBoxColumn North_uav_VRP;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox15;
        private System.Windows.Forms.ComboBox comboBox_origin;
        private System.Windows.Forms.Button button_originConfirm;
        private CCWin.SkinControl.SkinButton skinButton_VRPadjust;
    }
}

