using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Diagnostics;



namespace Diffusion_2
{
    public partial class MainForm : RibbonForm
    {
        private string portName = "COM1";
        private int baudRate = Properties.Settings.Default.BaudRate;
        private int timeout = Properties.Settings.Default.TimeOut;
        private GsmCommMain comm;
        private working Working;

        public MainForm()
        {
            InitializeComponent();
            CBfiltrocolumna.SelectedItem = FRBabonado;
        }

        public bool pendientes
        {
            set {UpdateLBpendientes();}
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Desea cerrar Diffusion?", "Confirmación", MessageBoxButtons.YesNo))
            {
                this.Close();
            }
        }

        private void BtnInfo_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(info))
                {
                    f.Activate();
                    return;
                }
            }
            Form info = new info();
            info.MdiParent = this;
            info.Show();
        }

        private void BtnCerrarVentanas_Click(object sender, EventArgs e)
        {
            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }
        }

        private void RBaddreg_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(addreg))
                {
                    f.Activate();
                    return;
                }
            }
            Form addreg = new addreg(-10);
            addreg.MdiParent = this;
            addreg.Show();
        }

        private void RBPuertos_Click(object sender, EventArgs e)
        {
            RBPuertos.Enabled = false;
            string[] ports = SerialPort.GetPortNames();
            RCBPuerto.DropDownItems.Clear();
            if (ports.Length == 0)
            {
                MessageBox.Show(this, "Por favor conecte el modem e intentelo nuevamente.", "No se encontraron dispositivos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RCBPuerto.DropDownItems.Add(Pninguno);
                RCBPuerto.SelectedItem = Pninguno;
            }
            else
            {
                foreach (string port in ports)
                {
                    Cursor.Current = Cursors.WaitCursor;
                    comm = new GsmCommMain(port, baudRate, timeout);
                    try
                    {
                        comm.Open();
                        if(comm.IsConnected())
                        {
                            IdentificationInfo dinfo = comm.IdentifyDevice();
                            RibbonButton puerto = new RibbonButton();
                            puerto.Tag = port;
                            puerto.Text = dinfo.Manufacturer.ToUpper() + " " + dinfo.Model + " (" + port + ")";
                            puerto.SmallImage = Diffusion_2.Properties.Resources.password_16;
                            RCBPuerto.DropDownItems.Add(puerto);
                            RCBPuerto.SelectedItem = puerto;
                        }
                        comm.Close();
                    }
                    catch (Exception ex)
                    {
                        //LOG
                    }
                }
            }
            RBPuertos.Enabled = true;
            RBtnConectar.Enabled = true;
        }

        private void RBtnConectar_Click(object sender, EventArgs e)
        {
            RBtnConectar.Enabled = false;
            portName = RCBPuerto.SelectedItem.Tag.ToString();
            Cursor.Current = Cursors.WaitCursor;
			comm = new GsmCommMain(portName, baudRate, timeout);
			Cursor.Current = Cursors.Default;
			//comm.PhoneConnected += new EventHandler(comm_PhoneConnected);
			//comm.PhoneDisconnected += new EventHandler(comm_PhoneDisconnected);
			try
			{
				Cursor.Current = Cursors.WaitCursor;
				comm.Open();
				Cursor.Current = Cursors.Default;
                IdentificationInfo dinfo = comm.IdentifyDevice();
                RLmarca.Text = "Marca: " + dinfo.Manufacturer.ToUpper();
                RLmodelo.Text = "Modelo: " + dinfo.Model;
                RLserie.Text = dinfo.SerialNumber;
                RBtnDesconectar.Enabled = true;
                RPDispositivo.Enabled = true;
                RCBPuerto.Enabled = false;
                RBPuertos.Enabled = false;
			}
			catch(Exception)
			{
                RBtnConectar.Enabled = true;
				Cursor.Current = Cursors.Default;
				MessageBox.Show(this, "No se pudo conectar a ese puerto!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
        }

        private void RBtnDesconectar_Click(object sender, EventArgs e)
        {
            comm.Close();
            RBtnDesconectar.Enabled = false;
            RBtnConectar.Enabled = true;
            RBPuertos.Enabled = true;
            RPDispositivo.Enabled = false;
            RCBPuerto.Enabled = true;
        }

        private void RBdatabase_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(database))
                {
                    f.Activate();
                    return;
                }
            }
            Form database = new database(null,"0");
            database.MdiParent = this;
            database.Show();
        }

        private void RBexportar_Click(object sender, EventArgs e)
        {
            SFDexport.Filter = "Excel 97-2003(*.xls)|*.xls";
            SFDexport.FileName = "import";
            if (this.SFDexport.ShowDialog() == DialogResult.OK)
            {
                if (SFDexport.FileName != "")
                {
                    File.Copy(Directory.GetCurrentDirectory() + "\\import.xls", SFDexport.FileName);
                }
            }
        }

        private void RBimportar_Click(object sender, EventArgs e)
        {
            if (this.OFDimport.ShowDialog() == DialogResult.OK)
            {
                DialogResult resultsend = MessageBox.Show(this, "Si los datos estan correctamente en el formato proceda. Recuerde el orden: Numero de abonado / cedula / Nombre / Direccion/ Sector / telefono. Ademas el telefono y el sector son obligatorios asi como la primera fila corresponde a los titulos.", "Esta seguro de Importar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultsend == DialogResult.Yes)
                {
                    if (System.IO.File.Exists(OFDimport.FileName))
                    {
                        BWimport.RunWorkerAsync();
                    }
                }
            }
        }

        private void BWimport_DoWork(object sender, DoWorkEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RBimportar.Image = Diffusion_2.Properties.Resources._154;
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(database))
                {
                    f.Close();
                }
            }
            string result = "";
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Open(OFDimport.FileName);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];
            Excel.Range range = worksheet.UsedRange;
            if ((range.Cells[1, 1] as Excel.Range).Value2.ToString() == "Abonado" &
                (range.Cells[1, 2] as Excel.Range).Value2.ToString() == "Cedula" &
                (range.Cells[1, 3] as Excel.Range).Value2.ToString() == "Nombre" &
                (range.Cells[1, 4] as Excel.Range).Value2.ToString() == "Direccion" &
                (range.Cells[1, 5] as Excel.Range).Value2.ToString() == "Sector" &
                (range.Cells[1, 6] as Excel.Range).Value2.ToString() == "Telefono")
            {
                for (int client = 2; client <= range.Rows.Count; client++)
                {
                    if (clientsTableAdapterM.CheckNumber((range.Cells[client, 6] as Excel.Range).Value2.ToString()) == 0)
                    {
                        clientsTableAdapterM.InsertClient((range.Cells[client, 1] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 2] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 3] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 4] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 5] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 6] as Excel.Range).Value2.ToString());

                    }
                    else
                    {
                        result = result + "\n\t" + (range.Cells[client, 3] as Excel.Range).Value2.ToString();
                    }
                    if (BWimport.CancellationPending)
                    {
                        e.Cancel = true;
                        Cursor.Current = Cursors.Default;
                        return;
                    }
                }
                if (result != "") {
                    MessageBox.Show("Los siguientes Abonados ya se encontraban en la base de datos: \n\t" + result);
                }
                Cursor.Current = Cursors.Default;
            }
            else
            {
                MessageBox.Show(this, "Por favor intente exportar el formato desde el programa y luego agregar los datos en el excel. No modifique los nombres de las columnas y mantenga el orden de las mismas.", "Formato incorrecto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            workbook.Close(true, Missing.Value, Missing.Value);
            excelApp.Quit();
            RBimportar.Image = Diffusion_2.Properties.Resources._146;
        }

        private void BWimport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RBactualizarabonados.PerformClick();
        }

        private void RBactualizarabonados_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(database))
                {
                    f.Close();
                    Form database = new database(null, "0");
                    database.MdiParent = this;
                    database.Show();
                    return;
                }
            }
        }

        private void RBbuscar_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(database))
                {
                    f.Close();
                } 
                
            }
            Form database = new database(RTBquery.TextBoxText, CBfiltrocolumna.SelectedItem.Tag.ToString());
            database.MdiParent = this;
            database.Show();
        }

        private void RTBquery_TextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RBbuscar.PerformClick();
            }
        }

        private void RBsoporte_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.fermongroup.com/es/contacto.html");
        }

        private void RBtnpagweb_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.fermongroup.com");
        }

        private void RBconfig_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(config))
                {
                    f.Activate();
                    return;
                }
            }
            Form config = new config();
            config.MdiParent = this;
            config.Show();
        }

        private void RBnewmessage_Click(object sender, EventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == typeof(send))
                {
                    f.Activate();
                    return;
                }
            }
            Form send = new send(this);
            send.MdiParent = this;
            send.Show();
        }

        private void RBTNsendsms_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Desea enviar " + clientsTableAdapterM.GetPendingCount().ToString() + " mensajes programados?", "Mensajes programados!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                if (BWsend.IsBusy != true)
                {
                    BWsend.RunWorkerAsync();
                    PBsend.Maximum = Convert.ToInt32(clientsTableAdapterM.GetPendingCount());
                    foreach (Form f in this.MdiChildren)
                    {
                        if (f.GetType() == typeof(working))
                        {
                            f.Close();
                        }
                    }
                    Working = new working();
                    Working.MdiParent = this;
                    Working.Show();
                }
            }
        }

        private void RBTNcancelsms_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Se eliminaran permanentemente todos los mensajes pendientes.", "Desea eliminar la cola de pendientes?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                clientsTableAdapterM.ResetJob();
                RBactualizarabonados.PerformClick();
                UpdateLBpendientes();
            }
        }

        private void UpdateLBpendientes() { 
            int count = Convert.ToInt32(clientsTableAdapterM.GetPendingCount());
            RLBpendientes.Text = count.ToString();
            RBactualizarabonados.PerformClick();
            if (count == 0)
            {
                RBTNcancelsms.Enabled = false;
                RBTNsendsms.Enabled = false;
            }
            else {
                RBTNcancelsms.Enabled = true;
                RBTNsendsms.Enabled = true;
                RLBpendientes.Text = count.ToString() + " SMS";
                DialogResult result = MessageBox.Show(this, "Desea enviar los mensajes programados?", "Tiene mensajes programados!", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    RBTNsendsms.PerformClick();
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateLBpendientes();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                if (comm.IsOpen() == true)
                {
                    comm.Close();
                }
            }
            catch (Exception E16)
            {
                Application.Exit();
            }

            Application.Exit();
        }

        private void BWsend_DoWork(object sender, DoWorkEventArgs e)
        {
            RBTNsendsms.Enabled = false;
            RBTNcancelsend.Enabled = true;
            string MSMS_Number, MMessage, i;
            i = clientsTableAdapterM.GetPendingCount().ToString();
            SmsSubmitPdu pdu;
            try
            {
                if (comm.IsConnected() == true)
                {
                    try
                    {
                        foreach (DataRow pending in this.clientsTableAdapterM.GetPending().Rows)
                        {
                            if ((BWsend.CancellationPending == true))
                            {
                                e.Cancel = true;
                                break;
                            }
                            else
                            {
                                BWsend.ReportProgress(0, new string[] { pending["ClientSector"].ToString(), pending["ClientName"].ToString(), pending["ClientPhone"].ToString(), "Procesando.." });
                                MSMS_Number = pending["ClientPhone"].ToString();
                                MMessage = pending["Message"].ToString();
                                if (MMessage != string.Empty && MMessage.Length < 160) //check message
                                {
                                    int valueParsed;
                                    if (MSMS_Number.StartsWith("2") == false && Int32.TryParse(MSMS_Number.Trim(), out valueParsed))//Check Phone Number
                                    {
                                        pdu = new SmsSubmitPdu(MMessage, MSMS_Number, "");
                                        comm.SendMessage(pdu);
                                        System.Threading.Thread.Sleep(Properties.Settings.Default.DelaySms);//Sleeps system for 1000ms for refreshing GSM Modem
                                        clientsTableAdapterM.UpdateSent(pending["ClientPhone"].ToString());
                                        Properties.Settings.Default.AppSMSsent = Properties.Settings.Default.AppSMSsent + 1;
                                        Properties.Settings.Default.Save();
                                        BWsend.ReportProgress(1, true);
                                    }
                                    else
                                    {
                                        BWsend.ReportProgress(1, false);
                                    }
                                }
                            }
                        }
                        MessageBox.Show("Todos los mensajes fueron enviados correctamente.\r\n\n " + i + " enviados.", "SMS enviados correctamente!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    catch (Exception E23)
                    {
                        MessageBox.Show("Error enviando el sms al telefono destino.\r\n\n " + E23.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        BWsend.ReportProgress(1, false);
                    }
                }
                else
                {
                    MessageBox.Show("No hay ningun modem conectado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception E7)
            {
                MessageBox.Show("Error enviando los mensajes.\r\n\nPor favor revise la conexion", "Error de Red!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RBTNcancelsend_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Se cancelara el envio de mensajes (posteriormente lo puede reiniciar).", "Desea cancelar el envio?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes & BWsend.WorkerSupportsCancellation == true)
            {
                BWsend.CancelAsync();
            }
        }

        private void BWsend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                MessageBox.Show("Se cancelo el envio!", "Cancelado!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (!(e.Error == null))
            {
                MessageBox.Show("Error: " + e.Error.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Working.SetStatus = false;
            }
            UpdateLBpendientes();
            RBTNcancelsend.Enabled = false;
            PBsend.Value = 0;
        }

        private void BWsend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                AddClient((string[])e.UserState);
            }
            else {
                PBsend.Value = (PBsend.Value + e.ProgressPercentage);
                SetStatus((bool)e.UserState);
            }
        }

        private void SetStatus(bool values) {
            Working.SetStatus = values;
        }

        private void AddClient(string[] Nclient) {
            Working.addclient = Nclient;
        }
    }
}