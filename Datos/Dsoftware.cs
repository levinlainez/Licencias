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
  public   class Dsoftware
    {
        public void mostrarsoftware(ref DataTable dt,string buscador)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_software", Conexiomaestra.conexion);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@letra", buscador);
                da.Fill(dt);
                Conexiomaestra.cerrar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.StackTrace);
            }
        }
        public void mostrar_software_todos(ref DataTable dt)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlDataAdapter da = new SqlDataAdapter("mostrar_software_todos", Conexiomaestra.conexion);
                da.Fill(dt);
                Conexiomaestra.cerrar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }
        public bool eliminar_software(LSoftware parametros)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("eliminar_software", Conexiomaestra.conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idsoftware", parametros.Id_software);
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
