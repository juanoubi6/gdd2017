using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class AltaAutomovil : Form
    {
        public AltaAutomovil()
        {
            InitializeComponent();
        }

        private void btnSelecTurno_Click(object sender, EventArgs e)
        {
            GrillaTurno_Auto grillaTurno = new GrillaTurno_Auto(this);
            grillaTurno.Show();
        }

        private void bntSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Auto grillaChofer = new GrillaChofer_Auto(this);
            grillaChofer.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int contadorErrores = 0;

            if (cmbMarca.SelectedValue == null)
            {
                contadorErrores++;
                errorMarca.Text = "El campo no puede ser vacio";
            }

            errorModelo.Text = Automovil.validarModelo(txtModelo.Text);
            if (errorModelo.Text != "") contadorErrores++;

            errorPatente.Text = Automovil.validarPatente(txtPatente.Text);
            if (errorPatente.Text != "") contadorErrores++;

            errorTurno.Text = Automovil.validarTurno(txtTurno.Text);
            if (errorTurno.Text != "") contadorErrores++;

            errorChofer.Text = Automovil.validarChofer(txtChofer.Text);
            if (errorChofer.Text != "") contadorErrores++;

        }
    }
}
