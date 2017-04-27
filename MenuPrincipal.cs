using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Automovil;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Cliente;
using UberFrba.Abm_Rol;
using UberFrba.Abm_Turno;
using UberFrba.Facturacion;
using UberFrba.Listado_Estadistico;
using UberFrba.Registro_Viajes;
using UberFrba.Rendicion_Viajes;

namespace UberFrba
{
    public partial class MenuPrincipal : Form
    {

        private List<String> funcionalidades;

        public MenuPrincipal(List<String> funcionalidadesDelRol)
        {
            InitializeComponent();
            this.funcionalidades = funcionalidadesDelRol;
            evaluarPermisos();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Esta seguro que desea salir de la aplicación?", "Atención", MessageBoxButtons.YesNoCancel))
            {
                Application.Exit();
            }
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
            AltaViaje altaViaje = new AltaViaje();
            altaViaje.Show();
        }

        private void rendiconDeViajeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void listadoEstadisticoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void altaAutoOpt_Click(object sender, EventArgs e)
        {
            AltaAutomovil altaAutomovil = new AltaAutomovil();
            altaAutomovil.Show();
        }

        private void listadoAutoOpt_Click(object sender, EventArgs e)
        {
            ListadoAutomovil listadoAutomovil = new ListadoAutomovil();
            listadoAutomovil.Show();
        }

        private void altaChoferOpt_Click(object sender, EventArgs e)
        {
            AltaChofer altaChofer = new AltaChofer();
            altaChofer.Show();
        }

        private void listadoChoferOpt_Click(object sender, EventArgs e)
        {
            ListadoChofer listadoChofer = new ListadoChofer();
            listadoChofer.Show();
        }

        private void altaClienteOpt_Click(object sender, EventArgs e)
        {
            AltaCliente altaCliente = new AltaCliente();
            altaCliente.Show();
        }

        private void listadoClienteOpt_Click(object sender, EventArgs e)
        {
            ListadoCliente listadoCliente = new ListadoCliente();
            listadoCliente.Show();
        }

        private void altaRolOpt_Click(object sender, EventArgs e)
        {
            AltaRol altaRol = new AltaRol();
            altaRol.Show();
        }

        private void listadoRolOpt_Click(object sender, EventArgs e)
        {
            ListadoRol listadoRol = new ListadoRol();
            listadoRol.Show();
        }

        private void altaTurnoOpt_Click(object sender, EventArgs e)
        {
            AltaTurno altaTurno = new AltaTurno();
            altaTurno.Show();
        }

        private void listadoTurnoOpt_Click(object sender, EventArgs e)
        {
            ListadoTurno listadoTurno = new ListadoTurno();
            listadoTurno.Show();
        }

        private void evaluarPermisos()
        {
            if (!funcionalidades.Contains("ABMauto")) automovilToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("ABMchofer")) choferToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("ABMcliente")) clienteToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("ABMturno")) turnoToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("ABMrol")) rolToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("Facturacion")) facturacionToolStripMenuItem1.Visible = false;
            if (!funcionalidades.Contains("RegistroViaje")) registroDeViajeToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("RendicionViaje")) rendiconDeViajeToolStripMenuItem.Visible = false;
            if (!funcionalidades.Contains("ListadoEstadistico")) listadoEstadisticoToolStripMenuItem1.Visible = false;
        }

    }
}
