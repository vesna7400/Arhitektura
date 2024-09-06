using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Arhitektura.Roles
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ime")]
        public string? Ime { get; set; }

        [BsonElement("prezime")]
        public string? Prezime { get; set; }

        [BsonElement("username")]
        public string? Username { get; set; }
    
        [BsonElement("password")]
        public string? Password { get; set; }
    
    }
}
