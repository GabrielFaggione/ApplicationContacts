using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain;
using ApplicationContacts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services
{
    public class TipoService : ITipoService
    {

        private readonly IRepository Repository;

        public TipoService(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<List<TipoClienteXEndereco>> GetAllTiposClienteXEndereco()
        {
            return await Repository.GetAllTipoClienteXEndereco();
        }

        public async Task<List<TipoClienteXTelefone>> GetAllTiposClienteXTelefone()
        {
            return await Repository.GetAllTipoClienteXTelefone();
        }

        public async Task<List<TipoRedeSocial>> GetAllTiposRedeSocial()
        {
            return await Repository.GetAllTipoRedeSocial();
        }
    }
}
