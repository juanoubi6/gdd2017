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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int contadorErrores = 0;

                //Valido que el campo Nombre sea correcto si es que se modificó
                if (txtNombre.Text != rolAModificar.Nombre)
                {
                    errorNombre.Text = Rol.validarNombre(txtNombre.Text);
                    if (errorNombre.Text != "") contadorErrores++;
                }

                //Selecciono todos los elementos de la lista de funcionalidades
                List<Int32> codigosFuncionalidades = new List<Int32>();
                var funcionalidades = lstFuncionalidad.SelectedItems;

                foreach (var funcionalidad in funcionalidades)
                {
                    var itemArray = ((DataRowView)funcionalidad).Row.ItemArray;
                    codigosFuncionalidades.Add((Int32)itemArray[0]);
                }

                //Verifico que se haya seleccionado alguna funcionalidad
                if (codigosFuncionalidades.Count == 0)
                {
                    contadorErrores++;
                    errorFuncionalidad.Text = "Debe seleccionar al menos una funcionalidad";
                }

                //Verifico si se activo o desactivo el rol
                rolAModificar.Activo = (chkHabilitado.Checked) ? (Byte)1 : (Byte)0;

                //Si no hay errores, se intenta modificar
                if (contadorErrores == 0)
                {
                    String[] respuesta = Rol.modificarRol(txtNombre.Text, codigosFuncionalidades,rolAModificar.Codigo,rolAModificar.Activo);
                    if (respuesta[0] == "Error")
                    {
                        lblErrorBaseDatos.Text = respuesta[1];
                        grpErrorBaseDatos.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show(respuesta[1], "Operación exitosa", MessageBoxButtons.OK);
                        this.Hide();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
