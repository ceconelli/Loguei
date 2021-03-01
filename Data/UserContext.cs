using Loguei.Models;
using Microsoft.EntityFrameworkCore;

namespace Loguei.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }

}