using POO.Jardines.Servicios.Interfaces;
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
    public partial class frmProductosAE : Form
    {
        private readonly IServiciosProductos _serviciosProductos;
        private Producto producto;
        private bool esEdicion=false;
        public frmProductosAE(IServiciosProductos serviciosProductos)
        {
            InitializeComponent();
            _serviciosProductos= serviciosProductos;
        }
        private void frmProductosAE_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboCategoria(ref cboCategorias);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (producto == null)
                {
                    producto = new Producto();
                }
                producto.NombreProducto = txtProducto.Text;
                producto.NombreLatin = txtLatin.Text;
                producto.UnidadesEnStock = int.Parse(textStock.Text);
                producto.NivelDeReposicion = int.Parse(txtReposicion.Text);
                producto.Categoria = (Categoria) cboCategorias.SelectedItem;
                producto.CategoriaId = (int)cboCategorias.SelectedValue;
                if (!_serviciosProductos.Existe(producto))
                {
                    _serviciosProductos.Guardar(producto);
                    if (!esEdicion)
                    {
                        MessageBox.Show("Registro Agregado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult dr = MessageBox.Show("Desea Agregar Otro Registro?", "Pregunta",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                        if (dr == DialogResult.No)
                        {
                            DialogResult = DialogResult.Cancel; ;
                        }
                        producto = null;

                    }
                    else
                    {
                        MessageBox.Show("Registro Editado", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }

                }
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProducto.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProducto, "Ingrese Un Producto");
            }
            if (string.IsNullOrEmpty(txtLatin.Text))
            {
                valido = false;
                errorProvider1.SetError(txtLatin, "Ingrese Un Latin");
            }
            int nro = 0;
            if (string.IsNullOrEmpty(txtReposicion.Text) || !int.TryParse(txtReposicion.Text, out nro))
            {
                valido = false;
                errorProvider1.SetError(txtReposicion, "Ingrese la Reposicion, SOLO ENTEROS");
            }
            if (string.IsNullOrEmpty(textStock.Text) || !int.TryParse(txtReposicion.Text, out nro))
            {
                valido = false;
                errorProvider1.SetError(textStock, "Ingrese El Stock, SOLO NUMEROS");
            }
            if (cboCategorias.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboCategorias, "Seleccionar Una Categoria");
            }
            return valido;

        }

    }
}
