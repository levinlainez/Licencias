using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Alejandria.Datos;
using Alejandria.Logica;
namespace Alejandria.Presentacion
{
    public partial class VisorLlaves : UserControl
    {
        public VisorLlaves()
        {
            InitializeComponent();
        }
        int idsoftware;
        private void btnagregar_Click(object sender, EventArgs e)
        {
            txtSoftware.Clear();
            txtLlave.Clear();
            PanelPrincipal.Enabled = false;
            panelNuevaLlave.Visible = true;
            panelNuevaLlave.Location = new Point((Width - panelNuevaLlave.Width) / 2, (Height - panelNuevaLlave.Height) / 2);

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            OcultarPaneles();
        }
        private void OcultarPaneles()
        {
            panelNuevaLlave.Visible = false;
            PanelPrincipal.Enabled = true;
        }

        private void btnguardar_Click(object sender, EventArgs e)
        {
            InsertarLlaves();
        }
        private void InsertarLlaves()
        {
            if (!string.IsNullOrEmpty(txtSoftware.Text))
            {
                if (!string.IsNullOrEmpty(txtLlave.Text))
                {
                    var funcion = new Dllaves();
                    var parametros = new Lllaves();
                    parametros.Software = txtSoftware.Text;
                    parametros.Llave = txtLlave.Text;
                    funcion.Insertar_Llaves(parametros);
                    OcultarPaneles();
                    txtbuscar.Clear();
                    dibujarLlaves();
                }
                else
                {
                    MessageBox.Show("Agrega la llave", "Llave");

                }
            }
            else
            {
                MessageBox.Show("Agrega el software para el cual crearas la Llave", "Software");
            }
        }
        public void dibujarLlaves()
        {
            FlowLayoutPanel1.Controls.Clear();
            try
            {
                var funcion = new Dsoftware();
                var dt = new DataTable();
                funcion.mostrarsoftware(ref dt, txtbuscar.Text);
                foreach (DataRow rdr in dt.Rows)
                {

                    Button b = new Button();
                    Panel panelC1 = new Panel();
                    Panel panelLATERAL = new Panel();

                    b.Text = (rdr["Software"].ToString());
                    b.Name = rdr["Id_software"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.ForeColor = Color.White;
                    b.TextAlign = ContentAlignment.MiddleCenter;

                    panelC1.Size = new System.Drawing.Size(244, 80);
                    panelC1.Name = rdr["Id_software"].ToString();

                    panelLATERAL.Size = new System.Drawing.Size(3, 58);
                    panelLATERAL.Dock = DockStyle.Left;
                    panelLATERAL.BackColor = Color.Transparent;
                    panelLATERAL.Name = rdr["Id_software"].ToString();
                    panelC1.Controls.Add(b);
                    panelC1.Controls.Add(panelLATERAL);
                    panelC1.BackColor = Color.FromArgb(20, 20, 20);
                    FlowLayoutPanel1.Controls.Add(panelC1);

                    b.BringToFront();
                    panelLATERAL.SendToBack();

                    b.Click += B_Click;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void B_Click(object sender, EventArgs e)
        {
            try
            {
                idsoftware = Convert.ToInt32(((Button)sender).Name);
            }
            catch (Exception)
            {

               
            }
            foreach (Control panelC2 in FlowLayoutPanel1.Controls)
            {
                if (panelC2 is Panel)
                {
                    foreach (Control panelLATERAL2 in panelC2.Controls)
                    {
                        if (panelLATERAL2 is Panel)
                        {
                            panelLATERAL2.BackColor = Color.Transparent;
                            panelC2.BackColor = Color.FromArgb(20, 20, 20);
                            break;
                        }
                    }
                }
            }
            string IdsoftwareName = ((Button)sender).Name;
            foreach (Control panelC1 in FlowLayoutPanel1.Controls)
            {
                if (panelC1 is Panel)
                {
                    foreach (Control panelLATERAL in panelC1.Controls)
                    {
                        if (panelLATERAL is Panel)
                        {
                            if (panelLATERAL.Name == IdsoftwareName)
                            {
                                panelLATERAL.BackColor = Color.OrangeRed;
                                panelC1.BackColor = Color.FromArgb(43, 43, 43);
                                break;
                            }
                        }
                    }
                }
            }

        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            dibujarLlaves();
        }

        private void VisorLlaves_Load(object sender, EventArgs e)
        {
            dibujarLlaves();
            PanelPrincipal.Dock = DockStyle.Fill;
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarSoftware();
        }
        private void EliminarSoftware()
        {
            var funcion = new Dsoftware();
            var parametros = new LSoftware();
            parametros.Id_software = idsoftware;
            funcion.eliminar_software(parametros);
            dibujarLlaves();
        }

    }
}
