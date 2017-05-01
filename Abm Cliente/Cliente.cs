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
                if (cmdUsuario.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo dar de baja el usuario" };
                cmdCliente.Connection.Close();
            }
            catch (Exception ex)
            {
                return new String[2] { "Error", "No se pudo dar de baja el cliente" };
            }

            return new String[2] { "Ok", "Cliente dado de baja satisfactoriamente" };
        }


    }
}
