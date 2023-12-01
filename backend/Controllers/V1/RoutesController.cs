using CodeRoute.DTO;
using CodeRoute.Auth;
using CodeRoute.Models;
using CodeRoute.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;

namespace CodeRoute.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class RoutesController : ControllerBase
    {
        private readonly RouteService _routeService;

        public RoutesController(RouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Roadmap>>> GetList()
        {
            int userId = await ParseToken();
            return await _routeService.GetRoutes(userId);
        }

        [HttpGet("{routId}", Name = "GetRouteInfoById")]
        public async Task<ActionResult<RouteInfo>> GetRouteInfoById(int routId)
        {
            int userId = await ParseToken();
            RouteInfo result;

            result = await _routeService.GetRouteByIdForUser(routId, userId);

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
            JwtSecurityToken jwtToken;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                jwtToken = (JwtSecurityToken)validatedToken;
            }
            catch (Exception)
            {
                return 1;
            }

            return int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
        }
    }
}