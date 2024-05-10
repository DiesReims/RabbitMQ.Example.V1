using Consumer.Application.Features.MessageFeatures.Command.CreateMessage;
using Consumer.Infraestructure.Repositories;
using EventBus.Messages.Contracts;
using MassTransit;

namespace Consumer.API.Events
{
    public class MessageConsumerSaver : IConsumer<MessageEvent>
    {
        private readonly MessageRepository _messageRepository;
        private readonly CreateMessageCommand _command;

        public MessageConsumerSaver(MessageRepository messageRepository, CreateMessageCommand command)
        {
            _messageRepository = messageRepository;
            _command = command;
        }

        public async Task Consume(ConsumeContext<MessageEvent> context)
        {
            try
            {
                Console.WriteLine($"Mensaje recibido: {context.Message.Text}");
                //MONGO SAVING PART
                DTOCreateMessage dtoMessage = new() { texto = context.Message?.Text };
                var res = await _command.CreateMessage(dtoMessage);
                return;
            }
            catch (Exception _e)
            {
                Console.WriteLine(_e.ToString());
                return;
            }
        }
    }
}
