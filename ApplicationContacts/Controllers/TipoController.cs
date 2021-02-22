using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {

        private readonly ITipoService TipoService;
        private readonly IMapper Mapper;

        public TipoController(ITipoService tipoService, IMapper mapper)
        {
            TipoService = tipoService;
            Mapper = mapper;
        }

        /// <summary>
        /// Retorna todos os tipos de associação entre Cliente e Endereço
        /// </summary>
        /// <returns></returns>
        // GET api/<TipoController>/clienteXendereco
        [HttpGet("clienteXendereco")]
        public async Task<IActionResult> GetTipoClienteXEnderecoAsync()
        {
            var tipos = await TipoService.GetAllTiposClienteXEndereco();
            return Ok(Mapper.Map<IEnumerable<TipoClienteXEnderecoDTO>>(tipos));
        }

        /// <summary>
        /// Retorna todos os tipos de associação entre Cliente e Telefone
        /// </summary>
        /// <returns></returns>
        // GET api/<TipoController>/clienteXtelefone
        [HttpGet("clienteXtelefone")]
        public async Task<IActionResult> GetTipoClienteXTelefoneAsync()
        {
            var tipos = await TipoService.GetAllTiposClienteXTelefone();
            return Ok(Mapper.Map<IEnumerable<TipoClienteXTelefoneDTO>>(tipos));
        }

        /// <summary>
        /// Retorna todos os tipos de redes sociais que podem ser associadas
        /// </summary>
        /// <returns></returns>
        // GET api/<Controller>/redes-sociais
        [HttpGet("redes-sociais")]
        public async Task<IActionResult> GetTipoRedeSocialAsync()
        {
            var tipos = await TipoService.GetAllTiposRedeSocial();
            return Ok(Mapper.Map<IEnumerable<TipoRedeSocialDTO>>(tipos));
        }

    }
}
