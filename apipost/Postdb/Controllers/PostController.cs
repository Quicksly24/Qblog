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

    [AllowAnonymous]
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
     
    [AllowAnonymous]
    [HttpGet ("api/Post/{id:int}")]
    public ActionResult get1post(string request){

       var response= posts.GetsinglePost(request);
       return Ok(response);

    }
    [AllowAnonymous]
    [HttpPut ("api/Post/")]
    public ActionResult updatepost(string id,string title,string body){

      var request = new Post(){
         id=id,
         title=title,
         body=body,
         Username="jeff"
            
      };

            posts.updatepost(request);
            return Ok("success");

    }

     [AllowAnonymous]
     [HttpDelete ("api/Post/")]
    public ActionResult deletepost(string id){

       posts.deletepost(id);
       return Ok("success");

    }


}