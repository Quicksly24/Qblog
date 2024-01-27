using Dapper;
using Microsoft.Data.SqlClient;
using Postdb.model;
namespace Postdb.data;



public class Dataacess : Ipost
{
    public string connectionstring = "Server=.\\SQLEXPRESS;Database=Qblog;Trusted_Connection=True;Trust Server Certificate=True";
    public string readquery = "select * from posts";

    public string singlereadquery = "select * from posts where id = @id";

    public string insertquery= "INSERT INTO posts(id, Username, title, body) VALUES (@id, @Username, @title, @body)";


    public string updatequery= "UPDATE posts SET Username = @Username, title = @title , body = @body WHERE id = @id";

    public string deletequery="DELETE FROM posts WHERE id = @id";

    List<Post> _products = new List<Post>();

    public void Createpost(Post post)
    {
        using(var connection = new SqlConnection(connectionstring)){
                    
           connection.Execute(insertquery,post);
        }
    }

    public void Createpost(Postrequest post)
    {
        throw new NotImplementedException();
    }

    public void deletepost(int ids)
    {
        using(var connection = new SqlConnection(connectionstring)){
                    
            connection.Execute(deletequery,new{id=ids});

        }
        
    }

    public List<Post> getpost()
    {
        using(var connection = new SqlConnection(connectionstring)){
                    
            return connection.Query<Post>(readquery).ToList();

        }
    }

    public Post GetsinglePost(int ids)
    {
        using(var connection = new SqlConnection(connectionstring)){
                    
            return connection.QuerySingle<Post>(singlereadquery,new{id=ids});

        }
    }

    public void updatepost(Post post)
    {
         using(var connection = new SqlConnection(connectionstring)){
                    

             connection.Execute(updatequery,post);
           

        }
        
    }
}

