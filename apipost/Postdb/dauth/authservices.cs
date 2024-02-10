

// public class Authservces : Iauth
// {

//     private readonly Itoken key;

//     public Authservces(Itoken key)
//     {
//         this.key = key;
//     }

//     public readonly static List<User3> users = new List<User3>();

//     public User2 login1(string username,string password)
//     {
//      var user = users.FirstOrDefault(u => u.username == username && u.password == password);

//     if (user != null)
//     {
//         var token = key.gentoken(username,password);

//         var response = new User2(){
//             id=user.id,
//             username=username,
//             email=user.email,
//             token=token

//         };
        
//         return response;
//     }
//     else
//     {
//         return null;
//     }
    
//     }

//     public User2 register1(string username,string email,string password)
//     {
//         bool userExists = users.Any(u => u.username == username || u.email == email);
//         if (userExists)
//         {
//           return null;
//         }

//         var token = key.gentoken(username,password);

//         var user = new User3{
//             id=Guid.NewGuid(),
//             username=username,
//             email=email,
//             password=password,
//             token=token,
//             createdAt=DateTime.UtcNow
//         };

//         users.Add(user);

//          var response = new User2(){
//             id=user.id,
//             username=username,
//             email=user.email,
//             token=token
//         };
        
//         return response;
        
//     }

//     public Responseuser register(string username, string email, string password)
//     {
//         throw new NotImplementedException();
//     }

//     public Responseuser login(string username, string password)
//     {
//         throw new NotImplementedException();
//     }
// }