using Contatos.Application.Extensions;
using Contatos.Infra.Extensions;
using MassTransit;
using Contatos.Worker.Consumers;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddApplication();
        builder.Services.AddInfra(builder.Configuration);

        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<CreateContatoConsumer>();
            x.AddConsumer<DeleteContatoConsumer>();
            x.AddConsumer<UpdateContatoConsumer>();

            var rabbitMqHost = builder.Configuration["RabbitMQ:Host"] ?? "rabbitmq";
            var rabbitMqUser = builder.Configuration["RabbitMQ:User"] ?? "guest";
            var rabbitMqPass = builder.Configuration["RabbitMQ:Password"] ?? "guest";

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqHost, "/", h =>
                {
                    h.Username(rabbitMqUser);
                    h.Password(rabbitMqPass);
                });

                cfg.ConfigureEndpoints(context);
            });
        });

        var host = builder.Build();
        host.Run();
    }
}