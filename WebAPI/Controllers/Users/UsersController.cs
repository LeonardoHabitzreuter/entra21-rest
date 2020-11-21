using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        
        public UsersController()
        {
            _usersService = new UsersService();
        }

        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            if(request.Profile == Profile.CBF && request.Password != "admin123")
            {
                return Unauthorized();
            }
            
            var response = _usersService.Create(request.Name, request.Profile);

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return Ok(response.Id);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _usersService.GetById(id);
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
    }
}
