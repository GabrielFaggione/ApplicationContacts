using ApplicationContacts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class RedeSocial
    {

        public int Id { get; private set; }
        public string Url { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public int TipoRedeSocialId { get; private set; }
        public TipoRedeSocial TipoRedeSocial { get; private set; }

        private RedeSocial() { }

        public RedeSocial(Cliente cliente, int tipoRedeSocialId)
        {
            Cliente = cliente;
            TipoRedeSocialId = tipoRedeSocialId;
        }

        public void Atualizar(RedeSocialDTO redeSocialDTO)
        {
            Url = redeSocialDTO.Url;
        }

    }
}
