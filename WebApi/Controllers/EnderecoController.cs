using Domain.Entity;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web.Helper;

namespace Web.Controllers
{
    [Route("Endereco")]
    public class EnderecoController : ControllerBase
    {

        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        /// <summary>
        /// Buscar todos os endereços.
        /// </summary>
        /// <remarks>
        /// Retorna uma array com todos os endereços cadastrados.
        /// </remarks>
        [HttpGet("BuscarTodos")]
        public List<Endereco> Get()
        {
            return _enderecoService.GetAllEnderecos();
        }

        /// <summary>
        /// Buscar endereço pelo ID.
        /// </summary>
        /// <remarks>
        /// Retorna o endereço correspondente ao ID.
        /// </remarks>
        /// <param name="id">ID do endereço.</param>
        [HttpGet("BuscarPorId")]
        public Endereco Get(int id)
        {
            return _enderecoService.GetEndereco(id);
        }

        /// <summary>
        /// Atualizar endereço.
        /// </summary>
        /// <remarks>
        /// Atualiza endereço pelo ID com as informações fornecidas.
        /// </remarks>
        /// <param name="id">ID do cliente.</param>
        /// <param name="endereco">Objeto com informações do endereço.</param>
        [HttpPut("Atualizar")]
        public void Put(int id, Endereco endereco)
        {
            _enderecoService.Update(id, endereco);
        }

        /// <summary>
        /// Inserir endereço
        /// </summary>
        /// <remarks>
        /// Insere endereço com as informações fornecidas.
        /// </remarks>
        /// <param name="endereco">Objeto com informações do endereço.</param>
        [HttpPost("Inserir")]
        public void Post(Endereco endereco)
        {
            _enderecoService.Add(endereco);
        }

        /// <summary>
        /// Apagar endereço.
        /// </summary>
        /// <remarks>
        /// Apaga endereço correspondente ao ID fornecido.
        /// </remarks>
        /// <param name="id">ID do cliente.</param>
        [HttpDelete("Apagar")]
        public void Delete(int id)
        {
            _enderecoService.Delete(id);
        }
    }
}