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
    }
}
