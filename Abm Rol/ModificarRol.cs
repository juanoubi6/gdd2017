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
    public partial class ModificarRol : Form
    {

        private Rol rolAModificar;

        public ModificarRol(Rol rol)
        {
            InitializeComponent();
            this.rolAModificar = rol;
        }

        private void ModificarRol_Load(object sender, EventArgs e)
        {
            try
            {
                //Cargo en pantalla los datos del rol elegido
                txtNombre.Text = rolAModificar.Nombre;
                chkHabilitado.Checked = (rolAModificar.Activo == 1) ? true : false;

                DataTable funcionalidades = Rol.obtenerFuncionalidades();
                lstFuncionalidad.DataSource = funcionalidades;
                lstFuncionalidad.DisplayMember = "Funcionalidad_Nombre";
                lstFuncionalidad.ValueMember = "Funcionalidad_Codigo";

                List<Int32> funcionalidadesDelRol = Rol.obtenerFuncionalidadesDeRol(rolAModificar.Codigo);

                foreach (Int32 funcionalidad in funcionalidadesDelRol)
                {
                    lstFuncionalidad.SelectedValue = funcionalidad;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
