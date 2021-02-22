using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(Cliente.ClienteXEnderecos));
            element.SetField("_clienteXendereco");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

            element = builder.Metadata.FindNavigation(nameof(Cliente.ClienteXTelefones));
            element.SetField("_clienteXtelefones");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

            element = builder.Metadata.FindNavigation(nameof(Cliente.RedesSociais));
            element.SetField("_redesSociais");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
