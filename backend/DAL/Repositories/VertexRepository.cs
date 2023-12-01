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

        public async Task<bool> AddVertex(Vertex vertex)
        {
            try
            {
                await _context.Vertexes.AddAsync(vertex);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<UserVertex>> GetAllVertexFromRoute(int routeId, int userId)
        {
            return await _context.UserVertexes
                .Where(uv => uv.User.UserId == userId)
                .Include(uv => uv.Vertex)
                .Include(uv => uv.Status)
                .Where(uv => uv.Vertex.RouteId == routeId)
                .ToListAsync();
        }

        public async Task<List<Vertex>> GetAllVertexFromRoute(int routeId)
        {
            return await _context.Vertexes
                .Where(v => v.RouteId == routeId)
                .ToListAsync();
        }


        public async Task <List<VertexConnection>> GetAllVertexConnectionsInRoute(int routeId)
        {
            return await _context.VertexConnections
                .Where(uv => uv.CurrentVertex.RouteId == routeId || uv.CurrentVertex.RouteId == 0)
                .Include(uv => uv.CurrentVertex)
                .Include(uv => uv.PreviousVertex)
                .ToListAsync();
        }


        public async Task<IEnumerable<VertexStatus>> GetAllVertexStatuses()
        {
            return await _context.VertexStatuses.ToListAsync();
        }

        public async Task<Vertex> GetVertex(int id)
        {
            return await _context.Vertexes.FirstOrDefaultAsync(v => v.VertexId == id);
        }
    }
}
