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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
                                    Descrpcion = reader.GetString(2)
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
