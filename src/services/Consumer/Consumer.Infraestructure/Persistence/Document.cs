using Consumer.Infraestructure.Persistence.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Consumer.Infraestructure.Persistence
{
    public abstract class Document : IDocument
    {
        [BsonRepresentation(BsonType.ObjectId)]
        abstract public string? Id { get; set; }
    }
}
