using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines.Servicios.Interfaces
{
    public interface IServiciosClientes
    {
        int GetCantidad();
        List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual);
        List<ClienteListDto> GetClientes();
        void Guardar(Cliente cliente);
        void Borrar(int ClienteId);
        bool Existe(Cliente cliente);
        Cliente GetClientePorId(int clienteId);
    }
}
