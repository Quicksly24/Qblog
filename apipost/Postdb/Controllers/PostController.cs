using Microsoft.AspNetCore.Mvc;
using Postdb.model;
using Postdb.data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
namespace Postdb.Controllers;

[Authorize]
[ApiController]
public class Postcontroller:ControllerBase{

    private readonly Ipost posts;
    private readonly Ilike like;
    private readonly ILogger ilogger;

    private readonly IConfiguration config;

    public Postcontroller(Ipost posts,Ilike like,ILogger<Postcontroller> logger,IConfiguration config)
    {
        this.posts = posts;
        this.like = like;
        ilogger=logger;

        this.config=config;
    }

  
    [HttpPost ("api/Post")]
    public ActionResult Createpost(Postrequest request){


       var user= User.FindFirstValue(ClaimTypes.Name);
       posts.Createpost(request,user);

       return Ok("success");

    }


    [AllowAnonymous]
    [HttpGet ("api/Post")]
    public ActionResult getallpost(){

       var response = posts.getpost();

       ilogger.LogInformation("got users successfully");

       return Ok(response);

    }

    [AllowAnonymous]
    [HttpGet ("api/Post/user/{id}")]
    public ActionResult getallpostbyuser(string id){

       var response = posts.getpostuser(id);

       ilogger.LogInformation("got all '{0}' post successfully",id);

       return Ok(response);

    }
     
   
    [HttpGet ("api/Post/{id}")]
    public ActionResult get1post(string id){

       var response= posts.GetsinglePost(id);
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