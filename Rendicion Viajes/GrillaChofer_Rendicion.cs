using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;

namespace UberFrba.Rendicion_Viajes
{
    public partial class GrillaChofer_Rendicion : Form
    {

        public RendicionViaje formularioRendicion;

        public GrillaChofer_Rendicion(RendicionViaje formulario)
        {
            InitializeComponent();
            this.formularioRendicion = formulario;
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
                    grillaChofer.Columns.Clear();

                    //Busco los clientes en la base de datos
                    DataTable dtChoferes = Chofer.buscarChoferes(txtNombre.Text, txtApellido.Text, (txtDni.Text == "") ? 0 : Decimal.Parse(txtDni.Text));

                    //Le asigno a la grilla los roles
                    grillaChofer.DataSource = dtChoferes;

                    //Agrego botones para Modificar y Eliminar Rol
                    DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
                    btnSeleccionar.HeaderText = "Seleccionar";
                    btnSeleccionar.Text = "Seleccionar";
                    btnSeleccionar.UseColumnTextForButtonValue = true;
                    grillaChofer.Columns.Add(btnSeleccionar);

                    grillaChofer.Columns["Chofer_Persona"].Visible = false;

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
            grillaChofer.DataSource = null;
            grillaChofer.Columns.Clear();
            limpiarFiltrosYErrores();
        }

        private void limpiarFiltrosYErrores()
        {
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDni.Text = "";
            errorDni.Text = "";
        }

        private void grillaChofer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Seleccionar" de algun chofer, se crea un objeto Chofer con los datos de la grilla y se lo manda a modificar           
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    //Solo puedo seleccionar choferes activos para rendir
                    if ((Byte)senderGrid.CurrentRow.Cells["Chofer_Activo"].Value == 1)
                    {
                        Chofer choferSeleccionado = new Chofer();
                        choferSeleccionado.Nombre = senderGrid.CurrentRow.Cells["Chofer_Nombre"].Value.ToString();
                        choferSeleccionado.Apellido = senderGrid.CurrentRow.Cells["Chofer_Apellido"].Value.ToString();
                        choferSeleccionado.Dni = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Dni"].Value;
                        choferSeleccionado.Telefono = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Telefono"].Value;
                        choferSeleccionado.Direccion = senderGrid.CurrentRow.Cells["Chofer_Direccion"].Value.ToString();
                        choferSeleccionado.FechaNacimiento = (DateTime)(senderGrid.CurrentRow.Cells["Chofer_Fecha_Nac"].Value);
                        choferSeleccionado.Mail = senderGrid.CurrentRow.Cells["Chofer_Mail"].Value.ToString();
                        choferSeleccionado.Activo = (Byte)senderGrid.CurrentRow.Cells["Chofer_Activo"].Value;
                        this.formularioRendicion.choferElegido = choferSeleccionado;
                        this.formularioRendicion.cambiarChofer();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No puede seleccionar este chofer ya que no esta activo", "Error", MessageBoxButtons.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del chofer: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }


        }
    }
}
