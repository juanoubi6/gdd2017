using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    public class Automovil
    {

        public Int32 Marca { get; set; }
        public String Modelo { get; set; }
        public String Patente { get; set; }
        public String Licencia { get; set; }
        public String Rodado { get; set; }
        public Decimal Chofer { get; set; }
        public Int32 Turno { get; set; }
        public Byte Activo { get; set; }

        public static String validarModelo(String modelo)
        {
            if (String.IsNullOrEmpty(modelo)) return "El campo no puede ser vacio";
            if (modelo.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarPatente(String patente)
        {
            if (String.IsNullOrEmpty(patente)) return "El campo no puede ser vacio";
            if (patente.Length > 10) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarChofer(String chofer)
        {
            if (String.IsNullOrEmpty(chofer)) return "El valor no puede ser vacio";
            return "";
        }

        public static String validarTurno(String turno)
        {
            if (String.IsNullOrEmpty(turno)) return "El valor no puede ser vacio";
            return "";
        }

        public static DataTable traerMarcas()
        {
            DataTable dtMarcas = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT * FROM Marca");
            cmd.Connection = DBconnection.getInstance();

            SqlDataAdapter adapterMarcas = new SqlDataAdapter(cmd);

            try
            {
                adapterMarcas.Fill(dtMarcas);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtMarcas;
        }

        public static String[] grabarAuto(Automovil autoAGrabar)
        {

            //Creo el comando necesario para grabar el turno en la tabla de turnos
            SqlCommand cmdAuto = new SqlCommand("sp_auto_alta");
            cmdAuto.CommandType = CommandType.StoredProcedure;
            cmdAuto.Connection = DBconnection.getInstance();
            cmdAuto.Parameters.Add("@marca", SqlDbType.Int).Value = autoAGrabar.Marca;
            cmdAuto.Parameters.Add("@modelo", SqlDbType.VarChar).Value = autoAGrabar.Modelo;
            cmdAuto.Parameters.Add("@patente", SqlDbType.VarChar).Value = autoAGrabar.Patente;
            cmdAuto.Parameters.Add("@licencia", SqlDbType.VarChar).Value = Convert.DBNull;
            cmdAuto.Parameters.Add("@rodado", SqlDbType.VarChar).Value = Convert.DBNull;
            cmdAuto.Parameters.Add("@chofer", SqlDbType.Decimal).Value = autoAGrabar.Chofer;
            cmdAuto.Parameters.Add("@turno", SqlDbType.Int).Value = autoAGrabar.Turno;
            cmdAuto.Parameters.Add("@activo", SqlDbType.TinyInt).Value = autoAGrabar.Activo;


            //Creo los parametro respuesta
            SqlParameter responseMsg = new SqlParameter();
            SqlParameter responseErr = new SqlParameter();
            responseMsg.ParameterName = "@resultado";
            responseErr.ParameterName = "@codOp";
            responseMsg.SqlDbType = System.Data.SqlDbType.VarChar;
            responseMsg.Direction = System.Data.ParameterDirection.Output;
            responseMsg.Size = 255;
            responseErr.SqlDbType = System.Data.SqlDbType.Int;
            responseErr.Direction = System.Data.ParameterDirection.Output;
            cmdAuto.Parameters.Add(responseMsg);
            cmdAuto.Parameters.Add(responseErr);

            //Se realiza toda la creacion del cliente en el ambito de una transaccion
            try
            {
                cmdAuto.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdAuto.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdAuto.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdAuto.Parameters["@resultado"].Value.ToString());

                cmdAuto.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdAuto.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Auto creado satisfactoriamente" };
        }

        public static DataTable buscarAutos(String patente, String modelo, Decimal dniChofer, Int32 codigoMarca)
        {
            DataTable dtAutos = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryAutos = "SELECT A.Auto_Marca, M.Marca_Nombre, A.Auto_Modelo, A.Auto_Patente, A.Auto_Rodado, A.Auto_Licencia,A.Auto_Chofer,C.Chofer_Nombre,C.Chofer_Apellido,A.Auto_Turno,T.Turno_Descripcion,A.Auto_Activo FROM Auto A JOIN Marca M on A.Auto_Marca = M.Marca_Codigo JOIN Chofer C on C.Chofer_Dni = A.Auto_Chofer JOIN Turno T on T.Turno_Codigo = A.Auto_Turno WHERE 1=1";

            //Armo la query dinamica en base a los parametros de busqueda que me hayan llegado
            if (!String.IsNullOrEmpty(patente))
            {
                queryAutos = queryAutos + " AND Auto_Patente = @patente";
                cmd.Parameters.Add("@patente", SqlDbType.VarChar).Value = patente;
            }
            if (!String.IsNullOrEmpty(modelo))
            {
                queryAutos = queryAutos + " AND Auto_Modelo LIKE '%' + @modelo + '%'";
                cmd.Parameters.Add("@modelo", SqlDbType.VarChar).Value = modelo;
            }
            if (dniChofer != 0)
            {
                queryAutos = queryAutos + " AND Auto_Chofer = @dniChofer";
                cmd.Parameters.Add("@dniChofer", SqlDbType.Decimal).Value = dniChofer;
            }
            if (codigoMarca != 0)
            {
                queryAutos = queryAutos + " AND Auto_Marca = @codigoMarca";
                cmd.Parameters.Add("@codigoMarca", SqlDbType.Int).Value = codigoMarca;
            }

            cmd.CommandText = queryAutos;
            SqlDataAdapter adapterAutos = new SqlDataAdapter(cmd);

            try
            {
                adapterAutos.Fill(dtAutos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtAutos;
        }

        public static String[] eliminarAuto(String patente)
        {
            //Creo el comando para dar de baja el turno
            SqlCommand cmdAuto = new SqlCommand("UPDATE Auto SET Auto_Activo = 0 WHERE Auto_Patente = @patente");
            cmdAuto.Connection = DBconnection.getInstance();
            cmdAuto.Parameters.Add("@patente", SqlDbType.VarChar).Value = patente;

            try
            {
                cmdAuto.Connection.Open();
                if (cmdAuto.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo dar de baja el automovil" };
                cmdAuto.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdAuto.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Automovil dado de baja satisfactoriamente" };
        }

        public static String[] modificarAuto(Automovil autoAModificar, String patenteAntigua)
        {
            SqlCommand cmdAuto = new SqlCommand("sp_auto_modif");
            cmdAuto.CommandType = CommandType.StoredProcedure;
            cmdAuto.Connection = DBconnection.getInstance();
            cmdAuto.Parameters.Add("@marca", SqlDbType.Int).Value = autoAModificar.Marca;
            cmdAuto.Parameters.Add("@modelo", SqlDbType.VarChar).Value = autoAModificar.Modelo;
            cmdAuto.Parameters.Add("@patente", SqlDbType.VarChar).Value = autoAModificar.Patente;
            cmdAuto.Parameters.Add("@patenteAnterior", SqlDbType.VarChar).Value = patenteAntigua;
            cmdAuto.Parameters.Add("@licencia", SqlDbType.VarChar).Value = autoAModificar.Licencia ?? Convert.DBNull;
            cmdAuto.Parameters.Add("@rodado", SqlDbType.VarChar).Value = autoAModificar.Rodado ?? Convert.DBNull;
            cmdAuto.Parameters.Add("@chofer", SqlDbType.Decimal).Value = autoAModificar.Chofer;
            cmdAuto.Parameters.Add("@turno", SqlDbType.Int).Value = autoAModificar.Turno;
            cmdAuto.Parameters.Add("@activo", SqlDbType.TinyInt).Value = autoAModificar.Activo;

            //Creo los parametro respuesta
            SqlParameter responseMsg = new SqlParameter();
            SqlParameter responseErr = new SqlParameter();
            responseMsg.ParameterName = "@resultado";
            responseErr.ParameterName = "@codOp";
            responseMsg.SqlDbType = System.Data.SqlDbType.VarChar;
            responseMsg.Direction = System.Data.ParameterDirection.Output;
            responseMsg.Size = 255;
            responseErr.SqlDbType = System.Data.SqlDbType.Int;
            responseErr.Direction = System.Data.ParameterDirection.Output;
            cmdAuto.Parameters.Add(responseMsg);
            cmdAuto.Parameters.Add(responseErr);

            try
            {
                cmdAuto.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdAuto.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdAuto.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdAuto.Parameters["@resultado"].Value.ToString());

                cmdAuto.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdAuto.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Auto actualizado satisfactoriamente" };
        }

    }
}
