using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class EstadoConfiguration : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(Estado.Cidades));
            element.SetField("_cidades");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
