using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Arhitektura.Models
{
    public class Aranzman
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("ukupnaCena")]
        public decimal UkupnaCena { get; set; }
        
        [BsonElement("placeno")]
        public bool Placeno { get; set; }
       
        [BsonElement("datumRealizacije")]
        public DateTime DatumRealizacije { get; set; }

        [BsonElement("hotel")]
        public Hotel? Hotel { get; set; }

        [BsonElement("opis")]
        public string? Opis { get; set; }

        [BsonElement("slika")]
        public string? Slika { get; set; }

        [BsonElement("turistickaAgencija")]
        public TuristickaAgencija? TuristickaAgencija { get; set; }
    }
}
