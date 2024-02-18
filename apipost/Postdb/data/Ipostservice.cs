using MongoDB.Driver;
using Postdb.data;
using Postdb.model;

public interface Ipost{

   
    List<Post> getpost();

    List<Post> getpostuser(string id);

    Post GetsinglePost(string id);

    void Createpost(Postrequest post,string user);

    void updatepost(Post post);

    void deletepost(string id);

    public UpdateResult updatepost1(string id,string title,string body);


}

