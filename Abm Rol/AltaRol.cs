using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace UberFrba.Abm_Rol
{
    public partial class AltaRol : Form
    {
        public AltaRol()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int contadorErrores = 0;

                //Valido que el campo Nombre sea correcto
                errorNombre.Text = Rol.validarNombre(txtNombre.Text);
                if (errorNombre.Text != "") contadorErrores++;

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

                //Si no hay errores, se intenta guardar el nuevo rol
                if (contadorErrores == 0)
                {
                    String[] respuesta = Rol.grabarRol(txtNombre.Text, codigosFuncionalidades);
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

        private void AltaRol_Load(object sender, EventArgs e)
        {
            DataTable funcionalidades = Rol.obtenerFuncionalidades();

            lstFuncionalidad.DataSource = funcionalidades;
            lstFuncionalidad.DisplayMember = "Funcionalidad_Nombre";
            lstFuncionalidad.ValueMember = "Funcionalidad_Codigo";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Text = String.Empty;
            lblErrorBaseDatos.Text = String.Empty;
            errorNombre.Text = String.Empty;
            errorFuncionalidad.Text = String.Empty;
            grpErrorBaseDatos.Visible = false;
        }
    }
}
