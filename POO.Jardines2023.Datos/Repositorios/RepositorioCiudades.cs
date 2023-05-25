﻿using POO.Jardines2023.Datos.Interfaces;
using POO.Jardines2023.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace POO.Jardines2023.Datos.Repositorios
{
    public class RepositorioCiudades : IRepositorioCiudades
    {
        private readonly string cadenaConexion;
        public RepositorioCiudades()
        {
            cadenaConexion = ConfigurationManager.ConnectionStrings["MiConexion"].ToString();
        }

        public void Agregar(Ciudad ciudad)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string InsertQuery = "INSERT INTO dbo.Ciudades (NombreCiudad, PaisId) VALUES (@NombreCiudad, @PaisId); SELECT SCOPE_IDENTITY()";
                using (var comando = new SqlCommand(InsertQuery, conn))
                {
                    comando.Parameters.Add("@NombreCiudad", SqlDbType.NVarChar);
                    comando.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;

                    comando.Parameters.Add("@PaisId", SqlDbType.Int);
                    comando.Parameters["@PaisId"].Value = ciudad.PaisId;

                    //ciudad.CiudadId = (int)comando.ExecuteScalar();
                    int Id = Convert.ToInt32(comando.ExecuteScalar());
                    ciudad.CiudadId = Id;
                }
            }

        }
        public void Borrar(int CiudadId)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM dbo.Ciudades where CiudadId=@CiudadId";
                using (var comando = new SqlCommand(deleteQuery, conn))
                {
                    comando.Parameters.Add("@CiudadId", SqlDbType.Int);
                    comando.Parameters["@CiudadId"].Value = CiudadId;

                    comando.ExecuteNonQuery();
                }
            }
        }
        public void Editar(Ciudad ciudad)
        {
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string UpdateQuery = "UPDATE dbo.Ciudades SET NombreCiudad=@NombreCiudad, PaisId=@PaisId WHERE CiudadId=@CiudadId";
                using (var cmd = new SqlCommand(UpdateQuery, conn))
                {
                    cmd.Parameters.Add("@NombreCiudad", SqlDbType.NVarChar);
                    cmd.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = ciudad.PaisId;

                    cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                    cmd.Parameters["@CiudadId"].Value = ciudad.CiudadId;

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public bool Existe(Ciudad ciudad)
        {
            int cantidad;
            using (var conn = new SqlConnection(cadenaConexion))
            {
                conn.Open();
                String SelectQuery;
                if (ciudad.CiudadId == 0)
                {
                    SelectQuery = "SELECT COUNT(*) FROM dbo.Ciudades WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId";
                }
                else
                {
                    SelectQuery = "SELECT COUNT(*) FROM dbo.Ciudades WHERE NombreCiudad=@NombreCiudad AND PaisId=@PaisId AND CiudadId!=@CiudadId";
                }
                using (var cmd = new SqlCommand(SelectQuery, conn))
                {
                    cmd.Parameters.Add("@NombreCiudad", SqlDbType.NVarChar);
                    cmd.Parameters["@NombreCiudad"].Value = ciudad.NombreCiudad;

                    cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                    cmd.Parameters["@PaisId"].Value = ciudad.PaisId;

                    if (ciudad.CiudadId != 0)
                    {
                        cmd.Parameters.Add("@CiudadId", SqlDbType.Int);
                        cmd.Parameters["@CiudadId"].Value = ciudad.CiudadId;
                    }
                    cantidad =Convert.ToInt32( cmd.ExecuteScalar());
                }
            }
            return cantidad > 0;
        }

        public List<Ciudad> Filtrar(Pais pais)
        {
            List<Ciudad> listaFiltrada = new List<Ciudad>();
            try
            {
                using (var conn = new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = "SELECT CiudadId, NombreCiudad, PaisId FROM dbo.Ciudades WHERE PaisId=@PaisId ORDER BY PaisId, NombreCiudad ";
                    using (var cmd = new SqlCommand(SelectQuery, conn))
                    {
                        cmd.Parameters.Add("@PaisId", SqlDbType.Int);
                        cmd.Parameters["@PaisId"].Value = pais.PaisId;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = ConstruirCiudad(reader); 
                                listaFiltrada.Add(ciudad);
                            }
                        }
                    }
                }
                return listaFiltrada;
            }
            catch (Exception)
            {
                throw;
            }

        }

        private Ciudad ConstruirCiudad(SqlDataReader reader)
        {
            return new Ciudad()
            {
                CiudadId = reader.GetInt32(0),
                NombreCiudad = reader.GetString(1),
                PaisId = reader.GetInt32(2)
            };
        }

        public int GetCantidad()
        {
            int cantidad = 0;
            using (var conn=new SqlConnection(cadenaConexion))
            {
                conn.Open();
                string SelectQuery = "SELECT COUNT(*) FROM dbo.Ciudades";
                using (var cmd =new SqlCommand (SelectQuery,conn))
                {
                    cantidad = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return cantidad;
        }

        public List<Ciudad> GetCiudades()
        {
            List<Ciudad> listaciudad=new List<Ciudad>();
            try
            {
                using (var conn=new SqlConnection(cadenaConexion))
                {
                    conn.Open();
                    string SelectQuery = "SELECT CiudadId, NombreCiudad, PaisId FROM dbo.Ciudades ORDER BY PaisId, NombreCiudad";
                    using (var cmd=new SqlCommand(SelectQuery, conn))
                    {
                        using (var reader= cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var ciudad = new Ciudad()
                                {
                                    CiudadId = reader.GetInt32(0),
                                    NombreCiudad = reader.GetString(1),
                                    PaisId = reader.GetInt32(2)
                                };
                                listaciudad.Add(ciudad);
                            }
                        }
                    }
                }
                return listaciudad;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
