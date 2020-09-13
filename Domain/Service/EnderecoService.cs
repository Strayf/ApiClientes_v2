using Domain.Entity;
using Domain.Interface.Repository;
using Domain.Interface.Service;
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
            _enderecoRepository.Update(id, endereco);
        }
    }
}
