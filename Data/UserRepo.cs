using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loguei.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loguei.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _context;

        public UserRepo(UserContext userContext)
        {
            _context = userContext;
        }
        public async Task<ActionResult<bool>> AddUser(User p_user)
        {
            _context.Users.Add(p_user);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteUser(string p_email)
        {
            throw new System.NotImplementedException();
        }

        public User GetUserByEmail(int id)
        {
            return _context.Users.FirstOrDefault(p => id.Equals(p.Id));
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }
    }
}