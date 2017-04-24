namespace UberFrba.Abm_Cliente
{
    partial class AltaCliente
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
            this.errorCodPostal = new System.Windows.Forms.Label();
            this.errorDireccion = new System.Windows.Forms.Label();
            this.errorEmail = new System.Windows.Forms.Label();
            this.errorTelefono = new System.Windows.Forms.Label();
            this.errorDni = new System.Windows.Forms.Label();
            this.errorNombre = new System.Windows.Forms.Label();
            this.errorApellido = new System.Windows.Forms.Label();
            this.errorFechaNac = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCodpostal = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.calendarioFechaNac = new System.Windows.Forms.MonthCalendar();
            this.btnCalendario = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.grpErrorBaseDatos = new System.Windows.Forms.GroupBox();
            this.lblErrorBaseDatos = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpErrorBaseDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(591, 280);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 280);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 9;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorCodPostal);
            this.groupBox1.Controls.Add(this.errorDireccion);
            this.groupBox1.Controls.Add(this.errorEmail);
            this.groupBox1.Controls.Add(this.errorTelefono);
            this.groupBox1.Controls.Add(this.errorDni);
            this.groupBox1.Controls.Add(this.errorNombre);
            this.groupBox1.Controls.Add(this.errorApellido);
            this.groupBox1.Controls.Add(this.errorFechaNac);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCodpostal);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDni);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.calendarioFechaNac);
            this.groupBox1.Controls.Add(this.btnCalendario);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtFechaNac);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.chkHabilitado);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 262);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // errorCodPostal
            // 
            this.errorCodPostal.AutoSize = true;
            this.errorCodPostal.Location = new System.Drawing.Point(195, 213);
            this.errorCodPostal.Name = "errorCodPostal";
            this.errorCodPostal.Size = new System.Drawing.Size(0, 13);
            this.errorCodPostal.TabIndex = 44;
            // 
            // errorDireccion
            // 
            this.errorDireccion.AutoSize = true;
            this.errorDireccion.Location = new System.Drawing.Point(195, 187);
            this.errorDireccion.Name = "errorDireccion";
            this.errorDireccion.Size = new System.Drawing.Size(0, 13);
            this.errorDireccion.TabIndex = 43;
            // 
            // errorEmail
            // 
            this.errorEmail.AutoSize = true;
            this.errorEmail.Location = new System.Drawing.Point(195, 161);
            this.errorEmail.Name = "errorEmail";
            this.errorEmail.Size = new System.Drawing.Size(0, 13);
            this.errorEmail.TabIndex = 42;
            // 
            // errorTelefono
            // 
            this.errorTelefono.AutoSize = true;
            this.errorTelefono.Location = new System.Drawing.Point(195, 135);
            this.errorTelefono.Name = "errorTelefono";
            this.errorTelefono.Size = new System.Drawing.Size(0, 13);
            this.errorTelefono.TabIndex = 41;
            // 
            // errorDni
            // 
            this.errorDni.AutoSize = true;
            this.errorDni.Location = new System.Drawing.Point(195, 109);
            this.errorDni.Name = "errorDni";
            this.errorDni.Size = new System.Drawing.Size(0, 13);
            this.errorDni.TabIndex = 40;
            // 
            // errorNombre
            // 
            this.errorNombre.AutoSize = true;
            this.errorNombre.Location = new System.Drawing.Point(195, 83);
            this.errorNombre.Name = "errorNombre";
            this.errorNombre.Size = new System.Drawing.Size(0, 13);
            this.errorNombre.TabIndex = 39;
            // 
            // errorApellido
            // 
            this.errorApellido.AutoSize = true;
            this.errorApellido.Location = new System.Drawing.Point(195, 57);
            this.errorApellido.Name = "errorApellido";
            this.errorApellido.Size = new System.Drawing.Size(0, 13);
            this.errorApellido.TabIndex = 38;
            // 
            // errorFechaNac
            // 
            this.errorFechaNac.AutoSize = true;
            this.errorFechaNac.Location = new System.Drawing.Point(278, 31);
            this.errorFechaNac.Name = "errorFechaNac";
            this.errorFechaNac.Size = new System.Drawing.Size(0, 13);
            this.errorFechaNac.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Cod.Postal*";
            // 
            // txtCodpostal
            // 
            this.txtCodpostal.Location = new System.Drawing.Point(68, 210);
            this.txtCodpostal.Name = "txtCodpostal";
            this.txtCodpostal.Size = new System.Drawing.Size(121, 20);
            this.txtCodpostal.TabIndex = 35;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(68, 80);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Nombre*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "DNI*";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(68, 106);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(121, 20);
            this.txtDni.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Direccion*";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(68, 184);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(121, 20);
            this.txtDireccion.TabIndex = 29;
            // 
            // calendarioFechaNac
            // 
            this.calendarioFechaNac.Location = new System.Drawing.Point(115, 25);
            this.calendarioFechaNac.Name = "calendarioFechaNac";
            this.calendarioFechaNac.TabIndex = 26;
            this.calendarioFechaNac.Visible = false;
            this.calendarioFechaNac.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.calendarioFechaNac_DateSelected);
            // 
            // btnCalendario
            // 
            this.btnCalendario.Location = new System.Drawing.Point(242, 26);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(29, 20);
            this.btnCalendario.TabIndex = 25;
            this.btnCalendario.Text = "...";
            this.btnCalendario.UseVisualStyleBackColor = true;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Fecha de Nacimiento";
            // 
            // txtFechaNac
            // 
            this.txtFechaNac.Location = new System.Drawing.Point(115, 26);
            this.txtFechaNac.Name = "txtFechaNac";
            this.txtFechaNac.ReadOnly = true;
            this.txtFechaNac.Size = new System.Drawing.Size(121, 20);
            this.txtFechaNac.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(68, 158);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(121, 20);
            this.txtEmail.TabIndex = 13;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(10, 236);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 12;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            this.chkHabilitado.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telefono*";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(68, 132);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(121, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Apellido*";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(68, 54);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(121, 20);
            this.txtApellido.TabIndex = 2;
            // 
            // grpErrorBaseDatos
            // 
            this.grpErrorBaseDatos.Controls.Add(this.lblErrorBaseDatos);
            this.grpErrorBaseDatos.Location = new System.Drawing.Point(12, 321);
            this.grpErrorBaseDatos.Name = "grpErrorBaseDatos";
            this.grpErrorBaseDatos.Size = new System.Drawing.Size(654, 74);
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
            // AltaCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 407);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AltaCliente";
            this.Text = "Alta Cliente";
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
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.MonthCalendar calendarioFechaNac;
        private System.Windows.Forms.Button btnCalendario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFechaNac;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodpostal;
        private System.Windows.Forms.Label errorCodPostal;
        private System.Windows.Forms.Label errorDireccion;
        private System.Windows.Forms.Label errorEmail;
        private System.Windows.Forms.Label errorTelefono;
        private System.Windows.Forms.Label errorDni;
        private System.Windows.Forms.Label errorNombre;
        private System.Windows.Forms.Label errorApellido;
        private System.Windows.Forms.Label errorFechaNac;
        private System.Windows.Forms.GroupBox grpErrorBaseDatos;
        private System.Windows.Forms.Label lblErrorBaseDatos;
    }
}