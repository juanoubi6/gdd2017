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

namespace UberFrba.Registro_Viajes
{
    public partial class GrillaChofer_Viaje : Form
    {

        public AltaViaje formularioAlta;

        public GrillaChofer_Viaje(AltaViaje formulario)
        {
            InitializeComponent();
            this.formularioAlta = formulario;
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

                    //Busco los choferes en la base de datos (solo activos)
                    DataTable dtChofer = Chofer.buscarChoferes(txtNombre.Text, txtApellido.Text, (txtDni.Text == "") ? 0 : Decimal.Parse(txtDni.Text));

                    //Le asigno a la grilla los choferes
                    grillaChofer.DataSource = dtChofer;

                    //Agrego botones para Seleccionar chofer
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

            //En caso de que se presiono el boton "Seleccionar" de algun chofer, se crea un objeto Chofer y se lo envia al formulario de llamada       
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    if ((Byte)senderGrid.CurrentRow.Cells["Chofer_Activo"].Value == 1)
                    {
                        Chofer choferElegido = new Chofer();
                        choferElegido.Nombre = senderGrid.CurrentRow.Cells["Chofer_Nombre"].Value.ToString();
                        choferElegido.Apellido = senderGrid.CurrentRow.Cells["Chofer_Apellido"].Value.ToString();
                        choferElegido.Dni = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Dni"].Value;
                        choferElegido.Telefono = (Decimal)senderGrid.CurrentRow.Cells["Chofer_Telefono"].Value;
                        choferElegido.Direccion = senderGrid.CurrentRow.Cells["Chofer_Direccion"].Value.ToString();
                        choferElegido.FechaNacimiento = (DateTime)(senderGrid.CurrentRow.Cells["Chofer_Fecha_Nac"].Value);
                        choferElegido.Mail = senderGrid.CurrentRow.Cells["Chofer_Mail"].Value.ToString();
                        choferElegido.Activo = (Byte)senderGrid.CurrentRow.Cells["Chofer_Activo"].Value;
                        this.formularioAlta.choferElegido = choferElegido;
                        this.formularioAlta.cambiarChofer();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("No puede seleccionar este chofer ya que no se encuentra activo", "Error", MessageBoxButtons.OK);
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
