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

    }
}
