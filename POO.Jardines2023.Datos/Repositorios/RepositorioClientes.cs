using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
using POO.Jardines2023.Entidades.Entidades.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Jardines2023.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioClientes
    {
		private string cadenaConexion;
        public RepositorioClientes()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string SelectQuery = "SELECT COUNT(*) FROM dbo.Clientes";
                using (var cmd = new SqlCommand(SelectQuery, conn))
                {
                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public List<ClienteListDto> GetClientes()
        {
			try
			{
                List<ClienteListDto> listaclientesdto=new List<ClienteListDto>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = "Select ClienteId, Nombres, Apellido, PaisId, CiudadId FROM dbo.Clientes Order By Apellido, Nombres";
                    using (var cmd=new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader=cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var clienteDto = ConstruirClienteDto(reader);
                                listaclientesdto.Add(clienteDto);
                            }
                        }
                    }
                }
                return listaclientesdto;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public List<ClienteListDto> GetClientesPorPagina(int registrosPorPagina, int paginaActual)
        {
            List<ClienteListDto> listaclientes = new List<ClienteListDto>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    //string SelectQuery = "SELECT CiudadId, NombreCiudad, PaisId FROM dbo.Ciudades ORDER BY PaisId, NombreCiudad OFFSET @cantidadRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    string SelectQuery = "SELECT ClienteId, Nombres, Apellido, PaisId, CiudadId FROM dbo.clientes order by Apellido, Nombres OFFSET @cantidadRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        comando.Parameters.Add("@cantidadRegistros", SqlDbType.Int);
                        comando.Parameters["@cantidadRegistros"].Value = registrosPorPagina * (paginaActual - 1);

                        comando.Parameters.Add("@cantidadPorPagina", SqlDbType.Int);
                        comando.Parameters["@cantidadPorPagina"].Value = registrosPorPagina;

                        using (var reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var cliente = ConstruirClienteDto(reader);
                                listaclientes.Add(cliente);
                            }
                        }
                    }
                }
                return listaclientes;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private ClienteListDto ConstruirClienteDto(SqlDataReader reader)
        {
            return new ClienteListDto()
            {
                ClienteId = reader.GetInt32(0),
                Nombre = reader.GetString(1),
                Apellido = reader.GetString(2),
                PaisId = reader.GetInt32(3),
                CiudadId = reader.GetInt32(4),
            };
        }
    }
}
