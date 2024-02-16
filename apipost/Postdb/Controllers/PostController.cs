using Microsoft.AspNetCore.Mvc;
using Postdb.model;
using Postdb.data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace Postdb.Controllers;

[Authorize]
[ApiController]
public class Postcontroller:ControllerBase{

    private readonly Ipost posts;
    private readonly Ilike like;

    public Postcontroller(Ipost posts,Ilike like)
    {
        this.posts = posts;
        this.like = like;
    }

  
    [HttpPost ("api/Post")]
    public ActionResult Createpost(Postrequest request){


       var user= User.FindFirstValue(ClaimTypes.Name);
       posts.Createpost(request,user);

       return Ok(user);

    }


    [AllowAnonymous]
    [HttpGet ("api/Post")]
    public ActionResult getallpost(){

       var response = posts.getpost();
       return Ok(response);

    }
     
  
    [HttpGet ("api/Post/{id:int}")]
    public ActionResult get1post(string request){

       var response= posts.GetsinglePost(request);
       return Ok(response);

    }
    
    [HttpPut ("api/Post/")]
    public ActionResult updatepost(string id,string title,string body){

           var response = posts.updatepost1(id,title,body);
            return Ok(response);

    }

     
     [HttpDelete ("api/Post/")]
    public ActionResult deletepost(string id){

       posts.deletepost(id);
       return Ok("success");

    }

     
    [HttpPost("api/Post/like")]

    public ActionResult likepost(string postid,string user){


      var response = like.Likepost(postid,user);  
      return Ok(response);

    }

     
    [HttpDelete("api/Post/like")]

    public ActionResult unlikepost(string likeid){

      var response=like.unLikepost(likeid);

      return Ok(response);

    }
    
     [HttpGet("api/Post/like")]

     public ActionResult likepostcount(string postid){
       
      var response = like.postcount(postid);
      return Ok(response);

    }


}