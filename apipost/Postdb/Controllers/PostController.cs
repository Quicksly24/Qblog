using Microsoft.AspNetCore.Mvc;
using Postdb.model;
using Postdb.data;
using Microsoft.AspNetCore.Authorization;
namespace Postdb.Controllers;

[Authorize]
[ApiController]
public class Postcontroller:ControllerBase{

    private readonly Ipost posts;

    public Postcontroller(Ipost posts)
    {
        this.posts = posts;
    }

    [HttpPost ("api/Post")]
    public ActionResult Createpost(Postrequest request){

       posts.Createpost(request);

       return Ok("success");

    }


    [AllowAnonymous]
    [HttpGet ("api/Post")]
    public ActionResult getallpost(){

       var response = posts.getpost();
       return Ok(response);

    }

    [HttpGet ("api/Post/{id:int}")]
    public ActionResult get1post(int request){

       var response= posts.GetsinglePost(request);
       return Ok(response);

    }

    [HttpPut ("api/Post/")]
    public ActionResult updatepost(string id,string title,string body){

      var request = new Post(){
         id=id,
         title=title,
         body=body,
            
      };

            posts.updatepost(request);
            return Ok("success");

    }

     [HttpDelete ("api/Post/{id:int}")]
    public ActionResult deletepost(int id){

       posts.deletepost(id);
       return Ok("success");

    }


}