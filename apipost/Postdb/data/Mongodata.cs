using MongoDB.Driver;
using Postdb.model;

namespace Postdb.data
{
    public class Mongodata : Ipost
    {
        string connectstring= "";
        string database="Quick";
        private const string colloctionname="Postv1";
        private const string colloctionname1 = "Postv2";
        private const string colloctionname2 = "Likes";

        public IMongoCollection<T> mongoCollection<T>(in string collection)
        {
            var connect = new MongoClient(connectstring);
            var db = connect.GetDatabase(database);
            return db.GetCollection<T>(collection);

        }


        public void Createpost(Postrequest post)
        {
            var posts = new Post{
                  body=post.body,
                  title=post.title,
                  Username="jeff",
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
            var filter = Builders<Post>.Filter.Eq("Id",post.id);
            var update = Builders<Post>.Update.Set(x=>x.title,post.title).Set(x=>x.title,post.body);

            collect.UpdateOne(filter,update);
           
             
            
        }
    }
}
