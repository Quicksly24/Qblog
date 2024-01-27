using Microsoft.AspNetCore.Mvc;


[ApiController]
public class Authcontoller:ControllerBase{


    private readonly Iauth _auth;

    public Authcontoller(Iauth auth)
    {
        _auth = auth;
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



}