using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace UberFrba.Abm_Cliente
{
    public class Cliente
    {

        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public String Mail { get; set; }
        public String Direccion { get; set; }
        public Decimal Telefono { get; set; }
        public Decimal CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public Decimal Dni { get; set; }
        public Byte Activo { get; set; }

        public static String validarFechaNac(DateTime fecha)
        {
            return "";
        }

        public static String validarNombre(String nombre)
        {
            if (String.IsNullOrEmpty(nombre))   return "El campo no puede ser vacio";
            if (nombre.Length > 255)            return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarApellido(String apellido)
        {
            if (String.IsNullOrEmpty(apellido)) return "El campo no puede ser vacio";
            if (apellido.Length > 255)          return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarDireccion(String direccion)
        {
            if (String.IsNullOrEmpty(direccion))    return "El campo no puede ser vacio";
            if (direccion.Length > 255)             return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarEmail(String email)
        {
            if (email.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarTelefono(String telefono)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(telefono))                 return "El campo no puede ser vacio";
            if (!Decimal.TryParse(telefono, out cantNumerica))  return "El valor no es numérico";
            if (Decimal.Parse(telefono) <= 0)                   return "El valor debe ser mayor a 0";
            if (telefono.Length > 18)                           return "El valor ingresado es demasiado grande";

            //Valido si el telefono del cliente ya existe en la base de datos
            DataTable dtCliente = new DataTable();

            SqlCommand cmd = new SqlCommand("SELECT * FROM SAPNU_PUAS.Cliente WHERE Cliente_Telefono = @telefono");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@telefono", SqlDbType.Decimal);
            cmd.Parameters["@telefono"].Value = Decimal.Parse(telefono);

            SqlDataAdapter adapterCliente = new SqlDataAdapter(cmd);

            try
            {
                adapterCliente.Fill(dtCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (dtCliente.Rows.Count > 0) return "El numero de telefono del cliente ingresado ya esta en uso";

            return "";
        }

        public static String validarDni(String dni)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(dni))                  return "El campo no puede ser vacio";
            if (!Decimal.TryParse(dni, out cantNumerica))   return "El valor no es numérico";
            if (Decimal.Parse(dni) <= 0)                    return "El valor debe ser mayor a 0";
            if (dni.Length > 18)                            return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarCodPostal(String codigo)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(codigo))                   return "El campo no puede ser vacio";
            if (!Decimal.TryParse(codigo, out cantNumerica))    return "El valor no es numérico";
            if (Decimal.Parse(codigo) <= 0)                     return "El valor debe ser mayor a 0";
            if (codigo.Length > 4)                              return "El valor ingresado es demasiado grande";
            return "";
        }

        public static DataTable buscarClientes(String nombreCliente, String apellidoCliente, Decimal dniCliente)
        {
            DataTable dtClientes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryClientes = "SELECT * FROM SAPNU_PUAS.Cliente WHERE 1=1";

            //Armo la query dinamica en base a los parametros de busqueda que me hayan llegado
            if (!String.IsNullOrEmpty(nombreCliente))
            {
                queryClientes = queryClientes + " AND Cliente_Nombre LIKE '%' + @nombreCliente + '%'";
                cmd.Parameters.Add("@nombreCliente", SqlDbType.VarChar);
                cmd.Parameters["@nombreCliente"].Value = nombreCliente;
            }
            if (!String.IsNullOrEmpty(apellidoCliente))
            {
                queryClientes = queryClientes + " AND Cliente_Apellido LIKE '%' + @apellidoCliente + '%'";
                cmd.Parameters.Add("@apellidoCliente", SqlDbType.VarChar);
                cmd.Parameters["@apellidoCliente"].Value = apellidoCliente;
            }
            if (dniCliente != 0)
            {
                queryClientes = queryClientes + " AND Cliente_Dni = @dniCliente";
                cmd.Parameters.Add("@dniCliente", SqlDbType.Decimal);
                cmd.Parameters["@dniCliente"].Value = dniCliente;
            }

            cmd.CommandText = queryClientes;
            SqlDataAdapter adapterClientes = new SqlDataAdapter(cmd);

            try
            {
                adapterClientes.Fill(dtClientes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtClientes;
        }

        public static String[] eliminarCliente(Decimal telefonoCliente)
        {
            //Creo el comando para dar de baja el cliente
            SqlCommand cmdCliente = new SqlCommand("UPDATE SAPNU_PUAS.Cliente SET Cliente_Activo = 0 WHERE Cliente_Telefono = @telefonoCliente");
            cmdCliente.Connection = DBconnection.getInstance();
            cmdCliente.Parameters.Add("@telefonoCliente", SqlDbType.Decimal);
            cmdCliente.Parameters["@telefonoCliente"].Value = telefonoCliente;

            //Creo el comando para dar de baja el usuario del cliente
            SqlCommand cmdUsuario = new SqlCommand("UPDATE Usuario SET Usuario_Activo = 0 WHERE Usuario_Username = @telefonoCliente");
            cmdUsuario.Connection = DBconnection.getInstance();
            cmdUsuario.Parameters.Add("@telefonoCliente", SqlDbType.VarChar);
            cmdUsuario.Parameters["@telefonoCliente"].Value = telefonoCliente.ToString();

            try
            {
                using (TransactionScope scope = new TransactionScope())
                {
                    cmdCliente.Connection.Open();
                    if (cmdCliente.ExecuteNonQuery() == 0) throw new Exception("No se pudo dar de baja el cliente");
                    if (cmdUsuario.ExecuteNonQuery() == 0) throw new Exception("No se pudo dar de baja el usuario asociado al cliente");
                    scope.Complete();
                    cmdCliente.Connection.Close();
                }
            }
            catch (Exception ex)
            {
                cmdCliente.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Cliente dado de baja satisfactoriamente" };
        }

        public static String[] grabarCliente(Cliente clienteAGrabar)
        {

            //Creo el comando necesario para grabar el cliente en la tabla de clientes
            SqlCommand cmdCliente = new SqlCommand("sp_cliente_alta");
            cmdCliente.CommandType = CommandType.StoredProcedure;
            cmdCliente.Connection = DBconnection.getInstance();
            cmdCliente.Parameters.Add("@nombre", SqlDbType.VarChar).Value = clienteAGrabar.Nombre;
            cmdCliente.Parameters.Add("@apellido", SqlDbType.VarChar).Value = clienteAGrabar.Apellido;
            cmdCliente.Parameters.Add("@dni", SqlDbType.Decimal).Value = clienteAGrabar.Dni;
            cmdCliente.Parameters.Add("@mail", SqlDbType.VarChar).Value = clienteAGrabar.Mail ?? Convert.DBNull;
            cmdCliente.Parameters.Add("@telefono", SqlDbType.Decimal).Value = clienteAGrabar.Telefono;
            cmdCliente.Parameters.Add("@direccion", SqlDbType.VarChar).Value = clienteAGrabar.Direccion;
            cmdCliente.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = clienteAGrabar.FechaNacimiento;
            cmdCliente.Parameters.Add("@codPostal", SqlDbType.Decimal).Value = clienteAGrabar.CodigoPostal;
            cmdCliente.Parameters.Add("@activo", SqlDbType.TinyInt).Value = clienteAGrabar.Activo;

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
            cmdCliente.Parameters.Add(responseMsg);
            cmdCliente.Parameters.Add(responseErr);

            //Se realiza toda la creacion del cliente
            try
            {
                cmdCliente.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdCliente.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdCliente.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdCliente.Parameters["@resultado"].Value.ToString());

                cmdCliente.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdCliente.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

        
            return new String[2] { "Ok", "Cliente creado satisfactoriamente. Puede hacer un Login como usuario utilizando su Telefono como Username y Password" };
        }

        public static String[] modificarCliente(Cliente clienteAModificar, Decimal telefonoAntiguo)
        {

            //Creo el comando necesario para modificar el cliente
            SqlCommand cmdCliente = new SqlCommand("UPDATE SAPNU_PUAS.Cliente SET Cliente_Nombre = @nombre, Cliente_Apellido = @apellido, Cliente_Dni = @dni, Cliente_Telefono = @telefono , Cliente_Mail = @mail , Cliente_Fecha_Nac = @fechaNacimiento, Cliente_Codigo_Postal = @codigoPostal, Cliente_Direccion = @direccion, Cliente_Activo = @activo WHERE Cliente_Telefono = @telefonoPreModificacion");
            cmdCliente.Connection = DBconnection.getInstance();
            cmdCliente.Parameters.Add("@nombre", SqlDbType.VarChar).Value = clienteAModificar.Nombre;
            cmdCliente.Parameters.Add("@apellido", SqlDbType.VarChar).Value = clienteAModificar.Apellido;
            cmdCliente.Parameters.Add("@dni", SqlDbType.Decimal).Value = clienteAModificar.Dni;
            cmdCliente.Parameters.Add("@mail", SqlDbType.VarChar).Value = clienteAModificar.Mail ?? Convert.DBNull;
            cmdCliente.Parameters.Add("@telefono", SqlDbType.Decimal).Value = clienteAModificar.Telefono;
            cmdCliente.Parameters.Add("@direccion", SqlDbType.VarChar).Value = clienteAModificar.Direccion;
            cmdCliente.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime).Value = clienteAModificar.FechaNacimiento;
            cmdCliente.Parameters.Add("@codigoPostal", SqlDbType.Decimal).Value = clienteAModificar.CodigoPostal;
            cmdCliente.Parameters.Add("@activo", SqlDbType.TinyInt).Value = clienteAModificar.Activo;
            cmdCliente.Parameters.Add("@telefonoPreModificacion", SqlDbType.Decimal).Value = telefonoAntiguo;

            try
            {
                cmdCliente.Connection.Open();
                if (cmdCliente.ExecuteNonQuery() == 0) throw new Exception ("No se pudieron actualizar los datos del cliente" );
                cmdCliente.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdCliente.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }           

            return new String[2] { "Ok", "Cliente actualizado satisfactoriamente" };
        }

    }
}
