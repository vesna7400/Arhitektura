using Arhitektura.IRepositories;
using Arhitektura.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Arhitektura.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly IMongoCollection<Hotel> _collection;
        private IMongoCollection<Destinacija> _destinacijaCollection;

        public HotelRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("arhitektura");
            _collection = database.GetCollection<Hotel>("hotel");
            _destinacijaCollection = database.GetCollection<Destinacija>("destinacija");
        }

        public List<Hotel> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public Hotel GetById(string id)
        {
            return _collection.Find(hotel => hotel.Id == id).FirstOrDefault();
        }

        public void Create(Hotel hotel)
        {
            _collection.InsertOne(hotel);
        }

        public void Update(string id, Hotel hotel)
        {
            _collection.ReplaceOne(hotel => hotel.Id == id, hotel);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(hotel => hotel.Id == id);
        }
    }
}
