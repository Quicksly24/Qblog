using Postdb.data;
using Postdb.model;

public interface Ipost{

    List<Post> getpost();

    Post GetsinglePost(int id);

    void Createpost(Post post);

    void updatepost(Post post);

    void deletepost(int id);


}

