using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface.Repository
{
    public interface IClienteRepository : IBaseRepository<Cliente>
    {
        int ConnectionTest();
        void Add(Cliente cliente);
        Cliente GetCliente(int id);
        List<Cliente> GetAllClientes();
        void Update(int id, Cliente cliente);
        void Delete(int id);
    }
}
