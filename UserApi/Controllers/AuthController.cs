using Core.Implementations;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly string _jwtKey;
        private readonly string _audience;
        private readonly string _issuer;
        private readonly GetUserByUsername _getUserByUsername;

        public AuthController(IConfiguration configuration, GetUserByUsername getUserByUsername)
        {
            _getUserByUsername = getUserByUsername;
            _jwtKey = configuration?["JwtSettings:SecretKey"];
            _audience = configuration?["JwtSettings:ValidAudience"];
            _issuer = configuration?["JwtSettings:ValidIssuer"];
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _getUserByUsername.Execute(request.Username);
            if (user == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            if (user.Password == request.Password)
            {
                var claims = new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _issuer,
                    audience: _audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(3),
                    signingCredentials: creds
                );

                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return Unauthorized("Invalid email or password.");
        }
    }
}
