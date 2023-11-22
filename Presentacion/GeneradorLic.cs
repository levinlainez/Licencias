using Alejandria.Datos;
using Alejandria.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Alejandria.Presentacion
{
    public partial class GeneradorLic : UserControl
    {
        public GeneradorLic()
        {
            InitializeComponent();
        }
        int Id_llave;
        string software;
        string llave;
        DateTime fechaFin;
        DateTime fechaInicio = DateTime.Now;
        int idcliente;
        string serial_licencia;
        string miCarpeta;
        string rutaCompleta;
        private AES aes = new AES();
        private void GeneradorLic_Load(object sender, EventArgs e)
        {
           
        }

        private void lblSoftware_Click(object sender, EventArgs e)
        {
            PanelLlaves.Visible = true;
            PanelLlaves.Dock = DockStyle.Fill;
            PanelLlaves.BringToFront();
            dibujarSoftware();
        }
        private void dibujarSoftware()
        {
            PanelLlaves.Controls.Clear();
            DataTable dt = new DataTable();
            Dsoftware funcion = new Dsoftware();
            funcion.mostrar_software_todos(ref dt);
            foreach (DataRow rdr in dt.Rows)
            {
                Button b = new Button();
                Panel panelC1 = new Panel();

                b.Text = (rdr["Software"].ToString());
                b.Name = rdr["Id_llave"].ToString();
                b.Tag = rdr["Llave"].ToString();
                b.Dock = DockStyle.Fill;
                b.BackColor = Color.FromArgb(40, 40, 40);
                b.Font = new Font("Microsoft Sans Serif", 12);
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderSize = 0;
                b.ForeColor = Color.White;
                b.TextAlign = ContentAlignment.MiddleLeft;

                panelC1.Size = new Size(244, 58);
                panelC1.Controls.Add(b);
                PanelLlaves.Controls.Add(panelC1);
                b.Click += B_Click;

            }
        }
        private void B_Click(object sender, EventArgs e)
        {
            Id_llave = Convert.ToInt32(((Button)sender).Name);
            lblSoftware.Text = "Llave Seleccionada: " + ((Button)sender).Text;
            software = ((Button)sender).Text;
            llave = Bases.Desencriptar(((Button)sender).Tag.ToString());
            PanelLlaves.Visible = false;
        }

        private void btnnuevocliente_Click(object sender, EventArgs e)
        {
            PanelNuevoCliente.Visible = true;
            PanelNuevoCliente.Dock = DockStyle.Fill;
            PanelNuevoCliente.BringToFront();
            limpiarClientes();
        }
        private void limpiarClientes()
        {
            txtcorreo.Clear();
            txtcelular.Clear();
            txtnombrecliente.Clear();
        }

        private void GuardarRegistro_Click(object sender, EventArgs e)
        {
            Lclientes parametros = new Lclientes();
            DClientes funcion = new DClientes();
            parametros.celular = txtcelular.Text;
            parametros.correo = txtcorreo.Text;
            parametros.nombre = txtnombrecliente.Text;
            if (funcion.insertarClientes(parametros) == true)
            {
                PanelNuevoCliente.Visible = false;
                PanelNuevoCliente.Dock = DockStyle.None;

            }
        }

        private void VOLVERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PanelNuevoCliente.Visible = false;
        }

        private void txtbuscarcliente_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtbuscarcliente.Text))
            {
                buscarClientes();
            }
            else
            {
                ocultarDatalistadoClientes();
            }
        }
        private void ocultarDatalistadoClientes()
        {
            datalistadoClientes.Visible = false;
        }
        private void buscarClientes()
        {
            DataTable dt = new DataTable();
            DClientes funcion = new DClientes();
            funcion.buscarClientes(ref dt, txtbuscarcliente.Text);
            datalistadoClientes.DataSource = dt;
            datalistadoClientes.Visible = true;
            datalistadoClientes.Columns[1].Visible = false;
            datalistadoClientes.Columns[2].Width = 200;
            datalistadoClientes.Columns[3].Visible = false;
            datalistadoClientes.Location = new Point(Panel14.Location.X, Panel14.Location.Y);
            datalistadoClientes.Size = new Size(356, 103);

            datalistadoClientes.BringToFront();
        }

        private void btnCrearLicencias_Click(object sender, EventArgs e)
        {
            if (idcliente > 0)
            {
                if (!string.IsNullOrEmpty(txtRuta.Text))
                {
                    crearSerial();
                    crearXml();
                    GuardarXml(aes.Encrypt(serial_licencia, llave, int.Parse("256")));
                    insertarLicencia();

                }
                else
                {
                    MessageBox.Show("Seleccione una ruta");

                }
            }
            else
            {
                MessageBox.Show("Seleccione un cliente");
            }
        }
        private void insertarLicencia()
        {
            Llicencias parametros = new Llicencias();
            DLicencias funcion = new DLicencias();
            parametros.Serial_Pc = txtserialpc.Text;
            parametros.Fecha_de_finalizacion = (fechaFin);
            parametros.Estado = Bases.Encriptar("ACTIVA");
            parametros.Periodo = Bases.Encriptar(txtnumero.Value + " " + txtperiodo.Text);
            parametros.Id_llave = Id_llave;
            parametros.Fecha_de_solicitud = DateTime.Now.ToString();
            parametros.Fecha_de_activacion = Bases.Encriptar(DateTime.Today.ToString());
            parametros.Id_cliente = idcliente;
            parametros.Serial = Bases.EncriptarConLlave(serial_licencia, llave);
            if (funcion.Insertar_Licencias(parametros) == true)
            {
                MessageBox.Show("Licencia creada en: " + rutaCompleta);
            }

        }
        private void crearSerial()
        {
            serial_licencia = "|" + txtserialpc.Text + "|" + lblfechaVenc.Text + "|" + "PENDIENTE" + "|" + software + "|";
        }
        private void crearXml()
        {
            miCarpeta = "Licencias_" + software;
            if (Directory.Exists(txtRuta.Text + miCarpeta))
            {

            }
            else
            {
                Directory.CreateDirectory(txtRuta.Text + miCarpeta);
            }
            rutaCompleta = txtRuta.Text + miCarpeta + @"\Licencia_" + software + "_" + (DateTime.Now.Month) + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".xml";
            FileInfo fi = new FileInfo(rutaCompleta);
            StreamWriter sw = null;
            try
            {
                if (File.Exists(rutaCompleta) == false)
                {
                    sw = File.CreateText(rutaCompleta);
                    sw.WriteLine(txtFormatoXml.Text);
                    sw.Flush();
                    sw.Close();
                }
                else
                {
                    File.Delete(rutaCompleta);
                    sw.WriteLine(txtFormatoXml.Text);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception)
            {

            }
        }
        private void GuardarXml(Object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(rutaCompleta);
            XmlElement root = doc.DocumentElement;
            root.Attributes.Item(0).Value = dbcnString.ToString();
            XmlTextWriter writer = new XmlTextWriter(rutaCompleta, null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
        }

        private void datalistadoClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idcliente = Convert.ToInt32(datalistadoClientes.SelectedCells[1].Value);
            txtbuscarcliente.Text = datalistadoClientes.SelectedCells[2].Value.ToString();
            datalistadoClientes.Visible = false;
        }

        private void txtnumero_ValueChanged(object sender, EventArgs e)
        {
            periodos();
        }
        public void periodos()
        {

            try
            {
                if (txtperiodo.Text == "mes (es)")
                {
                    fechaFin = fechaInicio.Date.AddMonths((int)txtnumero.Value);
                }
                if (txtperiodo.Text == "año (s)")
                {
                    fechaFin = fechaInicio.Date.AddYears((int)txtnumero.Value);
                }
                if (txtperiodo.Text == "dia (s)")
                {
                    fechaFin = fechaInicio.Date.AddDays(Convert.ToDouble(txtnumero.Value));
                }
                lblfechaVenc.Text = fechaFin.ToString("dd/MM/yyyy");

            }
            catch (Exception ex)
            {
            }
        }

        private void txtperiodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            periodos();
        }

        private void btnnuevaRuta_Click(object sender, EventArgs e)
        {
            Obtener_ruta();
        }
        public void Obtener_ruta()
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtRuta.Text = folderBrowserDialog1.SelectedPath;

            }

        }
    }
}
