using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberFrba.Abm_Turno
{
    public class Turno
    {

        public static String validarHoraInicio(DateTime horaIni)
        {
            return "";
        }

        public static String validarHoraFin(DateTime horaFin)
        {
            return "";
        }

        public static String validarDescripcion(String descripcion)
        {
            if (String.IsNullOrEmpty(descripcion))  return "El campo no puede ser vacio";
            if (descripcion.Length > 255)           return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarValorKm(String valor)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(valor))                return "El campo no puede ser vacio";
            if (!Decimal.TryParse(valor, out cantNumerica)) return "El valor no es numérico";
            if (Decimal.Parse(valor) <= 0)                  return "El valor de los kilómetros debe ser mayor a 0";
            if (valor.Length > 17)                          return "El valor ingresado es demasiado grande";
            return "";
        }

        public static String validarPrecioBase(String precioBase)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(precioBase))                   return "El campo no puede ser vacio";
            if (!Decimal.TryParse(precioBase, out cantNumerica))    return "El valor no es numérico";
            if (Decimal.Parse(precioBase) <= 0)                     return "El valor del precio base debe ser mayor a 0";
            if (precioBase.Length > 17)                             return "El valor ingresado es demasiado grande";
            return "";
        }

    }
}
