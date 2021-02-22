using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(Telefone.ClientesXTelefone));
            element.SetField("_clientesXtelefone");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
