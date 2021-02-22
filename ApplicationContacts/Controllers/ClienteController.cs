using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationContacts.API.Helpers;
using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain.DTOs;
using ApplicationContacts.Infrastructure.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApplicationContacts.API.Controllers
{
    /// <summary>
    /// API Responsável pelas requisições voltadas aos clientes
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService ClienteService;
        private readonly IMapper Mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            ClienteService = clienteService;
            Mapper = mapper;
        }

        /// <summary>
        /// Retorna os clientes baseado na paginação atual
        /// </summary>
        /// <param name="pageParams"></param>
        /// <returns></returns>
        // GET :api/<ClienteController>?pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PageParams pageParams)
        {
            var clientes = await ClienteService.GetClientesByPageParams(pageParams);
            var clientesDTO = Mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            Response.AddPagination(clientes.CurrentPage, clientes.TotalPages, clientes.PageSize, clientes.TotalCount);
            return Ok(clientesDTO);
        }

        /// <summary>
        /// Retorna todos os clientes cadastrados
        /// </summary>
        /// <returns></returns>
        [HttpGet("todos-usuarios")]
        public async Task<IActionResult> GetAsync()
        {
            var clientes = await ClienteService.GetClientes();
            var clientesDTO = Mapper.Map<IEnumerable<ClienteDTO>>(clientes);
            return Ok(clientesDTO);
        }

        /// <summary>
        /// Retorna um cliente especificado pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var cliente = await ClienteService.GetClienteInfo(id);
            if (cliente != null)
            {
                var clienteDTO = Mapper.Map<ClienteDTO>(cliente);
                return Ok(clienteDTO);
            }
            return BadRequest("Usuário não localizado");
        }

        /// <summary>
        /// Método para criação de um novo cliente
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        // POST api/<ClienteController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ClienteCadastroDTO clienteDTO)
        {
            var resultado = ClienteService.PostNovoCliente(clienteDTO);
            if (resultado)
            {
                var clientes = await ClienteService.GetClientes();
                var cliente = clientes.FirstOrDefault(f => f.Nome == clienteDTO.Nome && f.CPF == clienteDTO.CPF && f.RG == clienteDTO.RG);
                return Ok(cliente.Id);
            }
            return BadRequest();
        }

        /// <summary>
        /// Método para a atualização das informações do cliente
        /// </summary>
        /// <param name="clienteDTO"></param>
        /// <returns></returns>
        // PUT api/<ReceitasController>
        [HttpPut]
        public async Task<IActionResult> PutAsync([FromBody] ClienteDTO clienteDTO)
        {
            var cliente = await ClienteService.PutAtualizacaoCliente(clienteDTO);
            if (cliente != null)
                return Ok(Mapper.Map<ClienteDTO>(cliente));
            return BadRequest();
        }


    }
}
