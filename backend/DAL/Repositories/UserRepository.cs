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
            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
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
