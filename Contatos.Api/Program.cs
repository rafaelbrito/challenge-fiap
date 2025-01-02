using Contatos.Application.Interfaces;
using Contatos.Application.Services;
using Contatos.Core.Domain.Interfaces;
using Contatos.Infra.Data.Contexts;
using Contatos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Contatos.Application.UseCases.Contatos;
using Microsoft.OpenApi.Models;


namespace Contatos.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Contatos API",
                    Version = "v1",
                    Description = "API para gerenciar contatos.",
                    Contact = new OpenApiContact
                    {
                        Name = "Rafael de Sena Brito",
                        Email = "rafaelbrito@live.com",
                        Url = new Uri("https://github.com/rafaelbrito/challenge-fiap")
                    }
                });
            });

            builder.Services.AddMemoryCache();
            builder.Services.AddScoped<IServiceCache, MemoryCacheService>();
            builder.Services.AddTransient<IContatoRepository, ContatoRepository>();

            builder.Services.AddTransient<CreateContato>();
            builder.Services.AddTransient<GetContato>();
            builder.Services.AddTransient<UpdateContato>();
            builder.Services.AddTransient<DeleteContato>();

            builder.Services.AddDbContext<ContatosDbContext>(options =>
                     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
