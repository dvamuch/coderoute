using CodeRoute.Models;
using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeRoute.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserRouteController
    {
        private readonly RouteService _routeService;

        public UserRouteController(RouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet(Name = "GetStatusList")]
        public async Task<ActionResult<List<RouteStatus>>> GetStatusList()
        {
            return await _routeService.GetStatuses();
        }
    }
}
