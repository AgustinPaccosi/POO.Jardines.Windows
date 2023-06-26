using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System.Collections.Generic;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioClientes
    {
        void Agregar(Cliente cliente);
        void Borrar(int ClienteID);
        void Editar(Cliente cliente);
        bool Existe(Cliente cliente);
        int GetCantidad();
        Cliente GetClientesPorId(int clienteId);
        List<ClienteListDto> GetClientes();
        List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
        List<Ciudad> GetClienteFiltrado(int paisId);
        List<ClienteListDto> GetClientes(Pais paisFiltro, Ciudad ciudadFiltro);
    }
}
