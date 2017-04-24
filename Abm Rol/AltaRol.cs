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
            int contadorErrores = 0;

            errorNombre.Text = Rol.validarNombre(txtNombre.Text);
            if (errorNombre.Text != "") contadorErrores++;

            //TODO: validar que se haya seleccionado algo del listbox
            String valor = lstFuncionalidad.SelectedValue.ToString();


        }
    }
}
