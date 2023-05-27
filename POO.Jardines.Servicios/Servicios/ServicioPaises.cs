using POO.Jardines.Servicios.Interfaces;
using POO.Jardines2023.Datos.Repositorios;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Servicios
{
    public class ServicioPaises : IServicioPaises
    {
        private readonly RepositorioPaises _repositorio;
        public ServicioPaises()
        {
            _repositorio = new RepositorioPaises();
        }
        public List<Pais> GetPaises()
        {
            try
            {
                return _repositorio.GetPaises();
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
                return _repositorio.GetCantidad();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int paisId)
        {
            try
            {
                _repositorio.Borrar(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool Existe(Pais pais)
        {
            try
            {
                return _repositorio.Existe(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Pais pais)
        {
            try
            {
                if (pais.PaisId == 0)
                {
                    _repositorio.Agregar(pais);
                }
                else
                {
                    _repositorio.Editar(pais);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Pais GetPaisPorId(int paisId)
        {
            try
            {
                return _repositorio.GetPaisPorId(paisId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Pais> Filtrar(Pais pais)
        {
            try
            {
                return _repositorio.FiltrarPais(pais);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual)
        {
            try
            {
                return _repositorio.GetPaisesPorPagina(cantidad, paginaActual);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public List<Pais> Filtrar(Pais pais)
        //{
        //    try
        //    {
        //        return _repositorio.Filtrar(pais);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
