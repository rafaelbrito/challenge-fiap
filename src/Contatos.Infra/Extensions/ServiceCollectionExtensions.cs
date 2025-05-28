using Contatos.Core.Domain.Interfaces;
using Contatos.Core.Interfaces;
using Contatos.Infra.Data.Contexts;
using Contatos.Infra.Data.Repositories;
using Contatos.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contatos.Infra.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ContatosDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddMemoryCache();
            services.AddScoped<IServiceCache, MemoryCacheService>();


            services.AddScoped<IContatoRepository, ContatoRepository>();


            return services;
        }
    }
}
