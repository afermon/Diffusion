namespace Diffusion_2
{
    partial class send
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
            this.clientsTableAdapter = new Diffusion_2.Diffusion_DataBaseDataSetTableAdapters.ClientsTableAdapter();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTNcancelar = new System.Windows.Forms.Button();
            this.BTNsend = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.LBleft = new System.Windows.Forms.Label();
            this.BNTselectnone = new System.Windows.Forms.Button();
            this.BTNselectall = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CLBsectores = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBmessage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 500F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 538);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BTNcancelar);
            this.panel1.Controls.Add(this.BTNsend);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.LBleft);
            this.panel1.Controls.Add(this.BNTselectnone);
            this.panel1.Controls.Add(this.BTNselectall);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.CLBsectores);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.TBmessage);
            this.panel1.Location = new System.Drawing.Point(133, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(494, 354);
            this.panel1.TabIndex = 0;
            // 
            // BTNcancelar
            // 
            this.BTNcancelar.Location = new System.Drawing.Point(270, 328);
            this.BTNcancelar.Name = "BTNcancelar";
            this.BTNcancelar.Size = new System.Drawing.Size(119, 23);
            this.BTNcancelar.TabIndex = 9;
            this.BTNcancelar.Text = "Cancelar";
            this.BTNcancelar.UseVisualStyleBackColor = true;
            this.BTNcancelar.Click += new System.EventHandler(this.BTNcancelar_Click);
            // 
            // BTNsend
            // 
            this.BTNsend.Location = new System.Drawing.Point(110, 328);
            this.BTNsend.Name = "BTNsend";
            this.BTNsend.Size = new System.Drawing.Size(114, 23);
            this.BTNsend.TabIndex = 8;
            this.BTNsend.Text = "Programar SMS";
            this.BTNsend.UseVisualStyleBackColor = true;
            this.BTNsend.Click += new System.EventHandler(this.BTNsend_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maximo 160 caracteres.";
            // 
            // LBleft
            // 
            this.LBleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBleft.ForeColor = System.Drawing.Color.Red;
            this.LBleft.Location = new System.Drawing.Point(386, 302);
            this.LBleft.Name = "LBleft";
            this.LBleft.Size = new System.Drawing.Size(96, 23);
            this.LBleft.TabIndex = 6;
            this.LBleft.Text = "( 160 Restantes )";
            this.LBleft.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BNTselectnone
            // 
            this.BNTselectnone.Location = new System.Drawing.Point(173, 186);
            this.BNTselectnone.Name = "BNTselectnone";
            this.BNTselectnone.Size = new System.Drawing.Size(140, 30);
            this.BNTselectnone.TabIndex = 5;
            this.BNTselectnone.Text = "Borrar selección";
            this.BNTselectnone.UseVisualStyleBackColor = true;
            this.BNTselectnone.Click += new System.EventHandler(this.BNTselectnone_Click);
            // 
            // BTNselectall
            // 
            this.BTNselectall.Location = new System.Drawing.Point(27, 186);
            this.BTNselectall.Name = "BTNselectall";
            this.BTNselectall.Size = new System.Drawing.Size(140, 30);
            this.BTNselectall.TabIndex = 4;
            this.BTNselectall.Text = "Seleccionar Todos";
            this.BTNselectall.UseVisualStyleBackColor = true;
            this.BTNselectall.Click += new System.EventHandler(this.BTNselectall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(23, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sectores a notificar";
            // 
            // CLBsectores
            // 
            this.CLBsectores.CheckOnClick = true;
            this.CLBsectores.FormattingEnabled = true;
            this.CLBsectores.Location = new System.Drawing.Point(27, 26);
            this.CLBsectores.Name = "CLBsectores";
            this.CLBsectores.Size = new System.Drawing.Size(455, 154);
            this.CLBsectores.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(23, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mensaje:";
            // 
            // TBmessage
            // 
            this.TBmessage.Location = new System.Drawing.Point(27, 242);
            this.TBmessage.MaxLength = 160;
            this.TBmessage.Multiline = true;
            this.TBmessage.Name = "TBmessage";
            this.TBmessage.Size = new System.Drawing.Size(455, 57);
            this.TBmessage.TabIndex = 0;
            this.TBmessage.TextChanged += new System.EventHandler(this.TBmessage_TextChanged);
            // 
            // send
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "send";
            this.Text = "Envio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.send_FormClosed);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Diffusion_DataBaseDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LBleft;
        private System.Windows.Forms.Button BNTselectnone;
        private System.Windows.Forms.Button BTNselectall;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox CLBsectores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBmessage;
        private System.Windows.Forms.Button BTNcancelar;
        private System.Windows.Forms.Button BTNsend;
    }
}