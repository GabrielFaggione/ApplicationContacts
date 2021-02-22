using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Domain.DTOs
{
    public class CidadeDTO
    {

        public int Id { get; set; }
        public string Nome { get; set; }
        public EstadoDTO Estado { get; set; }
        public int EstadoId { get; set; }

    }
}
