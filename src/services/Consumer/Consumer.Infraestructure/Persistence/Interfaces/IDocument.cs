using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consumer.Infraestructure.Persistence.Interfaces
{
    public interface IDocument
    {
        [BsonId]
        string? Id { get; set; }
    }
}
