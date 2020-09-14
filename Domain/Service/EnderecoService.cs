using Domain.Entity;
using Domain.Helper;
using Domain.Interface.Repository;
using Domain.Interface.Service;
using System;
using System.Collections.Generic;

namespace Domain.Service
{
    public class EnderecoService : BaseService<Endereco>, IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
            : base(enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Add(Endereco endereco)
        {
            ValidaEndereco(endereco);
            _enderecoRepository.Add(endereco);
        }

        public void Delete(int id)
        {
            _enderecoRepository.Delete(id);
        }

        public List<Endereco> GetAllEnderecos()
        {
            return _enderecoRepository.GetAllEnderecos();
        }

        public Endereco GetEndereco(int id)
        {
            return _enderecoRepository.GetEndereco(id);
        }

        public void Update(int id, Endereco endereco)
        {
            ValidaEndereco(endereco);
            _enderecoRepository.Update(id, endereco);
        }

        private void ValidaEndereco(Endereco endereco)
        {
            Notification notif = new Notification();
            endereco.Validar(notif);

            if (notif.HasErrors())
            {
                throw new Exception("Erro(s) ao validar dados: " + notif.ListErrors());
            }
        }
    }
}
