using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Interfaces
{
    public interface IRepositorioClientes
    {
        int GetCantidad();
        List<ClienteListDto> GetClientes();
        List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
        void Agregar(Cliente cliente);
        void Borrar(int ClienteID);
        void Editar(Cliente cliente);
        bool Existe(Cliente cliente);
        List<Ciudad> GetClienteFiltrado(int paisId);
        Cliente GetClientesPorId(int clienteId);
    }
}
