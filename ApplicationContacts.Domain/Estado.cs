using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class Estado
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string UF { get; private set; }

        private HashSet<Cidade> _cidades;
        public IEnumerable<Cidade> Cidades => _cidades?.ToList();

        private Estado()
        {
            _cidades = new HashSet<Cidade>();
        }

        public Estado(int id, string nome, string uf)
        {
            Id = id;
            Nome = nome;
            UF = uf;
        }

    }
}
