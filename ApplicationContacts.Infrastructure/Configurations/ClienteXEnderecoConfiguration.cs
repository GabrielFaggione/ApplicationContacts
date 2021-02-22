using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class ClienteXEnderecoConfiguration : IEntityTypeConfiguration<ClienteXEndereco>
    {
        public void Configure(EntityTypeBuilder<ClienteXEndereco> builder)
        {

            builder.HasKey(b => b.Id);

            builder
                .HasOne(cxe => cxe.Cliente)
                .WithMany(c => c.ClienteXEnderecos)
                .HasForeignKey(cxe => cxe.ClienteId);
            builder
                .HasOne(cxe => cxe.Endereco)
                .WithMany(e => e.ClientesXEnderecos)
                .HasForeignKey(cxe => cxe.EnderecoId);
            builder
                .HasOne(cxe => cxe.TipoClienteXEndereco)
                .WithMany(t => t.ClientesXEnderecos)
                .HasForeignKey(cxe => cxe.TipoClienteXEnderecoId);

        }
    }
}
