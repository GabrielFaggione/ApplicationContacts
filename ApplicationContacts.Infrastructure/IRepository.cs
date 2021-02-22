using ApplicationContacts.Domain;
using ApplicationContacts.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContacts.Infrastructure
{
    public interface IRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Task<List<Cliente>> GetAllClientes();
        Task<PageList<Cliente>> GetAllClientes(PageParams pageParams);

        Task<Cliente> GetClienteInfo(int clienteId);

        Task<List<Cidade>> GetAllCidades();
        Task<List<Estado>> GetAllEstados();

        Task<List<Cidade>> GetCidadesByEstadoId(int estadoId);

        Task<List<TipoClienteXEndereco>> GetAllTipoClienteXEndereco();
        Task<TipoClienteXEndereco> GetTipoClienteXEnderecoById(int id);
        Task<List<TipoClienteXTelefone>> GetAllTipoClienteXTelefone();
        Task<TipoClienteXTelefone> GetTipoClienteXTelefoneById(int id);

        Task<List<Telefone>> GetAllTelefones();
        Task<Telefone> GetTelefoneByNumero(string numero);

        Task<List<Endereco>> GetAllEnderecos();
        Task<Endereco> GetEnderecoByFiltro(string rua, int numero, string complemento, int cidadeId);

        Task<List<TipoRedeSocial>> GetAllTipoRedeSocial();
        Task<TipoRedeSocial> GetTipoRedeSocialById(int id);

    }
}
