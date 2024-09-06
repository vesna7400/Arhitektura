using Arhitektura.IRepositories;
using Arhitektura.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Arhitektura.Repositories
{
    public class DestinacijaRepository : IDestinacijaRepository
    {
        private readonly IMongoCollection<Destinacija> _collection;

        public DestinacijaRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("arhitektura");
            _collection = database.GetCollection<Destinacija>("destinacija");
        }

        public List<Destinacija> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public Destinacija GetById(string id)
        {
            return _collection.Find(destinacija => destinacija.Id == id).FirstOrDefault();
        }

        public void Create(Destinacija destinacija)
        {
            _collection.InsertOne(destinacija);
        }

        public void Update(string id, Destinacija destinacija)
        {
            _collection.ReplaceOne(destinacija => destinacija.Id == id, destinacija);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(destinacija => destinacija.Id == id);
        }
    }
}
