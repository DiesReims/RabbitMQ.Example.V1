using Consumer.Infraestructure.Entities;
using Consumer.Infraestructure.Persistence.Interfaces;
using Consumer.Infraestructure.Persistence.Interfaces.IFeatures;

namespace Consumer.Infraestructure.Repositories
{
    public class MessageRepository : ICommandRepository<Message>
    {
        private readonly IAsyncRepository<Message> _repository;

        public MessageRepository(IAsyncRepository<Message> messageRepository)
        {
            _repository = messageRepository;
        }

        public async Task CreateEntity(Message entity)
        {
           await _repository.InsertOneAsync(entity);
        }

        public Task<bool> DeleteEntity(Message entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEntity(Message entity)
        {
            throw new NotImplementedException();
        }
    }
}
