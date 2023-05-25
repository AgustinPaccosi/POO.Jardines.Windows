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
    public class ServiciosCategorias : ServiciosCategoria
    {
        private readonly IRepositorioCategorias _repositorioCategorias;
        public ServiciosCategorias()
        {
            _repositorioCategorias = new RepositorioCategorias();
        }
        public void Borrar(int CategoriaId)
        {
            try
            {
                _repositorioCategorias.Borrar(CategoriaId);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Existe(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public int GetCantidad()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> GetCategorias()
        {
            try
            {
                var lista= _repositorioCategorias.GetCategorias();
                return lista;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Guardar(Categoria categoria)
        {
            throw new NotImplementedException();
        }
    }
}
