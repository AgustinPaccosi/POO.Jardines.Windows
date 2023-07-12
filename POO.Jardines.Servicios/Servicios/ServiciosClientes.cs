using POO.Jardines.Servicios.Interfaces;
using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Datos.Repositorios;
using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
		private readonly IRepositorioClientes _repositorioClientes;
        private readonly IRepositorioPaises _repositorioPaises;
        private readonly IRepositorioCiudades _repositorioCiudades;

        public ServiciosClientes()
        {
            _repositorioClientes = new RepositorioClientes();
            _repositorioPaises= new RepositorioPaises();
            _repositorioCiudades= new RepositorioCiudades();
        }

        public int GetCantidad()
        {
            try
            {
                var cantidad = _repositorioClientes.GetCantidad();
                return cantidad;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual)
        {
            try
            {
                var listaclienteporpagina = _repositorioClientes.GetClientesPorPagina(registrosPorPagina, paginaActual);
                //foreach (var item in listaclienteporpagina)
                //{
                //    var pais = _repositorioPaises.GetPaisPorId(item.PaisId);
                //    item.NombrePais = pais.NombrePais;
                //}
                //foreach (var item in listaclienteporpagina)
                //{
                //    var ciudad = _repositorioCiudades.CiudadPorId(item.CiudadId);
                //    item.NombreCiudad=ciudad.NombreCiudad;
                //}
                return listaclienteporpagina;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> GetClientes()
        {
			try
			{
                var listaclientes=_repositorioClientes.GetClientes();
                //foreach (var item in listaclientes)
                //{
                //    //Proxima Inner Join
                //    var pais = _repositorioPaises.GetPaisPorId(item.PaisId);
                //    item.NombrePais = pais.NombrePais;
                //}
                //foreach (var item in listaclientes)
                //{
                //    var ciudad = _repositorioCiudades.CiudadPorId(item.CiudadId);
                //    item.NombreCiudad = ciudad.NombreCiudad;
                //}
                return listaclientes;
            }
			catch (Exception)
			{

				throw;
			}
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    _repositorioClientes.Agregar(cliente);
                }
                else
                {
                    _repositorioClientes.Editar(cliente);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Borrar(int ClienteId)
        {
            try
            {
                _repositorioClientes.Borrar(ClienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                return _repositorioClientes.Existe(cliente);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Cliente GetClientePorId(int clienteId)
        {
            try
            {
                return _repositorioClientes.GetClientesPorId(clienteId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ClienteListDto> GetClientes(Pais paisFiltro, Ciudad ciudadFiltro)
        {
            try
            {
                return _repositorioClientes.GetClientes(paisFiltro, ciudadFiltro);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
