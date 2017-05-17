using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Turno;

namespace UberFrba.Registro_Viajes
{
    public partial class GrillaTurno_Viaje : Form
    {

        public AltaViaje formularioAlta;

        public GrillaTurno_Viaje(AltaViaje formulario)
        {
            InitializeComponent();
            this.formularioAlta = formulario;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                //Limpio la tabla de turnos
                grillaTurno.Columns.Clear();

                //Busco los turnos activos en la base de datos
                DataTable dtTurnos = Turno.buscarTurnos(txtDescripcion.Text);

                //Le asigno a la grilla los turnos
                grillaTurno.DataSource = dtTurnos;

                //Agrego el boton de seleccionar turno
                DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
                btnSeleccionar.HeaderText = "Seleccionar";
                btnSeleccionar.Text = "Seleccionar";
                btnSeleccionar.UseColumnTextForButtonValue = true;
                grillaTurno.Columns.Add(btnSeleccionar);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grillaTurno.DataSource = null;
            grillaTurno.Columns.Clear();
            limpiarFiltrosYErrores();
        }

        private void limpiarFiltrosYErrores()
        {
            txtDescripcion.Text = "";
        }

        private void grillaTurno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Seleccionar" de algun turno, se crea un objeto Turno con los datos de la grilla y se lo manda al formulario de alta      
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    //Chequeo que el turno elegido este activo
                    if ((Byte)senderGrid.CurrentRow.Cells["Turno_Activo"].Value == 0)
                    {
                        MessageBox.Show("No puede seleccionar este turno ya que no esta activo", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Turno turnoSeleccionado = new Turno();
                        turnoSeleccionado.Codigo = (Int32)senderGrid.CurrentRow.Cells["Turno_Codigo"].Value;
                        turnoSeleccionado.HoraFin = (Decimal)senderGrid.CurrentRow.Cells["Turno_Hora_Fin"].Value;
                        turnoSeleccionado.HoraInicio = (Decimal)senderGrid.CurrentRow.Cells["Turno_Hora_Inicio"].Value;
                        turnoSeleccionado.Descripcion = senderGrid.CurrentRow.Cells["Turno_Descripcion"].Value.ToString();
                        turnoSeleccionado.PrecioBase = (Decimal)senderGrid.CurrentRow.Cells["Turno_Precio_Base"].Value;
                        turnoSeleccionado.ValorKm = (Decimal)senderGrid.CurrentRow.Cells["Turno_Valor_Kilometro"].Value;
                        turnoSeleccionado.Activo = (Byte)senderGrid.CurrentRow.Cells["Turno_Activo"].Value;

                        this.formularioAlta.turnoElegido = turnoSeleccionado;
                        this.formularioAlta.cambiarTurno();
                        this.Hide();                      
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del cliente: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

    }
}
