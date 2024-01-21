using Microsoft.AspNetCore.Mvc;
using Postdb.model;
using Postdb.data;
namespace Postdb.Controllers;

[ApiController]
public class Postcontroller:ControllerBase{

    private readonly Ipost posts;

    public Postcontroller(Ipost posts)
    {
        this.posts = posts;
    }

    [HttpPost ("api/Post")]
    public ActionResult Createpost(Post request){

       posts.Createpost(request);

       return Ok("success");

    }

    [HttpGet ("api/Post")]
    public ActionResult getallpost(){

      //  var response = posts.getpost();
       return Ok();

    }

    [HttpGet ("api/Post/{id:int}")]
    public ActionResult get1post(int request){

      //  var response= posts.GetsinglePost(request);
       return Ok();

    }

    [HttpPut ("api/Post/")]
    public ActionResult updatepost(Post request){

            posts.updatepost(request);
            return Ok("success");

    }

     [HttpDelete ("api/Post/{id:int}")]
    public ActionResult deletepost(int id){

       posts.deletepost(id);
       return Ok("success");

    }


}