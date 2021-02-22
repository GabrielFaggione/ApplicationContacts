using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class Cidade
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }

        public int EstadoId { get; private set; }
        public Estado Estado { get; private set; }

        private HashSet<Endereco> _enderecos;
        public IEnumerable<Endereco> Enderecos => _enderecos?.ToList();

        private Cidade()
        {
            _enderecos = new HashSet<Endereco>();
        }

        public Cidade(int id, string nome, int estadoId)
        {
            Id = id;
            Nome = nome;
            EstadoId = estadoId;
        }


    }
}
