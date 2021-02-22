using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class TipoClienteXTelefoneConfiguration : IEntityTypeConfiguration<TipoClienteXTelefone>
    {
        public void Configure(EntityTypeBuilder<TipoClienteXTelefone> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(TipoClienteXTelefone.ClientesXTelefones));
            element.SetField("_clientesXtelefones");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
