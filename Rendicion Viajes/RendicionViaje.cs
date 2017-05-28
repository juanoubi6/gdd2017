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

namespace UberFrba.Rendicion_Viajes
{
    public partial class RendicionViaje : Form
    {

        public Chofer choferElegido;
        public Turno turnoChofer;

        public RendicionViaje()
        {
            InitializeComponent();
        }

        public void cambiarChofer()
        {
            txtChofer.Text = choferElegido.Nombre + " " + choferElegido.Apellido;
            mostrarViajes();
        }

        private void mostrarViajes()
        {
            //Una vez seleccionado el chofer, muestro sus viajes para la fecha y turno seleccionados
            DataTable dtViajesFactura = Rendicion.traerViajesDeRendicion(choferElegido,dtpInicio.Value);
            grillaViajesRendicion.DataSource = dtViajesFactura;

            //Conseguir datos del turno del chofer
            DataTable dtTurnoActual = Chofer.buscarTurnoActual(choferElegido);
            Turno nuevoTurno = new Turno();
            nuevoTurno.Codigo = (Int32)dtTurnoActual.Rows[0]["Chofer_Turno"];
            turnoChofer = nuevoTurno;
            txtTurno.Text = dtTurnoActual.Rows[0]["Turno_Descripcion"].ToString() + " (" + dtTurnoActual.Rows[0]["Turno_Hora_Inicio"].ToString() + " a " + dtTurnoActual.Rows[0]["Turno_Hora_Fin"].ToString() + ")";

        }

        private void btnRendir_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtTurno.Text = "";
            txtChofer.Text = "";
            errorFecha.Text = "";
            errorTurno.Text = "";
            grpErrorBaseDatos.Visible = false;
            lblErrorBaseDatos.Text = "";
            grillaViajesRendicion.DataSource = null;
        }

        private void btnSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Rendicion grillaChofer = new GrillaChofer_Rendicion(this);
            grillaChofer.Show();
        }
    }
}
