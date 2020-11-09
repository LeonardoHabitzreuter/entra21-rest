using Microsoft.AspNetCore.Mvc;
using Domain.Users;

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
    }
}
