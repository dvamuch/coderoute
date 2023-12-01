using CodeRoute.Models;
using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeRoute.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserRouteController : ControllerBase
    {
        private readonly RouteService _routeService;

        public UserRouteController(RouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpPost("{routeId}/{statusId}")]
        public async Task<ActionResult<bool>> ChangeVertexStatus(int routeId, int statusId)
        {
            int userId = await this.ParseToken();
            bool result = await _routeService.ChangeStatus(routeId, statusId, userId);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
