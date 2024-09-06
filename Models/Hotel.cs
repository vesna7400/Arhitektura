using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Arhitektura.Models
{
    public class Hotel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("naziv")]
        public string Naziv { get; set; }

        [BsonElement("brojZvezdica")]
        public int BrojZvezdica { get; set; }

        [BsonElement("opis")]
        public string Opis { get; set; }

        [BsonElement("destinacija")]
        public Destinacija Destinacija { get; set; }

        [BsonElement("slika")]
        public string? Slika { get; set; }

        [BsonIgnore]
        public List<Aranzman>? Aranzmani { get; set; }
    }
}
