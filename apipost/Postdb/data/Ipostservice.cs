using MongoDB.Driver;
using Postdb.data;
using Postdb.model;

public interface Ipost{

    List<Post> getpost();

    Post GetsinglePost(string id);

    void Createpost(Postrequest post);

    void updatepost(Post post);

    void deletepost(string id);

    public UpdateResult updatepost1(string id,string title,string body);


}

