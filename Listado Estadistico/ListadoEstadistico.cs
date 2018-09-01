using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {

            //Añado los items para el combo de años
            cmbAño.DisplayMember = "Año";
            cmbAño.ValueMember = "Valor";

            var itemsAño = new[] { 
                new { Año = "2014", Valor = 2014 }, 
                new { Año = "2015", Valor = 2015 }, 
                new { Año = "2016", Valor = 2016 },
                new { Año = "2017", Valor = 2017 },
                new { Año = "2018", Valor = 2018 }
            };

            cmbAño.DataSource = itemsAño;
            cmbAño.SelectedIndex = 0;

            //Añado los items para el combo de trimestres
            cmbTrimestre.DisplayMember = "Trimestre";
            cmbTrimestre.ValueMember = "Valor";

            var itemsTrimestre = new[] { 
                new { Trimestre = "Primer Trimestre", Valor = 1 }, 
                new { Trimestre = "Segundo Trimestre", Valor = 2 }, 
                new { Trimestre = "Tercer Trimestre", Valor = 3 },
                new { Trimestre = "Cuarto Trimestre", Valor = 4 }
            };

            cmbTrimestre.DataSource = itemsTrimestre;
            cmbTrimestre.SelectedIndex = 0;

            //Añado los items para el combo de estadisticas
            cmbEstadistica.DisplayMember = "Estadistica";
            cmbEstadistica.ValueMember = "Valor";

            var itemsEstadistica = new[] { 
                new { Estadistica = "Choferes con mayor recaudacion", Valor = 1 }, 
                new { Estadistica = "Choferes con el viaje más largo realizado", Valor = 2 }, 
                new { Estadistica = "Clientes con mayor consumo", Valor = 3 },
                new { Estadistica = "Clientes con mayor reuso de automovil en sus viajes", Valor = 4 }
            };

            cmbEstadistica.DataSource = itemsEstadistica;
            cmbEstadistica.SelectedIndex = 0;          


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32 valorAño = (Int32)(cmbAño.SelectedValue);
            Int32 valorQueryEstadistica = (Int32)(cmbEstadistica.SelectedValue);

            Int32 mesInicial, mesFinal;

            if ((Int32)(cmbTrimestre.SelectedValue) == 1)
            {
                mesInicial = 1;
                mesFinal = 3;
            }
            else if ((Int32)(cmbTrimestre.SelectedValue) == 2)
            {
                mesInicial = 4;
                mesFinal = 6;
            }
            else if ((Int32)(cmbTrimestre.SelectedValue) == 3)
            {
                mesInicial = 7;
                mesFinal = 9;
            }
            else
            {
                mesInicial = 10;
                mesFinal = 12;
            }

            try
            {
                DataTable dtListadoEstadisticas = Estadistica.obtenerListado(valorQueryEstadistica,valorAño, mesInicial, mesFinal);
                grillaEstadistica.DataSource = dtListadoEstadisticas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK);
            }

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            grillaEstadistica.DataSource = null;
        }
    }
}
