using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Entidades.Entidades;
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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            _serviciosProdutos = new ServiciosProductos();
        }
        private readonly ServiciosProductos _serviciosProdutos;
        private List<Producto> listaProd;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            try
            {
                listaProd = _serviciosProdutos.GetProductos();
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void MostrarDatosEnGrilla()
        {
            dgvDatos.Rows.Clear();
            foreach (var prod in listaProd)
            {
                DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, prod);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            //LblCantidad.Text = _servicios.GetCantidad().ToString();
            //lblPaginas1.Text = paginaActual.ToString();
            //lblPaginas2.Text = paginasTotales.ToString();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmProductosAE frm= new frmProductosAE(_serviciosProdutos);
            DialogResult dr=new DialogResult();
            frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }

        }
    }
}
