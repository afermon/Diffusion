namespace Diffusion_2
{
    partial class working
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DGWworking = new System.Windows.Forms.DataGridView();
            this.ClientSector = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DGWworking)).BeginInit();
            this.SuspendLayout();
            // 
            // DGWworking
            // 
            this.DGWworking.AllowUserToAddRows = false;
            this.DGWworking.AllowUserToDeleteRows = false;
            this.DGWworking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGWworking.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClientSector,
            this.ClientName,
            this.ClientPhone,
            this.wStatus});
            this.DGWworking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGWworking.Location = new System.Drawing.Point(0, 0);
            this.DGWworking.Name = "DGWworking";
            this.DGWworking.ReadOnly = true;
            this.DGWworking.Size = new System.Drawing.Size(633, 362);
            this.DGWworking.TabIndex = 0;
            // 
            // ClientSector
            // 
            this.ClientSector.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClientSector.HeaderText = "Sector";
            this.ClientSector.Name = "ClientSector";
            this.ClientSector.ReadOnly = true;
            this.ClientSector.Width = 120;
            // 
            // ClientName
            // 
            this.ClientName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClientName.HeaderText = "Nombre";
            this.ClientName.Name = "ClientName";
            this.ClientName.ReadOnly = true;
            this.ClientName.Width = 200;
            // 
            // ClientPhone
            // 
            this.ClientPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ClientPhone.HeaderText = "Telefono";
            this.ClientPhone.Name = "ClientPhone";
            this.ClientPhone.ReadOnly = true;
            this.ClientPhone.Width = 120;
            // 
            // wStatus
            // 
            this.wStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.wStatus.HeaderText = "Estado";
            this.wStatus.Name = "wStatus";
            this.wStatus.ReadOnly = true;
            this.wStatus.Width = 150;
            // 
            // working
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 362);
            this.Controls.Add(this.DGWworking);
            this.Name = "working";
            this.Text = "Enviando mensajes";
            ((System.ComponentModel.ISupportInitialize)(this.DGWworking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGWworking;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientSector;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn wStatus;
    }
}