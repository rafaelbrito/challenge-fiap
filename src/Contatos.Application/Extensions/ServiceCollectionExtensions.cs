using Contatos.Application.UseCases.Contatos;
using Microsoft.Extensions.DependencyInjection;

namespace Contatos.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<CreateContato>();
            services.AddScoped<GetContato>();
            services.AddScoped<UpdateContato>();
            services.AddScoped<DeleteContato>();
            return services;
        }
    }
}
