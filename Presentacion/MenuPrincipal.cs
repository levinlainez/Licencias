using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Alejandria.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Dock = DockStyle.Fill;
            panelVisor.Dock = DockStyle.Fill;
        }

        private void btnllaves_Click(object sender, EventArgs e)
        {
            lblBienvenida.Visible = false;
            panelVisor.Controls.Clear();
            VisorLlaves frm = new VisorLlaves();
            frm.Dock = DockStyle.Fill;
            panelVisor.Controls.Add(frm);
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblBienvenida.Visible = false;
            panelVisor.Controls.Clear();
            var frm = new GeneradorLic();
            frm.Dock = DockStyle.Fill;
            panelVisor.Controls.Add(frm);
            frm.Show();
        }

        private void btnverlicencias_Click(object sender, EventArgs e)
        {
            lblBienvenida.Visible = false;
            panelVisor.Controls.Clear();
            var frm = new Verlicencias();
            frm.Dock = DockStyle.Fill;
            panelVisor.Controls.Add(frm);
            frm.Show();
        }
    }
}
