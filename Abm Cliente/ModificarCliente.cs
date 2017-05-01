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
    public partial class ModificarCliente : Form
    {
        private Cliente clienteAModificar;

        public ModificarCliente(Cliente cliente)
        {
            InitializeComponent();
            this.clienteAModificar = cliente;
        }

        private void ModificarCliente_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo en pantalla los datos del cliente elegido
                txtNombre.Text = clienteAModificar.Nombre;
                txtApellido.Text = clienteAModificar.Apellido;
                txtCodpostal.Text = clienteAModificar.CodigoPostal.ToString();
                txtDireccion.Text = clienteAModificar.Direccion;
                txtTelefono.Text = clienteAModificar.Telefono.ToString();
                txtFechaNac.Text = clienteAModificar.FechaNacimiento.ToShortDateString();
                txtDni.Text = clienteAModificar.Dni.ToString();
                txtEmail.Text = clienteAModificar.Mail;
                chkHabilitado.Checked = (clienteAModificar.Activo == 1) ? true : false;               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado " + ex.Message, "Error", MessageBoxButtons.OK);
            }
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

                //Valido que el campo Telefono sea correcto y no esté repetido si es que se modificó
                if (txtTelefono.Text != clienteAModificar.Telefono.ToString())
                {
                    errorTelefono.Text = Cliente.validarTelefono(txtTelefono.Text);
                    if (errorTelefono.Text != "") contadorErrores++;
                }

                errorEmail.Text = Cliente.validarEmail(txtEmail.Text);
                if (errorEmail.Text != "") contadorErrores++;

                errorDireccion.Text = Cliente.validarDireccion(txtDireccion.Text);
                if (errorDireccion.Text != "") contadorErrores++;

                errorCodPostal.Text = Cliente.validarCodPostal(txtCodpostal.Text);
                if (errorCodPostal.Text != "") contadorErrores++;

                //Si no hay errores, se intenta guardar el nuevo cliente
                if (contadorErrores == 0)
                {
                    Cliente clienteAModificarEnBD = new Cliente();
                    clienteAModificarEnBD.Nombre = txtNombre.Text;
                    clienteAModificarEnBD.Apellido = txtApellido.Text;
                    clienteAModificarEnBD.Dni = Decimal.Parse(txtDni.Text);
                    clienteAModificarEnBD.Telefono = Decimal.Parse(txtTelefono.Text);
                    clienteAModificarEnBD.Direccion = txtDireccion.Text;
                    clienteAModificarEnBD.CodigoPostal = Decimal.Parse(txtCodpostal.Text);
                    clienteAModificarEnBD.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                    clienteAModificarEnBD.Activo = (chkHabilitado.Checked) ? (Byte)1 : (Byte)0;
                    clienteAModificarEnBD.Mail = (txtEmail.Text == "") ? null : txtEmail.Text;

                    String[] respuesta = Cliente.modificarCliente(clienteAModificarEnBD, clienteAModificar.Telefono);
                    if (respuesta[0] == "Error")
                    {
                        lblErrorBaseDatos.Text = respuesta[1];
                        grpErrorBaseDatos.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                        this.Hide();
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
    }
}
