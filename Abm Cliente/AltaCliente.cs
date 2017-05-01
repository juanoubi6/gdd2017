using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class AltaCliente : Form
    {
        public AltaCliente()
        {
            InitializeComponent();
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
                    errorFechaNac.Text = Cliente.validarFechaNac(DateTime.Parse(txtFechaNac.Text));
                    if (errorFechaNac.Text != "") contadorErrores++;
                }

                errorNombre.Text = Cliente.validarNombre(txtNombre.Text);
                if (errorNombre.Text != "") contadorErrores++;

                errorApellido.Text = Cliente.validarApellido(txtApellido.Text);
                if (errorApellido.Text != "") contadorErrores++;

                errorDni.Text = Cliente.validarDni(txtDni.Text);
                if (errorDni.Text != "") contadorErrores++;

                errorTelefono.Text = Cliente.validarTelefono(txtTelefono.Text);
                if (errorTelefono.Text != "") contadorErrores++;

                errorEmail.Text = Cliente.validarEmail(txtEmail.Text);
                if (errorEmail.Text != "") contadorErrores++;

                errorDireccion.Text = Cliente.validarDireccion(txtDireccion.Text);
                if (errorDireccion.Text != "") contadorErrores++;

                errorCodPostal.Text = Cliente.validarCodPostal(txtCodpostal.Text);
                if (errorCodPostal.Text != "") contadorErrores++;

                //Si no hay errores, se intenta guardar el nuevo cliente
                if (contadorErrores == 0)
                {
                    Cliente clienteAGrabar          = new Cliente();
                    clienteAGrabar.Nombre           = txtNombre.Text;
                    clienteAGrabar.Apellido         = txtApellido.Text;
                    clienteAGrabar.Dni              = Decimal.Parse(txtDni.Text);
                    clienteAGrabar.Telefono         = Decimal.Parse(txtTelefono.Text);
                    clienteAGrabar.Direccion        = txtDireccion.Text;
                    clienteAGrabar.CodigoPostal     = Decimal.Parse(txtCodpostal.Text);
                    clienteAGrabar.FechaNacimiento  = DateTime.Parse(txtFechaNac.Text);
                    clienteAGrabar.Activo           = 1;
                    clienteAGrabar.Mail             = (txtEmail.Text == "")? null : txtEmail.Text;

                    String[] respuesta = Cliente.grabarCliente(clienteAGrabar);
                    if (respuesta[0] == "Error")
                    {
                        lblErrorBaseDatos.Text = respuesta[1];
                        grpErrorBaseDatos.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            calendarioFechaNac.Visible  = true;
            btnCalendario.Visible       = false;
            calendarioFechaNac.BringToFront();
        }

        private void calendarioFechaNac_DateSelected(object sender, DateRangeEventArgs e)
        {
            txtFechaNac.Text = e.Start.ToShortDateString();
            calendarioFechaNac.Visible = false;
            btnCalendario.Visible = true;           
        }
    }
}
