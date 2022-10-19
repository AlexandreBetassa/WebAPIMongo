using MongoDB.Bson.Serialization.Attributes;

namespace APIAgendaMongo.Models
{
    public class Adress
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Rua { get; set; }
    }
}
