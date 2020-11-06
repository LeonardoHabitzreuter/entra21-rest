using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Users;

namespace WebAPI.Controllers.Users
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create(CreateUserRequest request)
        {
            if(request.Profile == Profile.CBF && request.Password != "admin123")
            {
                return Unauthorized();
            }

            var user = new User(request.Name, request.Profile);
            return Ok(user.Id);
        }
    }
}
