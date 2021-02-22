using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class TipoRedeSocial
    {

        public int Id { get; private set; }
        public string Nome { get; private set; }

        private HashSet<RedeSocial> _redesSociais;
        public IEnumerable<RedeSocial> RedesSociais => _redesSociais?.ToList();

        private TipoRedeSocial()
        {
            _redesSociais = new HashSet<RedeSocial>();
        }

        public TipoRedeSocial(int id, string nome)
        {
            Nome = nome;
            Id = id;
        }

    }
}
