using CodeRoute.Models;

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

        public User? GetUserByUserName(User user)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
        }

        public User AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
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

        public User FindUser(string username, string usermail)
        {
            return _context.Users.FirstOrDefault(u => u.UserName == username || u.Email == usermail);
        }
    }
}
