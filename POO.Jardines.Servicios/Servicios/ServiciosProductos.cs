using POO.Jardines.Servicios.Interfaces;
using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Datos.Repositorios;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;

namespace POO.Jardines.Servicios.Servicios
{
    public class ServiciosProductos : IServiciosProductos
    {
        private readonly IRepositorioDeProductos _repositorioDeProductos;
        private readonly IRepositorioCategorias _serviciosCategoria;
        public ServiciosProductos()
        {
            _serviciosCategoria = new RepositorioCategorias();
            _repositorioDeProductos = new RepositorioDeProductos();

        }
        public List<Producto> GetProductos()
        {
            try
            {
                var listaProd = _repositorioDeProductos.GetProductos();
                return listaProd;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void Borrar(int productoId)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Producto producto)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public Producto GetClientePorId(int productoId)
        {
            throw new NotImplementedException();
        }


        public void Guardar(Producto producto)
        {
            throw new NotImplementedException();
        }
    }
}
