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
    public partial class ListadoRol : Form
    {
        public ListadoRol()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //Limpio la tabla de roles
                grillaRol.DataSource = null;

                //Busco los roles activos en base de datos
                DataTable dtRoles = Rol.buscarRoles();

                //Le asigno a la grilla los roles
                grillaRol.DataSource = dtRoles;

                //Agrego botones para Modificar y Eliminar Rol
                DataGridViewButtonColumn btnModificar = new DataGridViewButtonColumn();
                btnModificar.HeaderText = "Modificar";
                btnModificar.Text = "Modificar";
                btnModificar.UseColumnTextForButtonValue = true;
                grillaRol.Columns.Add(btnModificar);

                DataGridViewButtonColumn btnBorrar = new DataGridViewButtonColumn();
                btnBorrar.HeaderText = "Eliminar";
                btnBorrar.Text = "Eliminar";
                btnBorrar.UseColumnTextForButtonValue = true;
                grillaRol.Columns.Add(btnBorrar);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void grillaRol_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            //En caso de que se presiono el boton "Modificar" de algun rol, se crea un objeto Rol con los datos de la grilla y se lo manda a modificar
            //En caso de que se presiono el boton "Eliminar" de algun rol, se confirma si se quiere eliminar ese rol y luego se ejecuta la acción.
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Modificar" && e.RowIndex >= 0)
            {
                try
                {
                    Rol rolAModificar = new Rol();
                    rolAModificar.Nombre = senderGrid.CurrentRow.Cells["Rol_Nombre"].Value.ToString();
                    rolAModificar.Codigo = (Int32)senderGrid.CurrentRow.Cells["Rol_Codigo"].Value;
                    rolAModificar.Activo = (Byte)senderGrid.CurrentRow.Cells["Rol_Activo"].Value;
                    ModificarRol modificarRol = new ModificarRol(rolAModificar);
                    this.Hide();
                    modificarRol.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion de rol " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Eliminar" && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult dialogResult = MessageBox.Show("Esta seguro que desea eliminar este rol?", "Confirmación", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        String[] respuesta = Rol.eliminarRol((Int32)senderGrid.CurrentRow.Cells["Rol_Codigo"].Value);
                        if (respuesta[0] == "Error")
                        {
                            MessageBox.Show("Error al eliminar rol: " + respuesta[1], "Error", MessageBoxButtons.OK);
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

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol();
            altaRol.Show();
            this.Hide();
        }

    }
}
