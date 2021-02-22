using ApplicationContacts.API.Services.Interfaces;
using ApplicationContacts.Domain;
using ApplicationContacts.Domain.DTOs;
using ApplicationContacts.Infrastructure;
using ApplicationContacts.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IRepository Repository;

        public ClienteService(IRepository repository)
        {
            Repository = repository;
        }

        public async Task<Cliente> GetClienteInfo(int clienteId)
        {
            var cliente = await Repository.GetClienteInfo(clienteId);
            if (cliente != null)
            {
                return cliente;
            }
            return null;
        }

        public async Task<List<Cliente>> GetClientes()
        {
            return await Repository.GetAllClientes();
        }

        public async Task<PageList<Cliente>> GetClientesByPageParams(PageParams pageParams)
        {
            return await Repository.GetAllClientes(pageParams);
        }

        public bool PostNovoCliente(ClienteCadastroDTO clienteDTO)
        {
            var Cliente = new Cliente(clienteDTO);
            Repository.Add(Cliente);
            return Repository.SaveChanges();
        }

        public bool PostNovoCliente(ClienteDTO clienteDTO)
        {
            var cliente = new Cliente(clienteDTO);
            Repository.Add(cliente);

            return Repository.SaveChanges();
        }

        public async Task<Cliente> PutAtualizacaoCliente(ClienteDTO clienteDTO)
        {
            var cliente = await Repository.GetClienteInfo(clienteDTO.Id);

            Dictionary<Telefone, TipoClienteXTelefone> telefones = new Dictionary<Telefone, TipoClienteXTelefone>();
            Dictionary<Endereco, TipoClienteXEndereco> enderecos = new Dictionary<Endereco, TipoClienteXEndereco>();
            List<RedeSocial> redesSociais = new List<RedeSocial>();

            foreach(var clienteXtelefone in clienteDTO.ClienteXTelefones)
            {
                var telefone = await Repository.GetTelefoneByNumero(clienteXtelefone.Telefone.Numero);
                var tipo = await Repository.GetTipoClienteXTelefoneById(clienteXtelefone.TipoClienteXTelefone.Id);
                if (telefone == null)
                    telefone = new Telefone(clienteXtelefone.Telefone);
                telefones.Add(telefone, tipo);
            }

            foreach (var clienteXendereco in clienteDTO.ClienteXEnderecos)
            {
                var endereco = await Repository.GetEnderecoByFiltro(clienteXendereco.Endereco.Rua, clienteXendereco.Endereco.Numero, clienteXendereco.Endereco.Complemento, clienteXendereco.Endereco.Cidade.Id);
                var tipo = await Repository.GetTipoClienteXEnderecoById(clienteXendereco.TipoClienteXEndereco.Id);
                if (endereco == null)
                    endereco = new Endereco(clienteXendereco.Endereco);
                enderecos.Add(endereco, tipo);
            }

            cliente.AtualizarEnderecos(enderecos.Keys.ToList(), enderecos.Values.ToList());
            cliente.AtualizarTelefones(telefones.Keys.ToList(), telefones.Values.ToList());
            cliente.AtualizarRedesSociais(clienteDTO.RedesSociais);
            Repository.Update(cliente);
            var result = Repository.SaveChanges();

            return cliente;

        }
    }
}
