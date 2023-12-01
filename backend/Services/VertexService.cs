using CodeRoute.DAL.Repositories;
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

        public async Task<Vertex> GetVertexById(int id)
        {
            return await _vertexRepository.GetVertex(id);
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
