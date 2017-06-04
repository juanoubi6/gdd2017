using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Chofer
{
    public partial class ListadoChofer : Form
    {
        public ListadoChofer()
        {
            InitializeComponent();
        }

        private Boolean validarFiltros(String nombre, String apellido, String dni)
        {
            //Valido DNI sea numerico
            Decimal dniDecimal;
            if (dni != "" && !Decimal.TryParse(dni, out dniDecimal))
            {
                errorDni.Text = "El DNI debe ser numérico";
                return false;
            }

            return true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                if (!validarFiltros(txtNombre.Text, txtApellido.Text, txtDni.Text))
                {
                    MessageBox.Show("Error en los filtros de búsqueda", "Error", MessageBoxButtons.OK);
                }
                else
                {

                    //Limpio la tabla de choferes
                    grillaChofer.Columns.Clear();

                    //Busco los choferes en la base de datos
                    DataTable dtChofer = Chofer.buscarChoferes(txtNombre.Text, txtApellido.Text, (txtDni.Text == "") ? 0 : Decimal.Parse(txtDni.Text));

                    //Le asigno a la grilla los roles
                    grillaChofer.DataSource = dtChofer;

                    //Agrego botones para Modificar y Eliminar Chofer
                    DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                    btnModificar.HeaderText = "Modificar";
                    btnModificar.Text = "Modificar";
                    btnModificar.UseColumnTextForButtonValue = true;
                    grillaChofer.Columns.Add(btnModificar);

                    DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                    btnBorrar.HeaderText = "Dar de baja";
                    btnBorrar.Text = "Dar de baja";
                    btnBorrar.UseColumnTextForButtonValue = true;
                    grillaChofer.Columns.Add(btnBorrar);

                    errorDni.Text = "";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grillaChofer.DataSource = null;
            grillaChofer.Columns.Clear();
            limpiarFiltrosYErrores();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void limpiarFiltrosYErrores()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            errorDni.Text = "";
        }

        private void btnAltaChofer_Click(object sender, EventArgs e)
        {
            AltaChofer altaChofer = new AltaChofer();
            altaChofer.Show();
            this.Hide();
        }

        private void grillaChofer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Modificar" de algun chofer, se crea un objeto Chofer con los datos de la grilla y se lo manda a modificar
            //En caso de que se presiono el boton "Eliminar" de algun chofer, se confirma si se quiere eliminar ese chofer y luego se ejecuta la acción.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Modificar" && e.RowIndex >= 0)
            {
                try
                {
                    Chofer choferAModificar = new Chofer();
                    choferAModificar.Nombre = senderGrid.CurrentRow.Cells["Chofer_Nombre"].Value.ToString();
                    choferAModificar.Apellido = senderGrid.CurrentRow.Cells["Chofer_Apellido"].Value.ToString();
                    choferAModificar.Dni = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Dni"].Value;
                    choferAModificar.Telefono = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Telefono"].Value;
                    choferAModificar.Direccion = senderGrid.CurrentRow.Cells["Chofer_Direccion"].Value.ToString();
                    choferAModificar.FechaNacimiento = (DateTime)(senderGrid.CurrentRow.Cells["Chofer_Fecha_Nac"].Value);
                    choferAModificar.Mail = senderGrid.CurrentRow.Cells["Chofer_Mail"].Value.ToString();
                    choferAModificar.Activo = (Byte)senderGrid.CurrentRow.Cells["Chofer_Activo"].Value;
                    ModificarChofer modificarChofer = new ModificarChofer(choferAModificar);
                    modificarChofer.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del chofer: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Dar de baja" && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja este chofer?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String[] respuesta = Chofer.eliminarChofer((Decimal)senderGrid.CurrentRow.Cells["Chofer_Telefono"].Value);
                        if (respuesta[0] == "Error")
                        {
                            MessageBox.Show("Error al dar de baja chofer: " + respuesta[1], "Error", MessageBoxButtons.OK);
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
