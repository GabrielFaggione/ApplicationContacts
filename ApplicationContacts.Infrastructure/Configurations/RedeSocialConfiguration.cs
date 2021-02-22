using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class RedeSocialConfiguration : IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(EntityTypeBuilder<RedeSocial> builder)
        {

            builder.HasKey(b => b.Id);

            builder
                .HasOne(r => r.Cliente)
                .WithMany(c => c.RedesSociais)
                .HasForeignKey(r => r.ClienteId);
            builder
                .HasOne(r => r.TipoRedeSocial)
                .WithMany(t => t.RedesSociais)
                .HasForeignKey(r => r.TipoRedeSocialId);

        }
    }
}
