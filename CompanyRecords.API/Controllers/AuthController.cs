using CompanyRecords.API.Models.DTO;
using CompanyRecords.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CompanyRecords.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtServices _jwtServices;

        public AuthController(JwtServices jwtServices)
        {
            _jwtServices = jwtServices;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Login user)
        {
            if (user.UserName == "admin" && user.Password == "password123")
            {
                var token = GenerateJwtToken(user);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(Login user)
        {
            var userJwt = new Models.Entity.User
            {
                Id = 1, // This should be replaced with actual user ID from your database
                UserName = user.UserName
            };

            return  _jwtServices.GenerateToken(userJwt);
        }
    }
}
