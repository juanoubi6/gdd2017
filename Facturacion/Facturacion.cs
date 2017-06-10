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
            int contadorErrores = 0;

            //Si no hay viajes no se puede facturar
            if (txtCantViajes.Text == "0")
            {
                contadorErrores++;
                errorViajes.Text = "No se puede facturar un cliente si no tiene viajes que facturar";
            }

            if (dtpInicio.Value == dtpFin.Value)
            {
                contadorErrores++;
                errorFechaFin.Text = "Las fechas de inicio y fin no pueden ser iguales";
                errorFechaIni.Text = "Las fechas de inicio y fin no pueden ser iguales";
            }

            if (dtpInicio.Value >= dtpFin.Value)
            {
                contadorErrores++;
                errorFechaIni.Text = "La fecha de inicio no puede ser mas grande que la de fin";
            }

            if (dtpFin.Value <= dtpInicio.Value)
            {
                contadorErrores++;
                errorFechaFin.Text = "La fecha de fin no puede ser menor a la fecha de inicio";
            }

            //Las fechas de facturacion no son del mismo mes
            if (dtpFin.Value.Month != dtpInicio.Value.Month)
            {
                contadorErrores++;
                MessageBox.Show("Las fechas en las que se factura deben pertenecer al mismo mes ya que la facturacion es mensual", "Error", MessageBoxButtons.OK);
            }

            if (contadorErrores == 0)
            {
                Factura nuevaFactura = new Factura();
                nuevaFactura.FechaInicio = dtpInicio.Value;
                nuevaFactura.FechaFin = dtpFin.Value;
                nuevaFactura.Cliente = clienteElegido.Telefono;
                nuevaFactura.Fecha = DateTime.Now;

                String[] respuesta = Factura.grabarFactura(nuevaFactura);
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCantViajes.Text = "";
            txtCliente.Text = "";
            clienteElegido = null;
            lblErrorBaseDatos.Text = "";
            grpErrorBaseDatos.Visible = false;
            errorFechaFin.Text = "";
            errorFechaIni.Text = "";
            grillaViajesFactura.DataSource = null;
        }
    }
}
