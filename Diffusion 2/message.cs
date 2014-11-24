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
    public partial class message : Form
    {
        private string name;
        private int index;
        public message(string _name, int _index)
        {
            InitializeComponent();
            name = _name;
            index = _index;
            LBname.Text = name;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            Form addreg = new addreg(index);
            addreg.MdiParent = this.MdiParent;
            addreg.Show();
            this.Close();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            DialogResult resultsend = MessageBox.Show(this, "Desea eliminar a " + name + " de los registros?", "Esta seguro de eliminar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultsend == DialogResult.Yes)
            {
                clientsTableAdapter.DeleteAbonado(index);
                MessageBox.Show("Eliminado correctamente!");
            }
            this.Close();
        }
    }
}
