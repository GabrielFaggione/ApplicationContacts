using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .HasOne(e => e.Cidade)
                .WithMany(c => c.Enderecos)
                .HasForeignKey(e => e.CidadeId);

            var element = builder.Metadata.FindNavigation(nameof(Endereco.ClientesXEnderecos));
            element.SetField("_clienteXendereco");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
