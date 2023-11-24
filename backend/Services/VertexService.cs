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

        public List<VertexStatus> GetAllVertexStatuses()
        {
            return _vertexRepository.GetAllVertexStatuses().ToList();
        }

        public Vertex GetVertexById(int id)
        {
            return _vertexRepository.GetVertex(id);
        }
    }
}
