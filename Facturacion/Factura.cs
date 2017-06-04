using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Cliente;

namespace UberFrba.Facturacion
{
    public class Factura
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Decimal Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public static DataTable traerViajesDeFactura(Cliente clienteElegido, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtViajes = new DataTable();

            //Creo el comando a ejecutar para traer todos los viajes de un cliente entre las fechas de facturación indicadas
            SqlCommand cmd = new SqlCommand("SELECT Viaje_Cant_Kilometros,Viaje_Fecha_Hora_Inicio,Viaje_Fecha_Hora_Fin,Viaje_Chofer as Dni_Chofer_Viaje,Viaje_Auto,Turno_Descripcion,Turno_Valor_Kilometro,Turno_Precio_Base FROM Viaje JOIN Turno on Viaje_Turno = Turno_Codigo WHERE Viaje_Cliente = @cliente AND (Viaje_Fecha_Hora_Inicio BETWEEN @fechaInicioFact AND @fechaFinFact)");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@cliente", SqlDbType.Decimal).Value = clienteElegido.Telefono;
            cmd.Parameters.Add("@fechaInicioFact", SqlDbType.Date).Value = fechaInicio.Date;
            cmd.Parameters.Add("@fechaFinFact", SqlDbType.Date).Value = fechaFin.Date;

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

        public static String[] grabarFactura(Factura nuevaFactura)
        {

            //Creo el comando necesario para grabar la factura y sus items
            SqlCommand cmdFactura = new SqlCommand("sp_fact_cliente");
            cmdFactura.CommandType = CommandType.StoredProcedure;
            cmdFactura.Connection = DBconnection.getInstance();
            cmdFactura.Parameters.Add("@fecha_ini", SqlDbType.DateTime).Value = nuevaFactura.FechaInicio;
            cmdFactura.Parameters.Add("@fecha_fin", SqlDbType.DateTime).Value = nuevaFactura.FechaFin;
            cmdFactura.Parameters.Add("@cliente", SqlDbType.Decimal).Value = nuevaFactura.Cliente;

            //Creo los parametros respuesta
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

            //Se realiza toda la creacion de la factura y sus items
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

            return new String[2] { "Ok", "Cliente facturado satisfactoriamente" };
        }
    }
}
