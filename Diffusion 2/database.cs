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
    public partial class database : Form
    {
        private string Query; 
        private string Type;

        public database(string _Query, string _Type)
        {
            InitializeComponent();
            Query = _Query;
            Type = _Type;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.BringToFront();
        }
        private void database_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            switch (Type) {
                case "1":
                    this.clientsTableAdapter.FilterByClientNumber(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "2":
                    this.clientsTableAdapter.FilterByClientId(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "3":
                    this.clientsTableAdapter.FilterByClientName(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "4":
                    this.clientsTableAdapter.FilterByClientAddress(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "5":
                    this.clientsTableAdapter.FilterByClientSector(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "6":
                    this.clientsTableAdapter.FilterByClientPhone(this.diffusion_DataBaseDataSet.Clients, Query);
                    break;
                case "7":
                    this.clientsTableAdapter.FilterBySend(this.diffusion_DataBaseDataSet.Clients);
                    break;
                default:
                    this.clientsTableAdapter.Fill(this.diffusion_DataBaseDataSet.Clients);
                    break;
            }
            DGVdatabase.Sort(DGVdatabase.Columns[Convert.ToInt32(Type)], ListSortDirection.Descending);
            Cursor.Current = Cursors.Default;
        }

        private void DGVdatabase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int ID = Convert.ToInt32(DGVdatabase.Rows[e.RowIndex].Cells[0].Value.ToString());
            Form mess = new message(DGVdatabase.Rows[e.RowIndex].Cells[3].Value.ToString(), ID);
            mess.MdiParent = this.MdiParent;
            mess.Show();
            this.Close();
        }

    }
}
