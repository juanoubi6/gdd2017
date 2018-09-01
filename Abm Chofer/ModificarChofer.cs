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
    public partial class ModificarChofer : Form
    {

        private Chofer choferAModificar;

        public ModificarChofer(Chofer chofer)
        {
            InitializeComponent();
            this.choferAModificar = chofer;
        }

        private void ModificarChofer_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo en pantalla los datos del cliente elegido
                txtNombre.Text = choferAModificar.Nombre;
                txtApellido.Text = choferAModificar.Apellido;
                txtDireccion.Text = choferAModificar.Direccion;
                txtTelefono.Text = choferAModificar.Telefono.ToString();
                txtFechaNac.Text = choferAModificar.FechaNacimiento.ToShortDateString();
                txtDni.Text = choferAModificar.Dni.ToString();
                txtEmail.Text = choferAModificar.Mail;
                chkHabilitado.Checked = (choferAModificar.Activo == 1) ? true : false;
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
                    errorFechaNac.Text = Chofer.validarFechaNac(DateTime.Parse(txtFechaNac.Text));
                    if (errorFechaNac.Text != "") contadorErrores++;
                }

                errorNombre.Text = Chofer.validarNombre(txtNombre.Text);
                if (errorNombre.Text != "") contadorErrores++;

                errorApellido.Text = Chofer.validarApellido(txtApellido.Text);
                if (errorApellido.Text != "") contadorErrores++;

                //Valido que el campo telefono sea correcto y no esté repetido si es que se modificó
                if (txtTelefono.Text != choferAModificar.Telefono.ToString())
                {
                    errorTelefono.Text = Chofer.validarTelefono(txtTelefono.Text);
                    if (errorTelefono.Text != "") contadorErrores++;
                }

                errorDni.Text = Chofer.validarDni(txtDni.Text);
                if (errorDni.Text != "") contadorErrores++;

                errorEmail.Text = Chofer.validarEmail(txtEmail.Text);
                if (errorEmail.Text != "") contadorErrores++;

                errorDireccion.Text = Chofer.validarDireccion(txtDireccion.Text);
                if (errorDireccion.Text != "") contadorErrores++;

                //Si no hay errores, se intenta modificar el nuevo chofer
                if (contadorErrores == 0)
                {
                    Chofer choferAModificarEnBD = new Chofer();
                    choferAModificarEnBD.Nombre = txtNombre.Text;
                    choferAModificarEnBD.Apellido = txtApellido.Text;
                    choferAModificarEnBD.Dni = Decimal.Parse(txtDni.Text);
                    choferAModificarEnBD.Telefono = Decimal.Parse(txtTelefono.Text);
                    choferAModificarEnBD.Direccion = txtDireccion.Text;
                    choferAModificarEnBD.FechaNacimiento = DateTime.Parse(txtFechaNac.Text);
                    choferAModificarEnBD.Activo = (chkHabilitado.Checked) ? (Byte)1 : (Byte)0;
                    choferAModificarEnBD.Mail = (txtEmail.Text == "") ? null : txtEmail.Text;

                    String[] respuesta = Chofer.modificarChofer(choferAModificarEnBD, choferAModificar.Telefono);
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
    }
}
