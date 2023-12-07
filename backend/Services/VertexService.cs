using CodeRoute.DAL.Repositories;
using CodeRoute.DTO;
using CodeRoute.Models;

namespace CodeRoute.Services
{
    public class VertexService
    {
        private readonly VertexRepository _vertexRepository;
        public VertexService(VertexRepository vertexRepository)
        {
            _vertexRepository = vertexRepository;
        }

        public async Task<List<VertexStatus>> GetAllVertexStatuses()
        {
            return (List<VertexStatus>)await _vertexRepository.GetAllVertexStatuses();
        }

        public async Task<NodeInfo> GetVertexById(int id)
        {
            return await GetVertexById(id, 1);
        }

        public async Task<NodeInfo> GetVertexById(int vertexId, int userId)
        {
            Vertex v = await _vertexRepository.GetVertex(vertexId);

            NodeInfo node = new NodeInfo()
            {
                VertexId = v.VertexId,
                RouteId = v.RouteId,
                Description = v.MarkdownPage,
                Title = v.Name
            };

            node.StatusId = await _vertexRepository.GetVertexStatusByUser(vertexId, userId);

            return node;
        }

        public async Task<bool> ChangeStatus(int vertexId, int statusId, int userId)
        {
            if (userId == 1) // user with id = 1 is special and he should not change statuses
            {
                return false;
            }

            var result = await _vertexRepository.ChangeRouteStatus(vertexId, statusId, userId);
            return result;
        }
    }
}
