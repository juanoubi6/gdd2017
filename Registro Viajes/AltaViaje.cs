using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class AltaViaje : Form
    {
        public AltaViaje()
        {
            InitializeComponent();
            dtpInicio.Format = DateTimePickerFormat.Custom;
            dtpInicio.CustomFormat = "MM/dd/yyyy hh:mm:ss";  
            dtpFin.Format = DateTimePickerFormat.Custom;
            dtpFin.CustomFormat = "MM/dd/yyyy hh:mm:ss";  
        }

        private void btnSelectAuto_Click(object sender, EventArgs e)
        {
            GrillaAuto_Viaje grillaAuto = new GrillaAuto_Viaje(this);
            grillaAuto.Show();
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



        }
    }
}
