using System.Collections.Generic;
using System.Threading.Tasks;
using Loguei.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loguei.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetUsers();
        User GetUserByEmail(int id);
        void AddUser(User p_user);
        void UpdateUser(User p_user);
        void DeleteUser(User userToBeRemoved);
    }
}