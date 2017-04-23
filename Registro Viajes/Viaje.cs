using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Registro_Viajes
{
    public class Viaje
    {
        public static String validarFechaHoraInicio(DateTime fechaHoraIni)
        {
            return "";
        }

        public static String validarFechaHoraFin(DateTime fechaHoraFin)
        {
            return "";
        }

        public static String validarCantKm(String cantidad)
        {
            int cantNumerica;
            if (String.IsNullOrEmpty(cantidad))             return "El valor no puede ser vacio";
            if (!int.TryParse(cantidad, out cantNumerica))  return "El valor no es numérico";
            if (Int32.Parse(cantidad) <= 0)                 return "El valor de los kilómetros debe ser mayor o igual a 0"; 
            return "";
        }

        public static String validarAuto(String auto)
        {
            if (String.IsNullOrEmpty(auto)) return "El valor no puede ser vacio";
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

        public static String validarCliente(String cliente)
        {
            if (String.IsNullOrEmpty(cliente)) return "El valor no puede ser vacio";
            return "";
        }
    }
}
