namespace Consumer.Infraestructure.Persistence.Interfaces.IFeatures
{
    public interface ICommandRepository<TDocument> where TDocument : IDocument
    {
        Task CreateEntity(TDocument entity);

        Task<bool> UpdateEntity(TDocument entity);

        Task<bool> DeleteEntity(TDocument entity);
    }
}
