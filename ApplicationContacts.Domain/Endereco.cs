using ApplicationContacts.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class Endereco
    {

        public int Id { get; private set; }
        public string Rua { get; private set; }
        public int Numero { get; private set; }
        public string Complemento { get; private set; }
        public string CEP { get; private set; }

        public int CidadeId { get; private set; }
        public Cidade Cidade { get; set; }

        private HashSet<ClienteXEndereco> _clienteXendereco;
        public IEnumerable<ClienteXEndereco> ClientesXEnderecos => _clienteXendereco?.ToList();

        private Endereco()
        {
            _clienteXendereco = new HashSet<ClienteXEndereco>();
        }

        public Endereco(string rua, int numero, string complemento, string cep, int cidadeId)
        {
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
            CEP = cep;
            CidadeId = cidadeId;
        }

        public Endereco(EnderecoDTO enderecoDTO)
        {
            Rua = enderecoDTO.Rua;
            Numero = enderecoDTO.Numero;
            Complemento = enderecoDTO.Complemento;
            CEP = enderecoDTO.CEP;
            CidadeId = enderecoDTO.Cidade.Id;

        }

    }
}
