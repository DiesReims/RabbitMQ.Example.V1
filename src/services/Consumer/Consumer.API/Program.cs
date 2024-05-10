using Consumer.API.Events;
using EventBus.Messages.Contracts;
using MassTransit;
using Consumer.Infraestructure;
using Consumer.Application;
using RabbitMQ.Client;
using EventBus.Messages.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//referencedProjects
builder.Services.AddInfraestructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumerSaver>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint(EventBusConstants.MessageEventQueueConsumer, c =>
        {
            c.Bind(EventBusConstants.MessageExchange, x =>
            {
                x.Durable = true;
                x.ExchangeType = ExchangeType.Fanout;
                x.RoutingKey = "";
            });

            c.ConfigureConsumer<MessageConsumerSaver>(context);
        });
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
