using ApplicationContacts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class Telefone
    {

        public int Id { get; private set; }
        public string Numero { get; private set; }

        private HashSet<ClienteXTelefone> _clientesXtelefone;
        public IEnumerable<ClienteXTelefone> ClientesXTelefone => _clientesXtelefone?.ToList();

        private Telefone()
        {
            _clientesXtelefone = new HashSet<ClienteXTelefone>();
        }

        public Telefone(string numero)
        {
            Numero = numero;
        }

        public Telefone(TelefoneDTO telefoneDTO)
        {
            Numero = telefoneDTO.Numero;
        }

    }
}
