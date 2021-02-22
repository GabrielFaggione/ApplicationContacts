using ApplicationContacts.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationContacts.Infrastructure.Configurations
{
    class TipoRedeSocialConfiguration : IEntityTypeConfiguration<TipoRedeSocial>
    {
        public void Configure(EntityTypeBuilder<TipoRedeSocial> builder)
        {

            builder.HasKey(b => b.Id);

            var element = builder.Metadata.FindNavigation(nameof(TipoRedeSocial.RedesSociais));
            element.SetField("_redesSociais");
            element.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
