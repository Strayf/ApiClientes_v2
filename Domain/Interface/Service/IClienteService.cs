using Domain.Entity;
using System.Collections.Generic;

namespace Domain.Interface.Service
{
    public interface IClienteService : IBaseService<Cliente>
    {
        bool TesteService();
        void Add(Cliente cliente);
        Cliente GetCliente(int id);
        List<Cliente> GetAllClientes();
        void Update(int id, Cliente cliente);
        void Delete(int id);
    }
}
