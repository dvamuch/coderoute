﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CodeRoute.Auth
{
    public class AuthOptions
    {
        public const string ISSUER = "CodeRouteAuthServer"; // издатель токена
        public const string AUDIENCE = "CodeRouteAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}
