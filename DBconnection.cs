using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace UberFrba
{
    public class DBconnection
    {

        private static SqlConnection BDconnection;

        public static SqlConnection getInstance()
        {
            if (BDconnection == null)
            {
                try
                {
                    //Para que ande esto, agregar la referencia a System.Configuration
                    BDconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["GD2017C1"].ConnectionString);
                    return BDconnection;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                return BDconnection;
            }

        }

    }
}
