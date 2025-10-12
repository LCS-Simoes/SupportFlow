using Microsoft.EntityFrameworkCore;
using SupportFlow.Domain.Entities;
using SupportFlow.Infrastructure.Data.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Infrastructure.Data
{
    public class SupportFlowDbContext : DbContext
    {
        public SupportFlowDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SuporteMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

        protected SupportFlowDbContext()
        {
        }
    }
}
