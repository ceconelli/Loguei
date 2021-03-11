using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Loguei.Data;
using Loguei.Dtos;
using Loguei.Models;
using Microsoft.AspNetCore.Mvc;

namespace Loguei.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController:ControllerBase
    {
        private readonly IUserRepo _userRepo;

        private readonly IMapper _mapper;

        public UsersController(IUserRepo userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<UserReadDto>> GetAllUsers()
        {
            var allUsers = _userRepo.GetUsers();
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(allUsers));
        }

        [HttpGet("{id}")]
        public ActionResult <IEnumerable<UserReadDto>> GetUserByEmail(int id)
        {
            var user = _userRepo.GetUserByEmail(id);
            return (user != null ? Ok(_mapper.Map<UserReadDto>(user)) : NotFound()); 
        }
        [HttpPost]
        public ActionResult<UserReadDto> CreateUser([FromBody]UserCreateDto newUser)
        {
            // string body = Request.Body.ReadAsync(;
            var userModel = _mapper.Map<User>(newUser);
            _userRepo.AddUser(userModel);
            _userRepo.SaveChanges();
            return Ok(userModel);
        }

    }
}