using Microsoft.AspNetCore.Mvc;
using Domain.Users;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        
        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost]
        [Authorize(Roles = "CBF")]
        public IActionResult Create(CreateUserRequest request)
        {
            var response = _usersService.Create(
                request.Name,
                request.Profile,
                request.Email,
                request.Password
            );

            if (!response.IsValid)
            {
                return BadRequest(response.Errors);
            }
            
            return NoContent();
        }

        [HttpGet("me")]
        [Authorize]
        public IActionResult GetById()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _usersService.GetById(Guid.Parse(userId));
            
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user);
        }
    }
}
