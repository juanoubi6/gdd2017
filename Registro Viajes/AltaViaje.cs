using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Turno;

namespace UberFrba.Registro_Viajes
{
    public partial class AltaViaje : Form
    {
        public Turno turnoElegido;
        public Chofer choferElegido;
        public Automovil autoElegido;
        public Cliente clienteElegido;

        public AltaViaje()
        {
            InitializeComponent();
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "MM/dd/yyyy hh:mm:ss";  
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "MM/dd/yyyy hh:mm:ss";  
        }

        private void bntSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Viaje grillaChofer = new GrillaChofer_Viaje(this);
            grillaChofer.Show();
        }

        private void btnSelectTurno_Click(object sender, EventArgs e)
        {
            GrillaTurno_Viaje grillaTurno = new GrillaTurno_Viaje(this);
            grillaTurno.Show();
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            GrillaCliente_Viaje grillaCliente = new GrillaCliente_Viaje(this);
            grillaCliente.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int contadorErrores = 0;

            errorFechaHoraIni.Text = Viaje.validarFechaHoraInicio(dtpInicio.Value);
            if (errorFechaHoraIni.Text != "") contadorErrores++;

            errorFechaHoraFin.Text = Viaje.validarFechaHoraFin(dtpInicio.Value);
            if (errorFechaHoraFin.Text != "") contadorErrores++;

            errorCantKm.Text = Viaje.validarCantKm(txtCantidad.Text);
            if (errorCantKm.Text != "") contadorErrores++;

            errorAuto.Text = Viaje.validarAuto(txtAuto.Text);
            if (errorAuto.Text != "") contadorErrores++;

            errorChofer.Text = Viaje.validarChofer(txtChofer.Text);
            if (errorChofer.Text != "") contadorErrores++;

            errorTurno.Text = Viaje.validarTurno(txtTurno.Text);
            if (errorTurno.Text != "") contadorErrores++;

            errorCliente.Text = Viaje.validarCliente(txtCliente.Text);
            if (errorCliente.Text != "") contadorErrores++;

            ////Validaciones adicionales
            //Fecha y hora de inicio y fin son iguales
            if (dtpInicio.Value == dtpFin.Value)
            {
                errorFechaHoraFin.Text = "Las fechas y horas de inicio y fin deben ser distintas";
                errorFechaHoraIni.Text = "Las fechas y horas de inicio y fin deben ser distintas";
                contadorErrores++;
            }

            //Fecha de inicio es mas grande que la fecha de fin
            if (dtpInicio.Value > dtpFin.Value)
            {
                errorFechaHoraFin.Text = "La fecha y hora de inicio no puede ser mayor a la fecha y hora de fin";
                errorFechaHoraIni.Text = "La fecha y hora de fin no puede ser menor a la fecha y hora de inicio";
                contadorErrores++;
            }

            //Si no hay errores, se intenta guardar el nuevo Turno
            if (contadorErrores == 0)
            {
                Viaje viajeAGrabar = new Viaje();
                viajeAGrabar.FechaHoraInicio = dtpInicio.Value;
                viajeAGrabar.FechaHoraFin = dtpFin.Value;
                viajeAGrabar.CantidadKm = Decimal.Parse(txtCantidad.Text);
                viajeAGrabar.Chofer = choferElegido.Dni;
                viajeAGrabar.Auto = autoElegido.Patente;
                viajeAGrabar.Turno = turnoElegido.Codigo;
                viajeAGrabar.Cliente = clienteElegido.Telefono;

                String[] respuesta = Viaje.registrarViaje(viajeAGrabar);
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

            //Luego de cambiar el chofer, busco el auto de este chofer y lo asigno
            try
            {
                DataTable dtAutoActivoChofer = Chofer.buscarAutoActivo(choferElegido);
                Automovil autoActivo = new Automovil();
                autoActivo.Patente = dtAutoActivoChofer.Rows[0]["Auto_Patente"].ToString();
                this.autoElegido = autoActivo;
                cambiarAuto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        public void cambiarTurno()
        {
            txtTurno.Text = turnoElegido.Descripcion + " (" + turnoElegido.HoraInicio.ToString() + " a " + turnoElegido.HoraFin.ToString() + ")";
        }

        public void cambiarAuto()
        {
            txtAuto.Text = autoElegido.Patente;
        }

        public void cambiarCliente()
        {
            txtCliente.Text = clienteElegido.Nombre + " " + clienteElegido.Apellido;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            lblErrorBaseDatos.Text = "";
            grpErrorBaseDatos.Visible = false;
            txtAuto.Text = "";
            txtChofer.Text = "";
            txtCliente.Text = "";
            txtTurno.Text = "";
            txtCantidad.Text = "";
            autoElegido = null;
            turnoElegido = null;
            clienteElegido = null;
            choferElegido = null;
            errorAuto.Text = "";
            errorCantKm.Text = "";
            errorChofer.Text = "";
            errorCliente.Text = "";
            errorFechaHoraFin.Text = "";
            errorFechaHoraIni.Text = "";
            errorTurno.Text = "";
        }

    }
}
