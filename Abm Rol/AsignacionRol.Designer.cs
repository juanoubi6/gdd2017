namespace UberFrba.Abm_Rol
{
    partial class AsignacionRol
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSeleccionUsuario = new System.Windows.Forms.Button();
            this.errorRoles = new System.Windows.Forms.Label();
            this.errorUsuario = new System.Windows.Forms.Label();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpErrorBaseDatos.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpErrorBaseDatos
            // 
            this.grpErrorBaseDatos.Controls.Add(this.lblErrorBaseDatos);
            this.grpErrorBaseDatos.Location = new System.Drawing.Point(12, 232);
            this.grpErrorBaseDatos.Name = "grpErrorBaseDatos";
            this.grpErrorBaseDatos.Size = new System.Drawing.Size(506, 67);
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
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(443, 192);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 19;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 192);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 18;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSeleccionUsuario);
            this.groupBox1.Controls.Add(this.errorRoles);
            this.groupBox1.Controls.Add(this.errorUsuario);
            this.groupBox1.Controls.Add(this.lstRoles);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 174);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // btnSeleccionUsuario
            // 
            this.btnSeleccionUsuario.Location = new System.Drawing.Point(176, 26);
            this.btnSeleccionUsuario.Name = "btnSeleccionUsuario";
            this.btnSeleccionUsuario.Size = new System.Drawing.Size(28, 23);
            this.btnSeleccionUsuario.TabIndex = 16;
            this.btnSeleccionUsuario.Text = "...";
            this.btnSeleccionUsuario.UseVisualStyleBackColor = true;
            this.btnSeleccionUsuario.Click += new System.EventHandler(this.btnSeleccionUsuario_Click);
            // 
            // errorRoles
            // 
            this.errorRoles.AutoSize = true;
            this.errorRoles.Location = new System.Drawing.Point(184, 88);
            this.errorRoles.Name = "errorRoles";
            this.errorRoles.Size = new System.Drawing.Size(0, 13);
            this.errorRoles.TabIndex = 15;
            // 
            // errorUsuario
            // 
            this.errorUsuario.AutoSize = true;
            this.errorUsuario.Location = new System.Drawing.Point(212, 30);
            this.errorUsuario.Name = "errorUsuario";
            this.errorUsuario.Size = new System.Drawing.Size(0, 13);
            this.errorUsuario.TabIndex = 14;
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(51, 53);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRoles.Size = new System.Drawing.Size(120, 95);
            this.lstRoles.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Rol*";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(50, 27);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(121, 20);
            this.txtUsuario.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Para seleccionar más de uno,  presionar Ctrl";
            // 
            // AsignacionRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 317);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "AsignacionRol";
            this.Text = "AsignacionRol";
            this.Load += new System.EventHandler(this.AsignacionRol_Load);
            this.grpErrorBaseDatos.ResumeLayout(false);
            this.grpErrorBaseDatos.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpErrorBaseDatos;
        private System.Windows.Forms.Label lblErrorBaseDatos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSeleccionUsuario;
        private System.Windows.Forms.Label errorRoles;
        private System.Windows.Forms.Label errorUsuario;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}