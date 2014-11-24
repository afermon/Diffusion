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
    public partial class send : Form
    {
        private MainForm mdiParent;

        public send(MainForm m1_)
        {
            InitializeComponent();
            this.mdiParent = m1_;
            CLBsectores.Items.Clear();
            foreach (DataRow sectors in this.clientsTableAdapter.GetSectors().Rows)
            {
                if (sectors["ClientSector"].ToString() == "")
                {
                    this.CLBsectores.Items.Add("NO ESPECIFICADO");
                }
                else
                {
                    this.CLBsectores.Items.Add(sectors["ClientSector"].ToString());
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }

        private void send_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.mdiParent.pendientes = true;

        }

        private void TBmessage_TextChanged(object sender, EventArgs e)
        {
            LBleft.Text = "( " + (160 - TBmessage.Text.Length).ToString() + " Restantes )";
        }

        private void BTNselectall_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBsectores.Items.Count; i++)
            {
                CLBsectores.SetItemChecked(i, true);
            }
        }

        private void BNTselectnone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CLBsectores.Items.Count; i++)
            {
                CLBsectores.SetItemChecked(i, false);
            }
        }

        private void BTNcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BTNsend_Click(object sender, EventArgs e)
        {
            if (TBmessage.TextLength > 0 & CLBsectores.CheckedItems.Count > 0)
            {
                BTNsend.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                foreach (string st in CLBsectores.CheckedItems)
                {
                    clientsTableAdapter.UpdateClientsToInform(true, TBmessage.Text, st);
                }
                BTNsend.Enabled = true;
                Cursor.Current = Cursors.Default;
                this.Close();
            }
            else {
                MessageBox.Show(this, "EL SMS no se puede enviar en blanco o sin destinatarios.", "Error!", MessageBoxButtons.OK ,MessageBoxIcon.Error);
            }
        }

    }
}
