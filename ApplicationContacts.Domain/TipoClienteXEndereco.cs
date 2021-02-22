using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class TipoClienteXEndereco
    {

        public int Id { get; private set; }
        public string Descricao { get; private set; }

        private HashSet<ClienteXEndereco> _clientesXenderecos;
        public IEnumerable<ClienteXEndereco> ClientesXEnderecos => _clientesXenderecos?.ToList();

        private TipoClienteXEndereco()
        {
            _clientesXenderecos = new HashSet<ClienteXEndereco>();
        }

        public TipoClienteXEndereco(int id, string descricao)
        {
            Descricao = descricao;
            Id = id;
        }

    }
}
