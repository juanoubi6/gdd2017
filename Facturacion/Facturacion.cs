using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    public partial class Facturacion : Form
    {
        public Cliente clienteElegido;

        public Facturacion()
        {
            InitializeComponent();
        }

        public void cambiarCliente()
        {
            txtCliente.Text = clienteElegido.Nombre + " " + clienteElegido.Apellido;
            mostrarViajes();
        }

        private void btnSelectCliente_Click(object sender, EventArgs e)
        {
            GrillaCliente_Facturacion grillaCliente = new GrillaCliente_Facturacion(this);
            grillaCliente.Show();
        }

        private void mostrarViajes()
        {
            //Una vez seleccionado el cliente, muestro sus viajes entre las fechas seleccionadas
            DataTable dtViajesFactura = Factura.traerViajesDeFactura(clienteElegido, dtpInicio.Value, dtpFin.Value);
            grillaViajesFactura.DataSource = dtViajesFactura;

            txtCantViajes.Text = dtViajesFactura.Rows.Count.ToString();
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFin.Value <= dtpInicio.Value)
            {
                MessageBox.Show("La fecha de fin de facturacion no puede ser menor o igual a la fecha de inicio", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if(clienteElegido != null) mostrarViajes();
            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            if (dtpInicio.Value >= dtpFin.Value)
            {
                MessageBox.Show("La fecha de inicio de facturacion no puede ser mayor o igual a la fecha de fin", "Error", MessageBoxButtons.OK);
            }
            else
            {
                if (clienteElegido != null) mostrarViajes();
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {

        }
    }
}
