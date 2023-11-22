using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alejandria.Logica
{
   public  class Llicencias
    {
        public int Id_licencia { get; set; }
        public string Serial_Pc { get; set; }
        public DateTime Fecha_de_finalizacion { get; set; }
        public string Estado { get; set; }
        public string Periodo { get; set; }
        public int Id_llave { get; set; }
        public string Fecha_de_solicitud { get; set; }
        public string Fecha_de_activacion { get; set; }
        public int Id_cliente { get; set; }
        public string Serial { get; set; }

    }
}
