using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin;

namespace GCS_5895
{
    public partial class waypointsMissionConfig : CCSkinMain
    {
        private Waypoints Mission;

        public waypointsMissionConfig(Waypoints Mission)
        {
            InitializeComponent();
            this.Mission = Mission;
            numericUpDown_WPradius.Value = Mission.waypointRadius;
            // CraigReynold's Path Following
            comboBox_controlMethod.Text = Mission_setting.pathFollowingMethod_name.FirstOrDefault
                (m => m.Value == Mission.pathFollowing_method).Key;
            comboBox_controlMethod.Items.AddRange(Mission_setting.pathFollowingMethod_name.Keys.ToArray());
            skinTrackBar_recedingSec.Value = Mission.recedingHorizon;
            label_recedingSec.Text = $"{(double)Mission.recedingHorizon / 10} (sec)";
            textBox_Kp.Text = $"{Mission.Kp}";
            textBox_Kd.Text = $"{Mission.Kd}";
            textBox_V.Text = $"{Mission.V}";
            textBox_Rmin.Text = $"{Mission.Rmin}";
        }

        private void skinButton_confirm_Click(object sender, EventArgs e)
        {
            Mission.waypointRadius = (int)numericUpDown_WPradius.Value;
            Mission.pathFollowing_method = Mission_setting.pathFollowingMethod_name[comboBox_controlMethod.Text];
            Mission.recedingHorizon = skinTrackBar_recedingSec.Value;
            try
            {
                Mission.Kp = double.Parse(textBox_Kp.Text);
                Mission.Kd = double.Parse(textBox_Kd.Text);
                Mission.V = double.Parse(textBox_V.Text);
                Mission.Rmin = double.Parse(textBox_Rmin.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
        }

        private void skinTrackBar_recedingSec_ValueChanged(object sender, EventArgs e)
        {
            label_recedingSec.Text = $"{(double)skinTrackBar_recedingSec.Value / 10} (sec)";
        }
    }
}
