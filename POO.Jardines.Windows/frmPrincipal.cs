using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPaises_Click(object sender, EventArgs e)
        {
            frmPaises frm=new frmPaises();
            frm.ShowDialog(this);
        }

        private void btnCiudades_Click(object sender, EventArgs e)
        {
            frmCiudades frm=new frmCiudades();
            frm.ShowDialog(this);
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias frm=new frmCategorias();
            frm.ShowDialog(this);
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.ShowDialog(this);

        }

        private void btnProduc_Click(object sender, EventArgs e)
        {
            frmProductos frm=new frmProductos();
            frm.ShowDialog(this);
        }
    }
}
