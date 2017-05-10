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

            SqlCommand cmd = new SqlCommand("SELECT * FROM Chofer WHERE Chofer_Dni = @dni");
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

            //Creo el comando necesario para grabar el cliente en la tabla de clientes
            SqlCommand cmdChofer = new SqlCommand("INSERT INTO Chofer (Chofer_Nombre,Chofer_Apellido,Chofer_Dni,Chofer_Mail,Chofer_Telefono,Chofer_Direccion,Chofer_Fecha_Nac,Chofer_Activo) values (@nombre,@apellido,@dni,@mail,@telefono,@direccion,@fechaNacimiento,@activo)");
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@nombre", SqlDbType.VarChar).Value = choferAGrabar.Nombre;
            cmdChofer.Parameters.Add("@apellido", SqlDbType.VarChar).Value = choferAGrabar.Apellido;
            cmdChofer.Parameters.Add("@dni", SqlDbType.Decimal).Value = choferAGrabar.Dni;
            cmdChofer.Parameters.Add("@mail", SqlDbType.VarChar).Value = choferAGrabar.Mail;
            cmdChofer.Parameters.Add("@telefono", SqlDbType.Decimal).Value = choferAGrabar.Telefono;
            cmdChofer.Parameters.Add("@direccion", SqlDbType.VarChar).Value = choferAGrabar.Direccion;
            cmdChofer.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = choferAGrabar.FechaNacimiento;
            cmdChofer.Parameters.Add("@activo", SqlDbType.TinyInt).Value = choferAGrabar.Activo;


            //Creo el comando necesario para crear el usuario asociado al cliente
            SqlCommand cmdUsuarioChofer = new SqlCommand("INSERT INTO Usuario(Usuario_Username,Usuario_Password,Usuario_Reintentos,Usuario_Activo) VALUES (@dni,@dniHash,0,1)");
            cmdUsuarioChofer.Connection = DBconnection.getInstance();
            cmdUsuarioChofer.Parameters.Add("@dni", SqlDbType.VarChar).Value = choferAGrabar.Dni.ToString();
            cmdUsuarioChofer.Parameters.Add("@dniHash", SqlDbType.VarChar).Value = LoginClass.GenerateSHA256String(choferAGrabar.Dni.ToString());


            //Creo el comando necesario para asignar el rol de "Chofer" al usuario del chofer
            SqlCommand cmdRolChofer = new SqlCommand("INSERT INTO Rol_x_Usuario(Usuario_Username,Rol_Codigo) values (@usuario,(SELECT Rol_Codigo FROM Rol WHERE Rol_Nombre = 'Chofer'))");
            cmdRolChofer.Connection = DBconnection.getInstance();
            cmdRolChofer.Parameters.Add("@usuario", SqlDbType.VarChar).Value = choferAGrabar.Dni.ToString();

            //Se realiza toda la creacion del chofer en el ambito de una transaccion
            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cmdChofer.Connection.Open();
                    if (cmdChofer.ExecuteNonQuery() == 0) throw new Exception("No se pudo grabar el cliente");
                    if (cmdUsuarioChofer.ExecuteNonQuery() == 0) throw new Exception("No se pudo crear el usuario asociado para el cliente");
                    if (cmdRolChofer.ExecuteNonQuery() == 0) throw new Exception("No se pudo asignar el rol de 'Cliente' al usuario del cliente");
                    scope.Complete();
                    cmdChofer.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                cmdChofer.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Chofer creado satisfactoriamente. Puede hacer un Login como usuario utilizando su DNI como Username y Password" };
        }

        public static DataTable buscarChoferes(String nombreChofer, String apellidoChofer, Decimal dniChofer)
        {
            DataTable dtChoferes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryChoferes = "SELECT * FROM Chofer WHERE 1=1";

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

        public static String[] modificarChofer(Chofer choferAModificar, Decimal dniPreModificacion)
        {

            //Creo el comando necesario para modificar el cliente
            SqlCommand cmdChofer = new SqlCommand("UPDATE Chofer SET Chofer_Nombre = @nombre, Chofer_Apellido = @apellido, Chofer_Dni = @dni, Chofer_Telefono = @telefono , Chofer_Mail = @mail , Chofer_Fecha_Nac = @fechaNacimiento, Chofer_Direccion = @direccion, Chofer_Activo = @activo WHERE Chofer_Dni = @dniPreModificacion");
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@nombre", SqlDbType.VarChar).Value = choferAModificar.Nombre;
            cmdChofer.Parameters.Add("@apellido", SqlDbType.VarChar).Value = choferAModificar.Apellido;
            cmdChofer.Parameters.Add("@dni", SqlDbType.Decimal).Value = choferAModificar.Dni;
            cmdChofer.Parameters.Add("@mail", SqlDbType.VarChar).Value = choferAModificar.Mail;
            cmdChofer.Parameters.Add("@telefono", SqlDbType.Decimal).Value = choferAModificar.Telefono;
            cmdChofer.Parameters.Add("@direccion", SqlDbType.VarChar).Value = choferAModificar.Direccion;
            cmdChofer.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = choferAModificar.FechaNacimiento;
            cmdChofer.Parameters.Add("@activo", SqlDbType.TinyInt).Value = choferAModificar.Activo;
            cmdChofer.Parameters.Add("@dniPreModificacion", SqlDbType.Decimal).Value = dniPreModificacion;

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

        public static String[] eliminarChofer(Decimal dniChofer)
        {

            //Creo el comando para dar de baja el chofer
            SqlCommand cmdChofer = new SqlCommand("UPDATE Chofer SET Chofer_Activo = 0 WHERE Chofer_Dni = @dniChofer");
            cmdChofer.Connection = DBconnection.getInstance();
            cmdChofer.Parameters.Add("@dniChofer", SqlDbType.Decimal).Value = dniChofer;

            //Creo el comando para dar de baja el usuario del chofer
            SqlCommand cmdUsuario = new SqlCommand("UPDATE Usuario SET Usuario_Activo = 0 WHERE Usuario_Username = @dniChofer");
            cmdUsuario.Connection = DBconnection.getInstance();
            cmdUsuario.Parameters.Add("@dniChofer", SqlDbType.VarChar).Value = dniChofer.ToString();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cmdChofer.Connection.Open();
                    if (cmdChofer.ExecuteNonQuery() == 0) throw new Exception("No se pudo dar de baja el chofer");
                    if (cmdUsuario.ExecuteNonQuery() == 0) throw new Exception("No se pudo dar de baja el usuario asociado al chofer");
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
    }
}
