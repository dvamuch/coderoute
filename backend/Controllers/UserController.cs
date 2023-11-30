using CodeRoute.Auth;
using CodeRoute.DTO;
using CodeRoute.Models;
using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CodeRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService) 
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("reg")]
        public async Task<IActionResult> RegUser([FromBody] UserLogInfo user)
        {
            User result = await _userService.RegUser(user);

            if (result != null)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> AuthUser([FromBody] UserLogInfo user)
        {
            User result = await _userService.AuthUser(user);

            if (result == null)
            {
                return BadRequest("Wrong password");
            }
            if (result.UserName == null || result.Email == null)
            {
                return BadRequest("User doesn't exist");
            }

            return Ok(new { token = CreateJWT(result) });
        }

        private string CreateJWT(User user)
        {
            var secretkey = AuthOptions.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var claims = new[] // NOTE: could also use List<Claim> here
			{
                new Claim(ClaimTypes.Name, user.UserName), // this will be "User.Identity.Name" value
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.UserId.ToString()) // this could the unique ID assigned to the user by a database
			};

            var token = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER, 
                audience: AuthOptions.AUDIENCE, 
                claims: claims, 
                expires: DateTime.Now.AddMinutes(60), 
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
