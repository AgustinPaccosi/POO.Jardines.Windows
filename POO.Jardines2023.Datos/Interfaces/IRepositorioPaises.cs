using POO.Jardines2023.Entidades.Entidades;
using System.Collections.Generic;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioPaises
    {
        void Agregar(Pais pais);
        void Borrar(int PaisId);
        void Editar(Pais pais);
        bool Existe(Pais pais);
        //int GetCantidad();
        int GetCantidad(string textoFiltro);

        List<Pais> GetPaises();
        Pais GetPaisPorId(int paisId);
        //List<Pais> FiltrarPais(Pais pais);
        List<Pais> GetPaises(string textoFiltro);

        List<Pais> GetPaisesPorPagina(int cantidad, int paginaActual, string textoFiltro);

    }
}