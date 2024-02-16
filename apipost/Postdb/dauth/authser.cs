



using MongoDB.Bson;
using MongoDB.Driver;

public class Authuser : Iauth, Ifollow
{

     string connectstring= "mongodb+srv://Quicksly:f4PvWY5G3RtuZcQo@cluster0.d2muozt.mongodb.net/?retryWrites=true&w=majority";
     string database = "User";

    string collectionname= "users";

    private IMongoCollection<T> getcollection<T>(in string collect){

        var connect = new MongoClient(connectstring);
        var db = connect.GetDatabase(database);

        return db.GetCollection<T>(collect);


    }


    private readonly Itoken key;

    public Authuser(Itoken key)
    {
        this.key = key;
    }

    public Responseuser login(string username, string password)
    {
        var collect = getcollection<User>(collectionname);

        var exist = collect.Find(u => u.username == username && u.password == password).FirstOrDefault();

         if (exist != null)
    {
        var token = key.gentoken(username,password);

        var response = new Responseuser(){
            username=username,
            email=exist.email,
            token=token

        };
        
        return response;
    }
    else
    {
        throw new Exception("username or password wrong");
    }

    }

    
    public Responseuser register(string username, string email, string password)
    {
        var collect = getcollection<User>(collectionname);

        var exist = collect.Find(u => u.username == username && u.password == password).FirstOrDefault();

        if(exist != null){

         throw new Exception("mandem user name is already taken");

        };


        var k=key.gentoken(username,email);

        var user = new User{
            username=username,
            email=email,
            token=k,
            password=password,
            followers=new List<Followers>{},
            createdAt=DateTime.UtcNow
        };


        collect.InsertOne(user);

         var response = new Responseuser(){
            id=user.id,
            username=username,
            email=user.email,
            token=k
        };
        
        return response;
        
    }

    

    public void follow(string id,string followerid)
    {
        var follow = new Followers{userid=followerid,Id=ObjectId.GenerateNewId().ToString()};

        var collect = getcollection<User>(collectionname);

        var filter = Builders<User>.Filter.Eq(u=>u.id,id);
        var update = Builders<User>.Update.Push(u=>u.followers,follow);

        collect.UpdateOne(filter,update);

    }

    public void unfollow(string id,string followerid)
    {
        var collect = getcollection<User>(collectionname);

        var filter = Builders<User>.Filter.Eq(u=>u.id,id);

        var update = Builders<User>.Update.PullFilter(u=>u.followers,f=>f.userid==followerid);

        collect.UpdateOne(filter,update);
    }


}
