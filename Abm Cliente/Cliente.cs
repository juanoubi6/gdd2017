using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Cliente
{
    public class Cliente
    {

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



    }
}
