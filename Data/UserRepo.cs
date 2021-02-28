using System.Collections.Generic;
using Loguei.Models;

namespace Loguei.Data
{
    public class UserRepo : IUserRepo
    {
        public bool AddUser(User p_user)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteUser(string p_email)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(string p_email)
        {
            return new User{Name = "gustavo",Password = "1234",Email = "gustavo@hotmail.com"};
        }

        public IEnumerable<User> GetUsers()
        {
            var allUsers = new List<User> 
            {
                new User{Name = "gustavo",Password = "1234",Email = "gustavo@hotmail.com"}
            };
            return allUsers;
        }
    }
}