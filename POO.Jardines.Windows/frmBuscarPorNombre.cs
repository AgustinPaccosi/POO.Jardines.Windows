﻿using System;
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
    public partial class frmBuscarPorNombre : Form
    {
        public frmBuscarPorNombre()
        {
            InitializeComponent();
        }
        private string textoFiltro;
        public string GetTexto()
        {
            return textoFiltro;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            textoFiltro=txtFiltro.Text;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
