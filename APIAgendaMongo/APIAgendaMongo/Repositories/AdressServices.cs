using APIAgendaMongo.Models;
using APIAgendaMongo.Utils;
using MongoDB.Driver;
using System.Collections.Generic;

namespace APIAgendaMongo.Repositories
{
    public class AdressServices
    {
        private readonly IMongoCollection<Adress> _adress;

        public AdressServices(IDatabaseSettings settings)
        {
            var adress = new MongoClient(settings.ConnectionString);
            var database = adress.GetDatabase(settings.DatabaseName);
            _adress = database.GetCollection<Adress>(settings.AdressCollectionName);
        }

        public Adress Create(Adress adress)
        {
            _adress.InsertOne(adress);
            return adress;
        }

        public List<Adress> Get() => _adress.Find(x => true).ToList();

        public Adress Get(string id) => _adress.Find(adress => adress.Id == id).FirstOrDefault();

        public void Update(string id, Adress adressIn) => _adress.ReplaceOne(adress => adress.Id == id, adressIn);

        public void Remove(Adress adressIn) => _adress.DeleteOne(adress => adress.Id == adressIn.Id);


    }
}
