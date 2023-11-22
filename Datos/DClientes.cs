using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alejandria.Logica;
namespace Alejandria.Datos
{
   public  class DClientes
    {
        public bool insertarClientes (Lclientes parametros)
        {
			try
			{
				Conexiomaestra.abrir();
				SqlCommand cmd = new SqlCommand("insertar_Clientes", Conexiomaestra.conexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@Cliente", parametros.nombre);
				cmd.Parameters.AddWithValue("@Correo", parametros.correo);
				cmd.Parameters.AddWithValue("@Celular", parametros.celular);
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
		public void buscarClientes(ref DataTable dt, string buscador)
		{
			try
			{
				Conexiomaestra.abrir();
				SqlDataAdapter da = new SqlDataAdapter("buscar_cliente_Form", Conexiomaestra.conexion);
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
    }
}
