using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Listado_Estadistico
{
    public class Estadistica
    {
        public static DataTable obtenerListado(int valorQueryEstadistica,int valorAño, int mesInicial, int mesFinal)
        {
            DataTable dtListado = new DataTable();

            String queryText;

            //Creo el comando a ejecutar dependiendo del valor de valorQueryEstadistica
            //1-Top 5 choferes mas recaudadores
            //2-Top 5 choferes con el viaje mas largo
            //3-Top 5 clientes con mayor consumo
            //4-Top 5 clientes que utilizaron más veces el mismo automóvil en los viajes que han realizado
            switch (valorQueryEstadistica)
            {
                case 1:
                    queryText = "SELECT * FROM SAPNU_PUAS.top5recaudacion(@año,@mesInicial,@mesFinal)";
                    break;
                case 2:
                    queryText = "SELECT * FROM SAPNU_PUAS.viajes_mas_largos(@año,@mesInicial,@mesFinal)";
                    break;
                case 3:
                    queryText = "SELECT * FROM SAPNU_PUAS.clientes_mayor_consumo(@año,@mesInicial,@mesFinal)";
                    break;
                case 4:
                    queryText = "SELECT * SAPNU_PUAS.top5ClienteAuto(@año,@mesInicial,@mesFinal)";
                    break;
                default:
                    throw new Exception("Error con el listado de estadisticas pedido");
            }

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = queryText;
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@año", SqlDbType.Int).Value = valorAño;
            cmd.Parameters.Add("@mesInicial", SqlDbType.Int).Value = mesInicial;
            cmd.Parameters.Add("@mesFinal", SqlDbType.Int).Value = mesFinal;

            SqlDataAdapter adapterListado = new SqlDataAdapter(cmd);

            try
            {
                adapterListado.Fill(dtListado);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtListado;
        }
    }
}
