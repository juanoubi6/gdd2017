using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Chofer;

namespace UberFrba.Rendicion_Viajes
{
    public class Rendicion
    {

        public DateTime Fecha { get; set; }
        public Decimal Chofer { get; set; }
        public Decimal Porcentaje { get; set; }
        public Decimal Turno { get; set; }

        public static DataTable traerViajesDeRendicion(Chofer choferElegido, DateTime fecha)
        {
            DataTable dtViajes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT * FROM Viaje WHERE Viaje_Chofer = @chofer AND CONVERT(date,Viaje_Fecha_Hora_Inicio) = @fecha");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@chofer", SqlDbType.Decimal).Value = choferElegido.Telefono;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

            SqlDataAdapter adapterViajes = new SqlDataAdapter(cmd);

            try
            {
                adapterViajes.Fill(dtViajes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtViajes;
        }


        public static String[] grabarRendicion(Rendicion nuevaRendicion)
        {
            //Creo el comando necesario para grabar la factura y sus items
            SqlCommand cmdFactura = new SqlCommand("sp_rendicion_viajes");
            cmdFactura.CommandType = CommandType.StoredProcedure;
            cmdFactura.Connection = DBconnection.getInstance();
            cmdFactura.Parameters.Add("@chofer_telefono", SqlDbType.Decimal).Value = nuevaRendicion.Chofer;
            cmdFactura.Parameters.Add("@fecha", SqlDbType.DateTime).Value = nuevaRendicion.Fecha;
            cmdFactura.Parameters.Add("@turno_codigo", SqlDbType.Decimal).Value = nuevaRendicion.Turno;
            cmdFactura.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = nuevaRendicion.Porcentaje;

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
            cmdFactura.Parameters.Add(responseMsg);
            cmdFactura.Parameters.Add(responseErr);

            //Se realiza toda la creacion de la factura y sus items en el ambito de una transaccion
            try
            {
                cmdFactura.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdFactura.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdFactura.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdFactura.Parameters["@resultado"].Value.ToString());

                cmdFactura.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdFactura.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Rendicion a chofer realizada satisfactoriamente" };
        }
    }
}
