using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace UberFrba
{
    public class LoginClass
    {

        public static DataTable login (String username, String password)
        {

            //Encripto la contraseña con el algoritmo sha256
            String hash = GenerateSHA256String(password);

            DataTable dtUsuario = new DataTable();

            //Voy a buscar si existe el usuario
            SqlCommand cmd = new SqlCommand("SELECT * FROM SAPNU_PUAS.Usuario where Usuario_Username=@username");
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

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM SAPNU_PUAS.Usuario where Usuario_Username=@username and Usuario_Password=@password");
                    cmd2.Connection = DBconnection.getInstance();
                    cmd2.Parameters.Add("@username", SqlDbType.VarChar);
                    cmd2.Parameters.Add("@password", SqlDbType.VarChar);
                    cmd2.Parameters["@username"].Value = username;
                    cmd2.Parameters["@password"].Value = hash;

                    SqlDataAdapter adapterUsuarioYContraseña = new SqlDataAdapter(cmd2);
                    adapterUsuarioYContraseña.Fill(dtUsuarioYPassword);

                    //Reviso si pude recuperar el usuario con la contraseña ingresada
                    if (dtUsuarioYPassword.Rows.Count > 0)
                    {
                        //En caso de haber encontrado un usuario, reviso si esta activo
                        if ((Byte)(dtUsuarioYPassword.Rows[0]["Usuario_Activo"]) == 0)
                        {
                            throw new DataException("Usuario bloqueado o inactivo");
                        }
                        else
                        {
                            //En caso de que el usuario no este bloqueado, se borran los reintentos y se buscan sus roles
                            borrarReintentos(dtUsuarioYPassword.Rows[0]["Usuario_Username"].ToString());
                            return buscarRoles(username);
                        }
                    }
                    else
                    {
                        //En caso de que la contraseña ingresada haya sido incorrecta, sumo un reintento
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

            SqlCommand cmd = new SqlCommand("UPDATE SAPNU_PUAS.Usuario SET Usuario_Reintentos = Usuario_Reintentos + 1 WHERE Usuario_Username = @username");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = (dtUsuario.Rows[0]["Usuario_Username"]);

            //Reviso si al aumentar la cantidad de reintentos se llega a los 3. De ser asi, bloqueo el usuario. Caso contrario, incremento el contador de reintentos
            if ((Int16)(dtUsuario.Rows[0]["Usuario_Reintentos"]) + 1 == 3)
            {
                //Sobreescribo el comando anterior para que además de incrementar el contador, cambie el estado del usuario
                cmd.CommandText = "UPDATE SAPNU_PUAS.Usuario SET Usuario_Reintentos = Usuario_Reintentos + 1,Usuario_Activo = 0 WHERE Usuario_Username = @username";
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
            //Borro todos los reintentos del usuario
            SqlCommand cmd = new SqlCommand("UPDATE SAPNU_PUAS.Usuario SET Usuario_Reintentos = 0 WHERE Usuario_Username = @username");
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

            //Traigo todos los roles asociados al usuario
            SqlCommand cmd2 = new SqlCommand("SELECT R.Rol_Codigo,R.Rol_Nombre FROM SAPNU_PUAS.Rol R join SAPNU_PUAS.Rol_x_Usuario RU on R.Rol_Codigo = RU.Rol_Codigo where RU.Usuario_Username=@username");
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
  
            //Busco todas las funcionalidades que posee el rol elegido
            SqlCommand cmd = new SqlCommand("SELECT F.Funcionalidad_Nombre FROM SAPNU_PUAS.Funcionalidad F join SAPNU_PUAS.Funcionalidad_x_Rol FR on F.Funcionalidad_Codigo = FR.Funcionalidad_Codigo where Rol_Codigo = @codigoRol");
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

        //Convierte el string que le des (una contraseña, por ejemplo) en un string encirptado con el algortimo sha256
        public static String GenerateSHA256String(String textoAHashear)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(textoAHashear);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

    }
}
