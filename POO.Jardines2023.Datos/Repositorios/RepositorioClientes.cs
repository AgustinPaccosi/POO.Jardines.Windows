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

        public void Agregar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string InsertQuery = @"INSERT INTO dbo.Clientes (Nombres, Apellido, Direccion, CodigoPostal, PaisId, CiudadId, Email ) 
                                        VALUES (@Nombres, @Apellido, @Direccion, @CodigoPostal, @PaisId, @CiudadId, @Email ); SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(InsertQuery, conn))
                {
                    comando.Parameters.Add("@Nombres", SqlDbType.NVarChar);
                    comando.Parameters["@Nombres"].Value = cliente.Nombre;

                    comando.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    comando.Parameters["@Apellido"].Value = cliente.Apellido;
                    
                    comando.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    comando.Parameters["@Direccion"].Value = cliente.Direccion;

                    comando.Parameters.Add("@CodigoPostal", SqlDbType.NVarChar);
                    comando.Parameters["@CodigoPostal"].Value = cliente.CodigoPostal;

                    comando.Parameters.Add("@PaisId", SqlDbType.Int);
                    comando.Parameters["@PaisId"].Value = cliente.PaisId;

                    comando.Parameters.Add("@CiudadId", SqlDbType.NVarChar);
                    comando.Parameters["@CiudadId"].Value = cliente.CiudadId;

                    comando.Parameters.Add("@Email", SqlDbType.NVarChar);
                    comando.Parameters["@Email"].Value = cliente.Email;

                    //ciudad.CiudadId = (int)comando.ExecuteScalar();
                    int Id = Convert.ToInt32(comando.ExecuteScalar());
                    cliente.ClienteId = Id;
                }
            }
        }

        public void Borrar(int ClienteID)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM dbo.Clientes where ClienteId=@ClienteId";
                    using (var comando = new SqlCommand(deleteQuery, conn))
                    {
                        comando.Parameters.Add("@ClienteId", SqlDbType.Int);
                        comando.Parameters["@ClienteId"].Value = ClienteID;

                        comando.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }        }

        public void Editar(Cliente cliente)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string UpdateQuery = @"UPDATE dbo.Clientes SET Nombres=@Nombres, Apellido=@Apellido,
                            Direccion=@Direccion, CodigoPostal=@CodigoPostal, PaisId=@PaisId, CiudadId=@CiudadId, Email=@Email
                            WHERE ClienteId=@ClienteId";
                using (var cmd = new SqlCommand(UpdateQuery, conn))
                {
                    cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar);
                    cmd.Parameters["@Nombres"].Value = cliente.Nombre;

                    cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                    cmd.Parameters["@Apellido"].Value = cliente.Apellido;

                    cmd.Parameters.Add("@Direccion", SqlDbType.NVarChar);
                    cmd.Parameters["@Direccion"].Value = cliente.Direccion;

                    cmd.Parameters.Add("@CodigoPostal", SqlDbType.NVarChar);
                    cmd.Parameters["@CodigoPostal"].Value = cliente.CodigoPostal;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = cliente.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = cliente.CiudadId;

                    cmd.Parameters.Add("@Email", SqlDbType.NVarChar);
                    cmd.Parameters["@Email"].Value = cliente.Email;

                    cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                    cmd.Parameters["@ClienteId"].Value = cliente.ClienteId;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool Existe(Cliente cliente)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    String SelectQuery;
                    if (cliente.ClienteId == 0)
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Clientes WHERE Nombres=@Nombres AND Apellido=@Apellido";
                    }
                    else
                    {
                        SelectQuery = "SELECT COUNT(*) FROM dbo.Clientes WHERE Nombres=@Nombres AND Apellido=@Apellido AND ClienteId=@ClienteId";
                    }
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        cmd.Parameters.Add("@Nombres", SqlDbType.NVarChar);
                        cmd.Parameters["@Nombres"].Value = cliente.Nombre;

                        cmd.Parameters.Add("@Apellido", SqlDbType.NVarChar);
                        cmd.Parameters["@Apellido"].Value = cliente.Apellido;

                        if (cliente.ClienteId != 0)
                        {
                            cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                            cmd.Parameters["@ClienteId"].Value = cliente.ClienteId;
                        }
                        cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return cantidad > 0;
            }
            catch (Exception)
            {

                throw;
            }
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

        public List<Ciudad> GetClienteFiltrado(int paisId)
        {
            throw new NotImplementedException();
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

        public Cliente GetClientesPorId(int clienteId)
        {
            try
            {
                Cliente cliente = null; 
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    
                    conn.Open();
                    string SelectQuery = @"Select ClienteId, Nombres, Apellido, Direccion, CodigoPostal, PaisId, CiudadId, Email
                        FROM dbo.Clientes WHERE ClienteId=@ClienteId";
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        cmd.Parameters.Add("@ClienteId", SqlDbType.Int);
                        cmd.Parameters["@ClienteId"].Value = clienteId;

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                cliente = new Cliente()
                                {
                                    ClienteId =reader.GetInt32(0),
                                    Nombre=reader.GetString(1),
                                    Apellido=reader.GetString(2),
                                    Direccion=reader.GetString(3),
                                    CodigoPostal=reader.GetString(4),
                                    PaisId=reader.GetInt32(5),
                                    CiudadId=reader.GetInt32(6),
                                    Email=reader.GetString(7)
                                };
                            }
                        }
                    }
                }
                return cliente;
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
                NombrePais = reader.GetString(3),
                NombreCiudad = reader.GetString(4),
            };
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
                    string SelectQuery = @"SELECT C.ClienteId, C.Nombres, C.Apellido, P.NombrePais, S.NombreCiudad 
                            FROM Clientes C
                            INNER JOIN Paises P ON P.PaisId=C.PaisId
                            INNER JOIN Ciudades S ON S.CiudadId=C.CiudadId
                            order by C.Apellido, c.Nombres 
                            OFFSET @cantidadRegistros ROWS FETCH NEXT @cantidadPorPagina ROWS ONLY";
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

        public List<ClienteListDto> GetClientes(Pais paisFiltro, Ciudad ciudadFiltro)
        {
            List<ClienteListDto> listaclientesdto = new List<ClienteListDto>();
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string SelectQuery = @"SELECT C.ClienteId, C.Nombres, C.Apellido, P.NombrePais, S.NombreCiudad 
                        FROM Clientes C
                        INNER JOIN Paises P ON P.PaisId=C.PaisId
                        INNER JOIN Ciudades S ON S.CiudadId=C.CiudadId
                        WHERE C.PaisId=@PaisId AND C.CiudadId=@CiudadId
                        Order By Apellido, Nombres";
                using (var cmd = new SqlCommand(SelectQuery, conn))
                {
                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = paisFiltro.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = ciudadFiltro.CiudadId;

                    using (var reader = cmd.ExecuteReader())
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
    }
}
