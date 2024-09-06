using Arhitektura.IRepositories;
using Arhitektura.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Arhitektura.Repositories
{
    public class AranzmanRepository : IAranzmanRepository
    {
        private readonly IMongoCollection<Aranzman> _collection;
        private IMongoCollection<Hotel> _hotelCollection;
        private IMongoCollection<TuristickaAgencija> _turistickaAgencijaCollection;

        public AranzmanRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("arhitektura");
            _collection = database.GetCollection<Aranzman>("aranzman");
            _hotelCollection = database.GetCollection<Hotel>("destinacija");
            _turistickaAgencijaCollection = database.GetCollection<TuristickaAgencija>("turisticka_agencija");
        }

        public List<Aranzman> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public Aranzman GetById(string id)
        {
            return _collection.Find(aranzman => aranzman.Id == id).FirstOrDefault();
        }

        public void Create(Aranzman aranzman)
        {
            _collection.InsertOne(aranzman);
        }

        public void Update(string id, Aranzman aranzman)
        {
            _collection.ReplaceOne(aranzman => aranzman.Id == id, aranzman);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(aranzman => aranzman.Id == id);
        }
    }
}
