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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea salir de la aplicación?", "Atención", MessageBoxButtons.YesNoCancel))
            {
                Application.Exit();
            }
        }

        private void automovilToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void choferToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rolToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void turnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void facturacionToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void registroDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rendiconDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listadoEstadisticoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
