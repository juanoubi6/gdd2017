using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;

namespace UberFrba.Abm_Automovil
{
    public partial class AltaAutomovil : Form
    {

        public Chofer choferElegido;
        public Turno turnoElegido;

        public AltaAutomovil()
        {
            InitializeComponent();
        }

        private void btnSelecTurno_Click(object sender, EventArgs e)
        {
            GrillaTurno_Auto grillaTurno = new GrillaTurno_Auto(this,"alta");
            grillaTurno.Show();
        }

        private void bntSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Auto grillaChofer = new GrillaChofer_Auto(this,"seleccion");
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

            //Si no hay errores, se intenta guardar el nuevo cliente
            if (contadorErrores == 0)
            {
                Automovil autoAGrabar = new Automovil();
                autoAGrabar.Marca = (Int32)(cmbMarca.SelectedValue);
                autoAGrabar.Modelo = txtModelo.Text;
                autoAGrabar.Patente = txtPatente.Text;
                autoAGrabar.Chofer = choferElegido.Telefono;
                autoAGrabar.Turno = turnoElegido.Codigo;
                autoAGrabar.Activo = 1;

                String[] respuesta = Automovil.grabarAuto(autoAGrabar);
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

        public void cambiarChofer()
        {
            txtChofer.Text = choferElegido.Nombre + " " + choferElegido.Apellido;
        }

        public void cambiarTurno()
        {
            txtTurno.Text = turnoElegido.Descripcion + " (" + turnoElegido.HoraInicio.ToString() + " a " + turnoElegido.HoraFin.ToString() + ")";
        }

        private void AltaAutomovil_Load(object sender, EventArgs e)
        {
            DataTable marcasDt = Automovil.traerMarcas();
            cmbMarca.DataSource = marcasDt;
            cmbMarca.DisplayMember = "Marca_Nombre";
            cmbMarca.ValueMember = "Marca_Codigo";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtPatente.Text = "";
            txtModelo.Text = "";
            txtChofer.Text = "";
            txtTurno.Text = "";
            choferElegido = null;
            turnoElegido = null;
            errorPatente.Text = "";
            errorModelo.Text = "";
            errorChofer.Text = "";
            errorTurno.Text = "";
            errorMarca.Text = "";
            lblErrorBaseDatos.Text = String.Empty;
            grpErrorBaseDatos.Visible = false;
        }

    }
}
