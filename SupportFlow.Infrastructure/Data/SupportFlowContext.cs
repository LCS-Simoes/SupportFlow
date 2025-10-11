using Microsoft.EntityFrameworkCore;
using SupportFlow.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Infrastructure.Data
{
    public class SupportFlowContext : DbContext
    {
        public SupportFlowContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Suporte> Suportes { get; set; }

        protected SupportFlowContext()
        {
        }
    }
}
