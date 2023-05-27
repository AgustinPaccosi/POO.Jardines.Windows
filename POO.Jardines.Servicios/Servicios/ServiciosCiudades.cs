using POO.Jardines.Servicios.Interfaces;
using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Datos.Repositorios;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Servicios
{
    public class ServiciosCiudades : IServiciosCiudades
    {
        private readonly IRepositorioCiudades _repositorioCiudades;
        private readonly IRepositorioPaises _repositorioPaises;
        public ServiciosCiudades()
        {
            _repositorioCiudades = new RepositorioCiudades();
            _repositorioPaises = new RepositorioPaises();   
        }
        public void Borrar(int CiudadId)
        {
            try
            {
                _repositorioCiudades.Borrar(CiudadId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Ciudad ciudad)
        {
            try
            {
                return _repositorioCiudades.Existe(ciudad);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> Filtrar(Pais pais)
        {
            try
            {
                var lista=_repositorioCiudades.Filtrar(pais);
                foreach (var item in lista)
                {
                    item.Pais = _repositorioPaises.GetPaisPorId(item.PaisId);
                }

                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidad()
        {
            try
            {
                return _repositorioCiudades.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int GetCantidadFiltrada(Pais pais)
        {
            try
            {
                return _repositorioCiudades.GetCantidadFiltrada(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> GetCiudades()
        {
            try
            {
                var lista= _repositorioCiudades.GetCiudades();
                foreach (var item in lista)
                {
                    item.Pais = _repositorioPaises.GetPaisPorId(item.PaisId); 
                }
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual)
        {
            try
            {
                var lista =_repositorioCiudades.GetCiudadesPorPagina(registrosPorPagina, paginaActual);
                foreach (var item in lista)
                {
                    item.Pais = _repositorioPaises.GetPaisPorId(item.PaisId);
                }
                return lista;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Ciudad ciudad)
        {
            try
            {
                if (ciudad.CiudadId==0)
                {
                    _repositorioCiudades.Agregar(ciudad);
                }
                else
                {
                    _repositorioCiudades.Editar(ciudad);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
