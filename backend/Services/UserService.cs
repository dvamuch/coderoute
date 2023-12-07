using CodeRoute.DTO;
using CodeRoute.Models;
using CodeRoute.DAL.Repositories;

namespace CodeRoute.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        public UserService(UserRepository userRepository) 
        {
            _userRepository = userRepository;
        }

        public async Task<User> RegUser(UserLogInfo user)
        {
            User newUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
                UserName = user.UserName,
                IsAdmin = false
            };

            return await _userRepository.AddUser(newUser);
        }

        public async Task<User> AuthUser(UserAuthInfo user)
        {
            if (user.Login == null || user.Login == "")
            {
                return new User();
            }

            User db_user = await _userRepository.FindUser(user.Login);

            if (db_user == null)
                return new User();

            if (db_user.Password == user.Password)
            {
                return db_user;
            }

            return null;
        }
    }
}
