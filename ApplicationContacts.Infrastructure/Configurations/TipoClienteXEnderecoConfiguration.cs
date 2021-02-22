using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class TipoClienteXEnderecoConfiguration : IEntityTypeConfiguration<TipoClienteXEndereco>
    {
        public void Configure(EntityTypeBuilder<TipoClienteXEndereco> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(TipoClienteXEndereco.ClientesXEnderecos));
            element.SetField("_clientesXenderecos");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
