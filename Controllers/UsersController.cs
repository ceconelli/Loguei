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

        [HttpGet("{id}",Name="GetUserByEmail")]
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
            return CreatedAtRoute(nameof(GetUserByEmail),new {id = userModel.Id},_mapper.Map<UserReadDto>(userModel));
            // return Ok(_mapper.Map<UserReadDto>(userModel));
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, UserUpdateDto userUpdateDto)
        {  
            var userFromDB = _userRepo.GetUserByEmail(id);
            if (userFromDB == null)
            {
                return NotFound();
            }
            _mapper.Map(userUpdateDto,userFromDB);
            _userRepo.UpdateUser(userFromDB);
            _userRepo.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteUser(int id)
        {
            var userToBeRemoved = _userRepo.GetUserByEmail(id);
            if (userToBeRemoved == null)
            {
                return NotFound();
            }
            _userRepo.DeleteUser(userToBeRemoved);
            _userRepo.SaveChanges();
            return NoContent();
        }

    }
}