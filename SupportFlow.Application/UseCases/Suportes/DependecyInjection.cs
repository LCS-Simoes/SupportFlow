using Microsoft.Extensions.DependencyInjection;

namespace SupportFlow.Application.UseCases.Suportes
{
    public static class DependecyInjectionSuporte
    {
        public static IServiceCollection AddApplicationSuport(this IServiceCollection services)
        {
            // Aqui você registra todos os seus UseCases
            services.AddScoped<CriarSuporteUseCase>();
            services.AddScoped<ListarSuporteUseCase>();
            services.AddScoped<DeletarSuporteUseCase>();
            services.AddScoped<AtualizarSuporteUseCase>();
            services.AddScoped<BuscarSuporteIdUseCase>();

            // Adicione todos os outros use cases que você tiver
            return services;
        }
    }
}
