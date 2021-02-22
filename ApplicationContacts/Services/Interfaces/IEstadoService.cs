using ApplicationContacts.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services.Interfaces
{
    public interface IEstadoService
    {

        Task<List<Estado>> GetAllEstados();
        Task<List<Cidade>> GetAllCidades();

    }
}
