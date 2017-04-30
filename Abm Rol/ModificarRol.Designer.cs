namespace UberFrba.Abm_Rol
{
    partial class ModificarRol
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
            this.errorFuncionalidad = new System.Windows.Forms.Label();
            this.errorNombre = new System.Windows.Forms.Label();
            this.lstFuncionalidad = new System.Windows.Forms.ListBox();
            this.chkHabilitado = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorFuncionalidad);
            this.groupBox1.Controls.Add(this.errorNombre);
            this.groupBox1.Controls.Add(this.lstFuncionalidad);
            this.groupBox1.Controls.Add(this.chkHabilitado);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(506, 174);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Carga de Campos";
            // 
            // errorFuncionalidad
            // 
            this.errorFuncionalidad.AutoSize = true;
            this.errorFuncionalidad.Location = new System.Drawing.Point(219, 88);
            this.errorFuncionalidad.Name = "errorFuncionalidad";
            this.errorFuncionalidad.Size = new System.Drawing.Size(0, 13);
            this.errorFuncionalidad.TabIndex = 15;
            // 
            // errorNombre
            // 
            this.errorNombre.AutoSize = true;
            this.errorNombre.Location = new System.Drawing.Point(212, 30);
            this.errorNombre.Name = "errorNombre";
            this.errorNombre.Size = new System.Drawing.Size(0, 13);
            this.errorNombre.TabIndex = 14;
            // 
            // lstFuncionalidad
            // 
            this.lstFuncionalidad.FormattingEnabled = true;
            this.lstFuncionalidad.Location = new System.Drawing.Point(85, 53);
            this.lstFuncionalidad.Name = "lstFuncionalidad";
            this.lstFuncionalidad.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstFuncionalidad.Size = new System.Drawing.Size(120, 95);
            this.lstFuncionalidad.TabIndex = 13;
            // 
            // chkHabilitado
            // 
            this.chkHabilitado.AutoSize = true;
            this.chkHabilitado.Location = new System.Drawing.Point(6, 151);
            this.chkHabilitado.Name = "chkHabilitado";
            this.chkHabilitado.Size = new System.Drawing.Size(73, 17);
            this.chkHabilitado.TabIndex = 12;
            this.chkHabilitado.Text = "Habilitado";
            this.chkHabilitado.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Funcionalidad*";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(85, 27);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(121, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre*";
            // 
            // ModificarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 313);
            this.Controls.Add(this.grpErrorBaseDatos);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Name = "ModificarRol";
            this.Text = "ModificarRol";
            this.Load += new System.EventHandler(this.ModificarRol_Load);
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
        private System.Windows.Forms.Label errorFuncionalidad;
        private System.Windows.Forms.Label errorNombre;
        private System.Windows.Forms.ListBox lstFuncionalidad;
        private System.Windows.Forms.CheckBox chkHabilitado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label1;
    }
}