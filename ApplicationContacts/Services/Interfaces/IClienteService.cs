using ApplicationContacts.Domain;
using ApplicationContacts.Domain.DTOs;
using ApplicationContacts.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services.Interfaces
{
    public interface IClienteService
    {

        Task<List<Cliente>> GetClientes();
        Task<PageList<Cliente>> GetClientesByPageParams(PageParams pageParams);
        Task<Cliente> GetClienteInfo(int clienteId);
        bool PostNovoCliente(ClienteCadastroDTO clienteDTO);
        bool PostNovoCliente(ClienteDTO clienteDTO);
        Task<Cliente> PutAtualizacaoCliente(ClienteDTO clienteDTO);

    }
}
