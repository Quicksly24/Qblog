﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Postdb.gmodel.post
{
    public class Likes
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Postid { get; set; }

        public string User { get; set; }

        
    }
}
