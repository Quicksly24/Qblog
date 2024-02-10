using Microsoft.AspNetCore.Mvc;
using Postdb.model;
using Postdb.data;
using Microsoft.AspNetCore.Authorization;
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

           var response = posts.updatepost1(id,title,body);
            return Ok(response);

    }

     [AllowAnonymous]
     [HttpDelete ("api/Post/")]
    public ActionResult deletepost(string id){

       posts.deletepost(id);
       return Ok("success");

    }

      [AllowAnonymous]
    [HttpPost("api/Post/like")]

    public ActionResult likepost(string postid,string user){


      var response = like.Likepost(postid,user);  
      return Ok(response);

    }
     [AllowAnonymous]
    [HttpDelete("api/Post/like")]

    public ActionResult unlikepost(string likeid){

      var response=like.unLikepost(likeid);

      return Ok(response);

    }
      [AllowAnonymous]
     [HttpGet("api/Post/like")]

     public ActionResult likepostcount(string postid){
       
      var response = like.postcount(postid);
      return Ok(response);

    }


}