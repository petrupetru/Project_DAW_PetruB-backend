using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_DAW_PetruB.Managers;
using Project_DAW_PetruB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Project_DAW_PetruB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthManager authManager;

        public AuthController(IAuthManager authManager)
        {
            this.authManager = authManager;
        }


        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] RegisterModel registerModel)
        {
            await authManager.Signup(registerModel);
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var tokens = await authManager.Login(loginModel);
            if(tokens != null)
            {
                return Ok(tokens?.AccessToken);
            }
            else
            {
                return BadRequest("FailedToLogin");
            }
        }
    }

    
}
