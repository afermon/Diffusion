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
        private string InputBuffer = " ";
        private string PortName;
        private bool NewData = false;
        private int signal;
        #endregion

        #region LOADS
        private void Fmain_Load(object sender, EventArgs e)
        {// TODO: esta línea de código carga datos en la tabla 'diffusion_DataBaseDataSet.Clients' Puede moverla o quitarla según sea necesario.
            this.clientsTableAdapter.Fill(this.diffusion_DataBaseDataSet.Clients);
            //load config
            loadportconfig();
            loadnetconfig();
            //Load sectors
            foreach (DataRow sectors in this.clientsTableAdapter.GetSectors().Rows)
            {
                this.LBsectors.Items.Add(sectors["ClientSector"].ToString());
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
        private void LOG(string message) {
            string[] msg = new string[] { message, DateTime.Now.ToString("t") };
            DGVlog.Rows.Add(msg);
        }
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
            }
        }
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
        #endregion
        private void MTBmessage_TextChanged(object sender, EventArgs e)
        {
            MTmessage.Text = "Digite el mensage a enviar:               " + MTBmessage.Text.Length.ToString() + "/160";
        }

        private void MBgetports_Click(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            if (ports.Length == 0)
            {
                MetroMessageBox.Show(this, "Por favor conecte la Data Card e intentelo nuevamente.", "No se encontraron dispositivos!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LOG("No ports detected!");
            }
            else
            {
                MCBports.Items.Clear();
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
            }
        }

        private void MBconnect_Click(object sender, EventArgs e)
        {
            try {
                if (MBconnect.Text == "Conectar")
                {
                    BWconnect.RunWorkerAsync();
                    PortName = MCBports.SelectedItem.ToString();
                    MPSprogress.Visible = true;
                }
                else
                {
                    SerialDisconnect();
                }
         }
        catch (Exception ex){
            MessageBox.Show("Error al abrir el puerto serial: " + ex.Message);
            //log("Error al abrir el puerto serial: " + ex.Message);
             }
        }

        private void SerialDisconnect() {
            if (SerialPort.IsOpen) SerialPort.Close();
            MBconnect.Text = "Conectar";
            LOG("Disconnected!");
            PBsignal.Image = MetroFramework.Diffusion.Properties.Resources.no_connection_256;
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
        private void wait() {
            int runs = 0;
            while (!NewData & runs <= 20 ) {
                System.Threading.Thread.Sleep(500);
                runs++;
            }
            NewData = false;
        }
        private void BWconnect_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
                SerialPort.PortName = PortName;
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

        private void MBsend_Click(object sender, EventArgs e)
        {
            if (MBsend.Text == "Enviar")
            {
                if (totalsms > 0)
                {
                    DialogResult resultsend = MessageBox.Show("Esta seguro de enviar " + totalsms.ToString() + " SMS?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resultsend == DialogResult.Yes)
                    {
                        MBsend.Text = "Cancelar";
                        BWsend.RunWorkerAsync();
                        LOG("Enviando SMS");
                    }
                }
                else
                {
                    DialogResult resultsend = MessageBox.Show("Esta seguro de enviar los mensajes pendientes?", "Advertencia", MessageBoxButtons.YesNo);
                    if (resultsend == DialogResult.Yes)
                    {
                        MBsend.Text = "Cancelar";
                        BWsend.RunWorkerAsync();
                        LOG("Enviando SMS pendientes");
                    }
                }

            }
            else
            {
                DialogResult resultsend = MessageBox.Show("Esta seguro de cancelar el envio?", "Advertencia", MessageBoxButtons.YesNo);
                if (resultsend == DialogResult.Yes)
                {
                    MBsend.Text = "Enviar";
                    BWsend.CancelAsync();
                    pbprogress.Value = 0;
                    LOG("envio cancelado");
                }
            }
        }

        private void BWsend_DoWork(object sender, DoWorkEventArgs e)
        {
            // WHEN YOU ESTART SENDING SMS
            e.Result = "";
            int pgr = 0;
            foreach (string sector in chksectores.CheckedItems)
            {
                usersTableAdapter.UpdateUsers("true", tbmsg.Text, sector);
                System.Threading.Thread.Sleep(500);
                log(sector + " Pendiente.");
            }
            pbprogress.Maximum = this.usersTableAdapter.GetPendientes().Count;
            chksectores.Enabled = false;
            tbmsg.Enabled = false;
            foreach (DataRow pendientes in this.usersTableAdapter.GetPendientes().Rows)
            {
                pgr++;
                log("Enviando " + pendientes["telefono"].ToString());
                //CODIGO PARA ENVIAR SMS
                SerialModem.Write("AT+CMGF=1" + (Char)13);
                System.Threading.Thread.Sleep(1000);
                SerialModem.Write("AT+CMGS=" + (Char)34 + pendientes["telefono"].ToString() + (Char)34 + (Char)13);
                System.Threading.Thread.Sleep(1000);
                //Enviar texto SMS a dispositivo GSM
                SerialModem.Write(pendientes["sms"].ToString() + (Char)26);
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                INPUTBUFFER2 = INPUTBUFFER;
                while (INPUTBUFFER2 == INPUTBUFFER)
                {
                    System.Threading.Thread.Sleep(500);

                }
                if (INPUTBUFFER.Contains("OK"))
                {
                    RESULT = "Correcto";
                    usersTableAdapter.UpdateENVIADO(pendientes["telefono"].ToString());
                }
                else
                {
                    RESULT = "Error";
                }
                backgroundWorker.ReportProgress(pgr);
                string[] envio = new string[] { pgr.ToString(), pendientes["sector"].ToString(), pendientes["nombre"].ToString(), pendientes["telefono"].ToString(), RESULT };
                dgwork.Rows.Insert(0, envio);
                if (RESULT == "Correcto")
                {
                    dgwork.Rows[0].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    dgwork.Rows[0].DefaultCellStyle.BackColor = Color.Red;
                }
                if (backgroundWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void BWsend_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbprogress.Value = e.ProgressPercentage;
            int porcentage = (e.ProgressPercentage * 100) / pbprogress.Maximum;
            lbprogress.Text = porcentage.ToString() + "%";
            if (e.ProgressPercentage == 1 & totalsms > 0) loadings.Hide();
        }

        private void BWsend_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("El envio ha sido cancelado!!");
                log("Envio cancelado");
            }
            else if (e.Error != null)
            {
                MessageBox.Show("Error!!. Detalles: " + (e.Error as Exception).ToString());
                log("Error");
            }
            else
            {
                MessageBox.Show("El envio fue completado exitosamente!!.");
                log("Envio completado");
            }
            pbprogress.Value = 0;
            lbprogress.Text = "0%";
            btnsend.Text = "Enviar";
            chksectores.Enabled = true;
            tbmsg.Enabled = true;
        }

        private void LBsectors_SelectedIndexChanged(object sender, EventArgs e)
        {
            for each
        }


       
       

    }
}
