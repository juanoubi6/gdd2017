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

            errorHoraInicio.Text = Turno.validarHoras(txtHoraInicio.Text);
            if (errorHoraInicio.Text != "") contadorErrores++;

            errorHoraFin.Text = Turno.validarHoras(txtHoraFin.Text);
            if (errorHoraFin.Text != "") contadorErrores++;

            errorDescripcion.Text = Turno.validarDescripcion(txtDescripcion.Text);
            if (errorDescripcion.Text != "") contadorErrores++;

            errorValorKm.Text = Turno.validarValorKm(txtValorkm.Text);
            if (errorValorKm.Text != "") contadorErrores++;

            errorPrecioBase.Text = Turno.validarPrecioBase(txtPrecioBase.Text);
            if (errorPrecioBase.Text != "") contadorErrores++;

            //Si no hay errores, se intenta guardar el nuevo Turno
            if (contadorErrores == 0)
            {

                //Valido que las horas de inicio y fin sean correctas
                Decimal horaInicio = Decimal.Parse(txtHoraInicio.Text);
                Decimal horaFin = Decimal.Parse(txtHoraFin.Text);

                if (horaInicio == horaFin)
                {
                    MessageBox.Show("Las horas de inicio y fin deben ser distintas", "Error", MessageBoxButtons.OK);
                }
                else if (horaInicio > horaFin)
                {
                    MessageBox.Show("La hora de inicio no puede ser mayor a la hora de fin", "Error", MessageBoxButtons.OK);
                }
                else
                {
                    Turno turnoAGrabar = new Turno();
                    turnoAGrabar.HoraInicio = horaInicio;
                    turnoAGrabar.HoraFin = horaFin;
                    turnoAGrabar.Descripcion = txtDescripcion.Text;
                    turnoAGrabar.ValorKm = Decimal.Parse(txtValorkm.Text);
                    turnoAGrabar.PrecioBase = Decimal.Parse(txtPrecioBase.Text);
                    turnoAGrabar.Activo = 1;


                    String[] respuesta = Turno.grabarTurno(turnoAGrabar);
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
            
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Text = "";
            txtHoraFin.Text = "";
            txtHoraInicio.Text = "";
            txtPrecioBase.Text = "";
            txtValorkm.Text = "";
            errorDescripcion.Text = "";
            errorHoraInicio.Text = "";
            errorHoraFin.Text = "";
            errorPrecioBase.Text = "";
            errorValorKm.Text = "";
            lblErrorBaseDatos.Text = String.Empty;
            grpErrorBaseDatos.Visible = false;
        }
    }
}
