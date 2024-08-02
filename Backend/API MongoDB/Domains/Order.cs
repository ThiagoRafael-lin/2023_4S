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

        //Refêrencia aos produtos do pedido
        [BsonElement("productId")]
        public List<string>? ProductId { get; set; }
        public List<Product>? Products { get; set; }

        //Refêrencia ao cliente que está fazendo o pedido
        [BsonElement("clientId")]
        public string? ClientId { get; set; }
        public Client? Client { get; set; }
        
    }
}
