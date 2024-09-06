using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Arhitektura.Models
{
    public class TuristickaAgencija
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("naziv")]
        public string? Naziv { get; set; }

        [BsonElement("adresa")]
        public string? Adresa { get; set; }

        [BsonElement("kontakt")]
        public string? Kontakt { get; set; }

        [BsonElement("slika")]
        public string? Slika { get; set; }

        [BsonIgnore]
        public List<Aranzman>? Aranzmani { get; set; }
    }
}
