using Microsoft.AspNetCore.Mvc;


[ApiController]
public class Authcontoller:ControllerBase{


    private readonly Iauth _auth;
    private readonly Ifollow follow;

    public Authcontoller(Iauth auth,Ifollow follow)
    {
        _auth = auth;
        this.follow = follow;
    }

    [HttpPost("api/login")]

    public ActionResult login(string name,string password){

        var response = _auth.login(name,password);

        return Ok(response);
    }


    [HttpPost("api/register")]

    public ActionResult register(string username,string email,string password){

        var response =  _auth.register(username,email,password);

        return Ok(response);
    }

    [HttpPost("api/follow")]

    public ActionResult followuser(string id,string followerid){

        follow.follow(id,followerid);
        return Ok();

    }

    [HttpDelete("api/follow")]

    public ActionResult unfollowuser(string id,string followerid){

        follow.unfollow(id,followerid);

        follow.unfollow(id,followerid);    
        return Ok();
        
    }



}
