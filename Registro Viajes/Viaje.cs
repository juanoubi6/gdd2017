using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Registro_Viajes
{
    public class Viaje
    {
        public Int32 Codigo { get; set; }
        public Decimal CantidadKm { get; set; }
        public DateTime FechaHoraInicio { get; set; }
        public DateTime FechaHoraFin { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal Chofer { get; set; }
        public String Auto { get; set; }
        public Int32 Turno { get; set; }
        public Decimal Cliente { get; set; }

        public static String validarFechaHoraInicio(DateTime fechaHoraIni)
        {
            return "";
        }

        public static String validarFechaHoraFin(DateTime fechaHoraFin)
        {
            return "";
        }

        public static String validarCantKm(String cantidad)
        {
            int cantNumerica;
            if (String.IsNullOrEmpty(cantidad))             return "El valor no puede ser vacio";
            if (!int.TryParse(cantidad, out cantNumerica))  return "El valor no es numérico";
            if (Int32.Parse(cantidad) <= 0)                 return "El valor de los kilómetros debe ser mayor a 0";
            if (cantidad.Length > 17)                       return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarAuto(String auto)
        {
            if (String.IsNullOrEmpty(auto)) return "El valor no puede ser vacio";
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

        public static String validarCliente(String cliente)
        {
            if (String.IsNullOrEmpty(cliente)) return "El valor no puede ser vacio";
            return "";
        }

        public static String[] registrarViaje(Viaje viajeAGrabar)
        {
            //Creo el comando necesario para grabar el turno en la tabla de turnos
            SqlCommand cmdViaje = new SqlCommand("SAPNU_PUAS.sp_viaje_alta");
            cmdViaje.CommandType = CommandType.StoredProcedure;
            cmdViaje.Connection = DBconnection.getInstance();
            cmdViaje.Parameters.Add("@viaje_cant_km", SqlDbType.Decimal).Value = viajeAGrabar.CantidadKm;
            cmdViaje.Parameters.Add("@viaje_hora_ini", SqlDbType.DateTime).Value = viajeAGrabar.FechaHoraInicio;
            cmdViaje.Parameters.Add("@viaje_hora_fin", SqlDbType.DateTime).Value = viajeAGrabar.FechaHoraFin;
            cmdViaje.Parameters.Add("@viaje_chofer", SqlDbType.Decimal).Value = viajeAGrabar.Chofer;
            cmdViaje.Parameters.Add("@viaje_auto", SqlDbType.VarChar).Value = viajeAGrabar.Auto;
            cmdViaje.Parameters.Add("@viaje_turno", SqlDbType.Int).Value = viajeAGrabar.Turno;
            cmdViaje.Parameters.Add("@viaje_cliente", SqlDbType.Decimal).Value = viajeAGrabar.Cliente;

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
            cmdViaje.Parameters.Add(responseMsg);
            cmdViaje.Parameters.Add(responseErr);

            //Se realiza toda la creacion del cliente en el ambito de una transaccion
            try
            {
                cmdViaje.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdViaje.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdViaje.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdViaje.Parameters["@resultado"].Value.ToString());

                cmdViaje.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdViaje.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Viaje creado satisfactoriamente" };
        }
    }
}
