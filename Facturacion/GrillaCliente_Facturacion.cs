using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    public partial class GrillaCliente_Facturacion : Form
    {
        public Facturacion formularioFacturacion;

        public GrillaCliente_Facturacion(Facturacion formulario)
        {
            InitializeComponent();
            this.formularioFacturacion = formulario;
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

                    //Le asigno a la grilla los roles
                    grillaCliente.DataSource = dtClientes;

                    //Agrego botones para Modificar y Eliminar Rol
                    DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
                    btnSeleccionar.HeaderText = "Seleccionar";
                    btnSeleccionar.Text = "Seleccionar";
                    btnSeleccionar.UseColumnTextForButtonValue = true;
                    grillaCliente.Columns.Add(btnSeleccionar);

                    errorDni.Text = "";

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grillaCliente.DataSource = null;
            grillaCliente.Columns.Clear();
            limpiarFiltrosYErrores();
        }

        private void limpiarFiltrosYErrores()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            errorDni.Text = "";
        }

        private void grillaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Seleccionar" de algun cliente, se crea un objeto Cliente con los datos de la grilla y se lo manda a modificar           
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    if ((Byte)senderGrid.CurrentRow.Cells["Cliente_Activo"].Value == 1)
                    {
                        Cliente clienteSeleccionado = new Cliente();
                        clienteSeleccionado.Nombre = senderGrid.CurrentRow.Cells["Cliente_Nombre"].Value.ToString();
                        clienteSeleccionado.Apellido = senderGrid.CurrentRow.Cells["Cliente_Apellido"].Value.ToString();
                        clienteSeleccionado.Dni = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Dni"].Value;
                        clienteSeleccionado.Telefono = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Telefono"].Value;
                        clienteSeleccionado.Direccion = senderGrid.CurrentRow.Cells["Cliente_Direccion"].Value.ToString();
                        clienteSeleccionado.FechaNacimiento = (DateTime)(senderGrid.CurrentRow.Cells["Cliente_Fecha_Nac"].Value);
                        clienteSeleccionado.Mail = senderGrid.CurrentRow.Cells["Cliente_Mail"].Value.ToString();
                        clienteSeleccionado.CodigoPostal = (Decimal)senderGrid.CurrentRow.Cells["Cliente_Codigo_Postal"].Value;
                        clienteSeleccionado.Activo = (Byte)senderGrid.CurrentRow.Cells["Cliente_Activo"].Value;
                        this.formularioFacturacion.clienteElegido = clienteSeleccionado;
                        this.formularioFacturacion.cambiarCliente();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No puede seleccionar este turno ya que no esta activo", "Error", MessageBoxButtons.OK);
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
