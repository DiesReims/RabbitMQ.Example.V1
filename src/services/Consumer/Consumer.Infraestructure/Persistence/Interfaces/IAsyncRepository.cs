namespace Consumer.Infraestructure.Persistence.Interfaces
{
    public interface IAsyncRepository<TDocument> where TDocument : IDocument
    {
        Task InsertOneAsync(TDocument document);
    }
}
