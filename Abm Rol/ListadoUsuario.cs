using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Abm_Rol
{
    public partial class ListadoUsuario : Form
    {

        public AsignacionRol formularioAsignacion;

        public ListadoUsuario(Form formulario)
        {
            InitializeComponent();
            this.formularioAsignacion = (AsignacionRol)formulario;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Limpio la tabla de turnos
            grillaUsuarios.Columns.Clear();

            //Busco los turnos activos en la base de datos
            DataTable dtUsuarios = Usuario.buscarUsuarios();

            //Le asigno a la grilla los turnos
            grillaUsuarios.DataSource = dtUsuarios;

            //Agrego el boton de seleccionar turno
            DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();
            btnSeleccionar.HeaderText = "Seleccionar";
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseColumnTextForButtonValue = true;
            grillaUsuarios.Columns.Add(btnSeleccionar);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grillaUsuarios.DataSource = null;
            grillaUsuarios.Columns.Clear();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grillaUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Seleccionar" de algun usuario, se crea un objeto Usuario con los datos de la grilla y se lo manda al formulario de asignación    
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    //Chequeo que el turno elegido este activo
                    if ((Byte)senderGrid.CurrentRow.Cells["Usuario_Activo"].Value == 0)
                    {
                        MessageBox.Show("No puede seleccionar este usuario ya que no esta activo", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        Usuario usuarioSeleccionado = new Usuario();
                        usuarioSeleccionado.Username = senderGrid.CurrentRow.Cells["Usuario_Username"].Value.ToString();

                        this.formularioAsignacion.usuarioElegido = usuarioSeleccionado;
                        this.formularioAsignacion.cambiarUsuario();
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
