using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain
{
    public class ClienteXTelefone
    {

        public int Id { get; private set; }
        
        public int TipoClienteXTelefoneId { get; private set; }
        public TipoClienteXTelefone TipoClienteXTelefone { get; private set; }

        public int ClienteId { get; private set; }
        public Cliente Cliente { get; private set; }

        public int TelefoneId { get; private set; }
        public Telefone Telefone { get; private set; }

        private ClienteXTelefone() { }

        public ClienteXTelefone(Cliente cliente, Telefone telefone, TipoClienteXTelefone tipo)
        {
            Cliente = cliente;
            Telefone = telefone;
            TipoClienteXTelefone = tipo;
        }

        public void Atualizar(TipoClienteXTelefone tipo)
        {
            TipoClienteXTelefone = tipo;
        }

    }
}
