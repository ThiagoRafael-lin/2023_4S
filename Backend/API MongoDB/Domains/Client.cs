﻿using MongoDB.Bson.Serialization.Attributes;
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
        public string? Cpf { get; set; }
        [BsonElement("Phone")]
        public string? Phone {  get; set; }
        [BsonElement("address")]
        public string? Address { get; set; }

        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Client()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }

    }
}
