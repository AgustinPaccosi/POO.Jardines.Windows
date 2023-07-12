using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmCategoriasAE : Form
    {
        private readonly IServiciosCategoria _servicioCategoria;

        public frmCategoriasAE(IServiciosCategoria servicioCategoria)
        {
            InitializeComponent();
            _servicioCategoria = servicioCategoria;
        }
        private Categoria categoria;
        private bool esEdicion=false;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descripcion;
                esEdicion=true;
            }
        }
        public static implicit operator frmCategoriasAE(frmPaisAE v)
        {
            throw new NotImplementedException();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (categoria == null)
                {
                    categoria = new Categoria();
                }
                
                categoria.NombreCategoria = txtCategoria.Text;
                categoria.Descripcion = txtDescripcion.Text;

                //DialogResult = DialogResult.OK;
                try
                {
                    if (!_servicioCategoria.Existe(categoria))
                    {
                        _servicioCategoria.Guardar(categoria);

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
                            categoria = null;
                            InicializarControles();
                        }
                        else
                        {
                            MessageBox.Show("Registro Editado", "Mensaje",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DialogResult = DialogResult.OK;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Registro Existente", "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void InicializarControles()
        {
            txtCategoria.Clear();
            txtDescripcion.Clear();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text) )
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Debe Ingreasar un pais!");
                

            }
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe Ingreasar Una Descripcion");
            }
            return valido;
        }
        public Categoria GetCategoria()
        {
            return categoria;
        }

        internal void SetCategoria(Categoria categoria)
        {
            this.categoria= categoria;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
