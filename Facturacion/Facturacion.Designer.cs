namespace UberFrba.Facturacion
{
    partial class Facturacion
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
            this.grpErrorBaseDatos = new System.Windows.Forms.GroupBox();
            this.lblErrorBaseDatos = new System.Windows.Forms.Label();
            this.btnFacturar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectCliente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.errorViajes = new System.Windows.Forms.Label();
            this.errorFechaFin = new System.Windows.Forms.Label();
            this.errorFechaIni = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantViajes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grillaViajesFactura = new System.Windows.Forms.DataGridView();
            this.errorCliente = new System.Windows.Forms.Label();
            this.grpErrorBaseDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaViajesFactura)).BeginInit();
            this.SuspendLayout();
            // 
            // grpErrorBaseDatos
            // 
            this.grpErrorBaseDatos.Controls.Add(this.lblErrorBaseDatos);
            this.grpErrorBaseDatos.Location = new System.Drawing.Point(12, 427);
            this.grpErrorBaseDatos.Name = "grpErrorBaseDatos";
            this.grpErrorBaseDatos.Size = new System.Drawing.Size(1016, 67);
            this.grpErrorBaseDatos.TabIndex = 20;
            this.grpErrorBaseDatos.TabStop = false;
            this.grpErrorBaseDatos.Text = "Error de base de datos";
            this.grpErrorBaseDatos.Visible = false;
            // 
            // lblErrorBaseDatos
            // 
            this.lblErrorBaseDatos.AutoSize = true;
            this.lblErrorBaseDatos.Location = new System.Drawing.Point(10, 30);
            this.lblErrorBaseDatos.Name = "lblErrorBaseDatos";
            this.lblErrorBaseDatos.Size = new System.Drawing.Size(0, 13);
            this.lblErrorBaseDatos.TabIndex = 0;
            // 
            // btnFacturar
            // 
            this.btnFacturar.Location = new System.Drawing.Point(953, 157);
            this.btnFacturar.Name = "btnFacturar";
            this.btnFacturar.Size = new System.Drawing.Size(75, 23);
            this.btnFacturar.TabIndex = 19;
            this.btnFacturar.Text = "Facturar";
            this.btnFacturar.UseVisualStyleBackColor = true;
            this.btnFacturar.Click += new System.EventHandler(this.btnFacturar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 160);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorCliente);
            this.groupBox1.Controls.Add(this.btnSelectCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.errorViajes);
            this.groupBox1.Controls.Add(this.errorFechaFin);
            this.groupBox1.Controls.Add(this.errorFechaIni);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCantViajes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 139);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // btnSelectCliente
            // 
            this.btnSelectCliente.Location = new System.Drawing.Point(183, 78);
            this.btnSelectCliente.Name = "btnSelectCliente";
            this.btnSelectCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCliente.TabIndex = 29;
            this.btnSelectCliente.Text = "Seleccionar";
            this.btnSelectCliente.UseVisualStyleBackColor = true;
            this.btnSelectCliente.Click += new System.EventHandler(this.btnSelectCliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 83);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Cliente*";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(57, 80);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(121, 20);
            this.txtCliente.TabIndex = 27;
            // 
            // errorViajes
            // 
            this.errorViajes.AutoSize = true;
            this.errorViajes.ForeColor = System.Drawing.Color.Red;
            this.errorViajes.Location = new System.Drawing.Point(187, 109);
            this.errorViajes.Name = "errorViajes";
            this.errorViajes.Size = new System.Drawing.Size(0, 13);
            this.errorViajes.TabIndex = 24;
            // 
            // errorFechaFin
            // 
            this.errorFechaFin.AutoSize = true;
            this.errorFechaFin.ForeColor = System.Drawing.Color.Red;
            this.errorFechaFin.Location = new System.Drawing.Point(185, 57);
            this.errorFechaFin.Name = "errorFechaFin";
            this.errorFechaFin.Size = new System.Drawing.Size(0, 13);
            this.errorFechaFin.TabIndex = 21;
            // 
            // errorFechaIni
            // 
            this.errorFechaIni.AutoSize = true;
            this.errorFechaIni.ForeColor = System.Drawing.Color.Red;
            this.errorFechaIni.Location = new System.Drawing.Point(185, 31);
            this.errorFechaIni.Name = "errorFechaIni";
            this.errorFechaIni.Size = new System.Drawing.Size(0, 13);
            this.errorFechaIni.TabIndex = 20;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(79, 54);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(99, 20);
            this.dtpFin.TabIndex = 19;
            this.dtpFin.ValueChanged += new System.EventHandler(this.dtpFin_ValueChanged);
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(78, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(100, 20);
            this.dtpInicio.TabIndex = 18;
            this.dtpInicio.ValueChanged += new System.EventHandler(this.dtpInicio_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Viajes";
            // 
            // txtCantViajes
            // 
            this.txtCantViajes.Location = new System.Drawing.Point(57, 106);
            this.txtCantViajes.Name = "txtCantViajes";
            this.txtCantViajes.ReadOnly = true;
            this.txtCantViajes.Size = new System.Drawing.Size(121, 20);
            this.txtCantViajes.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha Fin*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio*";
            // 
            // grillaViajesFactura
            // 
            this.grillaViajesFactura.AllowUserToAddRows = false;
            this.grillaViajesFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaViajesFactura.Location = new System.Drawing.Point(12, 189);
            this.grillaViajesFactura.Name = "grillaViajesFactura";
            this.grillaViajesFactura.ReadOnly = true;
            this.grillaViajesFactura.Size = new System.Drawing.Size(1016, 232);
            this.grillaViajesFactura.TabIndex = 21;
            // 
            // errorCliente
            // 
            this.errorCliente.AutoSize = true;
            this.errorCliente.ForeColor = System.Drawing.Color.Red;
            this.errorCliente.Location = new System.Drawing.Point(264, 83);
            this.errorCliente.Name = "errorCliente";
            this.errorCliente.Size = new System.Drawing.Size(0, 13);
            this.errorCliente.TabIndex = 30;
            // 
            // Facturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 503);
            this.Controls.Add(this.grillaViajesFactura);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnFacturar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "Facturacion";
            this.Text = "Facturacion";
            this.grpErrorBaseDatos.ResumeLayout(false);
            this.grpErrorBaseDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaViajesFactura)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorBaseDatos;
        private System.Windows.Forms.Label lblErrorBaseDatos;
        private System.Windows.Forms.Button btnFacturar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label errorViajes;
        private System.Windows.Forms.Label errorFechaFin;
        private System.Windows.Forms.Label errorFechaIni;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantViajes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView grillaViajesFactura;
        private System.Windows.Forms.Label errorCliente;
    }
}