using CodeRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeRoute.DAL.Repositories
{
    public class VertexRepository
    {
        private readonly Context _context;
        public VertexRepository(Context context)
        {
            _context = context;
        }


        public IEnumerable<UserVertex> GetAllVertexFromRoute(int routeId, int userId)
        {
            return _context.UserVertexes
                .Where(uv => uv.User.UserId == userId)
                .Include(uv => uv.Vertex)
                .Include(uv => uv.Status)
                .Where(uv => uv.Vertex.RouteId == routeId);
        }

        public IEnumerable<Vertex> GetAllVertexFromRoute(int routeId)
        {
            return _context.Vertexes
                .Where(v => v.RouteId == routeId);
        }


        public IEnumerable<VertexConnection> GetAllVertexConnectionsInRoute(int routeId)
        {
            return _context.VertexConnections
                .Where(uv => uv.CurrentVertex.RouteId == routeId || uv.CurrentVertex.RouteId == 0)
                .Include(uv => uv.CurrentVertex)
                .Include(uv => uv.PreviousVertex);
        }


        public IEnumerable<VertexStatus> GetAllVertexStatuses()
        {
            return _context.VertexStatuses;
        }

        public Vertex GetVertex(int id)
        {
            return _context.Vertexes.FirstOrDefault(v => v.VertexId == id);
        }
    }
}
