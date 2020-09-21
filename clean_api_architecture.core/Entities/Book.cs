using clean_api_architecture.shared.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace clean_api_architecture.core.Entities
{
    public class Book : EntityBase
    {
        [BsonElement("Name")]
        public string BookName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}