using MongoDB.Bson.Serialization.Attributes;

namespace APIAgendaMongo.Models
{
    public class Client
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public Adress Adress { get; set; }

    }
}
