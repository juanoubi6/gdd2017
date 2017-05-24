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
        public static DataTable traerViajesDeFactura(Cliente clienteElegido, DateTime fechaInicio, DateTime fechaFin)
        {
            DataTable dtViajes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT * FROM Viaje WHERE Viaje_Cliente = @cliente AND (Viaje_Fecha_Hora_Inicio BETWEEN @fechaInicioFact AND @fechaFinFact)");
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
    }
}
