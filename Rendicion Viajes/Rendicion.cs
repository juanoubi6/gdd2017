﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberFrba.Abm_Chofer;

namespace UberFrba.Rendicion_Viajes
{
    public class Rendicion
    {

        public DateTime Fecha { get; set; }
        public Decimal Chofer { get; set; }
        public Decimal Porcentaje { get; set; }
        public Decimal Turno { get; set; }

        public static DataTable traerViajesDeRendicion(Chofer choferElegido, DateTime fecha)
        {
            DataTable dtViajes = new DataTable();

            //Creo el comando a ejecutar
            SqlCommand cmd = new SqlCommand("SELECT Viaje_Codigo,Viaje_Cant_Kilometros,Viaje_Fecha_Hora_Inicio,Viaje_Fecha_Hora_Fin,Viaje_Chofer as Dni_Chofer_Viaje,Viaje_Auto,Turno_Descripcion,Turno_Valor_Kilometro,Turno_Precio_Base FROM SAPNU_PUAS.Viaje JOIN SAPNU_PUAS.Auto on Viaje_Auto = Auto_Patente JOIN SAPNU_PUAS.Turno on Viaje_Turno = Turno_Codigo WHERE Viaje_Chofer = @chofer AND Viaje_Turno = Auto_Turno AND CONVERT(date,Viaje_Fecha_Hora_Inicio) = @fecha");
            cmd.Connection = DBconnection.getInstance();
            cmd.Parameters.Add("@chofer", SqlDbType.Decimal).Value = choferElegido.Telefono;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = fecha.Date;

            SqlDataAdapter adapterViajes = new SqlDataAdapter(cmd);

            try
            {
                adapterViajes.Fill(dtViajes);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dtViajes;
        }


        public static String[] grabarRendicion(Rendicion nuevaRendicion)
        {
            //Creo el comando necesario para grabar la rendicion y sus viajes
            SqlCommand cmdRendicion = new SqlCommand("SAPNU_PUAS.sp_rendicion_viajes");
            cmdRendicion.CommandType = CommandType.StoredProcedure;
            cmdRendicion.Connection = DBconnection.getInstance();
            cmdRendicion.Parameters.Add("@chofer_telefono", SqlDbType.Decimal).Value = nuevaRendicion.Chofer;
            cmdRendicion.Parameters.Add("@fecha", SqlDbType.DateTime).Value = nuevaRendicion.Fecha;
            cmdRendicion.Parameters.Add("@turno_codigo", SqlDbType.Decimal).Value = nuevaRendicion.Turno;
            cmdRendicion.Parameters.Add("@porcentaje", SqlDbType.Decimal).Value = nuevaRendicion.Porcentaje;

            //Creo los parametros respuesta
            SqlParameter responseMsg = new SqlParameter();
            SqlParameter responseErr = new SqlParameter();
            responseMsg.ParameterName = "@resultado";
            responseErr.ParameterName = "@codOp";
            responseMsg.SqlDbType = System.Data.SqlDbType.VarChar;
            responseMsg.Direction = System.Data.ParameterDirection.Output;
            responseMsg.Size = 255;
            responseErr.SqlDbType = System.Data.SqlDbType.Int;
            responseErr.Direction = System.Data.ParameterDirection.Output;
            cmdRendicion.Parameters.Add(responseMsg);
            cmdRendicion.Parameters.Add(responseErr);

            try
            {
                cmdRendicion.Connection.Open();

                //Ejecuto el SP y veo el codigo de error
                cmdRendicion.ExecuteNonQuery();
                int codigoError = Convert.ToInt32(cmdRendicion.Parameters["@codOp"].Value);
                if (codigoError != 0) throw new Exception(cmdRendicion.Parameters["@resultado"].Value.ToString());

                cmdRendicion.Connection.Close();

            }
            catch (Exception ex)
            {
                cmdRendicion.Connection.Close();
                return new String[2] { "Error", ex.Message };
            }

            return new String[2] { "Ok", "Rendicion a chofer realizada satisfactoriamente" };
        }
    }
}
