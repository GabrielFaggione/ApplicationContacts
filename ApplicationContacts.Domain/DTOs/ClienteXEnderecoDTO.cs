using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class ClienteXEnderecoDTO
    {

        public int Id { get; set; }
        //public ClienteDTO Cliente { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public TipoClienteXEnderecoDTO TipoClienteXEndereco { get; set; }

    }
}
