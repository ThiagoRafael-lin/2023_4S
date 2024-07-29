using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Domains
{
    public class Client
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userId")]
        public string? UserID { get; set; }
        [BsonElement("cpf")]
        public int Cpf { get; set; }
        [BsonElement("Phone")]
        public int Phone {  get; set; }
        [BsonElement("address")]
        public string? Address { get; set; }
        [BsonElement("rg")]
        public int Rg { get; set; }
    }
}
