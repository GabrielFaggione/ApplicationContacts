using ApplicationContacts.Domain;
using ApplicationContacts.Domain.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationContacts.API.Helpers
{
    public class ApplicationContactsProfile : Profile
    {

        public ApplicationContactsProfile()
        {

            CreateMap<Cidade, CidadeDTO>();
            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteXEndereco, ClienteXEnderecoDTO>();
            CreateMap<ClienteXTelefone, ClienteXTelefoneDTO>();
            CreateMap<Endereco, EnderecoDTO>();
            CreateMap<Estado, EstadoDTO>();
            CreateMap<RedeSocial, RedeSocialDTO>();
            CreateMap<Telefone, TelefoneDTO>();
            CreateMap<TipoClienteXEndereco, TipoClienteXEnderecoDTO>();
            CreateMap<TipoClienteXTelefone, TipoClienteXTelefoneDTO>();
            CreateMap<TipoRedeSocial, TipoRedeSocialDTO>();

        }

    }
}
