using Consumer.Infraestructure.Persistence;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Document = Consumer.Infraestructure.Persistence.Document;

namespace Consumer.Infraestructure.Entities
{
    [BsonCollection("Messages")]
    public class Message : Document
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public override string? Id { get; set; }

        public string texto { get; set; }
    }
}
