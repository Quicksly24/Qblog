using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Postdb.gmodel.post
{
    public class Likes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Postid { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string Userid { get; set; }

        
    }


    public class Likeobj{

        public string likeid{get;set;}

        public bool state{get;set;}=false;

    }
}
