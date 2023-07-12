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
        private readonly IRepositorioCategorias _repositorioCategoria;
        public ServiciosProductos()
        {
            _repositorioCategoria = new RepositorioCategorias();
            _repositorioDeProductos = new RepositorioDeProductos();

        }
        public List<Producto> GetProductos()
        {
            try
            {
                var listaProd = _repositorioDeProductos.GetProductos();
                foreach (var item in listaProd)
                {
                    var categoria = _repositorioCategoria.GetCategoriaPorId(item.CategoriaId);
                    //item.Categoria = categoria.NombreCategoria;
                }

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
            try
            {
                return _repositorioDeProductos.Existe(producto);
            }
            catch (Exception)
            {

                throw;
            }
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
            try
            {
                if (producto.ProductoId == 0)
                {
                    _repositorioDeProductos.Agregar(producto);
                }
                else
                {
                    //_repositorioDeProductos.Editar(producto);
                    return;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
