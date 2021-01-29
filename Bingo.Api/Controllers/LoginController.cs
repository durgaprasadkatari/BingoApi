using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bingo.Api.Models;
using Bingo.Api.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Bingo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ILoginRepository<AdminLogin> _dataRepository;
        
        public LoginController(ILoginRepository<AdminLogin> dataRepository,IConfiguration config)
        {
            _dataRepository = dataRepository;
            _config = config;
        }

        [HttpPost]
        public IActionResult Login([FromBody] AdminLogin login)
        {
            var user = _dataRepository.Get(login.Username, login.Password);
            IActionResult response = Unauthorized();
            if (user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { playerid = user.Playerid, token = tokenStr });
            }

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Register([FromBody] AdminLogin loginDetails)
        {
            if (loginDetails is null)
            {
                return BadRequest("loginDetails is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dataRepository.Add(loginDetails);
            return Ok();
        }

        private string GenerateJSONWebToken(AdminLogin userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userInfo.Username),
                new Claim(JwtRegisteredClaimNames.UniqueName,userInfo.Playerid.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,userInfo.Playerid.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var encodedtoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedtoken;
        }

        
    }
}
