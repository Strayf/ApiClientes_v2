using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IEnderecoRepository : IBaseRepository<Endereco>
    {
        int ConnectionTest();
        void Add(Endereco endereco);
        Endereco GetEndereco(int id);
        List<Endereco> GetAllEnderecos();
        void Update(int id, Endereco endereco);
        void Delete(int id);
    }
}
