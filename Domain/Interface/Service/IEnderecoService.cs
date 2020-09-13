using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface IEnderecoService : IBaseService<Endereco>
    {
        void Add(Endereco cliente);
        Endereco GetEndereco(int id);
        List<Endereco> GetAllEnderecos();
        void Update(int id, Endereco cliente);
        void Delete(int id);
    }
}
