using Domain.Entity;
using Domain.Helper;
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
            ValidaCliente(cliente);
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
            ValidaCliente(cliente);
            _clienteRepository.Update(id, cliente);
        }

        private void ValidaCliente(Cliente cliente)
        {
            Notification notif = new Notification();
            cliente.Validar(notif);

            if (notif.HasErrors())
            {
                throw new Exception("Erro(s) ao validar dados: " + notif.ListErrors());
            }
        }
    }
}
