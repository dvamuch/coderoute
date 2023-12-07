using CodeRoute.Services;
using Microsoft.AspNetCore.Mvc;

namespace CodeRoute.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    public class VertexController : Controller
    {
        private VertexService _vertexService;
        public VertexController(VertexService vertexService)
        {
            _vertexService = vertexService;
        }


        [HttpGet(Name = "/Statuses")]
        public async Task<IActionResult> GetStatusList()
        {
            var res = await _vertexService.GetAllVertexStatuses();

            if (res == null || res.Count == 0)
            {
                return NotFound("Ничего нет");
            }

            return Ok(res);
        }

        [HttpGet("{vertexId}", Name = "/getVertex")]
        public async Task<IActionResult> GetVertexById(int vertexId)
        {
            var res = await _vertexService.GetVertexById(vertexId);

            if (res == null)
            {
                return NotFound("Ничего нет");
            }

            return Ok(res);
        }
    }
}
