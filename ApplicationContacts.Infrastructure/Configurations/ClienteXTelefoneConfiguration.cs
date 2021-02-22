using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class ClienteXTelefoneConfiguration : IEntityTypeConfiguration<ClienteXTelefone>
    {
        public void Configure(EntityTypeBuilder<ClienteXTelefone> builder)
        {
            builder.HasKey(b => b.Id);

            builder
                .HasOne(cxt => cxt.Cliente)
                .WithMany(c => c.ClienteXTelefones)
                .HasForeignKey(cxt => cxt.ClienteId);
            builder
                .HasOne(cxt => cxt.Telefone)
                .WithMany(t => t.ClientesXTelefone)
                .HasForeignKey(cxt => cxt.TelefoneId);
            builder
                .HasOne(cxt => cxt.TipoClienteXTelefone)
                .WithMany(t => t.ClientesXTelefones)
                .HasForeignKey(cxt => cxt.TipoClienteXTelefoneId);
        }
    }
}
