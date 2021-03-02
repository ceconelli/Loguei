using System.Collections.Generic;
using System.Threading.Tasks;
using Loguei.Data;
using Loguei.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loguei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UsersController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public ActionResult <IEnumerable<User>> GetAllUsers()
        {
            var allUsers = _userRepo.GetUsers();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public ActionResult <IEnumerable<User>> GetUserByEmail(int id)
        {
            var user = _userRepo.GetUserByEmail(id);
            return Ok(user);
        }
        [HttpPost]
        public ActionResult<User> PostUser(User newUser)
        {
            _userRepo.AddUser(newUser);
            return Ok(newUser);
        }

    }
}