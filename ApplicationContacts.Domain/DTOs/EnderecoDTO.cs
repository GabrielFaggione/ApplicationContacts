using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class EnderecoDTO
    {

        public int Id { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public CidadeDTO Cidade { get; set; }
        //public List<ClienteXEnderecoDTO> ClientesXEndereco { get; set; }

    }
}
