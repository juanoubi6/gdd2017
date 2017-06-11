using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class AltaChofer : Form
    {
        public AltaChofer()
        {
            InitializeComponent();
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            calendarioFechaNac.Visible = true;
            btnCalendario.Visible = false;
            calendarioFechaNac.BringToFront();
        }

        private void calendarioFechaNac_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = e.Start.ToShortDateString();
            calendarioFechaNac.Visible = false;
            btnCalendario.Visible = true;  
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int contadorErrores = 0;

                if (txtFechaNac.Text == "")
                {
                    errorFechaNac.Text = "El campo no puede ser vacio";
                    contadorErrores++;
                }
                else
                {
                    errorFechaNac.Text = Chofer.validarFechaNac(DateTime.Parse(txtFechaNac.Text));
                    if (errorFechaNac.Text != "") contadorErrores++;
                }

                errorNombre.Text = Chofer.validarNombre(txtNombre.Text);
                if (errorNombre.Text != "") contadorErrores++;

                errorApellido.Text = Chofer.validarApellido(txtApellido.Text);
                if (errorApellido.Text != "") contadorErrores++;

                errorDni.Text = Chofer.validarDni(txtDni.Text);
                if (errorDni.Text != "") contadorErrores++;

                errorTelefono.Text = Chofer.validarTelefono(txtTelefono.Text);
                if (errorTelefono.Text != "") contadorErrores++;

                errorEmail.Text = Chofer.validarEmail(txtEmail.Text);
                if (errorEmail.Text != "") contadorErrores++;

                errorDireccion.Text = Chofer.validarDireccion(txtDireccion.Text);
                if (errorDireccion.Text != "") contadorErrores++;

                //Si no hay errores, se intenta guardar el nuevo chofer
                if (contadorErrores == 0)
                {
                    Chofer choferAGrabar = new Chofer();
                    choferAGrabar.Nombre = txtNombre.Text;
                    choferAGrabar.Apellido = txtApellido.Text;
                    choferAGrabar.Dni = Decimal.Parse(txtDni.Text);
                    choferAGrabar.Telefono = Decimal.Parse(txtTelefono.Text);
                    choferAGrabar.Direccion = txtDireccion.Text;
                    choferAGrabar.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                    choferAGrabar.Activo = 1;
                    choferAGrabar.Mail = txtEmail.Text;

                    String[] respuesta = Chofer.grabarChofer(choferAGrabar);
                    if (respuesta[0] == "Error")
                    {
                        lblErrorBaseDatos.Text = respuesta[1];
                        grpErrorBaseDatos.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                        lblErrorBaseDatos.Text = String.Empty;
                        grpErrorBaseDatos.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            txtApellido.Text = String.Empty;
            txtDireccion.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtDni.Text = String.Empty;
            txtFechaNac.Text = String.Empty;
            txtTelefono.Text = String.Empty;
            errorNombre.Text = String.Empty;
            errorApellido.Text = String.Empty;
            errorDireccion.Text = String.Empty;
            errorEmail.Text = String.Empty;
            errorDni.Text = String.Empty;
            errorFechaNac.Text = String.Empty;
            errorTelefono.Text = String.Empty;
            lblErrorBaseDatos.Text = String.Empty;
            grpErrorBaseDatos.Visible = false;
        }
    }
}
