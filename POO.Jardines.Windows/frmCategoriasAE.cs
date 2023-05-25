﻿using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POO.Jardines.Windows
{
    public partial class frmCategoriasAE : Form
    {
        public frmCategoriasAE()
        {
            InitializeComponent();
        }
        private Categoria categoria;
        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            if (categoria != null)
            {
                txtCategoria.Text = categoria.NombreCategoria;
                txtDescripcion.Text = categoria.Descrpcion;
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

                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            bool valido = true;
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                valido = false;
                errorProvider1.SetError(txtCategoria, "Debe Ingreasar un pais!");

            }
            return valido;
        }
        public Categoria GetCategoria()
        {
            return categoria;
        }

        //public void SetPais(Pais pais)
        //{
        //    this.categoria = categoria;
        //}
    }
}
