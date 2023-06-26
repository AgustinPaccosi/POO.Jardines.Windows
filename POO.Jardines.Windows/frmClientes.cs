using POO.Jardines.Servicios.Interfaces;
using POO.Jardines.Servicios.Servicios;
using POO.Jardines.Windows.Helpers;
using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            _serviciosClientes = new ServiciosClientes();
        }

        int paginaActual = 1;
        int registros = 0;
        int paginasTotales = 0;
        int registrosPorPagina = 10;


        List<ClienteListDto> listaClienteDto=new List<ClienteListDto>();
        private readonly IServiciosClientes _serviciosClientes;
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                //listaClienteDto = _serviciosClientes.GetClientes();
                RecargarGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void RecargarGrilla()
        {
            try
            {
                registros = _serviciosClientes.GetCantidad();
                paginasTotales = FormHelper.CalcularPaginas(registros, registrosPorPagina);
                listaClienteDto = _serviciosClientes.GetClientesPorPagina(registrosPorPagina, paginaActual);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var cliente in listaClienteDto)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, cliente);
                GridHelper.AgregarFila(dgvDatos, r);
            }
            LblCantidad.Text = _serviciosClientes.GetCantidad().ToString();
            lblPaginas1.Text = paginaActual.ToString();
            lblPaginas2.Text = paginasTotales.ToString();

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            frmClientesAE frm = new frmClientesAE(_serviciosClientes);
            DialogResult dr= frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                RecargarGrilla();
                return;
            }
            
            //try
            //{
            //    Cliente cliente = frm.GetCliente();
            //    if (!_serviciosClientes.Existe(cliente))
            //    {
            //        _serviciosClientes.Guardar(cliente);
            //        var r = GridHelper.ConstruirFila(dgvDatos);
            //        GridHelper.SetearFila(r, cliente);
            //        GridHelper.AgregarFila(dgvDatos, r);
            //        RecargarGrilla();
            //        //corregir
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

        }
        private void btnPrincipio_Click(object sender, EventArgs e)
        {
            paginaActual = 1;
            MostrarPaginado();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual == 1)
            {
                return;
            }
            paginaActual--;
            MostrarPaginado();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (paginaActual == paginasTotales)
            {
                return;
            }
            paginaActual++;
            MostrarPaginado();

        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            paginaActual = paginasTotales;
            MostrarPaginado();

        }
        private void MostrarPaginado()
        {
            listaClienteDto = _serviciosClientes.GetClientesPorPagina(registrosPorPagina, paginaActual);
            RecargarGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ClienteListDto clienteDto = (ClienteListDto)r.Tag;
            ClienteListDto clienteCopiaDto = (ClienteListDto)clienteDto.Clone();
            try
            {
                Cliente cliente = _serviciosClientes.GetClientePorId(clienteDto.ClienteId);
                frmClientesAE frm = new frmClientesAE(_serviciosClientes) { Text = "Editar Cliente" };
                frm.SetCliente(cliente);

                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    RecargarGrilla();
                    return;
                }
                cliente = frm.GetCliente();
                GridHelper.SetearFila(r, cliente);
                RecargarGrilla();
            }
            catch (Exception ex)
            {
                GridHelper.SetearFila(r, clienteCopiaDto);
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            ClienteListDto cliente = (ClienteListDto)r.Tag;
            try
            {
                DialogResult dr = MessageBox.Show("Desea borrar el registro Seleccionado?",
                "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                _serviciosClientes.Borrar(cliente.ClienteId);
                GridHelper.Quitarfila(dgvDatos, r);
                RecargarGrilla();
                MessageBox.Show("Registro Borrado", "Mensaje",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private Pais paisFiltro;
        private Ciudad ciudadFiltro;
        private void porPaisYCiudadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBuscaPaisCiudad frm = new frmBuscaPaisCiudad() {Text="Seleccione Pais Y Ciudad" };
            DialogResult dr= frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            try
            {
                paisFiltro = frm.GetPais();
                ciudadFiltro = frm.GetCiudad();
                listaClienteDto = _serviciosClientes.GetClientes(paisFiltro, ciudadFiltro);
                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
