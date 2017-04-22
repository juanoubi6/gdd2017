using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Registro_Viajes
{
    public partial class AltaViaje : Form
    {
        public AltaViaje()
        {
            InitializeComponent();
        }

        private void btnSelectAuto_Click(object sender, EventArgs e)
        {
            GrillaAuto_Viaje grillaAuto = new GrillaAuto_Viaje(this);
            grillaAuto.Show();
        }

        private void bntSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Viaje grillaChofer = new GrillaChofer_Viaje(this);
            grillaChofer.Show();
        }

        private void btnSelectTurno_Click(object sender, EventArgs e)
        {
            GrillaTurno_Viaje grillaTurno = new GrillaTurno_Viaje(this);
            grillaTurno.Show();
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            GrillaCliente_Viaje grillaCliente = new GrillaCliente_Viaje(this);
            grillaCliente.Show();
        }
    }
}
