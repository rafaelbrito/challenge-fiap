using Contatos.Core.Domain.Interfaces;
using Contatos.Infra.Data.Contexts;
using Contatos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Contatos.Application.UseCases.Contatos;
using Microsoft.OpenApi.Models;
using Prometheus;
using Contatos.Infra.Services;
using Contatos.Core.Interfaces;
using MassTransit;

namespace Contatos.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
            builder.Services.AddTransient<IServiceCache, MemoryCacheService>();
            builder.Services.AddTransient<IContatoRepository, ContatoRepository>();

            builder.Services.AddTransient<CreateContato>();
            builder.Services.AddTransient<GetContato>();
            builder.Services.AddTransient<UpdateContato>();
            builder.Services.AddTransient<DeleteContato>();

            builder.Services.AddDbContext<ContatosDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ContatosDbContext>();
                context.Database.Migrate();
            }

            var rabbitMqHost = builder.Configuration["RabbitMQ:Host"] ?? "rabbitmq";
            var rabbitMqUser = builder.Configuration["RabbitMQ:User"] ?? "guest";
            var rabbitMqPass = builder.Configuration["RabbitMQ:Password"] ?? "guest";

            builder.Services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqHost, "/", h =>
                    {
                        h.Username(rabbitMqUser);
                        h.Password(rabbitMqPass);
                    });
                });
            });

            var app = builder.Build();

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapMetrics();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }
    }
}
