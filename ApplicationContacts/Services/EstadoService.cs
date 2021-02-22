using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain;
using ApplicationContacts.Domain.DTOs;
using ApplicationContacts.Infrastructure;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services
{
    public class EstadoService : IEstadoService
    {

        private readonly IRepository Repository;

        public EstadoService(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<List<Cidade>> GetAllCidades()
        {
            return await Repository.GetAllCidades();
        }

        public async Task<List<Estado>> GetAllEstados()
        {
            return await Repository.GetAllEstados();
        }

        public async Task<List<Cidade>> GetCidadesByEstadoId(int estadoId)
        {
            return await Repository.GetCidadesByEstadoId(estadoId);
        }
    }
}
