using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class ClienteDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public List<ClienteXEnderecoDTO> ClienteXEnderecos { get; set; }
        public List<ClienteXTelefoneDTO> ClienteXTelefones { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }

    }

    public class ClienteCadastroDTO
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
    }

}
