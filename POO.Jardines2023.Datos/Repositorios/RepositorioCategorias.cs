using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
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
    public class RepositorioCategorias : IRepositorioCategorias
    {
        private readonly string cadenaConexion;
        public RepositorioCategorias()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }
        public void Agregar(Categoria categoria)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string InsertQuery = "INSERT INTO dbo.Categorias (NombreCategoria, Descripcion) VALUES (@NombreCategoria, @Descripcion); SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(InsertQuery, conn))
                {
                    comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;
                    comando.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                    comando.Parameters["@Descripcion"].Value = categoria.Descripcion;


                    //ciudad.CiudadId = (int)comando.ExecuteScalar();
                    int Id = Convert.ToInt32(comando.ExecuteScalar());
                    categoria.CategoriaId = Id;
                }
            }

        }

        public void Borrar(int CategoriaId)
        {
            try
            {
                using (var conn= new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string deleteQuery = "DELETE FROM dbo.Categorias WHERE CategoriaId=@CategoriaId";
                    using (var cmd= new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                        cmd.Parameters["@CategoriaId"].Value= CategoriaId;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Editar(Categoria categoria)
        {
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string UpdateQuery = "UPDATE dbo.Categorias SET Descripcion=@Descripcion, NombreCategoria=@NombreCategoria WHERE CategoriaId=@CategoriaId";
                    using (var cmd = new SqlCommand(UpdateQuery, conn))
                    {
                        cmd.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                        cmd.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;

                        cmd.Parameters.Add("@Descripcion", SqlDbType.NVarChar);
                        cmd.Parameters["@Descripcion"].Value = categoria.Descripcion;

                        cmd.Parameters.Add("@CategoriaId", SqlDbType.NVarChar);
                        cmd.Parameters["@CategoriaId"].Value = categoria.CategoriaId;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Existe(Categoria categoria)
        {
            try
            {
                var cantidad = 0;
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery;
                    SelectQuery = "SELECT COUNT(*) FROM dbo.Categorias WHERE NombreCategoria=@NombreCategoria";
                    using (var comando = new SqlCommand(SelectQuery, conn))
                    {
                        comando.Parameters.Add("@NombreCategoria", SqlDbType.NVarChar);
                        comando.Parameters["@NombreCategoria"].Value = categoria.NombreCategoria;
                        cantidad = (int)comando.ExecuteScalar();
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
            using (var conn=new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string CountQuery = "Select Count(*) FROM dbo.Categorias";
                using (var comando = new SqlCommand(CountQuery, conn))
                {
                    cantidad = (int)comando.ExecuteScalar();
                }

            }
            return cantidad;
        }

        public Categoria GetCategoriaPorId(int CategoriaId)
        {
            Categoria categoria = null;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string SelectQuery = "SELECT CategoriaId, NombreCategoria FROM dbo.Categoria WHERE CategoriaId=@CategoriaId";
                using (var cmd = new SqlCommand(SelectQuery, conn))
                {
                    cmd.Parameters.Add("@CategoriaId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaId"].Value = CategoriaId;
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            reader.Read();
                            categoria = new Categoria()
                            {
                                CategoriaId = reader.GetInt32(0),

                                NombreCategoria = reader.GetString(1)
                            };

                        }
                    }
                }
            }
            return categoria;

        }

        public List<Categoria> GetCategorias()
        {
            try
            {
                List<Categoria> listacat = new List<Categoria>();
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    var SelectQuery = "SELECT CategoriaId, NombreCategoria, Descripcion FROM dbo.Categorias";
                    using (var cmd=new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var categoria = new Categoria()
                                {
                                    CategoriaId = reader.GetInt32(0),
                                    NombreCategoria = reader.GetString(1),
                                    Descripcion = reader.GetString(2)
                                };
                                listacat.Add(categoria);
                            }
                        }
                    }
                    return listacat;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
