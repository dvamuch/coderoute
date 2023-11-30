using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodeRoute.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "CodeRouteAuthServer"; // издатель токена
        public const string AUDIENCE = "CodeRouteAuthClient"; // потребитель токена

        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));

        private const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
    }
}
