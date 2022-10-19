using APIAgendaMongo.Models;
using APIAgendaMongo.Utils;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace APIAgendaMongo.Repositories
{
    public class ClientServices
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }

        public Client Create(Client client)
        {
            _clients.InsertOne(client);
            return client;
        }

        public List<Client> Get() => _clients.Find(x => true).ToList();

        public Client Get(string id) => _clients.Find(client => client.Id == id).FirstOrDefault();

        public void Update(string id, Client clientIn) => _clients.ReplaceOne(client => client.Id == id, clientIn);

        public void Remove(Client clientIn) => _clients.DeleteOne(client => client.Id == clientIn.Id);
    }
}
