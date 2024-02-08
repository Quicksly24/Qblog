using Postdb.model;
namespace Postdb.data;


public class Postsevices : Ipost
{    
    private readonly List<Post> posts = new List<Post>(){ 

         new Post()
        {
            id = "1",Username = "JohnDoe", title = "The Importance of Mindfulness in Everyday Life", body = "Mindfulness is the practice of paying attention to the present moment.",
        },
          new Post()
        {
            id = "2",Username = "John", title = "Everyday Life", body = "Mindfulness .",
        },
          new Post()
        {
            id = "3",Username = "Doe", title = "The Importance ", body = "Mind to the present moment.",
        },
          new Post()
        {
            id = "4",Username = "Jay", title = " Mindfulness in Everyday Life", body = "fulness is the practice.",
        },
          new Post()
        {
            id = "5",Username = "love", title = "The love of my Life", body = "Death is the end",
        },


    };
    public void Createpost(Postrequest post)
    {
        var pop =new Post(){
            id=Guid.NewGuid().ToString(),
            title=post.title,
            body=post.body,
            Username="",
            CreatedAt=DateTime.UtcNow

        };

        posts.Add(pop);
    }

   

    public void deletepost(string id)
    {
        string ids=id.ToString();
        var item = posts.Single(x => x.id==ids);
        posts.Remove(item);
    }

    public List<Post> getpost()
    {
        return posts.ToList();
    }

    public Post GetsinglePost(string id)
    {
        string ids=id.ToString();
        return posts.Where(x=>x.id == ids).Single();
    }

    public void updatepost(Post post)
    {
        var index = posts.FindIndex(x=>x.id==post.id);
        posts[index]= post;
    }
}