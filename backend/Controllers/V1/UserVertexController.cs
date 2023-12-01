using CodeRoute.Models;
using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeRoute.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class UserVertexController : ControllerBase
    {
        private readonly VertexService _vertexService;

        public UserVertexController(VertexService vertexService)
        {
            _vertexService = vertexService;
        }


        [HttpPost("{vertexId}/{statusId}")]
        public async Task<ActionResult<bool>> ChangeRouteStatus(int vertexId, int statusId)
        {
            int userId = await this.ParseToken();
            bool result = await _vertexService.ChangeStatus(vertexId, statusId, userId);

            if (result)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
