﻿using System.Net;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Postdb.gmodel.post;
using Postdb.model;

namespace Postdb.data
{
    public class Mongodata : Ipost,Ilike
    {

        private readonly ConnectionStrings _connect;

        public Mongodata(IOptions<ConnectionStrings> connect)
        {
            _connect = connect.Value;
        }
       
        string database="Quick";
        private const string colloctionname="Postv1";
    
        private const string colloctionname2 = "Likes";

    

        public IMongoCollection<T> mongoCollection<T>(in string collection)
        {
            var connect = new MongoClient(_connect.MongoDbConnectionString);
            var db = connect.GetDatabase(database);
            return db.GetCollection<T>(collection);

        }


        public void Createpost(Postrequest post,string user)
        {
            var posts = new Post{
                  body=post.body,
                  title=post.title,
                  Username=user,
                  CreatedAt=DateTime.UtcNow

            };

           var collect = mongoCollection<Post>(colloctionname);

           collect.InsertOne(posts);


        }

        public void deletepost(string id)
        {
            var collect = mongoCollection<Post>(colloctionname);
            collect.DeleteOne<Post>(x=>x.id==id);
           
        }

        public List<Post> getpost()
        {

         
            var collect = mongoCollection<Post>(colloctionname);

            return collect.Find<Post>(_ => true).ToList();
        }

        public Post GetsinglePost(string id)
        {
            var collect = mongoCollection<Post>(colloctionname);

            return collect.Find<Post>(x=>x.id==id).FirstOrDefault();
        }

        public void updatepost(Post post)
        {
            var collect = mongoCollection<Post>(colloctionname);
            var filter = Builders<Post>.Filter.Eq("id",post.id);
            var update = Builders<Post>.Update.Set(x=>x.title,post.title).Set(x=>x.title,post.body);

            collect.UpdateOne(filter,update);
                   
        }

         public UpdateResult updatepost1(string id,string title,string body)
        {
            var collect = mongoCollection<Post>(colloctionname);
            var filter = Builders<Post>.Filter.Eq("id",id);
            var update = Builders<Post>.Update.Set(x=>x.title,title).Set(x=>x.body,body);

            

           return collect.UpdateOne(filter,update);
                   
        }

        public string Likepost(string postid,string user)
        {
            var lik = new Likes{Postid=postid,User=user};

            var collect = mongoCollection<Likes>(colloctionname2);
            collect.InsertOne(lik);

           return "success";
            
        }

        public string unLikepost(string likeid)
        {
           var collect = mongoCollection<Likes>(colloctionname2);  
           collect.DeleteOne(x=>x.Id==likeid);

           return "success";
        }

      
        public long postcount(string postid)
        {
             var collect = mongoCollection<Likes>(colloctionname2);  

            
            long num2=collect.CountDocuments(x=>x.Postid==postid);
            
            return num2;
        }


    }
}
