using Alejandria.Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alejandria.Datos
{
  public  class DLicencias
    {
        public bool Insertar_Licencias(Llicencias parametros)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_lic", Conexiomaestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Serial_Licencia", parametros.Serial_Pc);
                cmd.Parameters.AddWithValue("@Fecha_de_finalizacion", parametros.Fecha_de_finalizacion);
                cmd.Parameters.AddWithValue("@Estado", parametros.Estado);
                cmd.Parameters.AddWithValue("@Periodo", parametros.Periodo);
                cmd.Parameters.AddWithValue("@Id_llave", parametros.Id_llave);
                cmd.Parameters.AddWithValue("@Fecha_de_solicitud", parametros.Fecha_de_solicitud);
                cmd.Parameters.AddWithValue("@Fecha_de_activacion", parametros.Fecha_de_activacion);
                cmd.Parameters.AddWithValue("@Id_cliente", parametros.Id_cliente);
                cmd.Parameters.AddWithValue("@Serial", parametros.Serial);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiomaestra.cerrar();
            }
        }
        public void mostrar_licencias_activas(ref DataTable dt)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Licencias_activas", Conexiomaestra.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Estado", Bases.Encriptar("ACTIVA"));
                da.Fill(dt);
                Conexiomaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public void mostrar_licencias_vencidas(ref DataTable dt)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("Licencias_vencidas", Conexiomaestra.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Estado", Bases.Encriptar("VENCIDA"));
                da.Fill(dt);
                Conexiomaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public bool Cambiar_a_licencias_vencidas()
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("Cambiar_a_licencias_vencidas", Conexiomaestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Estado", Bases.Encriptar("VENCIDA"));

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiomaestra.cerrar();
            }
        }
        public bool Cambiar_a_licencias_activas()
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("Cambiar_a_licencias_activas", Conexiomaestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Estado", Bases.Encriptar("ACTIVA"));

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiomaestra.cerrar();
            }
        }
        public bool eliminarLicencia(Llicencias parametros)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("eliminarLicencia", Conexiomaestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdLicencia", parametros.Id_licencia);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Conexiomaestra.cerrar();
            }
        }
    }
}
