using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba
{
    public class LoginClass
    {

        public static DataTable login (String username, String hash)
        {
            try
            {
                DataTable dtUsuario = new DataTable();

                //Creo el comando a ejecutar y sus parametros
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario where Usuario_Username=@username and Usuario_Password=@password");
                cmd.Connection = DBconnection.getInstance();
                cmd.Parameters.Add("@username", SqlDbType.VarChar);
                cmd.Parameters.Add("@password", SqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;
                cmd.Parameters["@password"].Value = hash;

                SqlDataAdapter adapterUsuario = new SqlDataAdapter(cmd);

                //El metodo Fill() te abre y cierra la conexion solo, por eso no la abri
                adapterUsuario.Fill(dtUsuario);

                //Si encuentra el usuario, voy a buscar sus roles
                if (dtUsuario.Rows.Count > 0)
                {
                    DataTable dtRoles = new DataTable();

                    //Creo el comando a ejecutar y sus parametros
                    SqlCommand cmd2 = new SqlCommand("SELECT R.Rol_Codigo,R.Rol_Nombre FROM Rol R join Rol_x_Usuario RU on R.Rol_Codigo = RU.Rol_Codigo where RU.Usuario_Username=@username");
                    cmd2.Connection = DBconnection.getInstance();
                    cmd2.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd2.Parameters["@username"].Value = username;

                    SqlDataAdapter adapterRoles = new SqlDataAdapter(cmd2);

                    adapterRoles.Fill(dtRoles);
                    return dtRoles;
                }
                else
                {
                    throw new Exception("No se encontraron datos para el usuario y contraseña informados");
                }

            }
            catch (Exception ex)
            {
                return new DataTable();
            }

        

                
        }

    }
}
