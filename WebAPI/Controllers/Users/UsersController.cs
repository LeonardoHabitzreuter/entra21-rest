﻿using Microsoft.AspNetCore.Mvc;
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

            // return BadRequest("O nome está inválido");

            var userId = _usersService.Create(request.Name, request.Profile);
            return Ok(userId);
        }
    }
}
