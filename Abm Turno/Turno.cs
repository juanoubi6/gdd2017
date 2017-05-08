﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Transactions;
using System.Data.SqlClient;

namespace UberFrba.Abm_Turno
{
    public class Turno
    {
        public Int32 Codigo { get; set; }
        public Decimal HoraInicio { get; set; }
        public Decimal HoraFin { get; set; }
        public String Descripcion { get; set; }
        public Decimal ValorKm { get; set; }
        public Decimal PrecioBase { get; set; }
        public Byte Activo { get; set; }

        public static String validarHoras(String hora)
        {
            Decimal cantNumerica;
            if (String.IsNullOrEmpty(hora)) return "El campo no puede ser vacio";
            if (!Decimal.TryParse(hora, out cantNumerica)) return "El valor no es numérico";
            if (Decimal.Parse(hora) < 0 || Decimal.Parse(hora) > 23) return "El valor debe ser mayor a 0 y menor o igual a 23";
            if (hora.Length > 2) return "El valor ingresado es invalido";
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

        public static String[] grabarTurno(Turno turnoAGrabar)
        {

            //Creo el comando necesario para grabar el cliente en la tabla de clientes
            SqlCommand cmdTurno = new SqlCommand("sp_alta_turno");
            cmdTurno.CommandType = CommandType.StoredProcedure;
            cmdTurno.Connection = DBconnection.getInstance();
            cmdTurno.Parameters.Add("@horaInicio", SqlDbType.Decimal).Value = turnoAGrabar.HoraInicio;
            cmdTurno.Parameters.Add("@horaFin", SqlDbType.Decimal).Value = turnoAGrabar.HoraFin;
            cmdTurno.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = turnoAGrabar.Descripcion;
            cmdTurno.Parameters.Add("@valorKm", SqlDbType.Decimal).Value = turnoAGrabar.ValorKm;
            cmdTurno.Parameters.Add("@precioBase", SqlDbType.Decimal).Value = turnoAGrabar.PrecioBase;
            cmdTurno.Parameters.Add("@activo", SqlDbType.TinyInt).Value = turnoAGrabar.Activo;
            
            //Se realiza toda la creacion del cliente en el ambito de una transaccion
            try
            {
                cmdTurno.Connection.Open();
                //ver como ejecutar el SP
                cmdTurno.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdTurno.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Turno creado satisfactoriamente" };
        }

        public static DataTable buscarTurnos(String descripcionTurno)
        {
            DataTable dtTurnos = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = DBconnection.getInstance();
            String queryTurnos = "SELECT * FROM Turno WHERE 1=1";

            //Armo la query dinamica en base a los parametros de busqueda que me hayan llegado
            if (!String.IsNullOrEmpty(descripcionTurno))
            {
                queryTurnos = queryTurnos + " AND Turno_Descripcion LIKE '%' + @descripcionTurno + '%'";
                cmd.Parameters.Add("@descripcionTurno", SqlDbType.VarChar).Value = descripcionTurno;
            }


            cmd.CommandText = queryTurnos;
            SqlDataAdapter adapterTurnos = new SqlDataAdapter(cmd);

            try
            {
                adapterTurnos.Fill(dtTurnos);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtTurnos;
        }

        public static String[] eliminarTurno(Int32 codigoTurno)
        {
            //Creo el comando para dar de baja el turno
            SqlCommand cmdTurno = new SqlCommand("UPDATE Turno SET Turno_Activo = 0 WHERE Turno_Codigo = @codigoTurno");
            cmdTurno.Connection = DBconnection.getInstance();
            cmdTurno.Parameters.Add("@codigoTurno", SqlDbType.Int).Value = codigoTurno;

            try
            {
                cmdTurno.Connection.Open();
                if (cmdTurno.ExecuteNonQuery() == 0) return new String[2] { "Error", "No se pudo dar de baja el cliente" };
                cmdTurno.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdTurno.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Turno dado de baja satisfactoriamente" };
        }

        public static String[] modificarTurno(Turno turnoAModificar)
        {
            SqlCommand cmdTurno = new SqlCommand("sp_modificar_turno");
            cmdTurno.CommandType = CommandType.StoredProcedure;
            cmdTurno.Connection = DBconnection.getInstance();
            cmdTurno.Parameters.Add("@codigo", SqlDbType.Int).Value = turnoAModificar.Codigo;
            cmdTurno.Parameters.Add("@horaInicio", SqlDbType.Decimal).Value = turnoAModificar.HoraInicio;
            cmdTurno.Parameters.Add("@horaFin", SqlDbType.Decimal).Value = turnoAModificar.HoraFin;
            cmdTurno.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = turnoAModificar.Descripcion;
            cmdTurno.Parameters.Add("@valorKm", SqlDbType.Decimal).Value = turnoAModificar.ValorKm;
            cmdTurno.Parameters.Add("@precioBase", SqlDbType.Decimal).Value = turnoAModificar.PrecioBase;
            cmdTurno.Parameters.Add("@activo", SqlDbType.TinyInt).Value = turnoAModificar.Activo;

            try
            {
                cmdTurno.Connection.Open();
                //ejecuto el sp.
                cmdTurno.Connection.Close();
            }
            catch (Exception ex)
            {
                cmdTurno.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Turno actualizado satisfactoriamente" };
        }

    }
}
