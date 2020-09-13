using Domain.Entity;
using Domain.Interface.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public int ConnectionTest()
        {
            int value = 0;
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"SELECT  ID, 
                                            Nome
                                    FROM dbo.Teste";
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    value = rdr.GetInt32(rdr.GetOrdinal("ID"));
                    string teste = rdr.GetString(rdr.GetOrdinal("Nome"));
                }
            }
            _baseConnection.Close();
            return value;
        }

        public void Add(Endereco endereco)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO dbo.Endereco(Logradouro, Estado, Cidade, Bairro)
                                    VALUES (@Logradouro, @Estado, @Cidade, @Bairro)";
                cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
                cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }

        public void Delete(int id)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"DELETE E 
                                    FROM dbo.Endereco E
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }

        public List<Endereco> GetAllEnderecos()
        {
            List<Endereco> enderecos = new List<Endereco>();
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"SELECT  Id, 
                                            Logradouro,
                                            Estado,
                                            Cidade,
                                            Bairro
                                    FROM dbo.Endereco";
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Endereco e = new Endereco();
                    e.IdEndereco = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    e.Logradouro = rdr.GetString(rdr.GetOrdinal("Logradouro"));
                    e.Estado = rdr.GetString(rdr.GetOrdinal("Estado"));
                    e.Cidade = rdr.GetString(rdr.GetOrdinal("Cidade"));
                    e.Bairro = rdr.GetString(rdr.GetOrdinal("Bairro"));
                    enderecos.Add(e);
                }
            }
            _baseConnection.Close();
            return enderecos;
        }

        public Endereco GetEndereco(int id)
        {
            Endereco endereco = new Endereco();
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"SELECT  Id, 
                                            Logradouro,
                                            Estado,
                                            Cidade,
                                            Bairro
                                    FROM dbo.Endereco
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    endereco.IdEndereco = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    endereco.Logradouro = rdr.GetString(rdr.GetOrdinal("Logradouro"));
                    endereco.Estado = rdr.GetString(rdr.GetOrdinal("Estado"));
                    endereco.Cidade = rdr.GetString(rdr.GetOrdinal("Cidade"));
                    endereco.Bairro = rdr.GetString(rdr.GetOrdinal("Bairro"));
                }
            }
            _baseConnection.Close();
            return endereco;
        }

        public void Update(int id, Endereco endereco)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"UPDATE E
                                    SET E.Logradouro = @Logradouro,
                                        E.Estado = @Estado,
                                        E.Cidade = @Cidade,
                                        E.Bairro = @Bairro
                                    FROM dbo.Endereco E
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Logradouro", endereco.Logradouro);
                cmd.Parameters.AddWithValue("@Estado", endereco.Estado);
                cmd.Parameters.AddWithValue("@Cidade", endereco.Cidade);
                cmd.Parameters.AddWithValue("@Bairro", endereco.Bairro);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }
    }
}
