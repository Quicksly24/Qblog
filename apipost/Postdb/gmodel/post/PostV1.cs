

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Postdb.gmodel.post
{
    public class PostV1
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string id { get; set; }

        public string Username { get; set; }

        public string title { get; set; }

        public string body { get; set; }

        public List<Nlike> Likes { get; set; }

        public DateTime CreatedAt { get; set; }
    }

    public class Nlike
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int id { get; set; }

    }
}
