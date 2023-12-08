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
        public async Task<ActionResult<List<RoutesWithDirections>>> GetList()
        {
            int userId = await this.ParseToken();
            return await _routeService.GetRoutes(userId);
        }

        [HttpGet("{routId}", Name = "GetRouteInfoById")]
        public async Task<ActionResult<RouteInfo>> GetRouteInfoById(int routId)
        {
            int userId = await this.ParseToken();
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

    }
}