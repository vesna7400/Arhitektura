using Arhitektura.IRepositories;
using Arhitektura.Models;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Arhitektura.Repositories
{
    public class TuristickaAgencijaRepository : ITuristickaAgencijaRepository
    {
        private readonly IMongoCollection<TuristickaAgencija> _collection;

        public TuristickaAgencijaRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("arhitektura");
            _collection = database.GetCollection<TuristickaAgencija>("turisticka_agencija");
        }

        public List<TuristickaAgencija> GetAll()
        {
            return _collection.Find(_ => true).ToList();
        }

        public TuristickaAgencija GetById(string id)
        {
            return _collection.Find(turistickaAgencija => turistickaAgencija.Id == id).FirstOrDefault();
        }

        public void Create(TuristickaAgencija turistickaAgencija)
        {
            _collection.InsertOne(turistickaAgencija);
        }

        public void Update(string id, TuristickaAgencija turistickaAgencija)
        {
            _collection.ReplaceOne(turistickaAgencija => turistickaAgencija.Id == id, turistickaAgencija);
        }

        public void Delete(string id)
        {
            _collection.DeleteOne(turistickaAgencija => turistickaAgencija.Id == id);
        }
    }
}
