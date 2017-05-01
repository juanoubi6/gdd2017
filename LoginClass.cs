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

                DataTable dtUsuario = new DataTable();

                //Voy a buscar si existe el usuario
                SqlCommand cmd = new SqlCommand("SELECT * FROM Usuario where Usuario_Username=@username");
                cmd.Connection = DBconnection.getInstance();
                cmd.Parameters.Add("@username", SqlDbType.VarChar);
                cmd.Parameters["@username"].Value = username;

                SqlDataAdapter adapterUsuario = new SqlDataAdapter(cmd);

                try
                {
                    adapterUsuario.Fill(dtUsuario);

                    //Si encuentra el usuario, voy a verificar si la contraseña es correcta
                    if (dtUsuario.Rows.Count > 0)
                    {
                        DataTable dtUsuarioYPassword = new DataTable();

                        SqlCommand cmd2 = new SqlCommand("SELECT * FROM Usuario where Usuario_Username=@username and Usuario_Password=@password");
                        cmd2.Connection = DBconnection.getInstance();
                        cmd2.Parameters.Add("@username", SqlDbType.VarChar);
                        cmd2.Parameters.Add("@password", SqlDbType.VarChar);
                        cmd2.Parameters["@username"].Value = username;
                        cmd2.Parameters["@password"].Value = hash;

                        SqlDataAdapter adapterUsuarioYContraseña = new SqlDataAdapter(cmd2);
                        adapterUsuarioYContraseña.Fill(dtUsuarioYPassword);

                        //Si encuentro el usuario y la contraseña es correcta, verifico que no este bloqueado
                        if (dtUsuarioYPassword.Rows.Count > 0)
                        {
                            if ((Byte)(dtUsuarioYPassword.Rows[0]["Usuario_Activo"]) == 0)
                            {
                                throw new DataException("Usuario bloqueado o inactivo");
                            }
                            else
                            {
                                borrarReintentos(dtUsuarioYPassword.Rows[0]["Usuario_Username"].ToString());
                                return buscarRoles(username);
                            }
                        }
                        else
                        {
                            aumentarReintentos(dtUsuario);
                            throw new DataException("Contraseña incorrecta");
                        }
                    }
                    else
                    {
                        throw new DataException("Usuario inexistente");
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }

        }

        private static void aumentarReintentos(DataTable dtUsuario)
        {

            SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Usuario_Reintentos = Usuario_Reintentos + 1 WHERE Usuario_Username = @username");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = (dtUsuario.Rows[0]["Usuario_Username"]);

            //Reviso si al aumentar la cantidad de reintentos se llega a los 3. De ser asi, bloqueo el usuario. Caso contrario, incremento el contador de reintentos
            if ((Int16)(dtUsuario.Rows[0]["Usuario_Reintentos"]) + 1 == 3)
            {
                //Sobreescribo el comando anterior para que además de incrementar el contador, cambie el estado del usuario
                cmd.CommandText = "UPDATE Usuario SET Usuario_Reintentos = Usuario_Reintentos + 1,Usuario_Activo = 0 WHERE Usuario_Username = @username";
            }

            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static void borrarReintentos(String username)
        {

            SqlCommand cmd = new SqlCommand("UPDATE Usuario SET Usuario_Reintentos = 0 WHERE Usuario_Username = @username");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;
          
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static DataTable buscarRoles(String username)
        {
            DataTable dtRoles = new DataTable();

            //Creo el comando a ejecutar y sus parametros
            SqlCommand cmd2 = new SqlCommand("SELECT R.Rol_Codigo,R.Rol_Nombre FROM Rol R join Rol_x_Usuario RU on R.Rol_Codigo = RU.Rol_Codigo where RU.Usuario_Username=@username");
            cmd2.Connection = DBconnection.getInstance();
            cmd2.Parameters.Add("@username", SqlDbType.VarChar);
            cmd2.Parameters["@username"].Value = username;

            SqlDataAdapter adapterRoles = new SqlDataAdapter(cmd2);

            try
            {
                adapterRoles.Fill(dtRoles);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtRoles;
        }

        public static List<String> buscarPermisos(Int32 codigo_rol)
        {
            List<String> funcionalidades = new List<String>();
  
            //Creo el comando a ejecutar y sus parametros
            SqlCommand cmd = new SqlCommand("SELECT F.Funcionalidad_Nombre FROM Funcionalidad F join Funcionalidad_x_Rol FR on F.Funcionalidad_Codigo = FR.Funcionalidad_Codigo where Rol_Codigo = @codigoRol");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmd.Parameters["@codigoRol"].Value = codigo_rol;

            SqlDataReader reader;

            try
            {

                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    funcionalidades.Add(reader["Funcionalidad_Nombre"].ToString());
                }

                cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return funcionalidades;

        }

    }
}
