namespace UberFrba.Rendicion_Viajes
{
    partial class RendicionViaje
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
            this.grillaViajesRendicion = new System.Windows.Forms.DataGridView();
            this.grpErrorBaseDatos = new System.Windows.Forms.GroupBox();
            this.lblErrorBaseDatos = new System.Windows.Forms.Label();
            this.btnRendir = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectChofer = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtChofer = new System.Windows.Forms.TextBox();
            this.errorTurno = new System.Windows.Forms.Label();
            this.errorFecha = new System.Windows.Forms.Label();
            this.dtpInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.errorChofer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grillaViajesRendicion)).BeginInit();
            this.grpErrorBaseDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grillaViajesRendicion
            // 
            this.grillaViajesRendicion.AllowUserToAddRows = false;
            this.grillaViajesRendicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaViajesRendicion.Location = new System.Drawing.Point(12, 159);
            this.grillaViajesRendicion.Name = "grillaViajesRendicion";
            this.grillaViajesRendicion.ReadOnly = true;
            this.grillaViajesRendicion.Size = new System.Drawing.Size(1016, 232);
            this.grillaViajesRendicion.TabIndex = 26;
            // 
            // grpErrorBaseDatos
            // 
            this.grpErrorBaseDatos.Controls.Add(this.lblErrorBaseDatos);
            this.grpErrorBaseDatos.Location = new System.Drawing.Point(12, 397);
            this.grpErrorBaseDatos.Name = "grpErrorBaseDatos";
            this.grpErrorBaseDatos.Size = new System.Drawing.Size(1016, 67);
            this.grpErrorBaseDatos.TabIndex = 25;
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
            // btnRendir
            // 
            this.btnRendir.Location = new System.Drawing.Point(953, 127);
            this.btnRendir.Name = "btnRendir";
            this.btnRendir.Size = new System.Drawing.Size(75, 23);
            this.btnRendir.TabIndex = 24;
            this.btnRendir.Text = "Rendir";
            this.btnRendir.UseVisualStyleBackColor = true;
            this.btnRendir.Click += new System.EventHandler(this.btnRendir_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 130);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 23;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorChofer);
            this.groupBox1.Controls.Add(this.btnSelectChofer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtChofer);
            this.groupBox1.Controls.Add(this.errorTurno);
            this.groupBox1.Controls.Add(this.errorFecha);
            this.groupBox1.Controls.Add(this.dtpInicio);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtTurno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1016, 110);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // btnSelectChofer
            // 
            this.btnSelectChofer.Location = new System.Drawing.Point(183, 52);
            this.btnSelectChofer.Name = "btnSelectChofer";
            this.btnSelectChofer.Size = new System.Drawing.Size(75, 23);
            this.btnSelectChofer.TabIndex = 29;
            this.btnSelectChofer.Text = "Seleccionar";
            this.btnSelectChofer.UseVisualStyleBackColor = true;
            this.btnSelectChofer.Click += new System.EventHandler(this.btnSelectChofer_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Chofer*";
            // 
            // txtChofer
            // 
            this.txtChofer.Location = new System.Drawing.Point(57, 54);
            this.txtChofer.Name = "txtChofer";
            this.txtChofer.ReadOnly = true;
            this.txtChofer.Size = new System.Drawing.Size(121, 20);
            this.txtChofer.TabIndex = 27;
            // 
            // errorTurno
            // 
            this.errorTurno.AutoSize = true;
            this.errorTurno.ForeColor = System.Drawing.Color.Red;
            this.errorTurno.Location = new System.Drawing.Point(187, 83);
            this.errorTurno.Name = "errorTurno";
            this.errorTurno.Size = new System.Drawing.Size(0, 13);
            this.errorTurno.TabIndex = 24;
            // 
            // errorFecha
            // 
            this.errorFecha.AutoSize = true;
            this.errorFecha.ForeColor = System.Drawing.Color.Red;
            this.errorFecha.Location = new System.Drawing.Point(163, 31);
            this.errorFecha.Name = "errorFecha";
            this.errorFecha.Size = new System.Drawing.Size(0, 13);
            this.errorFecha.TabIndex = 20;
            // 
            // dtpInicio
            // 
            this.dtpInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInicio.Location = new System.Drawing.Point(57, 28);
            this.dtpInicio.Name = "dtpInicio";
            this.dtpInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpInicio.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Turno";
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(57, 80);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.ReadOnly = true;
            this.txtTurno.Size = new System.Drawing.Size(121, 20);
            this.txtTurno.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha*";
            // 
            // errorChofer
            // 
            this.errorChofer.AutoSize = true;
            this.errorChofer.Location = new System.Drawing.Point(265, 58);
            this.errorChofer.Name = "errorChofer";
            this.errorChofer.Size = new System.Drawing.Size(0, 13);
            this.errorChofer.TabIndex = 30;
            // 
            // RendicionViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 475);
            this.Controls.Add(this.grillaViajesRendicion);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnRendir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "RendicionViaje";
            this.Text = "Rendicion de Viajes";
            ((System.ComponentModel.ISupportInitialize)(this.grillaViajesRendicion)).EndInit();
            this.grpErrorBaseDatos.ResumeLayout(false);
            this.grpErrorBaseDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grillaViajesRendicion;
        private System.Windows.Forms.GroupBox grpErrorBaseDatos;
        private System.Windows.Forms.Label lblErrorBaseDatos;
        private System.Windows.Forms.Button btnRendir;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectChofer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtChofer;
        private System.Windows.Forms.Label errorTurno;
        private System.Windows.Forms.Label errorFecha;
        private System.Windows.Forms.DateTimePicker dtpInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label errorChofer;
    }
}