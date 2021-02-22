using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class TipoClienteXTelefone
    {

        public int Id { get; private set; }
        public string Descricao { get; private set; }

        private HashSet<ClienteXTelefone> _clientesXtelefones;
        public IEnumerable<ClienteXTelefone> ClientesXTelefones => _clientesXtelefones?.ToList();

        private TipoClienteXTelefone()
        {
            _clientesXtelefones = new HashSet<ClienteXTelefone>();
        }

        public TipoClienteXTelefone(int id, string descricao)
        {
            Descricao = descricao;
            Id = id;
        }

    }
}
