using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            int contadorErrores = 0;

            //El chofer no tiene viajes
            if (grillaViajesRendicion.RowCount == 0)
            {
                MessageBox.Show("El chofer no tiene viajes para rendir", "Error en rendición", MessageBoxButtons.OK);
                contadorErrores++;
            }

            //No hay chofer seleccionado
            if (txtChofer.Text == "")
            {
                errorChofer.Text = "Debe seleccionar un chofer";
                contadorErrores++;
            }

            //No hay ningun turno (el turno es el turno del chofer)
            if (txtTurno.Text == "")
            {
                errorTurno.Text = "El turno no puede ser vacio. Consulte si su chofer tiene un turno asociado";
                contadorErrores++;
            }

            if (contadorErrores == 0)
            {
                Rendicion nuevaRendicion = new Rendicion();
                nuevaRendicion.Porcentaje = Convert.ToDecimal(ConfigurationManager.AppSettings["PorcentajeRendicion"]);
                nuevaRendicion.Turno = turnoChofer.Codigo;
                nuevaRendicion.Chofer = choferElegido.Telefono;
                nuevaRendicion.Fecha = dtpInicio.Value;

                String[] respuesta = Rendicion.grabarRendicion(nuevaRendicion);
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

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (choferElegido != null)
            {
                mostrarViajes();
            }
        }
    }
}
