using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clean_api_architecture.shared.Abstractions
{
    public abstract class EntityBase : IEntity
    {   
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }
        [BsonElement("__v")]
        public int Version { get; set; }
    }
}
