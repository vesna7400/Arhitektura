using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Arhitektura.Models
{
    public class Destinacija
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("mesto")]
        public string? Mesto { get; set; }

        [BsonElement("drzava")]
        public string? Drzava { get; set; }

        [BsonElement("opis")]
        public string? Opis { get; set; }

        [BsonElement("slika")]
        public string? Slika { get; set; }
    }
}
