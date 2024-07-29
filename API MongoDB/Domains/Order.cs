using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace API_MongoDB.Domains
{
    public class Order
    {
        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("date")]
        public DateTime Date { get; set; }
        [BsonElement("status")]
        public string? Status { get; set; }

        [BsonElement("products")]
        public List<Product> Products { get; set; } = new List<Product>();

        [BsonElement("client")]
        public List<Client> Client { get; set; } = new List<Client>();
    }
}
