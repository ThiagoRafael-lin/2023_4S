using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Domains
{
    public class Users
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string? Name { get; set; }
        [BsonElement("email")]
        public string? Email { get; set; }

        [BsonElement("senha")]
        public string? Senha { get; set; }

        [BsonElement("cidade")]
        public string? Cidade { get; set; }
    }
}
