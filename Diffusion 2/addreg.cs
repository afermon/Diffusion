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
    public partial class addreg : Form
    {
        private int ID;
        private bool edit = false;
        public addreg(int _ID)
        {
            InitializeComponent();
            if (_ID != -10) {
                edit = true;
                ID = _ID;
                BtnGuardar.Text = "Actualizar";
            } 
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (edit) {
                clientsTableAdapterA.UpdateClient(tbnabonado.Text.ToString(), TBcedula.Text.ToString(), TBnombre.Text.ToString(), TBdireccion.Text.ToString(), CBNsectores.SelectedItem.ToString(), tbcelular.Text, ID);
                this.Close();
            }
            else
            {
                clientsTableAdapterA.InsertClient(tbnabonado.Text.ToString(), TBcedula.Text.ToString(), TBnombre.Text.ToString(), TBdireccion.Text.ToString(), CBNsectores.SelectedItem.ToString(), tbcelular.Text);
                this.Close();
            }
        }

        private void addreg_Load(object sender, EventArgs e)
        {
            CBNsectores.Items.Clear();
            foreach (DataRow sectors in this.clientsTableAdapterA.GetSectors().Rows)
            {
                if (sectors["ClientSector"].ToString() != ""){
                    this.CBNsectores.Items.Add(sectors["ClientSector"].ToString());
                }
            }
            if (edit)
            {
                DataTable DTclient = this.clientsTableAdapterA.GetClient(ID);
                DataRow DRclient = DTclient.Rows[0];
                tbnabonado.Text = DRclient["ClientNumber"].ToString();
                TBcedula.Text = DRclient["ClientID"].ToString();
                TBnombre.Text = DRclient["ClientName"].ToString();
                TBdireccion.Text = DRclient["ClientAddress"].ToString();
                CBNsectores.SelectedItem = DRclient["ClientSector"].ToString();
                tbcelular.Text = DRclient["ClientPhone"].ToString();
            }
        }
    }
}
