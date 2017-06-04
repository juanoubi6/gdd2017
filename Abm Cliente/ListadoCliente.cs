using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Cliente
{
    public partial class ListadoCliente : Form
    {
        public ListadoCliente()
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

                    //Limpio la tabla de clientes
                    grillaCliente.Columns.Clear();

                    //Busco los clientes en la base de datos
                    DataTable dtClientes = Cliente.buscarClientes(txtNombre.Text, txtApellido.Text, (txtDni.Text == "") ? 0 : Decimal.Parse(txtDni.Text));

                    //Le asigno a la grilla los clientes
                    grillaCliente.DataSource = dtClientes;

                    //Agrego botones para Modificar y Eliminar Clientes
                    DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                    btnModificar.HeaderText = "Modificar";
                    btnModificar.Text = "Modificar";
                    btnModificar.UseColumnTextForButtonValue = true;
                    grillaCliente.Columns.Add(btnModificar);

                    DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                    btnBorrar.HeaderText = "Dar de baja";
                    btnBorrar.Text = "Dar de baja";
                    btnBorrar.UseColumnTextForButtonValue = true;
                    grillaCliente.Columns.Add(btnBorrar);

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
            grillaCliente.DataSource = null;
            grillaCliente.Columns.Clear();
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

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            altaCliente.Show();
            this.Hide();
        }

        private void grillaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Modificar" de algun cliente, se crea un objeto Cliente con los datos de la grilla y se lo manda a modificar
            //En caso de que se presiono el boton "Eliminar" de algun cliente, se confirma si se quiere eliminar ese cliente y luego se ejecuta la acción.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Modificar" && e.RowIndex >= 0)
            {
                try
                {
                    Cliente clienteAModificar = new Cliente();
                    clienteAModificar.Nombre = senderGrid.CurrentRow.Cells["Cliente_Nombre"].Value.ToString();
                    clienteAModificar.Apellido = senderGrid.CurrentRow.Cells["Cliente_Apellido"].Value.ToString();
                    clienteAModificar.Dni = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Dni"].Value;
                    clienteAModificar.Telefono = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Telefono"].Value;
                    clienteAModificar.Direccion = senderGrid.CurrentRow.Cells["Cliente_Direccion"].Value.ToString();
                    clienteAModificar.FechaNacimiento = (DateTime)(senderGrid.CurrentRow.Cells["Cliente_Fecha_Nac"].Value);
                    clienteAModificar.Mail = senderGrid.CurrentRow.Cells["Cliente_Mail"].Value.ToString();
                    clienteAModificar.CodigoPostal = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Codigo_Postal"].Value;
                    clienteAModificar.Activo = (Byte)senderGrid.CurrentRow.Cells["Cliente_Activo"].Value;
                    ModificarCliente modificarCliente = new ModificarCliente(clienteAModificar);
                    modificarCliente.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del cliente: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Dar de baja" && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja este cliente?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String[] respuesta = Cliente.eliminarCliente((Decimal)senderGrid.CurrentRow.Cells["Cliente_Telefono"].Value);
                        if (respuesta[0] == "Error")
                        {
                            MessageBox.Show("Error al dar de baja cliente: " + respuesta[1], "Error", MessageBoxButtons.OK);
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
