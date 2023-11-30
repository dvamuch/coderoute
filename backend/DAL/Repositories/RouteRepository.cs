using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Extensions.Logging;
using CodeRoute.Logs;
using Microsoft.EntityFrameworkCore;

namespace CodeRoute.DAL.Repositories
{
    public class RouteRepository
    {
        private readonly Context _context;
        private Logger<RouteRepository> _logger;

        public RouteRepository(Context context, Logger<RouteRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<Models.Route>> GetAllRoutes()
        {
            try
            {
                return await _context.Routes.Skip(1).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with add new route in bd", null);
            }

            return null;
        }

        internal async Task<Models.Route?> GetRouteById(int id)
        {
            return await _context.Routes.FirstOrDefaultAsync(route => route.RouteId == id && id != 1);
        }

        public async Task<bool> AddRoute(Models.Route route)
        {
            try
            {
                await _context.Routes.AddAsync(route);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException, "Error with add new route in bd", null);
                return false;
            }

            return true;
        }

    }
}
