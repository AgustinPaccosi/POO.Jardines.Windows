using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioCiudades
    {
        void Agregar(Ciudad ciudad);
        void Borrar(int CiudadId);
        Ciudad CiudadPorId(int ciudadId);
        void Editar(Ciudad ciudad);
        bool Existe(Ciudad ciudad);
        List<Ciudad> Filtrar(Pais pais);
        int GetCantidad();
        int GetCantidadFiltrada(Pais pais);
        List<Ciudad> GetCiudades();
        List<Ciudad> GetCiudades(int paisId);
        List<Ciudad> GetCiudadesPorPagina(int registrosPorPagina, int paginaActual);
    }
}
