using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


[ApiController]
public class Authcontoller:ControllerBase{


    private readonly Iauth _auth;
    private readonly Ifollow follow;

    private readonly Validator _validator;

    public Authcontoller(Iauth auth,Ifollow follow,IOptions<Validator> validator)
    {
        _auth = auth;
        this.follow = follow;
        _validator=validator.Value;
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

    [AllowAnonymous]
    [HttpPost("api/refresh")]

    public ActionResult refresh([FromBody]Refreshobject refresh){

        var response=_auth.refresh(refresh.refreshtoken,refresh.expjwt);
        return Ok(response);

    }

     [Authorize]
     [HttpPost("api/follow")]

    public ActionResult followuser(string id,string followerid){

        follow.follow(id,followerid);
        return Ok();

    }

    [Authorize]
    [HttpDelete("api/follow")]

    public ActionResult unfollowuser(string id,string followerid){


        follow.unfollow(id,followerid);    
        return Ok();
        
    }

    
}
