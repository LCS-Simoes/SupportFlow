using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SupportFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Infrastructure.Data.Map
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(110);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Setor).HasConversion<string>().IsRequired();
            builder.Property(x => x.Perfil).HasConversion<string>().IsRequired();
        }
    }
}
