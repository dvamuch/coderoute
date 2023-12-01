using CodeRoute.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeRoute.DAL.Repositories
{
    public class UserRepository
    {
        private readonly Context _context;
        private Logger<UserRepository> _logger;

        public UserRepository(Context context, Logger<UserRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public async Task<User> GetUserByUserName(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == user.UserName);
        }

        public async Task<User> AddUser(User user)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();


                var routes = _context.Routes.ToList();
                foreach (var route in routes)
                {
                    _context.UserRoutes.Add(new UserRoute()
                    {
                        RouteId = route.RouteId,
                        UserId = user.UserId,
                        RouteStatusId = 1, // Не начат
                    });
                }

                var vertices = _context.Vertexes.ToList();
                foreach (var vertex in vertices)
                {
                    _context.UserVertexes.Add(new UserVertex()
                    {
                        UserId = user.UserId,
                        VertexId = vertex.VertexId,
                        StatusId = 1, // Не изучено
                    });
                }

                await _context.SaveChangesAsync();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    _logger.LogError(ex.InnerException, "Ошибка при добавлении нового пользователя", null);
                }
                else
                {
                    _logger.LogError(ex, "Ошибка при добавлении нового пользователя", null);
                }
                return null;
            }

            return user;
        }

        public async Task<User> FindUser(string username, string usermail)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username || u.Email == usermail);
        }
    }
}
