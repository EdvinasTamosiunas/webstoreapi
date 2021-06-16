using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DataTransferObjects;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using WebstoreAPI.Contracts;
using WebstoreAPI.Services;

namespace API.Controllers
{
    
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUriService _uriService;

        public UserController(IUserService userService, IUriService uriService)
        {
            _userService = userService;
            _uriService = uriService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(ApiRoutes.Users.Login)]
        public async Task<IActionResult> AttemptUserLogin([FromBody] LoginRequest userRequest)
        {
            var user = await _userService.CheckLoginInfo(userRequest);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        [Route(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetUsers();
            if (users == null) return NoContent();
            return Ok(users);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut]
        [Route(ApiRoutes.Users.UpdateUser)]
        public async Task<IActionResult> UpdateUser([FromBody] User user)
        {
            var updatedUser = await _userService.UpdateUser(user);
            if (updatedUser == null) return NotFound();
            return Ok(updatedUser);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost]
        [Route(ApiRoutes.Users.AddUser)]
        public async Task<IActionResult> AddUser([FromBody] UserRequest userRequest)
        {
            var user = await _userService.CreateUser(userRequest);
            if (user == null) return BadRequest();
            var locationUri = _uriService.GetUserUri(user.Id.ToString());
            return Created(locationUri,user);
        }
    }
}