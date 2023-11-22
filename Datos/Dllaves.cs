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
    public class Dllaves
    {
        public bool Insertar_Llaves(Lllaves parametros)
        {
            try
            {
                Conexiomaestra.abrir();
                SqlCommand cmd = new SqlCommand("Insertar_llave", Conexiomaestra.conexion );
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Software", parametros.Software);
                cmd.Parameters.AddWithValue("@Llave", parametros.Llave);
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
