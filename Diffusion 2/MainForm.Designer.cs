namespace Diffusion_2
{
    partial class MainForm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.RtabInicio = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.BtnCerrarVentanas = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel2 = new System.Windows.Forms.RibbonPanel();
            this.RBPuertos = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator3 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonLabel5 = new System.Windows.Forms.RibbonLabel();
            this.RCBPuerto = new System.Windows.Forms.RibbonComboBox();
            this.Pninguno = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator2 = new System.Windows.Forms.RibbonSeparator();
            this.RBtnConectar = new System.Windows.Forms.RibbonButton();
            this.RBtnDesconectar = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonComboBox1 = new System.Windows.Forms.RibbonComboBox();
            this.RPDispositivo = new System.Windows.Forms.RibbonPanel();
            this.RLmarca = new System.Windows.Forms.RibbonLabel();
            this.RLmodelo = new System.Windows.Forms.RibbonLabel();
            this.RLserieup = new System.Windows.Forms.RibbonLabel();
            this.RLserie = new System.Windows.Forms.RibbonLabel();
            this.Rtabdb = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.RBimportar = new System.Windows.Forms.RibbonButton();
            this.RBexportar = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel4 = new System.Windows.Forms.RibbonPanel();
            this.RBaddreg = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.RBdatabase = new System.Windows.Forms.RibbonButton();
            this.RBactualizarabonados = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.CBfiltrocolumna = new System.Windows.Forms.RibbonComboBox();
            this.FRBabonado = new System.Windows.Forms.RibbonButton();
            this.FRBcedula = new System.Windows.Forms.RibbonButton();
            this.FRBnombre = new System.Windows.Forms.RibbonButton();
            this.FRBdireccion = new System.Windows.Forms.RibbonButton();
            this.FRBsector = new System.Windows.Forms.RibbonButton();
            this.FRBTelefono = new System.Windows.Forms.RibbonButton();
            this.FRBpendientes = new System.Windows.Forms.RibbonButton();
            this.ribbonLabel3 = new System.Windows.Forms.RibbonLabel();
            this.RTBquery = new System.Windows.Forms.RibbonTextBox();
            this.RBbuscar = new System.Windows.Forms.RibbonButton();
            this.Rtabsms = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.RBnewmessage = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel8 = new System.Windows.Forms.RibbonPanel();
            this.RBTNsendsms = new System.Windows.Forms.RibbonButton();
            this.RBTNcancelsend = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel13 = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.RLBpendientes = new System.Windows.Forms.RibbonLabel();
            this.RBTNcancelsms = new System.Windows.Forms.RibbonButton();
            this.RTabInfo = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel9 = new System.Windows.Forms.RibbonPanel();
            this.RBinfo = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel11 = new System.Windows.Forms.RibbonPanel();
            this.RBsoporte = new System.Windows.Forms.RibbonButton();
            this.ribbonPanel10 = new System.Windows.Forms.RibbonPanel();
            this.RBtnpagweb = new System.Windows.Forms.RibbonButton();
            this.RPconfig = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel12 = new System.Windows.Forms.RibbonPanel();
            this.RBconfig = new System.Windows.Forms.RibbonButton();
            this.SFDexport = new System.Windows.Forms.SaveFileDialog();
            this.OFDimport = new System.Windows.Forms.OpenFileDialog();
            this.BWimport = new System.ComponentModel.BackgroundWorker();
            this.clientsTableAdapterM = new Diffusion_2.Diffusion_DataBaseDataSetTableAdapters.ClientsTableAdapter();
            this.BWsend = new System.ComponentModel.BackgroundWorker();
            this.MainRibbon = new System.Windows.Forms.Ribbon();
            this.BtnInfo = new System.Windows.Forms.RibbonOrbMenuItem();
            this.btnSalir2 = new System.Windows.Forms.RibbonOrbMenuItem();
            this.Salir = new System.Windows.Forms.RibbonOrbOptionButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PBsend = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RtabInicio
            // 
            this.RtabInicio.Panels.Add(this.ribbonPanel1);
            this.RtabInicio.Panels.Add(this.ribbonPanel2);
            this.RtabInicio.Panels.Add(this.RPDispositivo);
            this.RtabInicio.Text = "Inicio";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.BtnCerrarVentanas);
            this.ribbonPanel1.Text = "";
            // 
            // BtnCerrarVentanas
            // 
            this.BtnCerrarVentanas.Image = global::Diffusion_2.Properties.Resources._75;
            this.BtnCerrarVentanas.SmallImage = ((System.Drawing.Image)(resources.GetObject("BtnCerrarVentanas.SmallImage")));
            this.BtnCerrarVentanas.Text = "Cerrar Ventanas";
            this.BtnCerrarVentanas.Click += new System.EventHandler(this.BtnCerrarVentanas_Click);
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.Items.Add(this.RBPuertos);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator3);
            this.ribbonPanel2.Items.Add(this.ribbonLabel5);
            this.ribbonPanel2.Items.Add(this.RCBPuerto);
            this.ribbonPanel2.Items.Add(this.ribbonSeparator2);
            this.ribbonPanel2.Items.Add(this.RBtnConectar);
            this.ribbonPanel2.Items.Add(this.RBtnDesconectar);
            this.ribbonPanel2.Text = "Conexión";
            // 
            // RBPuertos
            // 
            this.RBPuertos.Image = global::Diffusion_2.Properties.Resources._85;
            this.RBPuertos.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBPuertos.SmallImage")));
            this.RBPuertos.Text = "Obtener Puertos";
            this.RBPuertos.Click += new System.EventHandler(this.RBPuertos_Click);
            // 
            // ribbonLabel5
            // 
            this.ribbonLabel5.Text = "Dispositivo:";
            this.ribbonLabel5.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // RCBPuerto
            // 
            this.RCBPuerto.AllowTextEdit = false;
            this.RCBPuerto.DropDownItems.Add(this.Pninguno);
            this.RCBPuerto.Text = "";
            this.RCBPuerto.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.RCBPuerto.TextBoxText = "Ninguno";
            // 
            // Pninguno
            // 
            this.Pninguno.Image = ((System.Drawing.Image)(resources.GetObject("Pninguno.Image")));
            this.Pninguno.SmallImage = global::Diffusion_2.Properties.Resources.cross_161;
            this.Pninguno.Tag = "COM1";
            this.Pninguno.Text = "Ninguno";
            // 
            // RBtnConectar
            // 
            this.RBtnConectar.Enabled = false;
            this.RBtnConectar.Image = ((System.Drawing.Image)(resources.GetObject("RBtnConectar.Image")));
            this.RBtnConectar.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBtnConectar.SmallImage")));
            this.RBtnConectar.Text = "Conectar";
            this.RBtnConectar.Click += new System.EventHandler(this.RBtnConectar_Click);
            // 
            // RBtnDesconectar
            // 
            this.RBtnDesconectar.DropDownItems.Add(this.ribbonSeparator1);
            this.RBtnDesconectar.DropDownItems.Add(this.ribbonComboBox1);
            this.RBtnDesconectar.Enabled = false;
            this.RBtnDesconectar.Image = global::Diffusion_2.Properties.Resources._159;
            this.RBtnDesconectar.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBtnDesconectar.SmallImage")));
            this.RBtnDesconectar.Text = "Desconectar";
            this.RBtnDesconectar.Click += new System.EventHandler(this.RBtnDesconectar_Click);
            // 
            // ribbonComboBox1
            // 
            this.ribbonComboBox1.Text = "ribbonComboBox1";
            this.ribbonComboBox1.TextBoxText = "";
            // 
            // RPDispositivo
            // 
            this.RPDispositivo.Enabled = false;
            this.RPDispositivo.Items.Add(this.RLmarca);
            this.RPDispositivo.Items.Add(this.RLmodelo);
            this.RPDispositivo.Items.Add(this.RLserieup);
            this.RPDispositivo.Items.Add(this.RLserie);
            this.RPDispositivo.Text = "Dispositivo";
            // 
            // RLmarca
            // 
            this.RLmarca.Enabled = false;
            this.RLmarca.Text = "Marca: ";
            // 
            // RLmodelo
            // 
            this.RLmodelo.Enabled = false;
            this.RLmodelo.Text = "Modelo: ";
            // 
            // RLserieup
            // 
            this.RLserieup.Enabled = false;
            this.RLserieup.Text = "Serie:";
            // 
            // RLserie
            // 
            this.RLserie.Enabled = false;
            this.RLserie.Text = "No conectado";
            // 
            // Rtabdb
            // 
            this.Rtabdb.Panels.Add(this.ribbonPanel3);
            this.Rtabdb.Panels.Add(this.ribbonPanel4);
            this.Rtabdb.Panels.Add(this.ribbonPanel5);
            this.Rtabdb.Panels.Add(this.ribbonPanel6);
            this.Rtabdb.Text = "Base de Datos";
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Items.Add(this.RBimportar);
            this.ribbonPanel3.Items.Add(this.RBexportar);
            this.ribbonPanel3.Text = "Importar / Exportar";
            // 
            // RBimportar
            // 
            this.RBimportar.FlashIntervall = 100;
            this.RBimportar.Image = global::Diffusion_2.Properties.Resources._146;
            this.RBimportar.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBimportar.SmallImage")));
            this.RBimportar.Text = "Importar";
            this.RBimportar.Click += new System.EventHandler(this.RBimportar_Click);
            // 
            // RBexportar
            // 
            this.RBexportar.Image = global::Diffusion_2.Properties.Resources._147;
            this.RBexportar.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBexportar.SmallImage")));
            this.RBexportar.Text = "Exportar Formato";
            this.RBexportar.Click += new System.EventHandler(this.RBexportar_Click);
            // 
            // ribbonPanel4
            // 
            this.ribbonPanel4.Items.Add(this.RBaddreg);
            this.ribbonPanel4.Text = null;
            // 
            // RBaddreg
            // 
            this.RBaddreg.Image = global::Diffusion_2.Properties.Resources._190;
            this.RBaddreg.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBaddreg.SmallImage")));
            this.RBaddreg.Text = "Añadir Abonado";
            this.RBaddreg.Click += new System.EventHandler(this.RBaddreg_Click);
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Items.Add(this.RBdatabase);
            this.ribbonPanel5.Items.Add(this.RBactualizarabonados);
            this.ribbonPanel5.Text = null;
            // 
            // RBdatabase
            // 
            this.RBdatabase.Image = global::Diffusion_2.Properties.Resources._84;
            this.RBdatabase.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBdatabase.SmallImage")));
            this.RBdatabase.Text = "Ver Abonados";
            this.RBdatabase.Click += new System.EventHandler(this.RBdatabase_Click);
            // 
            // RBactualizarabonados
            // 
            this.RBactualizarabonados.Image = global::Diffusion_2.Properties.Resources._85;
            this.RBactualizarabonados.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBactualizarabonados.SmallImage")));
            this.RBactualizarabonados.Text = "Actualizar Lista";
            this.RBactualizarabonados.Click += new System.EventHandler(this.RBactualizarabonados_Click);
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Items.Add(this.ribbonLabel1);
            this.ribbonPanel6.Items.Add(this.CBfiltrocolumna);
            this.ribbonPanel6.Items.Add(this.ribbonLabel3);
            this.ribbonPanel6.Items.Add(this.RTBquery);
            this.ribbonPanel6.Items.Add(this.RBbuscar);
            this.ribbonPanel6.Text = "Filtrar";
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Text = "Filtrar por:";
            // 
            // CBfiltrocolumna
            // 
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBabonado);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBcedula);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBnombre);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBdireccion);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBsector);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBTelefono);
            this.CBfiltrocolumna.DropDownItems.Add(this.FRBpendientes);
            this.CBfiltrocolumna.Text = "";
            this.CBfiltrocolumna.TextBoxText = "# Abonado";
            // 
            // FRBabonado
            // 
            this.FRBabonado.Image = ((System.Drawing.Image)(resources.GetObject("FRBabonado.Image")));
            this.FRBabonado.SmallImage = global::Diffusion_2.Properties.Resources.solution_16;
            this.FRBabonado.Tag = "1";
            this.FRBabonado.Text = "# Abonado";
            // 
            // FRBcedula
            // 
            this.FRBcedula.Image = ((System.Drawing.Image)(resources.GetObject("FRBcedula.Image")));
            this.FRBcedula.SmallImage = global::Diffusion_2.Properties.Resources.solution_16;
            this.FRBcedula.Tag = "2";
            this.FRBcedula.Text = "Cedula";
            // 
            // FRBnombre
            // 
            this.FRBnombre.Image = ((System.Drawing.Image)(resources.GetObject("FRBnombre.Image")));
            this.FRBnombre.SmallImage = global::Diffusion_2.Properties.Resources.solution_16;
            this.FRBnombre.Tag = "3";
            this.FRBnombre.Text = "Nombre";
            // 
            // FRBdireccion
            // 
            this.FRBdireccion.Image = ((System.Drawing.Image)(resources.GetObject("FRBdireccion.Image")));
            this.FRBdireccion.SmallImage = global::Diffusion_2.Properties.Resources.solution_16;
            this.FRBdireccion.Tag = "4";
            this.FRBdireccion.Text = "Dirección";
            // 
            // FRBsector
            // 
            this.FRBsector.Image = ((System.Drawing.Image)(resources.GetObject("FRBsector.Image")));
            this.FRBsector.SmallImage = global::Diffusion_2.Properties.Resources.world_16;
            this.FRBsector.Tag = "5";
            this.FRBsector.Text = "Sector";
            // 
            // FRBTelefono
            // 
            this.FRBTelefono.Image = ((System.Drawing.Image)(resources.GetObject("FRBTelefono.Image")));
            this.FRBTelefono.SmallImage = global::Diffusion_2.Properties.Resources.solution_16;
            this.FRBTelefono.Tag = "6";
            this.FRBTelefono.Text = "Telefono";
            // 
            // FRBpendientes
            // 
            this.FRBpendientes.Image = ((System.Drawing.Image)(resources.GetObject("FRBpendientes.Image")));
            this.FRBpendientes.SmallImage = global::Diffusion_2.Properties.Resources.info_16;
            this.FRBpendientes.Tag = "7";
            this.FRBpendientes.Text = "Pendientes";
            // 
            // ribbonLabel3
            // 
            this.ribbonLabel3.Text = "Consulta:";
            // 
            // RTBquery
            // 
            this.RTBquery.Text = "";
            this.RTBquery.TextBoxText = "";
            this.RTBquery.TextBoxKeyDown += new System.Windows.Forms.KeyEventHandler(this.RTBquery_TextBoxKeyDown);
            // 
            // RBbuscar
            // 
            this.RBbuscar.Image = global::Diffusion_2.Properties.Resources._12;
            this.RBbuscar.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBbuscar.SmallImage")));
            this.RBbuscar.Text = "Buscar";
            this.RBbuscar.Click += new System.EventHandler(this.RBbuscar_Click);
            // 
            // Rtabsms
            // 
            this.Rtabsms.Panels.Add(this.ribbonPanel7);
            this.Rtabsms.Panels.Add(this.ribbonPanel8);
            this.Rtabsms.Panels.Add(this.ribbonPanel13);
            this.Rtabsms.Text = "Envio de SMS";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Items.Add(this.RBnewmessage);
            this.ribbonPanel7.Text = "1) Paso";
            // 
            // RBnewmessage
            // 
            this.RBnewmessage.Image = global::Diffusion_2.Properties.Resources._49;
            this.RBnewmessage.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBnewmessage.SmallImage")));
            this.RBnewmessage.Text = "Programar mensaje";
            this.RBnewmessage.Click += new System.EventHandler(this.RBnewmessage_Click);
            // 
            // ribbonPanel8
            // 
            this.ribbonPanel8.Items.Add(this.RBTNsendsms);
            this.ribbonPanel8.Items.Add(this.RBTNcancelsend);
            this.ribbonPanel8.Text = "2) Paso";
            // 
            // RBTNsendsms
            // 
            this.RBTNsendsms.Image = global::Diffusion_2.Properties.Resources._35;
            this.RBTNsendsms.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBTNsendsms.SmallImage")));
            this.RBTNsendsms.Text = "Enviar mensajes";
            this.RBTNsendsms.Click += new System.EventHandler(this.RBTNsendsms_Click);
            // 
            // RBTNcancelsend
            // 
            this.RBTNcancelsend.Enabled = false;
            this.RBTNcancelsend.Image = global::Diffusion_2.Properties.Resources._752;
            this.RBTNcancelsend.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBTNcancelsend.SmallImage")));
            this.RBTNcancelsend.Text = "Cancelar Envio";
            this.RBTNcancelsend.Click += new System.EventHandler(this.RBTNcancelsend_Click);
            // 
            // ribbonPanel13
            // 
            this.ribbonPanel13.Items.Add(this.ribbonLabel2);
            this.ribbonPanel13.Items.Add(this.RLBpendientes);
            this.ribbonPanel13.Items.Add(this.RBTNcancelsms);
            this.ribbonPanel13.Text = "Programados";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Text = "Mensajes pendientes";
            // 
            // RLBpendientes
            // 
            this.RLBpendientes.Text = "0";
            this.RLBpendientes.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            // 
            // RBTNcancelsms
            // 
            this.RBTNcancelsms.Image = global::Diffusion_2.Properties.Resources._149;
            this.RBTNcancelsms.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBTNcancelsms.SmallImage")));
            this.RBTNcancelsms.Text = "Cancelar Pendientes";
            this.RBTNcancelsms.Click += new System.EventHandler(this.RBTNcancelsms_Click);
            // 
            // RTabInfo
            // 
            this.RTabInfo.Panels.Add(this.ribbonPanel9);
            this.RTabInfo.Panels.Add(this.ribbonPanel11);
            this.RTabInfo.Panels.Add(this.ribbonPanel10);
            this.RTabInfo.Text = "Información";
            // 
            // ribbonPanel9
            // 
            this.ribbonPanel9.Items.Add(this.RBinfo);
            this.ribbonPanel9.Text = "Informacion";
            // 
            // RBinfo
            // 
            this.RBinfo.Image = global::Diffusion_2.Properties.Resources._71;
            this.RBinfo.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBinfo.SmallImage")));
            this.RBinfo.Text = "Informacion";
            this.RBinfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // ribbonPanel11
            // 
            this.ribbonPanel11.Items.Add(this.RBsoporte);
            this.ribbonPanel11.Text = "Soporte";
            // 
            // RBsoporte
            // 
            this.RBsoporte.Image = global::Diffusion_2.Properties.Resources._72;
            this.RBsoporte.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBsoporte.SmallImage")));
            this.RBsoporte.Text = "Soporte";
            this.RBsoporte.Click += new System.EventHandler(this.RBsoporte_Click);
            // 
            // ribbonPanel10
            // 
            this.ribbonPanel10.Items.Add(this.RBtnpagweb);
            this.ribbonPanel10.Text = "Pagina Web";
            // 
            // RBtnpagweb
            // 
            this.RBtnpagweb.Image = global::Diffusion_2.Properties.Resources.FG_Logo;
            this.RBtnpagweb.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBtnpagweb.SmallImage")));
            this.RBtnpagweb.Text = "Fermon Group";
            this.RBtnpagweb.Click += new System.EventHandler(this.RBtnpagweb_Click);
            // 
            // RPconfig
            // 
            this.RPconfig.Panels.Add(this.ribbonPanel12);
            this.RPconfig.Text = "Configuración";
            // 
            // ribbonPanel12
            // 
            this.ribbonPanel12.Items.Add(this.RBconfig);
            this.ribbonPanel12.Text = "Configuración";
            // 
            // RBconfig
            // 
            this.RBconfig.Image = global::Diffusion_2.Properties.Resources._51;
            this.RBconfig.SmallImage = ((System.Drawing.Image)(resources.GetObject("RBconfig.SmallImage")));
            this.RBconfig.Text = "Configuración";
            this.RBconfig.Click += new System.EventHandler(this.RBconfig_Click);
            // 
            // SFDexport
            // 
            this.SFDexport.Title = "Guardar Formato";
            // 
            // OFDimport
            // 
            this.OFDimport.Filter = "Excel 97-2003(*.xls)|*.xls| Excel 2007(*.xlsx)|*.xlsx";
            this.OFDimport.Title = "Importar Abonados";
            // 
            // BWimport
            // 
            this.BWimport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWimport_DoWork);
            this.BWimport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWimport_RunWorkerCompleted);
            // 
            // clientsTableAdapterM
            // 
            this.clientsTableAdapterM.ClearBeforeFill = true;
            // 
            // BWsend
            // 
            this.BWsend.WorkerReportsProgress = true;
            this.BWsend.WorkerSupportsCancellation = true;
            this.BWsend.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BWsend_DoWork);
            this.BWsend.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BWsend_ProgressChanged);
            this.BWsend.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BWsend_RunWorkerCompleted);
            // 
            // MainRibbon
            // 
            this.MainRibbon.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.MainRibbon.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.Minimized = false;
            this.MainRibbon.Name = "MainRibbon";
            // 
            // 
            // 
            this.MainRibbon.OrbDropDown.BorderRoundness = 8;
            this.MainRibbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.MainRibbon.OrbDropDown.MenuItems.Add(this.BtnInfo);
            this.MainRibbon.OrbDropDown.MenuItems.Add(this.btnSalir2);
            this.MainRibbon.OrbDropDown.Name = "";
            this.MainRibbon.OrbDropDown.OptionItems.Add(this.Salir);
            this.MainRibbon.OrbDropDown.Size = new System.Drawing.Size(527, 160);
            this.MainRibbon.OrbDropDown.TabIndex = 0;
            this.MainRibbon.OrbImage = global::Diffusion_2.Properties.Resources.home_16;
            this.MainRibbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2010;
            this.MainRibbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.MainRibbon.Size = new System.Drawing.Size(768, 183);
            this.MainRibbon.TabIndex = 0;
            this.MainRibbon.Tabs.Add(this.RtabInicio);
            this.MainRibbon.Tabs.Add(this.Rtabdb);
            this.MainRibbon.Tabs.Add(this.Rtabsms);
            this.MainRibbon.Tabs.Add(this.RPconfig);
            this.MainRibbon.Tabs.Add(this.RTabInfo);
            this.MainRibbon.TabsMargin = new System.Windows.Forms.Padding(12, 26, 20, 0);
            this.MainRibbon.Text = "Diffusion";
            this.MainRibbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // BtnInfo
            // 
            this.BtnInfo.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.BtnInfo.Image = global::Diffusion_2.Properties.Resources.info_16;
            this.BtnInfo.SmallImage = global::Diffusion_2.Properties.Resources.info_16;
            this.BtnInfo.Text = "Información";
            this.BtnInfo.Click += new System.EventHandler(this.BtnInfo_Click);
            // 
            // btnSalir2
            // 
            this.btnSalir2.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.btnSalir2.Image = global::Diffusion_2.Properties.Resources.cross_161;
            this.btnSalir2.SmallImage = global::Diffusion_2.Properties.Resources.cross_161;
            this.btnSalir2.Text = "Cerrar";
            this.btnSalir2.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Salir
            // 
            this.Salir.Image = global::Diffusion_2.Properties.Resources.cross_161;
            this.Salir.SmallImage = global::Diffusion_2.Properties.Resources.cross_161;
            this.Salir.Text = "Salir";
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PBsend});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStrip1.Size = new System.Drawing.Size(768, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PBsend
            // 
            this.PBsend.Name = "PBsend";
            this.PBsend.Size = new System.Drawing.Size(300, 16);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 528);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.MainRibbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Tag = " ";
            this.Text = "Diffusion App";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon MainRibbon;
        private System.Windows.Forms.RibbonTab Rtabsms;
        private System.Windows.Forms.RibbonTab RtabInicio;
        private System.Windows.Forms.RibbonTab Rtabdb;
        private System.Windows.Forms.RibbonTab RTabInfo;
        private System.Windows.Forms.RibbonOrbOptionButton Salir;
        private System.Windows.Forms.RibbonOrbMenuItem BtnInfo;
        private System.Windows.Forms.RibbonOrbMenuItem btnSalir2;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton BtnCerrarVentanas;
        private System.Windows.Forms.RibbonPanel ribbonPanel2;
        private System.Windows.Forms.RibbonButton RBtnConectar;
        private System.Windows.Forms.RibbonButton RBtnDesconectar;
        private System.Windows.Forms.RibbonButton RBPuertos;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator3;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonComboBox ribbonComboBox1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator2;
        private System.Windows.Forms.RibbonComboBox RCBPuerto;
        private System.Windows.Forms.RibbonPanel RPDispositivo;
        private System.Windows.Forms.RibbonLabel RLmarca;
        private System.Windows.Forms.RibbonLabel RLmodelo;
        private System.Windows.Forms.RibbonLabel RLserieup;
        private System.Windows.Forms.RibbonLabel RLserie;
        private System.Windows.Forms.RibbonLabel ribbonLabel5;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonButton RBimportar;
        private System.Windows.Forms.RibbonButton RBexportar;
        private System.Windows.Forms.RibbonTab RPconfig;
        private System.Windows.Forms.RibbonPanel ribbonPanel4;
        private System.Windows.Forms.RibbonButton RBaddreg;
        private System.Windows.Forms.RibbonButton Pninguno;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton RBdatabase;
        private System.Windows.Forms.SaveFileDialog SFDexport;
        private System.Windows.Forms.OpenFileDialog OFDimport;
        private System.ComponentModel.BackgroundWorker BWimport;
        private Diffusion_DataBaseDataSetTableAdapters.ClientsTableAdapter clientsTableAdapterM;
        private System.Windows.Forms.RibbonButton RBactualizarabonados;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonComboBox CBfiltrocolumna;
        private System.Windows.Forms.RibbonButton FRBabonado;
        private System.Windows.Forms.RibbonButton FRBcedula;
        private System.Windows.Forms.RibbonButton FRBnombre;
        private System.Windows.Forms.RibbonButton FRBdireccion;
        private System.Windows.Forms.RibbonButton FRBTelefono;
        private System.Windows.Forms.RibbonLabel ribbonLabel3;
        private System.Windows.Forms.RibbonTextBox RTBquery;
        private System.Windows.Forms.RibbonButton RBbuscar;
        private System.Windows.Forms.RibbonButton FRBsector;
        private System.Windows.Forms.RibbonButton FRBpendientes;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonPanel ribbonPanel8;
        private System.Windows.Forms.RibbonPanel ribbonPanel9;
        private System.Windows.Forms.RibbonButton RBinfo;
        private System.Windows.Forms.RibbonPanel ribbonPanel10;
        private System.Windows.Forms.RibbonButton RBtnpagweb;
        private System.Windows.Forms.RibbonPanel ribbonPanel11;
        private System.Windows.Forms.RibbonButton RBsoporte;
        private System.Windows.Forms.RibbonPanel ribbonPanel12;
        private System.Windows.Forms.RibbonButton RBconfig;
        private System.Windows.Forms.RibbonButton RBnewmessage;
        private System.Windows.Forms.RibbonButton RBTNsendsms;
        private System.Windows.Forms.RibbonPanel ribbonPanel13;
        private System.Windows.Forms.RibbonButton RBTNcancelsms;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.RibbonLabel RLBpendientes;
        private System.ComponentModel.BackgroundWorker BWsend;
        private System.Windows.Forms.RibbonButton RBTNcancelsend;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar PBsend;
    }
}

