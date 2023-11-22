using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alejandria.Logica;
using Alejandria.Datos;
namespace Alejandria.Presentacion
{
    public partial class Verlicencias : UserControl
    {
        public Verlicencias()
        {
            InitializeComponent();
        }
        int estado = 0;
        int idlicencia;
        private void btnLicActivas_Click(object sender, EventArgs e)
        {
            estado = 1;
            Cambiar_a_licencias_activas();
            Cambiar_a_licencias_vencidas();
            mostrarLicActivas();
            desencryptar_datagridview();
        }
        public void desencryptar_datagridview()
        {
            foreach (DataGridViewRow row in datalistado.Rows)
            {
                string Estado = Bases.Desencriptar(Convert.ToString(row.Cells["Estado"].Value));
                string Periodo = Bases.Desencriptar(Convert.ToString(row.Cells["Periodo"].Value));

                if (Periodo.Contains("?"))
                {
                    Periodo = Periodo.Replace("?", "ñ");

                }

                row.Cells["Estado"].Value = Estado;
                row.Cells["Periodo"].Value = Periodo;


            }

        }
        private void Cambiar_a_licencias_activas()
        {
            var funcion = new DLicencias();
            funcion.Cambiar_a_licencias_activas();

        }
        private void Cambiar_a_licencias_vencidas()
        {
            var funcion = new DLicencias();
            funcion.Cambiar_a_licencias_vencidas();

        }
        private void mostrarLicActivas()
        {
            var funcion = new DLicencias();
            var dt = new DataTable();
            funcion.mostrar_licencias_activas(ref dt);
            datalistado.DataSource = dt;
            datalistado.Columns[1].Visible = false;
            Bases.diseñodgoscuro(ref datalistado);
        }
        private void mostrarLicVencidas()
        {
            var funcion = new DLicencias();
            var dt = new DataTable();
            funcion.mostrar_licencias_vencidas(ref dt);
            datalistado.DataSource = dt;
            datalistado.Columns[1].Visible = false;
            Bases.diseñodgoscuro(ref datalistado);
        }

        private void btnLicVencidas_Click(object sender, EventArgs e)
        {
            estado = 2;
            Cambiar_a_licencias_activas();
            Cambiar_a_licencias_vencidas();
            mostrarLicVencidas();
            desencryptar_datagridview();
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            eliminarLicencia();
            if (estado == 1)
            {
                mostrarLicActivas();
                desencryptar_datagridview();
            }
            else if (estado == 2)
            {
                mostrarLicVencidas();
                desencryptar_datagridview();
            }
        }
        private void eliminarLicencia()
        {
            var funcion = new DLicencias();
            var parametros = new Llicencias();
            parametros.Id_licencia = idlicencia;
            funcion.eliminarLicencia(parametros);
        }

        private void datalistado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idlicencia = Convert.ToInt32(datalistado.SelectedCells[1].Value);
            }
            catch (Exception)
            {


            }
        }
    }
}
