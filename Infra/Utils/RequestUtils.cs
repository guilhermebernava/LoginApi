using Infra.Exceptions;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;

namespace Infra.Utils
{
    public static class RequestUtils
    {

        public static string GetEmailFromJWT(IHeaderDictionary headers)
        {
            var existHeader = headers.TryGetValue("Authorization", out var headerValue);

            if (existHeader == false)
            {
                throw new UtilsException("Not found any headers");
            }

            var stream = headerValue[0].Split(" ")[1];
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            if (tokenS == null)
            {
                throw new UtilsException("JWT is null");
            }

            return (string)tokenS.Payload["email"];
        }
    }
}
