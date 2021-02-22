using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class ClienteXEndereco
    {

        public int Id { get; private set; }

        public int TipoClienteXEnderecoId { get; private set; }
        public TipoClienteXEndereco TipoClienteXEndereco { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public int EnderecoId { get; private set; }
        public Endereco Endereco { get; private set; }

        private ClienteXEndereco() { }

        public ClienteXEndereco(Cliente cliente, Endereco endereco, TipoClienteXEndereco tipo)
        {
            Cliente = cliente;
            Endereco = endereco;
            TipoClienteXEndereco = tipo;
        }

        public void Atualizar(TipoClienteXEndereco tipo)
        {
            TipoClienteXEndereco = tipo;
        }

    }
}
