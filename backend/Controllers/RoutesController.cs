using CodeRoute.DTO;
using CodeRoute.Auth;
using CodeRoute.Models;
using CodeRoute.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

using System.IdentityModel.Tokens.Jwt;

namespace CodeRoute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoutesController : ControllerBase
    {
        private readonly RouteService _routeService;

        public RoutesController(RouteService routeService) 
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Route>>> GetList()
        {
            return await _routeService.GetRoutes();
        }

        [Authorize]
        [HttpGet("{routId}/{userId}", Name = "/get")]
        public async Task<ActionResult<RouteInfo>> GetRouteInfoById(int routId, int userId)
        {
            int token = await ParseToken();
            var result =  await _routeService.GetRouteByIdForUser(routId, userId);

            if (result == null)
            {
                return NotFound("Такого нету");
            }

            return Ok(result);
        }

        [HttpGet("{routId}", Name = "/get2")]
        public async Task<ActionResult<RouteInfo>> GetRouteInfoById(int routId)
        {
            int userId = await ParseToken();
            RouteInfo result;

            if (userId != 0)
                result = await _routeService.GetRouteByIdForUser(routId, userId);
            else
                result = await _routeService.GetRouteById(routId);

            if (result == null)
            {
                return NotFound("Такого нету");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddRoute([FromBody] Roadmap roadmap)
        {
            bool result = await _routeService.AddRoute(roadmap);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        private async Task<int> ParseToken()
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (HttpContext.Request.Headers.Authorization.Count == 0)
            {
                return 0;
            }
            var token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];

            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuer = false,
                ValidateAudience = false
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            return int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
        }
    }
}