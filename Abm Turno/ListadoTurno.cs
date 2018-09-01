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
    public partial class ListadoTurno : Form
    {
        public ListadoTurno()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                //Limpio la tabla de turnos
                grillaTurno.Columns.Clear();

                //Busco los turnos en la base de datos
                DataTable dtTurnos = Turno.buscarTurnos(txtDescripcion.Text);

                //Le asigno a la grilla los turnos
                grillaTurno.DataSource = dtTurnos;

                //Agrego botones para Modificar y Eliminar turno
                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                btnModificar.HeaderText = "Modificar";
                btnModificar.Text = "Modificar";
                btnModificar.UseColumnTextForButtonValue = true;
                grillaTurno.Columns.Add(btnModificar);

                DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                btnBorrar.HeaderText = "Dar de baja";
                btnBorrar.Text = "Dar de baja";
                btnBorrar.UseColumnTextForButtonValue = true;
                grillaTurno.Columns.Add(btnBorrar);
              
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

        private void btnAltaTurno_Click(object sender, EventArgs e)
        {
            AltaTurno altaTurno = new AltaTurno();
            altaTurno.Show();
            this.Hide();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grillaTurno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Modificar" de algun turno, se crea un objeto Turno con los datos de la grilla y se lo manda a modificar
            //En caso de que se presiono el boton "Eliminar" de algun turno, se confirma si se quiere eliminar ese Turno y luego se ejecuta la acción.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Modificar" && e.RowIndex >= 0)
            {
                try
                {
                    Turno turnoAModificar = new Turno();
                    turnoAModificar.Codigo = (Int32)senderGrid.CurrentRow.Cells["Turno_Codigo"].Value;
                    turnoAModificar.HoraFin = (Decimal)senderGrid.CurrentRow.Cells["Turno_Hora_Fin"].Value;
                    turnoAModificar.HoraInicio = (Decimal)senderGrid.CurrentRow.Cells["Turno_Hora_Inicio"].Value;
                    turnoAModificar.Descripcion = senderGrid.CurrentRow.Cells["Turno_Descripcion"].Value.ToString();
                    turnoAModificar.PrecioBase = (Decimal)senderGrid.CurrentRow.Cells["Turno_Precio_Base"].Value;
                    turnoAModificar.ValorKm = (Decimal)senderGrid.CurrentRow.Cells["Turno_Valor_Kilometro"].Value;
                    turnoAModificar.Activo = (Byte)senderGrid.CurrentRow.Cells["Turno_Activo"].Value;
                    ModificarTurno modificarTurno = new ModificarTurno(turnoAModificar);
                    modificarTurno.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del turno: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Dar de baja" && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja este turno?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String[] respuesta = Turno.eliminarTurno((Int32)senderGrid.CurrentRow.Cells["Turno_Codigo"].Value);
                        if (respuesta[0] == "Error")
                        {
                            MessageBox.Show("Error al dar de baja turno: " + respuesta[1], "Error", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion de rol " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }
    }
}
