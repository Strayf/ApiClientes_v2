using Domain.Entity;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;

namespace Domain.Service
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Add(Cliente cliente)
        {
            _clienteRepository.Add(cliente);
        }

        public void Delete(int id)
        {
            _clienteRepository.Delete(id);
        }

        public List<Cliente> GetAllClientes()
        {
            return _clienteRepository.GetAllClientes();
        }

        public Cliente GetCliente(int id)
        {
            return _clienteRepository.GetCliente(id);
        }

        public bool TesteService()
        {
            if (_clienteRepository.ConnectionTest() > 0)
                return true;
            return false;
        }

        public void Update(int id, Cliente cliente)
        {
            _clienteRepository.Update(id, cliente);
        }
    }
}
