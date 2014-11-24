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
    public partial class working : Form
    {
        public working()
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

        public string[] addclient {
            set { UpdateDataGrid(value); }
        }
        public bool SetStatus {
            set { Status(value); }
        }

        private void UpdateDataGrid(string[] client) {
            DGWworking.Rows.Insert(0, client);
        }

        private void Status(bool st) {
            if (st)
            {
                DGWworking.Rows[0].DefaultCellStyle.BackColor = Color.Olive;
                DGWworking.Rows[0].Cells[3].Value = "Enviado!";
            }
            else
            {
                DGWworking.Rows[0].DefaultCellStyle.BackColor = Color.Orange;
                DGWworking.Rows[0].Cells[3].Value = "Numero erroneo!";
            }
        }
    }
}
