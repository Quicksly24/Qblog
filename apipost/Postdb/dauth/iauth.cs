

public interface Iauth{

   
    public Responseuser register(string username,string email,string password);

    public Responseuser login(string username,string password);

    public string refresh(string refeshtoken,string jwt);



}