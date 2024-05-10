using EventBus.Messages.Common;
using EventBus.Messages.Contracts;
using MassTransit;
using Publisher.API.Events;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<MessageConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint(EventBusConstants.MessageEventQueuePublisher, c =>
        {
            c.Bind(EventBusConstants.MessageExchange, x =>
            {
                x.Durable = true;
                x.ExchangeType = ExchangeType.Fanout;
                x.RoutingKey = "";
            } );

            c.ConfigureConsumer<MessageConsumer>(context);
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
