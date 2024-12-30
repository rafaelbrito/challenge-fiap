
using Contatos.Application.Interfaces;
using Contatos.Application.Services;
using Contatos.Core.Domain.Interfaces;
using Contatos.Infra.Data.Contexts;
using Contatos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Contatos.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IServiceCache, MemoryCacheService>();
            builder.Services.AddTransient<IContatoRepository, ContatoRepository>();

            builder.Services.AddDbContext<ContatosDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();


            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
