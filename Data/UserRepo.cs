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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void AddUser(User p_user)
        {
            if (p_user == null)
            {
                throw new System.ArgumentNullException(nameof(p_user));
            }
            _context.Users.Add(p_user);
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