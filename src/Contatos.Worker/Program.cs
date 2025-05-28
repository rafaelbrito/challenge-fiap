using Contatos.Worker;
using Contatos.Application.Extensions;
using Contatos.Infra.Extensions;
using MassTransit;
using Contatos.Worker.Consumers;


var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
builder.Services.AddApplication();
builder.Services.AddInfra(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<CreateContatoConsumer>();
    x.AddConsumer<DeleteContatoConsumer>();
    x.AddConsumer<UpdateContatoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ConfigureEndpoints(context);
    });
});

var host = builder.Build();
host.Run();
