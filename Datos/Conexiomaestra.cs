using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Alejandria.Datos
{
   public  class Conexiomaestra
    {
        public static SqlConnection conexion = new SqlConnection(@"Data source=DESKTOP-LF0SRT0\SQLEXPRESS; Initial Catalog= ADMINLICENCIAS; Integrated Security = true");
        public static void abrir()
        {
            if (conexion.State == ConnectionState.Closed )
            {
                conexion.Open();
            }
        }
        public static void cerrar()
        {
            if (conexion.State== ConnectionState.Open )
            {
                conexion.Close();
            }
        }

    }
}
