using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace UberFrba.Abm_Rol
{
    public class Rol
    {

        public String Nombre { get; set; }
        public Int32 Codigo { get; set; }
        public Byte Activo { get; set; }

        public static String validarNombre(String nombre)
        {
            
            if (String.IsNullOrEmpty(nombre))   return "El campo no puede ser vacio";
            if (nombre.Length > 255)            return "El valor ingresado es demasiado grande";

            //Valido si el nombre del rol ya existe en la base de datos
            DataTable dtRol = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Rol WHERE LOWER(Rol_Nombre) = LOWER(@nombre)");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmd.Parameters["@nombre"].Value = nombre;

            SqlDataAdapter adapterRol = new SqlDataAdapter(cmd);

            try
            {
                adapterRol.Fill(dtRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtRol.Rows.Count > 0) return "El nombre del rol ingresado ya esta en uso";

            return "";
        }

        public static String validarRol()
        {

            return "";
        }

        public static DataTable obtenerFuncionalidades()
        {

            DataTable dtFuncionalidad = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Funcionalidad");
            cmd.Connection = DBconnection.getInstance();

            SqlDataAdapter adapterFuncionalidad = new SqlDataAdapter(cmd);

            try
            {
                adapterFuncionalidad.Fill(dtFuncionalidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtFuncionalidad;
        }

        public static String[] grabarRol(String nombreRol ,List<Int32> codigos)
        {

            //Creo el comando necesario para grabar el rol en la tabla de Roles y retornar su ID generado
            SqlCommand cmd = new SqlCommand("INSERT INTO Rol (Rol_Nombre,Rol_Activo) OUTPUT INSERTED.Rol_Codigo VALUES(@nombreRol,1)");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@nombreRol", SqlDbType.VarChar);
            cmd.Parameters["@nombreRol"].Value = nombreRol;

            int idRolInsertado = 0;
            try
            {
                cmd.Connection.Open();
                idRolInsertado = (int)cmd.ExecuteScalar();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return new String[2] { "Error", "No se pudo insertar el rol en la base de datos" };
            }

            //Verifico si se inserto el rol en la base de datos. En ese caso, inserto las funcionalidades en el rol
            if (idRolInsertado > 0)
            {
                //Creo el comando necesario para ingresarle una funcionalidad a mi rol recien creado
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Funcionalidad_x_Rol (Rol_Codigo,Funcionalidad_Codigo) VALUES (@codigoRol,@codigoFuncionalidad)");
                cmd2.Connection = DBconnection.getInstance();
                cmd2.Parameters.Add("@codigoRol", SqlDbType.Int);
                cmd2.Parameters.Add("@codigoFuncionalidad", SqlDbType.Int);
                cmd2.Parameters["@codigoRol"].Value = idRolInsertado;

                try
                {
                    cmd2.Connection.Open();
                    foreach (Int32 codigoFuncionalidad in codigos)
                    {
                        cmd2.Parameters["@codigoFuncionalidad"].Value = codigoFuncionalidad;
                        if (cmd2.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudieron insertar las funcionalidades del rol" };
                    }             
                    cmd2.Connection.Close();
                }
                catch (Exception ex)
                {
                    cmd2.Connection.Close();
                    return new String[2] { "Error", "No se pudo insertar alguna de las funcionalidades del rol en la base de datos" };
                }


            }

            return new String[2] { "Ok", "Rol creado satisfactoriamente" };
        }

        public static String[] modificarRol(String nombreRol, List<Int32> codigos, Int32 codigoRol, Byte activo)
        {

            //Creo el comando necesario para modificar el rol
            SqlCommand cmd = new SqlCommand("UPDATE Rol SET Rol_Nombre = @nombreRol, Rol_Activo = @activo WHERE Rol_Codigo = @codigoRol");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@nombreRol", SqlDbType.VarChar);
            cmd.Parameters.Add("@activo", SqlDbType.TinyInt);
            cmd.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmd.Parameters["@nombreRol"].Value = nombreRol;
            cmd.Parameters["@activo"].Value = activo;
            cmd.Parameters["@codigoRol"].Value = codigoRol;

            try
            {
                cmd.Connection.Open();
                if (cmd.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo actualizar el rol en la base de datos" };
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return new String[2] { "Error", "No se pudo actualizar el rol en la base de datos" };
            }

            //Primero borro todas las antiguas funcionalidades del rol. Luego, agrego las nuevas
            SqlCommand cmdBorrar = new SqlCommand("DELETE FROM Funcionalidad_x_Rol WHERE Rol_Codigo = @codigoRol");
            cmdBorrar.Connection = DBconnection.getInstance();
            cmdBorrar.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmdBorrar.Parameters["@codigoRol"].Value = codigoRol;
         
            //Creo el comando necesario para agregar las nuevas funcionalidades
            SqlCommand cmdInsertar = new SqlCommand("INSERT INTO Funcionalidad_x_Rol (Rol_Codigo,Funcionalidad_Codigo) VALUES (@codigoRol,@codigoFuncionalidad)");
            cmdInsertar.Connection = DBconnection.getInstance();
            cmdInsertar.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmdInsertar.Parameters.Add("@codigoFuncionalidad", SqlDbType.Int);
            cmdInsertar.Parameters["@codigoRol"].Value = codigoRol;

            try
            {
                cmdInsertar.Connection.Open();

                //Ejecuto la query para borrar las viejas funcionalidades
                if (cmdBorrar.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudieron actualizar las funcionalidades del rol" };
               
                //Ejecuto la query para agregar las nuevas funcionalidades al rol
                foreach (Int32 codigoFuncionalidad in codigos)
                {
                    cmdInsertar.Parameters["@codigoFuncionalidad"].Value = codigoFuncionalidad;
                    if (cmdInsertar.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudieron actualizar las funcionalidades del rol" };
                }

                cmdInsertar.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdInsertar.Connection.Close();
                return new String[2] { "Error", "No se pudo actualizar alguna de las funcionalidades del rol en la base de datos" };
            }


            return new String[2] { "Ok", "Rol actualizado satisfactoriamente" };
        }

        public static DataTable buscarRoles()
        {
            DataTable dtRoles = new DataTable();

            //Creo el comando a ejecutar y sus parametros
            SqlCommand cmd2 = new SqlCommand("SELECT * FROM Rol R");
            cmd2.Connection = DBconnection.getInstance();

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

        public static String[] eliminarRol(Int32 codigoRol)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Rol SET Rol_Activo = 0 WHERE Rol_Codigo = @codigoRol");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmd.Parameters["@codigoRol"].Value = codigoRol;
          
            try
            {
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                return new String[2] { "Error", "No se pudo dar de baja el rol" };
            }

            return new String[2] { "Ok", "Rol dado de baja satisfactoriamente" };
        }

        public static List<Int32> obtenerFuncionalidadesDeRol(Int32 codigoRol)
        {
            List<Int32> funcionalidades = new List<Int32>();

            //Creo el comando a ejecutar y sus parametros
            SqlCommand cmd = new SqlCommand("SELECT Funcionalidad_Codigo FROM Funcionalidad_x_Rol WHERE Rol_Codigo = @codigoRol");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@codigoRol", SqlDbType.Int);
            cmd.Parameters["@codigoRol"].Value = codigoRol;

            SqlDataReader reader;

            try
            {

                cmd.Connection.Open();
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    funcionalidades.Add((Int32)reader["Funcionalidad_Codigo"]);
                }

                cmd.Connection.Close();

            }
            catch (Exception ex)
            {
                cmd.Connection.Close();
                throw ex;
            }

            return funcionalidades;

        }        

    }
}
