using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurno : Form
    {
        public AltaTurno()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int contadorErrores = 0;

            errorHoraInicio.Text = Turno.validarHoraInicio(dtpInicio.Value);
            if (errorHoraInicio.Text != "") contadorErrores++;

            errorHoraFin.Text = Turno.validarHoraFin(dtpFin.Value);
            if (errorHoraFin.Text != "") contadorErrores++;

            errorDescripcion.Text = Turno.validarDescripcion(txtDescripcion.Text);
            if (errorDescripcion.Text != "") contadorErrores++;

            errorValorKm.Text = Turno.validarValorKm(txtValorkm.Text);
            if (errorValorKm.Text != "") contadorErrores++;

            errorPrecioBase.Text = Turno.validarPrecioBase(txtPrecioBase.Text);
            if (errorPrecioBase.Text != "") contadorErrores++;

            ////Validaciones adicionales
            //Fecha y hora de inicio y fin son iguales
            if (dtpInicio.Value.TimeOfDay == dtpFin.Value.TimeOfDay)
            {
                errorHoraInicio.Text = "Las horas de inicio y fin deben ser distintas";
                errorHoraFin.Text    = "Las horas de inicio y fin deben ser distintas";
                contadorErrores++;
            }

            //Fecha de inicio es mas grande que la fecha de fin
            if (dtpInicio.Value.TimeOfDay > dtpFin.Value.TimeOfDay)
            {
                errorHoraInicio.Text = "La hora de inicio no puede ser mayor a la hora de fin";
                errorHoraFin.Text    = "La hora de fin no puede ser menor a la hora de inicio";
                contadorErrores++;
            }

            //Fecha y hora de fin son de distintos dias
            
        }
    }
}
