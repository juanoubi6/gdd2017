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
            int contadorErrores = 0;

            if (errorFechaNac.Text == "")
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

        }
    }
}
