using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Abm_Chofer;
using UberFrba.Abm_Turno;

namespace UberFrba.Abm_Automovil
{
    public partial class ModificarAutomovil : Form
    {
        private Automovil autoAModificar;
        public Chofer choferElegido;
        public Turno turnoElegido;

        public ModificarAutomovil(Automovil auto)
        {
            InitializeComponent();
            this.autoAModificar = auto;
        }

        private void ModificarAutomovil_Load(object sender, EventArgs e)
        {
            DataTable marcasDt = Automovil.traerMarcas();
            cmbMarca.DataSource = marcasDt;
            cmbMarca.DisplayMember = "Marca_Nombre";
            cmbMarca.ValueMember = "Marca_Codigo";
            cmbMarca.SelectedValue = autoAModificar.Marca;

            DataTable dtChoferElegido = Chofer.buscarChoferPorPk(autoAModificar.Chofer);
            DataTable dtTurnoElegido = Turno.buscarTurnoPorPk(autoAModificar.Turno);

            //Asigno el chofer elegido
            Chofer nuevoChofer = new Chofer();
            nuevoChofer.Telefono = (Decimal)dtChoferElegido.Rows[0]["Chofer_Telefono"];
            choferElegido = nuevoChofer;

            //Asigno el turno elegido
            Turno nuevoTurno = new Turno();
            nuevoTurno.Codigo = (Int32)dtTurnoElegido.Rows[0]["Turno_Codigo"];
            turnoElegido = nuevoTurno;


            chkHabilitado.Checked = (autoAModificar.Activo == 1) ? true : false;
            txtModelo.Text = autoAModificar.Modelo;
            txtPatente.Text = autoAModificar.Patente;
            txtChofer.Text = dtChoferElegido.Rows[0]["Chofer_Nombre"].ToString() + " " + dtChoferElegido.Rows[0]["Chofer_Apellido"].ToString();
            txtTurno.Text = dtTurnoElegido.Rows[0]["Turno_Descripcion"].ToString() + " (" + dtTurnoElegido.Rows[0]["Turno_Hora_Inicio"].ToString() + " a " + dtTurnoElegido.Rows[0]["Turno_Hora_Fin"].ToString() + ")";
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int contadorErrores = 0;

            if (cmbMarca.SelectedValue == null)
            {
                contadorErrores++;
                errorMarca.Text = "El campo no puede ser vacio";
            }

            errorModelo.Text = Automovil.validarModelo(txtModelo.Text);
            if (errorModelo.Text != "") contadorErrores++;

            //Si cambie la patente con respecto a la antigua, la valido
            if (txtPatente.Text != autoAModificar.Patente)
            {
                errorPatente.Text = Automovil.validarPatente(txtPatente.Text);
                if (errorPatente.Text != "") contadorErrores++;
            }

            errorTurno.Text = Automovil.validarTurno(txtTurno.Text);
            if (errorTurno.Text != "") contadorErrores++;

            errorChofer.Text = Automovil.validarChofer(txtChofer.Text);
            if (errorChofer.Text != "") contadorErrores++;

            //Si no hay errores, se intenta modificar el automovil
            if (contadorErrores == 0)
            {
                Automovil autoAModificarEnBD = new Automovil();
                autoAModificarEnBD.Marca = (Int32)(cmbMarca.SelectedValue);
                autoAModificarEnBD.Modelo = txtModelo.Text;
                autoAModificarEnBD.Patente = txtPatente.Text;
                autoAModificarEnBD.Chofer = choferElegido.Telefono;
                autoAModificarEnBD.Turno = turnoElegido.Codigo;
                autoAModificarEnBD.Activo = (chkHabilitado.Checked) ? (Byte)1 : (Byte)0; ;

                String[] respuesta = Automovil.modificarAuto(autoAModificarEnBD,autoAModificar.Patente);
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

        public void cambiarChofer()
        {
            txtChofer.Text = choferElegido.Nombre + " " + choferElegido.Apellido;
        }

        public void cambiarTurno()
        {
            txtTurno.Text = turnoElegido.Descripcion + " (" + turnoElegido.HoraInicio.ToString() + " a " + turnoElegido.HoraFin.ToString() + ")";
        }

        private void btnSelecTurno_Click(object sender, EventArgs e)
        {
            GrillaTurno_Auto grillaTurno = new GrillaTurno_Auto(this,"modificar");
            grillaTurno.Show();
        }

        private void bntSelectChofer_Click(object sender, EventArgs e)
        {
            GrillaChofer_Auto grillaChofer = new GrillaChofer_Auto(this, "modificar");
            grillaChofer.Show();
        }


    }
}
