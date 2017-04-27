using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRoles = LoginClass.login(txtUsuario.Text, txtContraseña.Text);
                if (dtRoles.Rows.Count != 0)
                {
                    //Le asigno a la grilla los roles
                    gridRoles.DataSource = dtRoles;
                    DataGridViewButtonColumn btnSeleccionar = new DataGridViewButtonColumn();

                    //Agrego un boton para seleccionar el rol en la grilla
                    btnSeleccionar.HeaderText = "Seleccionar";
                    btnSeleccionar.Text = "Seleccionar";
                    btnSeleccionar.UseColumnTextForButtonValue = true;
                    gridRoles.Columns.Add(btnSeleccionar);

                    gridRoles.Visible = true;

                } else {

                    MessageBox.Show("Su usuario no tiene roles asignados", "Error", MessageBoxButtons.OK);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al realizar el login: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void gridRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && senderGrid.CurrentCell.Value.ToString() == "Seleccionar" && e.RowIndex >= 0)
            {
                try
                {
                    List<String> funcionalidades = LoginClass.buscarPermisos((Int32)senderGrid.CurrentRow.Cells["Rol_Codigo"].Value);
                    MenuPrincipal menuPrincipal = new MenuPrincipal(funcionalidades);
                    this.Hide();
                    menuPrincipal.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error al realizar la seleccion de rol " + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }



    }
}
