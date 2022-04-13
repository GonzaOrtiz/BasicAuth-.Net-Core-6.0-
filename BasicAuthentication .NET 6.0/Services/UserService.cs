using BasicAuthentication_.NET_6._0.Models;
using System.Collections.Generic;
using System.Linq;

namespace BasicAuthentication_.NET_6._0.Services
{
    public class UserService : IUserService
    {
        readonly List<User> UserList = new()
        {
            new User { Id = 1, FullName = "Pablo Juarez", Email = "pablo@gmail.com", Password = "123456" },
            new User { Id = 2, FullName = "Marcos Shocklender", Email = "marcos@gmail.com", Password = "123456" },
            new User { Id = 3, FullName = "Gabriela Riquelme", Email = "gaby@gmail.com", Password = "123456" },
            new User { Id = 4, FullName = "Robertina Shautrack", Email = "robertina@gmail.com", Password = "123456" }
        };
        public bool isUser(string email, string password)
        {
            var userFind = UserList.Where(u => u.Email == email && u.Password == password);
            if (userFind.Any()) return true;
            else return false;
        }
    }
}
