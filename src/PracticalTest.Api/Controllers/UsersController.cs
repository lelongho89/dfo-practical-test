using Microsoft.AspNetCore.Mvc;
using PracticalTestApi.Filters;
using PracticalTestApi.Models;
using PracticalTestApi.Services;
using PracticalTestApi.Services.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace PracticalTestApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ApiExceptionFilter]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            this._userService = userService;
        }


        // GET: api/users
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<User>), 200)]
        public IActionResult GetUsers()
        {
            return Ok(_userService.GetAllUsers());
        }

        // GET: api/users/5
        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(UserDto), 200)]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUser(id);
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public IActionResult CreateUser([FromBody] CreateUserDto model)
        {
            var createdUser = _userService.CreateUser(model);

            return StatusCode(201, createdUser);
        }

        // PUT: api/users/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(UserDto), 201)]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public IActionResult UpdateUser(int id, [FromBody] UpdateUserDto model)
        {
            model.Id = id;
            var updatedUser = _userService.UpdateUser(model);

            return StatusCode(201, updatedUser);
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ErrorDto), 400)]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
    }
}
