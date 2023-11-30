using CodeRoute.DTO;
using CodeRoute.Models;
using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{routId}/{userId}", Name = "/get")]
        public async Task<ActionResult<RouteInfo>> GetRouteInfoById(int routId, int userId)
        {
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
            var result = await _routeService.GetRouteById(routId);

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
