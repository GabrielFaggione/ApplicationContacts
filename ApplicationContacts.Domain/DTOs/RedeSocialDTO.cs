using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class RedeSocialDTO
    {

        public int Id { get; set; }
        public string Url { get; set; }
        public ClienteDTO Cliente { get; set; }
        public TipoRedeSocialDTO TipoRedeSocial { get; set; }


    }
}
