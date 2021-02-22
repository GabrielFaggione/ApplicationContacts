using ApplicationContacts.Domain;
using ApplicationContacts.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationContacts.Infrastructure
{
    public class Repository : IRepository
    {

        private readonly ApplicationContractsContext Context;
        public Repository(ApplicationContractsContext context)
        {
            Context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            Context.Add(entity);
        }

        public bool SaveChanges()
        {
            return (Context.SaveChanges() > 0);
        }

        public void Update<T>(T entity) where T : class
        {
            Context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            Context.Remove(entity);
        }

        public Task<List<Cliente>> GetAllClientes()
        {
            IQueryable<Cliente> query = Context.Clientes;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Nome);
            
            return query.ToListAsync();
        }

        public async Task<PageList<Cliente>> GetAllClientes(PageParams pageParams)
        {
            IQueryable<Cliente> query = Context.Clientes;
            if (!string.IsNullOrEmpty(pageParams.Filtro)){
                query = query.Where(w => w.Nome.ToLower().Contains(pageParams.Filtro.ToLower()));
            }
            query = query
                .OrderBy(o => o.Nome);

            return await PageList<Cliente>.CreateAsync(query, pageParams.pageNumber, pageParams.PageSize);
        }

        public async Task<Cliente> GetClienteInfo(int clienteId)
        {
            IQueryable<Cliente> query = Context.Clientes;
            query = query//.AsNoTracking()
                .Where(w => w.Id == clienteId)
                .Include(i => i.RedesSociais)
                    .ThenInclude(ti => ti.TipoRedeSocial)
                .Include(i => i.ClienteXEnderecos)
                    .ThenInclude(ti => ti.Endereco)
                    .ThenInclude(ti => ti.Cidade)
                    .ThenInclude(ti => ti.Estado)
                .Include(i => i.ClienteXEnderecos)
                    .ThenInclude(ti => ti.TipoClienteXEndereco)
                .Include(i => i.ClienteXTelefones)
                    .ThenInclude(ti => ti.Telefone)
                .Include(i => i.ClienteXTelefones)
                    .ThenInclude(ti => ti.TipoClienteXTelefone);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Estado>> GetAllEstados()
        {
            IQueryable<Estado> query = Context.Estados;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Nome);

            return await query.ToListAsync();
        }

        public async Task<List<Cidade>> GetAllCidades()
        {
            IQueryable<Cidade> query = Context.Cidades;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Nome);

            return await query.ToListAsync();
        }

        public async Task<List<Cidade>> GetCidadesByEstadoId(int estadoId)
        {
            IQueryable<Cidade> query = Context.Cidades;
            query = query//.AsNoTracking()
                .Where(w => w.EstadoId == estadoId)
                .OrderBy(o => o.Nome);

            return await query.ToListAsync();
        }

        public async Task<List<TipoClienteXEndereco>> GetAllTipoClienteXEndereco()
        {
            IQueryable<TipoClienteXEndereco> query = Context.TiposClienteXEndereco;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Descricao);

            return await query.ToListAsync();
        }

        public async Task<List<TipoClienteXTelefone>> GetAllTipoClienteXTelefone()
        {
            IQueryable<TipoClienteXTelefone> query = Context.TiposClienteXTelefone;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Descricao);

            return await query.ToListAsync();
        }

        public async Task<List<Telefone>> GetAllTelefones()
        {
            IQueryable<Telefone> query = Context.Telefones;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Numero);

            return await query.ToListAsync();
        }

        public async Task<Telefone> GetTelefoneByNumero(string numero)
        {
            IQueryable<Telefone> query = Context.Telefones;
            query = query//.AsNoTracking()
                .Where(w => w.Numero == numero);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Endereco>> GetAllEnderecos()
        {
            IQueryable<Endereco> query = Context.Enderecos;
            query = query//.AsNoTracking()
                .Include(i => i.Cidade)
                    .ThenInclude(ti => ti.Estado)
                .OrderBy(o => o.Cidade.Estado.Nome)
                    .ThenBy(tb => tb.Cidade.Nome);
            return await query.ToListAsync();
        }

        public async Task<Endereco> GetEnderecoByFiltro(string rua, int numero, string complemento, int cidadeId)
        {
            IQueryable<Endereco> query = Context.Enderecos;
            query = query//.AsNoTracking()
                .Where(w => w.Rua == rua && w.Numero == numero && w.Complemento == complemento && w.CidadeId == cidadeId)
                .Include(i => i.Cidade)
                    .ThenInclude(ti => ti.Estado);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TipoClienteXEndereco> GetTipoClienteXEnderecoById(int id)
        {
            IQueryable<TipoClienteXEndereco> query = Context.TiposClienteXEndereco;
            query = query//.AsNoTracking()
                .Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TipoClienteXTelefone> GetTipoClienteXTelefoneById(int id)
        {
            IQueryable<TipoClienteXTelefone> query = Context.TiposClienteXTelefone;
            query = query//.AsNoTracking()
                .Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<TipoRedeSocial>> GetAllTipoRedeSocial()
        {
            IQueryable<TipoRedeSocial> query = Context.TiposRedeSocial;
            query = query//.AsNoTracking()
                .OrderBy(o => o.Nome);

            return await query.ToListAsync();
        }

        public async Task<TipoRedeSocial> GetTipoRedeSocialById(int id)
        {
            IQueryable<TipoRedeSocial> query = Context.TiposRedeSocial;
            query = query//.AsNoTracking()
                .Where(w => w.Id == id);

            return await query.FirstOrDefaultAsync();
        }
    }
}
