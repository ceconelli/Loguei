using System.Collections.Generic;
using Loguei.Models;

namespace Loguei.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserByEmail(string p_email);
        bool AddUser(User p_user);
        bool DeleteUser(string p_email);
    }
}