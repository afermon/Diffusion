using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;// interface metro
using System.IO.Ports; // Serial Port
using System.Data.OleDb;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace MetroFramework.Diffusion
{
    public partial class Fmain : MetroForm
    {
        public Fmain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        #region Variables
        private string InputBuffer = "buffer";//never null
        private string ImportConnectionString;
        private bool NewData = false;
        private int signal;
        string already = " ";
        #endregion
        private void LOG(string message)
        {
            string[] msg = new string[] { message, DateTime.Now.ToString("t") };
            DGVlog.Rows.Add(msg);
        }
        private void wait()
        {
            int runs = 0;
            while (!NewData & runs <= 20)
            {
                System.Threading.Thread.Sleep(500);
                runs++;
            }
            NewData = false;
        }
        #region OnLoad
        private void Fmain_Load(object sender, EventArgs e)
        {// TODO: esta línea de código carga datos en la tabla 'diffusion_DataBaseDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.Fill(this.diffusion_DataBaseDataSet.Clients);
            //load config
            loadportconfig();
            loadnetconfig();
            //Load sectors
            MLinfo.Text = Application.ProductVersion;
            foreach (DataRow sectors in this.clientsTableAdapter.GetSectors().Rows)
            {
                this.LBsectors.Items.Add(sectors["ClientSector"].ToString());
            }
            LOG("Sectors Loaded");
            if (Convert.ToInt32(clientsTableAdapter.GetPendingCount()) > 0)
            {
                DialogResult resultsend = MetroMessageBox.Show(this, "Para enviarlos presione \"Enviar\" sin selecionar sectores.", "Tiene envios pendientes. Desea conservarlos?", MessageBoxButtons.YesNo);
                if (resultsend == DialogResult.No)
                {
                    clientsTableAdapter.ResetJob();
                }
                else
                {
                   LOG("SMS pending");
                }
            }
        }
        private void loadportconfig()
        { //load port config from properties
            MCBflow.SelectedIndex = Properties.Settings.Default.PortHandshake - 1;
            MCBparity.SelectedIndex = Properties.Settings.Default.PortParity - 1;
            MCBstopbits.SelectedIndex = Properties.Settings.Default.PortStopbits - 1;
            MCBbitxs.SelectedIndex = MCBbitxs.FindString(Properties.Settings.Default.PortBitsxs.ToString());
            MCBdatabits.SelectedIndex = MCBdatabits.FindString(Properties.Settings.Default.PortDatabits.ToString());
            MTBreadbuffer.Text = Properties.Settings.Default.PortReadbuffer.ToString();
            MTBwaittime.Text = Properties.Settings.Default.PortWaittime.ToString();
            MTBwritebuffer.Text = Properties.Settings.Default.PortWritebuffer.ToString();
        }
        private void loadnetconfig()
        { //Load net config from properties
            MTBcostxsms.Text = Properties.Settings.Default.Netcostxsms.ToString();
            MTBsim.Text = Properties.Settings.Default.Netpin.ToString();
            MTBsmscenter.Text = Properties.Settings.Default.Netsmscenter.ToString();
            MLcostxsms.Text = Properties.Settings.Default.Netcostxsms.ToString();
        }
        #endregion
        #region KeyPress
        private void MTBcostxsms_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || (e.KeyChar == 44 & !MTBcostxsms.Text.Contains(","))) // Only numbers
            {
              e.Handled = false;
            }
            else
            {
              e.Handled = true; // disable others
            }
        }
        private void MTBsim_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // Only numbers
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // disable others
            }
        }
        private void MTBsmscenter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // Only numbers
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // disable others
            }
        }
        private void MTBreadbuffer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // Only numbers
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // disable others
            }
        }
        private void MTBwritebuffer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // Only numbers
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // disable others
            }
        }
        private void MTBwaittime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar)) // Only numbers
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true; // disable others
            }
        }
        #endregion
        #region Config
        private void MBresetconfig_Click(object sender, EventArgs e)
        {
           DialogResult resetconfigResult = MetroMessageBox.Show(this, "Desea restablecer la configuración default del puerto", "Poner configuración default?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
           if (resetconfigResult == DialogResult.OK)
           {    //reset port config
               Properties.Settings.Default.PortHandshake = 1;
               Properties.Settings.Default.PortParity = 3;
               Properties.Settings.Default.PortStopbits = 2;
               Properties.Settings.Default.PortDatabits = 8;
               Properties.Settings.Default.PortBitsxs = 9600;
               Properties.Settings.Default.PortReadbuffer = 1024;
               Properties.Settings.Default.PortWritebuffer = 1024;
               Properties.Settings.Default.PortWaittime = 500;
               Properties.Settings.Default.Save();
               loadportconfig();
           }
        }
        private void MBresetnet_Click(object sender, EventArgs e)
        {
            DialogResult resetconfigResult = MetroMessageBox.Show(this, "Desea restablecer la configuración default de RED", "Poner configuración default?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resetconfigResult == DialogResult.OK)
            {   //reset net config
                Properties.Settings.Default.Netcostxsms = 3;
                Properties.Settings.Default.Netpin = 0;
                Properties.Settings.Default.Netsmscenter = 506789502020000;
                Properties.Settings.Default.Save();
                loadnetconfig();
            }
        }
        private void MBsaveconfig_Click(object sender, EventArgs e)
        {   //save port config
            DialogResult saveconfigResult = MetroMessageBox.Show(this, "Guarda la nueva configuración del puerto.", "Desea Guardar la configuración del puerto?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (saveconfigResult == DialogResult.OK)
            {
                Properties.Settings.Default.PortHandshake = MCBflow.SelectedIndex + 1;
                Properties.Settings.Default.PortParity = MCBparity.SelectedIndex + 1;
                Properties.Settings.Default.PortStopbits = MCBstopbits.SelectedIndex + 1;
                Properties.Settings.Default.PortDatabits = Convert.ToInt32(MCBdatabits.SelectedItem.ToString());
                Properties.Settings.Default.PortBitsxs = Convert.ToInt32(MCBbitxs.SelectedItem.ToString());
                Properties.Settings.Default.PortReadbuffer = Convert.ToInt32(MTBreadbuffer.Text);
                Properties.Settings.Default.PortWritebuffer = Convert.ToInt32(MTBwritebuffer.Text);
                Properties.Settings.Default.PortWaittime = Convert.ToInt32(MTBwaittime.Text);
                Properties.Settings.Default.Save();
            }
        }
        private void MBsavenet_Click(object sender, EventArgs e)
        {   //save net config
            DialogResult saveconfigResult = MetroMessageBox.Show(this, "Guarda la nueva configuración de red.", "Desea Guardar la configuración de red?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (saveconfigResult == DialogResult.OK)
            {
                Properties.Settings.Default.Netcostxsms = Convert.ToSingle(MTBcostxsms.Text);
                Properties.Settings.Default.Netpin = Convert.ToInt32(MTBsim.Text);
                Properties.Settings.Default.Netsmscenter = Convert.ToDouble(MTBsmscenter.Text);
                Properties.Settings.Default.Save();
                MLcostxsms.Text = Properties.Settings.Default.Netcostxsms.ToString();
            }
        }
        #endregion
        #region Sectors
        private void LBsectors_DrawItem(object sender, DrawItemEventArgs e)
        {// change color of listbox
            if (e.Index < 0) return;
            //if the item state is selected them change the back color 
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e = new DrawItemEventArgs(e.Graphics, e.Font, e.Bounds, e.Index, e.State ^ DrawItemState.Selected, e.ForeColor, Color.FromArgb(243, 119, 53));//Choose the color
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            // Draw the current item text
            e.Graphics.DrawString(LBsectors.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }
        private void MBallsectors_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LBsectors.Items.Count; i++)
            {
                LBsectors.SetSelected(i, true);
            }
        }
        private void MBnonesectors_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LBsectors.Items.Count; i++)
            {
                LBsectors.SetSelected(i, false);
            }
        }
        private void LBsectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            MBnonesectors.Enabled = false;
            MBallsectors.Enabled = false;
            int ClientsCount = 0;
            foreach (string sector in LBsectors.SelectedItems)
            {
                ClientsCount = ClientsCount + Convert.ToInt32(clientsTableAdapter.GetClientCount(sector));
            }
            MLsmscount.Text = ClientsCount.ToString();
            float totalcost = ClientsCount * Properties.Settings.Default.Netcostxsms;
            MLtotalcost.Text = totalcost.ToString();
            MBnonesectors.Enabled = true;
            MBallsectors.Enabled = true;
        }
        #endregion
        private void MTBmessage_TextChanged(object sender, EventArgs e)
        {
            MTmessage.Text = "Digite el mensage a enviar:               " + MTBmessage.Text.Length.ToString() + "/160";
        }
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                InputBuffer = SerialPort.ReadExisting().Trim().ToString();
                LOG("> " + InputBuffer.Trim());
                if (InputBuffer.Contains("+CME ERROR: 11") || InputBuffer.Contains("+CME ERROR: 12"))
                {
                    MetroMessageBox.Show(this, "Actualize el pin en \"Configuración\" y reinicie la aplicacion.!", "PIN/PUK Requerido!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                NewData = true;
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #region Connection
        private void MBgetports_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            MCBports.Items.Clear();
            if (ports.Length == 0)
            {
                MetroMessageBox.Show(this, "Por favor conecte la Data Card e intentelo nuevamente.", "No se encontraron dispositivos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LOG("No ports detected!");
                MCBports.Items.Add("Ninguno");
                MCBports.SelectedItem = "Ninguno";
                MBconnect.Enabled = false;
            }
            else
            {
                foreach (string port in ports)
                {
                    try
                    {
                        System.IO.Ports.SerialPort PortTest = new System.IO.Ports.SerialPort();
                        PortTest.PortName = port;
                        PortTest.Open();
                        PortTest.Close();
                        MCBports.Items.Add(port);
                    }
                    catch (Exception ex)
                    {
                        LOG(port + " busy");
                    }
                    if (port == Properties.Settings.Default.PortLastused)
                    {
                        MCBports.SelectedItem = port;
                    }
                }
                MBconnect.Enabled = true;
                MCBports.Enabled = true;
            }
        }
        private void SerialDisconnect()
        {
            if (SerialPort.IsOpen) SerialPort.Close();
            MBconnect.Text = "Conectar";
            LOG("Disconnected!");
            FLPsend.Enabled = false;
            MPport.Enabled = true;
            PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.no_connection_256;
        }
        private void MBconnect_Click(object sender, EventArgs e)
        {
            if (MBconnect.Text == "Conectar")
            {
                BWconnect.RunWorkerAsync();
                MPSprogress.Visible = true;
            }
            else
            {
                SerialDisconnect();
            }
        }
        private void BWconnect_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
                SerialPort.PortName = MCBports.SelectedItem.ToString();
                SerialPort.Parity = (System.IO.Ports.Parity)Properties.Settings.Default.PortParity;
                SerialPort.Handshake = (System.IO.Ports.Handshake)Properties.Settings.Default.PortHandshake;
                SerialPort.StopBits = (System.IO.Ports.StopBits)Properties.Settings.Default.PortStopbits;
                SerialPort.BaudRate = Properties.Settings.Default.PortBitsxs;
                SerialPort.DataBits = Properties.Settings.Default.PortDatabits;
                SerialPort.DtrEnable = false;
                SerialPort.ReadBufferSize = Properties.Settings.Default.PortReadbuffer;
                SerialPort.WriteBufferSize = Properties.Settings.Default.PortWritebuffer;
                SerialPort.WriteTimeout = Properties.Settings.Default.PortWaittime;
                SerialPort.RtsEnable = true;
                SerialPort.Encoding = System.Text.Encoding.Default;
                SerialPort.Open();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, "Por favor intente con otro puerto. " + ex.Message, "Error al abrir el puerto serie!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (SerialPort.IsOpen)
            {
                SerialPort.Write("AT \r");
                wait();
                if (InputBuffer.Contains("OK"))
                {
                    LOG("Device detected!");
                    Properties.Settings.Default.PortLastused = SerialPort.PortName;
                    Properties.Settings.Default.Save();
                    if (Properties.Settings.Default.Netpin != 0)
                    {
                        try
                        {
                            SerialPort.Write("AT+CPIN=" + Properties.Settings.Default.Netpin.ToString() + (Char)13);
                            System.Threading.Thread.Sleep(1000);
                            LOG("Pin Sent");
                        }
                        catch (Exception es)
                        {
                            LOG(es.Message);
                        }
                    }
                    SerialPort.Write("AT+CREG? \r");
                    wait();
                    if (InputBuffer.Contains("+CREG: 1,1")) //network aviable
                    {
                        LOG("Network aviable!");
                        MBconnect.Text = "Desconectar";
                        LOG("Connected!");
                        FLPsend.Enabled = true;
                        MPport.Enabled = false;
                        SerialPort.Write("AT+CSQ \r");
                        wait();
                        InputBuffer = InputBuffer.Substring(InputBuffer.IndexOf(':') + 2);//UPDATE HERE
                        signal = Convert.ToInt32(InputBuffer.Split(',')[0]);
                        LOG("Signal: " + signal.ToString() + "db");
                        if (signal <= 0 || signal == 99) PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.no_connection_256;
                        if (signal > 0 & signal < 15) PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.medium_connection_256;
                        if (signal >= 15 & signal < 30) PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.low_connection_256;
                        if (signal >= 30 & signal < 99) PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.high_connection_256;
                        SerialPort.Write("AT+CGSN \r");
                        wait();
                        MLemei.Text = InputBuffer.Split('O')[0];
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Por favor cambie de lugar la data card e intentelo nuevamente.", "Red movil no disponible. Abortado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        LOG("Network not aviable!");
                        SerialDisconnect();
                    }
                }
                else
                {
                    MetroMessageBox.Show(this, "Por favor cambie el puerto e intentelo nuevamente.", "Dispositivo no detectado en puerto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LOG("Device not detected!");
                    SerialDisconnect();
                }
            }
        }
        private void BWconnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MPSprogress.Visible = false;
        }
        #endregion
        #region Send
        private void MBsend_Click(object sender, EventArgs e)
        {
            if (MBsend.Text == "Enviar")
            {
                if (MLsmscount.Text != "0")
                {
                    if (MTBmessage.Text.Length > 0)
                    {
                        DialogResult resultsend = MetroMessageBox.Show(this, "Presione Yes si esta seguro.", "Esta seguro de enviar " + MLsmscount.Text + " SMS?", MessageBoxButtons.YesNo);
                        if (resultsend == DialogResult.Yes)
                        {
                            MBsend.Text = "Cancelar";
                            BWsend.RunWorkerAsync();
                            LOG("Sending SMS");
                        }
                    }
                    else 
                    { 
                         MetroMessageBox.Show(this, "Por favor digite el mensaje e intentelo nuevamente.", "SMS en blanco!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (Convert.ToInt32(clientsTableAdapter.GetPendingCount()) > 0){
                        DialogResult resultsend = MetroMessageBox.Show(this, "Presione Yes si esta seguro.", "Esta seguro de enviar los mensajes pendientes?", MessageBoxButtons.YesNo);
                        if (resultsend == DialogResult.Yes)
                        {
                            MBsend.Text = "Cancelar";
                            BWsend.RunWorkerAsync();
                            LOG("Sending old SMS");
                        }
                    }
                    else
                    {
                        MetroMessageBox.Show(this, "Por favor seleccione los sectores e intentelo nuevamente. ", "No hay SMS pendientes!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DialogResult resultsend = MetroMessageBox.Show(this, "Se cancelaran todos los mensajes pendientes. Todavia estaran en memoria.", "Esta seguro de cancelar el envio?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resultsend == DialogResult.Yes)
                {
                    MBsend.Text = "Enviar";
                    BWsend.CancelAsync();
                    MPBprogress.Value = 0;
                    LOG("Job canceled.");
                    DialogResult result = MetroMessageBox.Show(this, "Se eliminaran permanentemente todos los mensajes pendientes.", "Desea eliminar la cola de pendientes?", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (result == DialogResult.Yes)
                    {
                        clientsTableAdapter.ResetJob();
                        LOG("Queue cleared.");
                    }
                }
            }
        }
        private void BWsend_DoWork(object sender, DoWorkEventArgs e)
        {
            MPSprogress.Visible = true;
            e.Result = "";
            int pgr = 0;
            string result = " ";
            foreach (string st in LBsectors.SelectedItems)
            {
                clientsTableAdapter.UpdateClientsToInform(true, MTBmessage.Text, st);
                LOG(st + " Pending.");
            }
            MPBprogress.Maximum = Convert.ToInt32(clientsTableAdapter.GetPendingCount());
            foreach (DataRow pending in this.clientsTableAdapter.GetPending().Rows)
            {
                pgr++;
                LOG("Enviando " + pending["ClientPhone"].ToString());
                if (pending["ClientPhone"].ToString().StartsWith("2") || pending["ClientPhone"].ToString().StartsWith(" ") || pending["ClientPhone"].ToString() != String.Empty)
                {
                    SerialPort.Write("AT+CMGF=1" + (Char)13);
                    wait();
                    SerialPort.Write("AT+CMGS=" + (Char)34 + pending["ClientPhone"].ToString() + (Char)34 + (Char)13);
                    wait();
                    SerialPort.Write(pending["Message"].ToString() + (Char)26);
                    Application.DoEvents();
                    wait();
                    if (InputBuffer.Contains("OK"))
                    {
                        result = "Enviado";
                        clientsTableAdapter.UpdateSent(pending["ClientPhone"].ToString());
                    }
                    else
                    {
                        result = "Error";
                    }
                }
                else
                {
                    LOG(pending["ClientName"].ToString() + "Phone error!");
                }
                BWsend.ReportProgress(pgr);
                string[] job = new string[] { pgr.ToString(), pending["ClientSector"].ToString(), pending["ClientName"].ToString(), pending["ClientPhone"].ToString(), result };
                DGVjob.Rows.Insert(0, job);
                if (result == "Enviado")
                {
                    DGVjob.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    DGVjob.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                }
                if (BWsend.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
        private void BWsend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MPBprogress.Value = e.ProgressPercentage;
        }
        private void BWsend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MetroMessageBox.Show(this, "El envio ha sido cancelado!!", "Envio cancelado!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("El envio ha sido cancelado!!");
                LOG("Job canceled");

            }
            else if (e.Error != null)
            {
                MetroMessageBox.Show(this, "Error!!. Detalles: " + (e.Error as Exception).ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LOG("Error");
            }
            else
            {
                MetroMessageBox.Show(this, "El envio fue completado exitosamente.", "Envio completado!", MessageBoxButtons.OK, MessageBoxIcon.Question);
                LOG("Job completed");
            }
            MPBprogress.Value = 0;
            MBsend.Text = "Enviar";
            MPSprogress.Visible = false;
        }
        #endregion
        #region Links
        private void MLicon8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://icons8.com/");
        }
        private void MLmetro_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://viperneo.github.io/winforms-modernui/");
        }
        private void MLfermongroup_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fermongroup.com/");
        }
        private void MLsupport_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.fermongroup.com/contact/");
        }
        #endregion
        #region imports
        private void MBimport_Click(object sender, EventArgs e)
        {
            if (MBimport.Text == "Importar")
            {
                if (this.OFDimport.ShowDialog() == DialogResult.OK)
                {
                   DialogResult resultsend = MetroMessageBox.Show(this, "Si los datos estan correctamente en el formato proceda. Recuerde el orden: Numero de abonado / cedula / Nombre / Direccion/ Sector / telefono. Ademas el telefono y el sector son obligatorios.", "Esta seguro de Importar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                   if (resultsend == DialogResult.Yes)
                   {
                       if (System.IO.File.Exists(OFDimport.FileName))
                       {
                           MBimport.Text = "Cancelar";
                           BWimport.RunWorkerAsync();
                       }
                   }
                }
            }
            else
            {
                DialogResult resultsend = MetroMessageBox.Show(this, "Se cancelara el proceso.", "Esta seguro de cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (resultsend == DialogResult.Yes)
                {
                    MBsend.Text = "Importar";
                    BWimport.CancelAsync();
                    MPBprogress.Value = 0;
                    LOG("Import canceled.");
                }
            }
        }
        private void BWimport_DoWork(object sender, DoWorkEventArgs e)
        {
            MPSprogress.Visible = true;
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
                MPBprogress.Maximum = range.Rows.Count - 1;
                for (int client = 2; client <= range.Rows.Count; client++)
                {
                    if (clientsTableAdapter.CheckNumber((range.Cells[client, 6] as Excel.Range).Value2.ToString()) == 0)
                    {
                        clientsTableAdapter.InsertClient((range.Cells[client, 1] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 2] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 3] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 4] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 5] as Excel.Range).Value2.ToString(),
                                                         (range.Cells[client, 6] as Excel.Range).Value2.ToString());

                    }
                    else
                    {
                        already = already + client.ToString() + ", ";
                    }
                    BWimport.ReportProgress(client);
                    if (BWsend.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Por favor intente exportar el formato desde el programa y luego agregar los datos en el excel. No modifique los nombres de las columnas y mantenga el orden de las mismas.", "Formato incorrecto!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            workbook.Close(true, Missing.Value, Missing.Value);
            excelApp.Quit();
        }
        private void BWimport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            MPBprogress.Value = e.ProgressPercentage;
        }
        private void BWimport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (already != " ")
            {
                MetroMessageBox.Show(this, MPBprogress.Value.ToString() + " procesados correctamente. Registros que ya estaban en la base de datos:" + already, "Datos importados!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                MetroMessageBox.Show(this, MPBprogress.Value.ToString() + " procesados correctamente.", "Datos importados!", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            this.clientsTableAdapter.Fill(this.diffusion_DataBaseDataSet.Clients);
            MPBprogress.Value = 0;
            MPSprogress.Visible = true;
            MBimport.Text = "Importar";
        }
        private void MBexport_Click(object sender, EventArgs e)
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
        #endregion

    }
}
