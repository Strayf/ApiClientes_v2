using Domain.Interface.Repository;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Infra.Repository
{
    public class BaseRepository<T> : IDisposable, IBaseRepository<T> where T : class
    {
        protected SqlConnection _baseConnection;

        public BaseRepository(IConfiguration configuration)
        {
            _baseConnection = new SqlConnection(configuration.GetConnectionString("BaseAPIContext"));
        }

        public void AddTest(T obj)
        {
            _baseConnection.Open();
            Type t = obj.GetType();
            var props = t.GetProperties();
            using (var cmd = _baseConnection.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO dbo.Teste(ID, Nome)
                    VALUES (@IdCliente, @Nome)
                ";
                foreach (var p in props)
                {
                    cmd.Parameters.AddWithValue(p.Name, p.GetValue(obj));
                }
                cmd.ExecuteNonQuery();
            }
            _baseConnection.Close();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T obj)
        {
            throw new NotImplementedException();
        }

        public void Update(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
