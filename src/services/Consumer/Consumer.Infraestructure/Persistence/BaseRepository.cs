using Consumer.Infraestructure.Persistence.Interfaces;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infraestructure.Persistence
{
    public class BaseRepository<TDocument> : IAsyncRepository<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection = null!;

        public BaseRepository(IConfiguration configuration) {
            var client = MongoDBConnection.GetClient(configuration);
            var database = client.GetDatabase(configuration.GetSection("MongoDBSettings")["DatabaseName"]);
            //var database = client.GetDatabase(Convert.ToString(configuration.GetSection("MongoDBSettings:DatabaseName")));
            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type DocumentType)
        {
            return (DocumentType.GetCustomAttributes(typeof(BsonCollectionAttribute),true)
                .FirstOrDefault()! as BsonCollectionAttribute)!.CollectioName;
        }

        Task IAsyncRepository<TDocument>.InsertOneAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }
    }
}
