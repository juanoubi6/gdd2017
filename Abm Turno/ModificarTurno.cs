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
    public partial class ModificarTurno : Form
    {
        private Turno turnoAModificar;

        public ModificarTurno(Turno turno)
        {
            InitializeComponent();
            this.turnoAModificar = turno;
        }

        private void ModificarTurno_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo en pantalla los datos del turno elegido
                txtHoraInicio.Text = turnoAModificar.HoraInicio.ToString();
                txtHoraFin.Text = turnoAModificar.HoraFin.ToString();
                txtDescripcion.Text = turnoAModificar.Descripcion;
                txtPrecioBase.Text = turnoAModificar.PrecioBase.ToString();
                txtValorkm.Text = turnoAModificar.ValorKm.ToString();
                chkHabilitado.Checked = (turnoAModificar.Activo == 1) ? true : false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado " + ex.Message, "Error", MessageBoxButtons.OK);
            }
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

            //Si no hay errores, se intenta modificar el Turno
            if (contadorErrores == 0)
            {
                Turno turnoAModificarEnBD = new Turno();
                turnoAModificarEnBD.Codigo = turnoAModificar.Codigo;
                turnoAModificarEnBD.HoraInicio = Decimal.Parse(txtHoraInicio.Text);
                turnoAModificarEnBD.HoraFin = Decimal.Parse(txtHoraFin.Text);
                turnoAModificarEnBD.Descripcion = txtDescripcion.Text;
                turnoAModificarEnBD.ValorKm = Decimal.Parse(txtValorkm.Text);
                turnoAModificarEnBD.PrecioBase = Decimal.Parse(txtPrecioBase.Text);
                turnoAModificarEnBD.Activo = (chkHabilitado.Checked) ? (Byte)1 : (Byte)0;


                String[] respuesta = Turno.modificarTurno(turnoAModificarEnBD);
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
}
