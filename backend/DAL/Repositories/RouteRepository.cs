using CodeRoute.Models;
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


        public async Task<List<Models.RouteStatus>> GetStatuses()
        {
            try
            {
                return await _context.RouteStatuses.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with add new route in bd", null);
            }

            return null;
        }

        public async Task<List<Direction>> GetAllDirections()
        {
            return await _context.Directions.ToListAsync();
        }

        public async Task<List<Models.Route>> GetRoutesByDirection(int directId)
        {
            return await _context.DirectionRoutes
                .Include(dr =>dr.Route)
                .Where(dr => dr.DirectionId == directId)
                .Select(dr => dr.Route)
                .ToListAsync();
        }

        public async Task<List<DirectionRoute>> GetRoutesWithDirections()
        {
            return await _context.DirectionRoutes
                .Include(dr => dr.Direction)
                .Include(dr => dr.Route)
                .GroupBy(dr => dr.Direction)
                .Select(g => g.First())
                .ToListAsync();
        }

        public async Task<int> GetStatusIdByIds(int routeId, int userId)
        {
            try
            {
                var userRoute = await _context.UserRoutes
                    .Include(ur => ur.RouteStatus)
                    .FirstOrDefaultAsync(ur => ur.RouteId == routeId && ur.UserId == userId);

                if (userRoute == null)
                {
                    return 0;
                }

                return userRoute.RouteStatus.RouteStatusId;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with get status by ids", null);
            }

            return 0;
        }


        public async Task<Models.Route?> GetRouteById(int id)
        {
            return await _context.Routes.FirstOrDefaultAsync(route => route.RouteId == id && id != 1);
        }


        public async Task<int?> GetRouteStatusById(int routeId, int userId)
        {
            var userRoutes = await _context.UserRoutes.FirstOrDefaultAsync(ur => ur.RouteId == routeId && ur.UserId == userId);
            return userRoutes.RouteStatusId;
        }


        public async Task<bool> ChangeRouteStatus(int routeId, int statusId, int userId)
        {
            try
            {
                var userRoute = await _context.UserRoutes.FirstOrDefaultAsync(ur => ur.RouteId == routeId && ur.UserId == userId);
                if (userRoute == null)
                {
                    await _context.UserRoutes.AddAsync(new Models.UserRoute()
                    {
                        UserId = userId,
                        RouteId = routeId,
                        RouteStatusId = statusId
                    });
                }
                else
                {
                    userRoute.RouteStatusId = statusId;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with add new route in bd", null);
                return false;
            }
        }

        public async Task<bool> AddRoute(Models.Route route)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Routes.AddAsync(route);
                await _context.SaveChangesAsync();

                await _context.UserRoutes.AddAsync(new Models.UserRoute()
                {
                    RouteId = _context.Routes.OrderBy(r => r.RouteId).LastOrDefault().RouteId,
                    UserId = 1,
                    RouteStatusId = 1
                });

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
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
