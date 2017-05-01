using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

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

            SqlCommand cmd = new SqlCommand("SELECT * FROM Cliente WHERE Cliente_Telefono = @telefono");
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
            String queryClientes = "SELECT * FROM Cliente WHERE 1=1";

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
            SqlCommand cmdCliente = new SqlCommand("UPDATE Cliente SET Cliente_Activo = 0 WHERE Cliente_Telefono = @telefonoCliente");
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
                cmdCliente.Connection.Open();
                if (cmdCliente.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo dar de baja el cliente" };
                if (cmdUsuario.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo dar de baja el usuario asociado al cliente" };
                cmdCliente.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdCliente.Connection.Close();
                return new String[2] { "Error", "No se pudo dar de baja el cliente" };
            }

            return new String[2] { "Ok", "Cliente dado de baja satisfactoriamente" };
        }

        public static String[] grabarCliente(Cliente clienteAGrabar)
        {

            //Creo el comando necesario para grabar el cliente en la tabla de clientes
            SqlCommand cmdCliente = new SqlCommand("INSERT INTO Cliente (Cliente_Nombre,Cliente_Apellido,Cliente_Dni,Cliente_Mail,Cliente_Telefono,Cliente_Direccion,Cliente_Fecha_Nac,Cliente_Codigo_Postal,Cliente_Activo) values (@nombre,@apellido,@dni,@mail,@telefono,@direccion,@fechaNacimiento,@codigoPostal,@activo)");
            cmdCliente.Connection = DBconnection.getInstance();
            cmdCliente.Parameters.Add("@nombre", SqlDbType.VarChar);
            cmdCliente.Parameters.Add("@apellido", SqlDbType.VarChar);
            cmdCliente.Parameters.Add("@dni", SqlDbType.Decimal);
            cmdCliente.Parameters.Add("@mail", SqlDbType.VarChar);
            cmdCliente.Parameters.Add("@telefono", SqlDbType.Decimal);
            cmdCliente.Parameters.Add("@direccion", SqlDbType.VarChar);
            cmdCliente.Parameters.Add("@fechaNacimiento", SqlDbType.DateTime);
            cmdCliente.Parameters.Add("@codigoPostal", SqlDbType.Decimal);
            cmdCliente.Parameters.Add("@activo", SqlDbType.TinyInt);
            cmdCliente.Parameters["@nombre"].Value = clienteAGrabar.Nombre;
            cmdCliente.Parameters["@apellido"].Value = clienteAGrabar.Apellido;
            cmdCliente.Parameters["@dni"].Value = clienteAGrabar.Dni;
            cmdCliente.Parameters["@mail"].Value = clienteAGrabar.Mail ?? Convert.DBNull;
            cmdCliente.Parameters["@telefono"].Value = clienteAGrabar.Telefono; 
            cmdCliente.Parameters["@direccion"].Value = clienteAGrabar.Direccion;
            cmdCliente.Parameters["@fechaNacimiento"].Value = clienteAGrabar.FechaNacimiento;
            cmdCliente.Parameters["@codigoPostal"].Value = clienteAGrabar.CodigoPostal;
            cmdCliente.Parameters["@activo"].Value = clienteAGrabar.Activo;

            //Creo el comando necesario para crear el usuario asociado al cliente
            SqlCommand cmdUsuarioCliente = new SqlCommand("INSERT INTO Usuario(Usuario_Username,Usuario_Password,Usuario_Reintentos,Usuario_Activo) VALUES (@telefono,@dni,0,1)");
            cmdUsuarioCliente.Connection = DBconnection.getInstance();
            cmdUsuarioCliente.Parameters.Add("@telefono", SqlDbType.VarChar);
            cmdUsuarioCliente.Parameters.Add("@dni", SqlDbType.VarChar);
            cmdUsuarioCliente.Parameters["@telefono"].Value = clienteAGrabar.Telefono.ToString();
            cmdUsuarioCliente.Parameters["@dni"].Value = clienteAGrabar.Dni.ToString();


            //Creo el comando necesario para asignar el rol de "Cliente" al usuario del cliente
            SqlCommand cmdRolCliente = new SqlCommand("INSERT INTO Rol_x_Usuario(Usuario_Username,Rol_Codigo) values (@usuario,(SELECT Rol_Codigo FROM Rol WHERE Rol_Nombre = 'Cliente'))");
            cmdRolCliente.Connection = DBconnection.getInstance();
            cmdRolCliente.Parameters.Add("@usuario", SqlDbType.VarChar);
            cmdRolCliente.Parameters["@usuario"].Value = clienteAGrabar.Telefono.ToString();
            
            try
            {
                cmdCliente.Connection.Open();
                if (cmdCliente.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo grabar el cliente" };
                if (cmdUsuarioCliente.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo crear el usuario asociado para el cliente" };
                if (cmdRolCliente.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo asignar el rol de 'Cliente' al usuario del cliente" };
                cmdCliente.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdCliente.Connection.Close();
                return new String[2] { "Error", "No se pudo realizar la operacion de alta: " + ex.Message };
            }

            return new String[2] { "Ok", "Cliente creado satisfactoriamente. Puede hacer un Login como usuario utilizando su Telefono como Username y DNI como Password" };
        }


    }
}
