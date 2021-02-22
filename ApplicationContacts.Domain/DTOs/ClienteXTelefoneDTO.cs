using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class ClienteXTelefoneDTO
    {

        public int Id { get; set; }
        //public ClienteDTO Cliente { get; set; }
        public TelefoneDTO Telefone { get; set; }
        public TipoClienteXTelefoneDTO TipoClienteXTelefone { get; set; }

    }
}
