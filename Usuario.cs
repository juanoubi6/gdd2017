using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba
{
    public class Usuario
    {

        public String Username { get; set; }
        public Decimal Telefono { get; set; }

        public static DataTable buscarUsuarios()
        {
            DataTable dtUsuarios = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT U.Usuario_Username,U.Usuario_Activo FROM SAPNU_PUAS.Usuario U");
            cmd.Connection = DBconnection.getInstance();
       
            SqlDataAdapter adapterUsuarios = new SqlDataAdapter(cmd);

            try
            {
                adapterUsuarios.Fill(dtUsuarios);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtUsuarios;
        }
    }
}
