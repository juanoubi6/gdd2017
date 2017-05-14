using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Automovil
{
    public partial class ListadoAutomovil : Form
    {

        private Decimal dniChoferFiltro = 0;

        public ListadoAutomovil()
        {
            InitializeComponent();
            this.dniChoferFiltro = 0;
        }

        private void ListadoAutomovil_Load(object sender, EventArgs e)
        {
            this.dniChoferFiltro = 0;

            DataTable marcasDt = Automovil.traerMarcas();
            cmbMarca.DataSource = marcasDt;
            cmbMarca.DisplayMember = "Marca_Nombre";
            cmbMarca.ValueMember = "Marca_Codigo";
            cmbMarca.SelectedIndex = -1;
        }

        private void btnBuscarChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Auto grillaSeleccionChofer = new GrillaChofer_Auto(this,"filtro");
            grillaSeleccionChofer.Show();
        }

        public void cambiarChofer(String chofer,Decimal dniChofer)
        {
            txtChofer.Text = chofer;
            this.dniChoferFiltro = dniChofer;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtChofer.Text = "";
            txtModelo.Text = "";
            txtPatente.Text = "";
            grillaAutomovil.DataSource = null;
            grillaAutomovil.Columns.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAltaAutomovil_Click(object sender, EventArgs e)
        {
            AltaAutomovil altaAutomovil = new AltaAutomovil();
            altaAutomovil.Show();
            this.Hide();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpio la tabla de clientes
                grillaAutomovil.Columns.Clear();

                //Busco los clientes en la base de datos
                DataTable dtAutos = Automovil.buscarAutos(txtPatente.Text, txtModelo.Text, dniChoferFiltro,((cmbMarca.Text == "")? 0 :(Int32)cmbMarca.SelectedValue));

                //Le asigno a la grilla los roles
                grillaAutomovil.DataSource = dtAutos;

                //Escondo datos que puedan confundir al usuario (Codigo de marca, Dni del chofer)
                grillaAutomovil.Columns["Auto_Marca"].Visible = false;
                grillaAutomovil.Columns["Auto_Chofer"].Visible = false;
                grillaAutomovil.Columns["Auto_Turno"].Visible = false;

                //Agrego botones para Modificar y Eliminar Rol
                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                btnModificar.HeaderText = "Modificar";
                btnModificar.Text = "Modificar";
                btnModificar.UseColumnTextForButtonValue = true;
                grillaAutomovil.Columns.Add(btnModificar);

                DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                btnBorrar.HeaderText = "Dar de baja";
                btnBorrar.Text = "Dar de baja";
                btnBorrar.UseColumnTextForButtonValue = true;
                grillaAutomovil.Columns.Add(btnBorrar);

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void grillaAutomovil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Modificar" de algun auto, se crea un objeto Automovil con los datos de la grilla y se lo manda a modificar
            //En caso de que se presiono el boton "Eliminar" de algun auto, se confirma si se quiere eliminar ese Auto y luego se ejecuta la acción.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Modificar" && e.RowIndex >= 0)
            {
                try
                {
                    Automovil autoAModificar = new Automovil();
                    autoAModificar.Chofer = (Decimal)senderGrid.CurrentRow.Cells["Auto_Chofer"].Value;
                    autoAModificar.Turno = (Int32)senderGrid.CurrentRow.Cells["Auto_Turno"].Value;
                    autoAModificar.Marca = (Int32)senderGrid.CurrentRow.Cells["Auto_Marca"].Value;
                    autoAModificar.Patente = senderGrid.CurrentRow.Cells["Auto_Patente"].Value.ToString();
                    autoAModificar.Modelo = senderGrid.CurrentRow.Cells["Auto_Modelo"].Value.ToString();
                    autoAModificar.Rodado = senderGrid.CurrentRow.Cells["Auto_Rodado"].Value.ToString();
                    autoAModificar.Licencia = senderGrid.CurrentRow.Cells["Auto_Licencia"].Value.ToString();
                    autoAModificar.Activo = (Byte)senderGrid.CurrentRow.Cells["Auto_Activo"].Value;
                    ModificarAutomovil modificarAuto = new ModificarAutomovil(autoAModificar);
                    modificarAuto.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion del automovil: " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Dar de baja" && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Esta seguro que desea dar de baja este automovil?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String[] respuesta = Automovil.eliminarAuto(senderGrid.CurrentRow.Cells["Auto_Patente"].Value.ToString());
                        if (respuesta[0] == "Error")
                        {
                            MessageBox.Show("Error al dar de baja automovil: " + respuesta[1], "Error", MessageBoxButtons.OK);
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
