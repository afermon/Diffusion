using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diffusion_2
{
    public partial class config : Form
    {
        public config()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void config_Load(object sender, EventArgs e)
        {
            CBbaudrate.SelectedItem = Properties.Settings.Default.BaudRate.ToString();
            CBtimeout.SelectedItem = Properties.Settings.Default.TimeOut.ToString();
            NUDdelay.Value = Properties.Settings.Default.DelaySms;
            LBsmsenviados.Text = Properties.Settings.Default.AppSMSsent.ToString() + " SMS enviados.";
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BaudRate = Convert.ToInt32(CBbaudrate.SelectedItem.ToString());
            Properties.Settings.Default.TimeOut = Convert.ToInt32(CBtimeout.SelectedItem.ToString());
            Properties.Settings.Default.DelaySms = Convert.ToInt32(NUDdelay.Value);
            Properties.Settings.Default.Save();
            MessageBox.Show("Guardado correctamente.");
            this.Close();
        }
    }
}
