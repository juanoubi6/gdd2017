using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Automovil
{
    public class Automovil
    {

        public static String validarModelo(String modelo)
        {
            if (String.IsNullOrEmpty(modelo)) return "El campo no puede ser vacio";
            if (modelo.Length > 255) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarPatente(String patente)
        {
            if (String.IsNullOrEmpty(patente)) return "El campo no puede ser vacio";
            if (patente.Length > 10) return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarChofer(String chofer)
        {
            if (String.IsNullOrEmpty(chofer)) return "El valor no puede ser vacio";
            return "";
        }

        public static String validarTurno(String turno)
        {
            if (String.IsNullOrEmpty(turno)) return "El valor no puede ser vacio";
            return "";
        }

    }
}
