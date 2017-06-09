namespace UberFrba.Registro_Viajes
{
    partial class AltaViaje
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorCliente = new System.Windows.Forms.Label();
            this.errorChofer = new System.Windows.Forms.Label();
            this.errorCantKm = new System.Windows.Forms.Label();
            this.errorFechaHoraFin = new System.Windows.Forms.Label();
            this.errorFechaHoraIni = new System.Windows.Forms.Label();
            this.dtpFin = new System.Windows.Forms.DateTimePicker();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.btnSelectCliente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.bntSelectChofer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpErrorBaseDatos = new System.Windows.Forms.GroupBox();
            this.lblErrorBaseDatos = new System.Windows.Forms.Label();
            this.errorAuto = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpErrorBaseDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(618, 235);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 235);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 5;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorCliente);
            this.groupBox1.Controls.Add(this.errorChofer);
            this.groupBox1.Controls.Add(this.errorAuto);
            this.groupBox1.Controls.Add(this.errorCantKm);
            this.groupBox1.Controls.Add(this.errorFechaHoraFin);
            this.groupBox1.Controls.Add(this.errorFechaHoraIni);
            this.groupBox1.Controls.Add(this.dtpFin);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.btnSelectCliente);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTurno);
            this.groupBox1.Controls.Add(this.bntSelectChofer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtChofer);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtAuto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(681, 217);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // errorCliente
            // 
            this.errorCliente.AutoSize = true;
            this.errorCliente.ForeColor = System.Drawing.Color.Red;
            this.errorCliente.Location = new System.Drawing.Point(269, 187);
            this.errorCliente.Name = "errorCliente";
            this.errorCliente.Size = new System.Drawing.Size(0, 13);
            this.errorCliente.TabIndex = 26;
            // 
            // errorChofer
            // 
            this.errorChofer.AutoSize = true;
            this.errorChofer.ForeColor = System.Drawing.Color.Red;
            this.errorChofer.Location = new System.Drawing.Point(269, 109);
            this.errorChofer.Name = "errorChofer";
            this.errorChofer.Size = new System.Drawing.Size(0, 13);
            this.errorChofer.TabIndex = 24;
            // 
            // errorCantKm
            // 
            this.errorCantKm.AutoSize = true;
            this.errorCantKm.ForeColor = System.Drawing.Color.Red;
            this.errorCantKm.Location = new System.Drawing.Point(186, 83);
            this.errorCantKm.Name = "errorCantKm";
            this.errorCantKm.Size = new System.Drawing.Size(0, 13);
            this.errorCantKm.TabIndex = 22;
            // 
            // errorFechaHoraFin
            // 
            this.errorFechaHoraFin.AutoSize = true;
            this.errorFechaHoraFin.ForeColor = System.Drawing.Color.Red;
            this.errorFechaHoraFin.Location = new System.Drawing.Point(267, 57);
            this.errorFechaHoraFin.Name = "errorFechaHoraFin";
            this.errorFechaHoraFin.Size = new System.Drawing.Size(0, 13);
            this.errorFechaHoraFin.TabIndex = 21;
            // 
            // errorFechaHoraIni
            // 
            this.errorFechaHoraIni.AutoSize = true;
            this.errorFechaHoraIni.ForeColor = System.Drawing.Color.Red;
            this.errorFechaHoraIni.Location = new System.Drawing.Point(267, 31);
            this.errorFechaHoraIni.Name = "errorFechaHoraIni";
            this.errorFechaHoraIni.Size = new System.Drawing.Size(0, 13);
            this.errorFechaHoraIni.TabIndex = 20;
            // 
            // dtpFin
            // 
            this.dtpFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFin.Location = new System.Drawing.Point(107, 54);
            this.dtpFin.Name = "dtpFin";
            this.dtpFin.Size = new System.Drawing.Size(151, 20);
            this.dtpFin.TabIndex = 19;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(107, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(151, 20);
            this.dtpInicio.TabIndex = 18;
            // 
            // btnSelectCliente
            // 
            this.btnSelectCliente.Location = new System.Drawing.Point(183, 182);
            this.btnSelectCliente.Name = "btnSelectCliente";
            this.btnSelectCliente.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCliente.TabIndex = 17;
            this.btnSelectCliente.Text = "Seleccionar";
            this.btnSelectCliente.UseVisualStyleBackColor = true;
            this.btnSelectCliente.Click += new System.EventHandler(this.btnSelectCliente_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Cliente*";
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(57, 184);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.ReadOnly = true;
            this.txtCliente.Size = new System.Drawing.Size(121, 20);
            this.txtCliente.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Turno*";
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(57, 158);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(121, 20);
            this.txtTurno.TabIndex = 12;
            // 
            // bntSelectChofer
            // 
            this.bntSelectChofer.Location = new System.Drawing.Point(183, 104);
            this.bntSelectChofer.Name = "bntSelectChofer";
            this.bntSelectChofer.Size = new System.Drawing.Size(75, 23);
            this.bntSelectChofer.TabIndex = 11;
            this.bntSelectChofer.Text = "Seleccionar";
            this.bntSelectChofer.UseVisualStyleBackColor = true;
            this.bntSelectChofer.Click += new System.EventHandler(this.bntSelectChofer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chofer*";
            // 
            // txtChofer
            // 
            this.txtChofer.Location = new System.Drawing.Point(57, 106);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(121, 20);
            this.txtChofer.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Auto*";
            // 
            // txtAuto
            // 
            this.txtAuto.Location = new System.Drawing.Point(57, 132);
            this.txtAuto.Name = "txtAuto";
            this.txtAuto.ReadOnly = true;
            this.txtAuto.Size = new System.Drawing.Size(121, 20);
            this.txtAuto.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cant Km*";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(57, 80);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(121, 20);
            this.txtCantidad.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha y Hora Fin*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha y Hora Inicio*";
            // 
            // grpErrorBaseDatos
            // 
            this.grpErrorBaseDatos.Controls.Add(this.lblErrorBaseDatos);
            this.grpErrorBaseDatos.Location = new System.Drawing.Point(12, 272);
            this.grpErrorBaseDatos.Name = "grpErrorBaseDatos";
            this.grpErrorBaseDatos.Size = new System.Drawing.Size(681, 67);
            this.grpErrorBaseDatos.TabIndex = 16;
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
            // errorAuto
            // 
            this.errorAuto.AutoSize = true;
            this.errorAuto.ForeColor = System.Drawing.Color.Red;
            this.errorAuto.Location = new System.Drawing.Point(185, 134);
            this.errorAuto.Name = "errorAuto";
            this.errorAuto.Size = new System.Drawing.Size(0, 13);
            this.errorAuto.TabIndex = 23;
            // 
            // AltaViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 360);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaViaje";
            this.Text = "Registro de Viaje";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpErrorBaseDatos.ResumeLayout(false);
            this.grpErrorBaseDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bntSelectChofer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectCliente;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.DateTimePicker dtpFin;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label errorCliente;
        private System.Windows.Forms.Label errorChofer;
        private System.Windows.Forms.Label errorCantKm;
        private System.Windows.Forms.Label errorFechaHoraFin;
        private System.Windows.Forms.Label errorFechaHoraIni;
        private System.Windows.Forms.GroupBox grpErrorBaseDatos;
        private System.Windows.Forms.Label lblErrorBaseDatos;
        private System.Windows.Forms.Label errorAuto;
    }
}