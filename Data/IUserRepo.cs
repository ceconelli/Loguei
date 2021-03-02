using System.Collections.Generic;
using System.Threading.Tasks;
using Loguei.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loguei.Data
{
    public interface IUserRepo
    {
        IEnumerable<User> GetUsers();
        User GetUserByEmail(int id);
        Task<ActionResult<bool>> AddUser(User p_user);
        bool DeleteUser(string p_email);
    }
}