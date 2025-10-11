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
    public class SuporteMap : IEntityTypeConfiguration<Suporte>
    {
        public void Configure(EntityTypeBuilder<Suporte> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(120);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.UsuarioID);
            builder.HasOne(x => x.Usuario);
        }
    }
}
