using CodeRoute.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace CodeRoute
{
    public static class ControllerExtension
    {

        public static async Task<int> ParseToken(this ControllerBase controller)
        {
            JwtSecurityToken jwtToken;
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = controller.HttpContext.Request.Headers.Authorization.ToString().Split(' ')[1];

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuer = false,
                    ValidateAudience = false
                }, out SecurityToken validatedToken);

                jwtToken = (JwtSecurityToken)validatedToken;
            }
            catch (Exception)
            {
                return 1;
            }

            return int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
        }
    }
}
