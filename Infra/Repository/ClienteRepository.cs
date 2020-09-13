using Domain.Entity;
using Domain.Interface.Repository;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Infra.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration)
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

        public void Add(Cliente cliente)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"INSERT INTO dbo.Cliente(Nome, CPF, DataNascimento)
                                    VALUES (@Nome, @CPF, @DataNascimento)";
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }

        public void Delete(int id)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"DELETE C 
                                    FROM dbo.Cliente C
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"SELECT  Id, 
                                            Nome,
                                            CPF,
                                            DataNascimento
                                    FROM dbo.Cliente";
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cliente c = new Cliente();
                    c.IdCliente = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    c.Nome = rdr.GetString(rdr.GetOrdinal("Nome"));
                    c.CPF = rdr.GetString(rdr.GetOrdinal("CPF"));
                    c.DataNascimento = rdr.GetDateTime(rdr.GetOrdinal("DataNascimento"));
                    clientes.Add(c);
                }
            }
            _baseConnection.Close();
            return clientes;
        }

        public Cliente GetCliente(int id)
        {
            Cliente cliente = new Cliente();
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"SELECT  Id, 
                                            Nome,
                                            CPF,
                                            DataNascimento
                                    FROM dbo.Cliente
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                var rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    cliente.IdCliente = rdr.GetInt32(rdr.GetOrdinal("Id"));
                    cliente.Nome = rdr.GetString(rdr.GetOrdinal("Nome"));
                    cliente.CPF = rdr.GetString(rdr.GetOrdinal("CPF"));
                    cliente.DataNascimento = rdr.GetDateTime(rdr.GetOrdinal("DataNascimento"));
                }
            }
            _baseConnection.Close();
            return cliente;
        }

        public void Update(int id, Cliente cliente)
        {
            _baseConnection.Open();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"UPDATE C
                                    SET C.Nome = @Nome,
                                        C.CPF = @CPF,
                                        C.DataNascimento = @DataNascimento
                                    FROM dbo.Cliente C
                                    WHERE Id = @Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Nome", cliente.Nome);
                cmd.Parameters.AddWithValue("@CPF", cliente.CPF);
                cmd.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento);
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }
    }
}
