using EventBus.Messages.Contracts;
using MassTransit;

namespace Publisher.API.Events
{
    public class MessageConsumer : IConsumer<MessageEvent>
    {
        public async Task Consume(ConsumeContext<MessageEvent> context)
        {
            await Console.Out.WriteLineAsync($"Mensaje publicado: {context.Message.Text}");
        }
    }
}
