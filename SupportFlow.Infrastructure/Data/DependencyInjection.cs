using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportFlow.Domain.Interfaces;
using SupportFlow.Infrastructure.Data.Repositories;

namespace SupportFlow.Infrastructure.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<SupportFlowDbContext>(options =>
                options.UseSqlite(connectionString));

            services.AddScoped<IUsuario, UsuarioRepository>();
            services.AddScoped<ISuporte, SuporteRepository>();

            return services;
        } 
    }
}
