using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Rol
{
    public class Rol
    {

        public static String validarNombre(String nombre)
        {
            if (String.IsNullOrEmpty(nombre))   return "El campo no puede ser vacio";
            if (nombre.Length > 255)            return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarRol()
        {

            return "";
        }

    }
}
