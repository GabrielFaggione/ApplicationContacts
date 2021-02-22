using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationContacts.API.Services;
using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApplicationContacts.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoController : ControllerBase
    {

        private readonly IMapper Mapper;
        private readonly IEstadoService EstadoService;

        public EstadoController(IMapper mapper, IEstadoService estadoService)
        {
            Mapper = mapper;
            EstadoService = estadoService;
        }

        /// <summary>
        /// Recupera todos os Estados do Brasil
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var estados = await EstadoService.GetAllEstados();
            var estadosDTO = Mapper.Map<IEnumerable<EstadoDTO>>(estados);
            return Ok(estadosDTO);
        }

        /// <summary>
        /// Recupera todas as cidades
        /// </summary>
        /// <returns></returns>
        [HttpGet("Cidades")]
        public async Task<IActionResult> GetCidadesAsync()
        {
            var cidades = await EstadoService.GetAllCidades();
            var cidadesDTO = Mapper.Map<IEnumerable<CidadeDTO>>(cidades);
            return Ok(cidadesDTO);
        }

    }
}
