using ApplicationContacts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services.Interfaces
{
    public interface ITipoService
    {

        Task<List<TipoRedeSocial>> GetAllTiposRedeSocial();
        Task<List<TipoClienteXEndereco>> GetAllTiposClienteXEndereco();
        Task<List<TipoClienteXTelefone>> GetAllTiposClienteXTelefone();

    }
}
