using Microsoft.Extensions.DependencyInjection;

namespace SupportFlow.Application.UseCases.Usuarios
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplicationUser(this IServiceCollection services)
        {
            // Aqui você registra todos os seus UseCases
            services.AddScoped<CriarUsuarioUseCase>();
            services.AddScoped<ListarUsuarioUseCase>();
            services.AddScoped<BuscarUsuarioIdUseCase>();
            services.AddScoped<AtualizarUsuarioUseCase>();
            services.AddScoped<DeletarUsuarioUseCase>();
            services.AddScoped<AutenticacaoUseCase>();

            return services;

            /*
             * Posteriormente usar as Interfaces do UseCase 
            */
        }
    }
}
