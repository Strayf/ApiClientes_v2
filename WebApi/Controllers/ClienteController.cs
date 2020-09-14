using Domain.Entity;
using Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Web.Helper;

namespace Web.Controllers
{
    [ApiController]
    [Route("Cliente")]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        /// <summary>
        /// Buscar todos os clientes.
        /// </summary>
        /// <remarks>
        /// Retorna uma array com todos os clientes cadastrados.
        /// </remarks>
        [HttpGet("BuscarTodos")]
        public List<Cliente> Get()
        {
            return _clienteService.GetAllClientes();
        }

        /// <summary>
        /// Buscar cliente pelo ID.
        /// </summary>
        /// <remarks>
        /// Retorna o cliente correspondente ao ID.
        /// </remarks>
        /// <param name="id">ID do cliente.</param>
        [HttpGet("BuscarPorId")]
        public Cliente Get(int id)
        {
            return _clienteService.GetCliente(id);
        }

        /// <summary>
        /// Atualizar cliente.
        /// </summary>
        /// <remarks>
        /// Atualiza cliente pelo ID com as informações fornecidas.
        /// </remarks>
        /// <param name="id">ID do cliente.</param>
        /// <param name="cliente">Objeto com informações do cliente.</param>
        [HttpPut("Atualizar")]
        public void Put(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Update(id, cliente);
            }
            else
            {
                throw new Exception("Request Inválida.");
            }
        }

        /// <summary>
        /// Inserir cliente
        /// </summary>
        /// <remarks>
        /// Insere cliente com as informações fornecidas.
        /// </remarks>
        /// <param name="cliente">Objeto com informações do cliente.</param>
        [HttpPost("Inserir")]
        public void Post(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.Add(cliente);
            }
            else
            {
                throw new Exception("Request Inválida.");
            }
        }

        /// <summary>
        /// Apagar cliente.
        /// </summary>
        /// <remarks>
        /// Apaga cliente correspondente ao ID fornecido.
        /// </remarks>
        /// <param name="id">ID do cliente.</param>
        [HttpDelete("Apagar")]
        public void Delete(int id)
        {
            _clienteService.Delete(id);
        }
    }
}