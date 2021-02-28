using System.Collections.Generic;
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

    }
}