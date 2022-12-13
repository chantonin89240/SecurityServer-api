using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;

namespace SecurityServer.Service
{
    public class ValidateJWTService
    {
        public bool IsValid
        {
            get;
        }
        public string Username
        {
            get;
        }
        public string Role
        {
            get;
        }

        public ValidateJWTService(HttpRequest request)
        {
            if (!request.Headers.ContainsKey("Authorization"))
            {
                IsValid = false;
                return;
            }
            string authorizationHeader = request.Headers["Authorization"];
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                IsValid = false;
                return;
            }

            IDictionary<string, object> claims = null;
            try
            {
                if (authorizationHeader.StartsWith("Bearer"))
                {
                    authorizationHeader = authorizationHeader.Substring(7);
                }
                claims = new JwtBuilder().WithAlgorithm(new HMACSHA256Algorithm()).WithSecret("your secret security key string").MustVerifySignature().Decode<IDictionary<string, object>>(authorizationHeader);

            }
            catch (Exception exception)
            {
                IsValid = false;
                return;

            }

            if (!claims.ContainsKey("email"))
            {
                IsValid = false;
                return;
            }
            IsValid = true;
            Username = Convert.ToString(claims["email"]);
            Role = Convert.ToString(claims["role"]);
        
    }
       
    }
}
