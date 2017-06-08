using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;


namespace UberFrba.Abm_Chofer
{
    public class Chofer
    {

        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Mail { get; set; }
        public String Direccion { get; set; }
        public Decimal Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Decimal Dni { get; set; }
        public Byte Activo { get; set; }

        public static String validarFechaNac(DateTime fecha)
        {
            return "";
        }

        public static String validarNombre(String nombre)
        {
            if (String.IsNullOrEmpty(nombre)) return "El campo no puede ser vacio";
            if (nombre.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarApellido(String apellido)
        {
            if (String.IsNullOrEmpty(apellido)) return "El campo no puede ser vacio";
            if (apellido.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarDireccion(String direccion)
        {
            if (String.IsNullOrEmpty(direccion)) return "El campo no puede ser vacio";
            if (direccion.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarEmail(String email)
        {
            if (String.IsNullOrEmpty(email)) return "El campo no puede ser vacio";
            if (email.Length > 50) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarTelefono(String telefono)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(telefono))                 return "El campo no puede ser vacio";
            if (!Decimal.TryParse(telefono, out cantNumerica))  return "El valor no es numérico";
            if (Decimal.Parse(telefono) <= 0)                   return "El valor debe ser mayor a 0";
            if (telefono.Length > 18)                           return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarDni(String dni)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(dni)) return "El campo no puede ser vacio";
            if (!Decimal.TryParse(dni, out cantNumerica)) return "El valor no es numérico";
            if (Decimal.Parse(dni) <= 0) return "El valor debe ser mayor a 0";
            if (dni.Length > 18) return "El valor ingresado es demasiado grande";

            //Valido si el DNI del chofer ya existe en la base de datos
            DataTable dtChofer = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAPNU_PUAS.Chofer WHERE Chofer_Dni = @dni");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@dni", SqlDbType.Decimal).Value = Decimal.Parse(dni);

            SqlDataAdapter adapterChofer = new SqlDataAdapter(cmd);

            try
            {
                adapterChofer.Fill(dtChofer);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtChofer.Rows.Count > 0) return "Ya existe un chofer con el DNI ingresado";

            return "";

        }

        public static String[] grabarChofer(Chofer choferAGrabar)
        {

            //Creo el comando necesario para grabar el chofer en la tabla de choferes
            SqlCommand cmdChofer = new SqlCommand("SAPNU_PUAS.sp_chofer_alta");
            cmdChofer.CommandType = CommandType.StoredProcedure;
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@nombre", SqlDbType.VarChar).Value = choferAGrabar.Nombre;
            cmdChofer.Parameters.Add("@apellido", SqlDbType.VarChar).Value = choferAGrabar.Apellido;
            cmdChofer.Parameters.Add("@dni", SqlDbType.Decimal).Value = choferAGrabar.Dni;
            cmdChofer.Parameters.Add("@mail", SqlDbType.VarChar).Value = choferAGrabar.Mail;
            cmdChofer.Parameters.Add("@telefono", SqlDbType.Decimal).Value = choferAGrabar.Telefono;
            cmdChofer.Parameters.Add("@direccion", SqlDbType.VarChar).Value = choferAGrabar.Direccion;
            cmdChofer.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = choferAGrabar.FechaNacimiento;
            cmdChofer.Parameters.Add("@activo", SqlDbType.TinyInt).Value = choferAGrabar.Activo;

            //Creo los parametro respuesta
            SqlParameter responseMsg = new SqlParameter();
            SqlParameter responseErr = new SqlParameter();
            responseMsg.ParameterName = "@resultado";
            responseErr.ParameterName = "@codOp";
            responseMsg.SqlDbType = System.Data.SqlDbType.VarChar;
            responseMsg.Direction = System.Data.ParameterDirection.Output;
            responseMsg.Size = 255;
            responseErr.SqlDbType = System.Data.SqlDbType.Int;
            responseErr.Direction = System.Data.ParameterDirection.Output;
            cmdChofer.Parameters.Add(responseMsg);
            cmdChofer.Parameters.Add(responseErr);

            //Se realiza toda la creacion del chofer
            try
            {
                cmdChofer.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdChofer.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdChofer.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdChofer.Parameters["@resultado"].Value.ToString());

                cmdChofer.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdChofer.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }


            return new String[2] { "Ok", "Chofer creado satisfactoriamente. Puede hacer un Login como usuario utilizando su Telefono como Username y Password" };
        }

        public static DataTable buscarChoferes(String nombreChofer, String apellidoChofer, Decimal dniChofer)
        {
            DataTable dtChoferes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryChoferes = "SELECT * FROM SAPNU_PUAS.Chofer WHERE 1=1";

            //Armo la query dinamica en base a los parametros de busqueda que me hayan llegado
            if (!String.IsNullOrEmpty(nombreChofer))
            {
                queryChoferes = queryChoferes + " AND Chofer_Nombre LIKE '%' + @nombreChofer + '%'";
                cmd.Parameters.Add("@nombreChofer", SqlDbType.VarChar).Value = nombreChofer;
            }
            if (!String.IsNullOrEmpty(apellidoChofer))
            {
                queryChoferes = queryChoferes + " AND Chofer_Apellido LIKE '%' + @apellidoChofer + '%'";
                cmd.Parameters.Add("@apellidoChofer", SqlDbType.VarChar).Value = apellidoChofer;
            }
            if (dniChofer != 0)
            {
                queryChoferes = queryChoferes + " AND Chofer_Dni = @dniChofer";
                cmd.Parameters.Add("@dniChofer", SqlDbType.Decimal).Value = dniChofer;
            }

            cmd.CommandText = queryChoferes;
            SqlDataAdapter adapterChoferes = new SqlDataAdapter(cmd);

            try
            {
                adapterChoferes.Fill(dtChoferes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtChoferes;
        }

        public static DataTable buscarChoferPorPk(Decimal telefonoChofer)
        {
            DataTable dtChoferes = new DataTable();

            //Creo el comando a ejecutar para buscar un chofer en base a su telefono
            SqlCommand cmd = new SqlCommand("SELECT Chofer_Nombre,Chofer_Apellido,Chofer_Telefono FROM SAPNU_PUAS.Chofer WHERE Chofer_Telefono = @telefonoChofer");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@telefonoChofer", SqlDbType.Decimal).Value = telefonoChofer;
           
            SqlDataAdapter adapterChoferes = new SqlDataAdapter(cmd);

            try
            {
                adapterChoferes.Fill(dtChoferes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtChoferes;
        }

        public static DataTable buscarChoferesActivos(String nombreChofer, String apellidoChofer, Decimal dniChofer)
        {
            DataTable dtChoferes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryChoferes = "SELECT * FROM SAPNU_PUAS.Chofer WHERE Chofer_Activo = 1";

            //Armo la query dinamica en base a los parametros de busqueda que me hayan llegado
            if (!String.IsNullOrEmpty(nombreChofer))
            {
                queryChoferes = queryChoferes + " AND Chofer_Nombre LIKE '%' + @nombreChofer + '%'";
                cmd.Parameters.Add("@nombreChofer", SqlDbType.VarChar).Value = nombreChofer;
            }
            if (!String.IsNullOrEmpty(apellidoChofer))
            {
                queryChoferes = queryChoferes + " AND Chofer_Apellido LIKE '%' + @apellidoChofer + '%'";
                cmd.Parameters.Add("@apellidoChofer", SqlDbType.VarChar).Value = apellidoChofer;
            }
            if (dniChofer != 0)
            {
                queryChoferes = queryChoferes + " AND Chofer_Dni = @dniChofer";
                cmd.Parameters.Add("@dniChofer", SqlDbType.Decimal).Value = dniChofer;
            }

            cmd.CommandText = queryChoferes;
            SqlDataAdapter adapterChoferes = new SqlDataAdapter(cmd);

            try
            {
                adapterChoferes.Fill(dtChoferes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtChoferes;
        }

        public static String[] modificarChofer(Chofer choferAModificar, Decimal telefonoPreModificacion)
        {

            //Creo el comando necesario para modificar el chofer
            SqlCommand cmdChofer = new SqlCommand("UPDATE SAPNU_PUAS.Chofer SET Chofer_Nombre = @nombre, Chofer_Apellido = @apellido, Chofer_Dni = @dni, Chofer_Telefono = @telefono , Chofer_Mail = @mail , Chofer_Fecha_Nac = @fechaNacimiento, Chofer_Direccion = @direccion, Chofer_Activo = @activo WHERE Chofer_Telefono = @telefonoPreModificacion");
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@nombre", SqlDbType.VarChar).Value = choferAModificar.Nombre;
            cmdChofer.Parameters.Add("@apellido", SqlDbType.VarChar).Value = choferAModificar.Apellido;
            cmdChofer.Parameters.Add("@dni", SqlDbType.Decimal).Value = choferAModificar.Dni;
            cmdChofer.Parameters.Add("@mail", SqlDbType.VarChar).Value = choferAModificar.Mail;
            cmdChofer.Parameters.Add("@telefono", SqlDbType.Decimal).Value = choferAModificar.Telefono;
            cmdChofer.Parameters.Add("@direccion", SqlDbType.VarChar).Value = choferAModificar.Direccion;
            cmdChofer.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = choferAModificar.FechaNacimiento;
            cmdChofer.Parameters.Add("@activo", SqlDbType.TinyInt).Value = choferAModificar.Activo;
            cmdChofer.Parameters.Add("@telefonoPreModificacion", SqlDbType.Decimal).Value = telefonoPreModificacion;

            try
            {
                cmdChofer.Connection.Open();
                if (cmdChofer.ExecuteNonQuery() == 0) throw new Exception("No se pudieron actualizar los datos del chofer");
                cmdChofer.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdChofer.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Chofer actualizado satisfactoriamente" };
        }

        public static String[] eliminarChofer(Decimal telefonoChofer)
        {

            //Creo el comando para dar de baja el chofer
            SqlCommand cmdChofer = new SqlCommand("UPDATE SAPNU_PUAS.Chofer SET Chofer_Activo = 0 WHERE Chofer_Dni = @telefonoChofer");
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@telefonoChofer", SqlDbType.Decimal).Value = telefonoChofer;

            //Creo el comando para dar de baja el usuario del chofer
            SqlCommand cmdUsuario = new SqlCommand("UPDATE SAPNU_PUAS.Usuario SET Usuario_Activo = 0 WHERE Usuario_Username = @telefonoChofer");
            cmdUsuario.Connection = DBconnection.getInstance();
            cmdUsuario.Parameters.Add("@telefonoChofer", SqlDbType.VarChar).Value = telefonoChofer.ToString();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cmdChofer.Connection.Open();
                    cmdChofer.ExecuteNonQuery();
                    cmdUsuario.ExecuteNonQuery();
                    scope.Complete();
                    cmdChofer.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                cmdChofer.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Chofer dado de baja satisfactoriamente" };
        }

        public static DataTable buscarAutoActivo(Chofer choferElegido)
        {
            DataTable dtAutoBuscado = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT Auto_Patente FROM SAPNU_PUAS.Auto WHERE Auto_Chofer = @choferTelefono AND Auto_Activo = 1");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@choferTelefono", SqlDbType.Decimal).Value = choferElegido.Telefono;
            
            SqlDataAdapter adapterAutos = new SqlDataAdapter(cmd);

            try
            {
                adapterAutos.Fill(dtAutoBuscado);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtAutoBuscado.Rows.Count == 0) throw new Exception("No se encontró un auto activo para el chofer seleccionado");

            return dtAutoBuscado;
        
        }

        public static DataTable buscarTurnoActual(Chofer choferElegido)
        {
            DataTable dtDatosTurno = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT Auto_Turno AS Chofer_Turno, Turno_Descripcion,Turno_Hora_Inicio,Turno_Hora_Fin FROM SAPNU_PUAS.Chofer join SAPNU_PUAS.Auto ON Auto_Chofer = Chofer_Telefono join SAPNU_PUAS.Turno ON Auto_Turno = Turno_Codigo WHERE Chofer_Telefono = @choferTel AND Auto_Activo = 1");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@choferTel", SqlDbType.Decimal).Value = choferElegido.Telefono;
         
            SqlDataAdapter adapterChoferes = new SqlDataAdapter(cmd);

            try
            {
                adapterChoferes.Fill(dtDatosTurno);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtDatosTurno;
        }
    }
}
