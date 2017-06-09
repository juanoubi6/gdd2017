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
    public partial class AsignacionRol : Form
    {

        public Usuario usuarioElegido;

        public AsignacionRol()
        {
            InitializeComponent();
        }

        private void btnSeleccionUsuario_Click(object sender, EventArgs e)
        {
            ListadoUsuario listadoUsuarios = new ListadoUsuario(this);
            listadoUsuarios.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int contadorErrores = 0;

                //Valido que el campo Usuario sea correcto
                if (txtUsuario.Text == "")
                {
                    contadorErrores++;
                    errorUsuario.Text = "El usuario no puede ser vacio";
                }

                //Selecciono todos los elementos de la lista de roles
                List<Int32> codigosRoles = new List<Int32>();
                var roles = lstRoles.SelectedItems;

                foreach (var rol in roles)
                {
                    var itemArray = ((DataRowView)rol).Row.ItemArray;
                    codigosRoles.Add((Int32)itemArray[0]);
                }

                //Verifico que se haya seleccionado algun rol
                if (codigosRoles.Count == 0)
                {
                    contadorErrores++;
                    errorRoles.Text = "Debe seleccionar al menos un rol";
                }

                //Si no hay errores, se intenta guardar el nuevo rol
                if (contadorErrores == 0)
                {
                    String[] respuesta = Rol.asignarRoles(usuarioElegido, codigosRoles);
                    if (respuesta[0] == "Error")
                    {
                        lblErrorBaseDatos.Text = respuesta[1];
                        grpErrorBaseDatos.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = String.Empty;
            lblErrorBaseDatos.Text = String.Empty;
            errorUsuario.Text = String.Empty;
            errorRoles.Text = String.Empty;
            grpErrorBaseDatos.Visible = false;
        }

        private void AsignacionRol_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable funcionalidades = Rol.obtenerRoles();

                lstRoles.DataSource = funcionalidades;
                lstRoles.DisplayMember = "Rol_Nombre";
                lstRoles.ValueMember = "Rol_Codigo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al buscar los roles: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }

        public void cambiarUsuario()
        {
            txtUsuario.Text = usuarioElegido.Username;
        }
    }
}
