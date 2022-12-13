using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public class GenerateJWTToken
    {
        private readonly IJwtAlgorithm _algorythm;
        private readonly IJsonSerializer _serializer;
        private readonly IBase64UrlEncoder _base64UrlEncoder;
        private readonly IJwtEncoder _jwtEncoder;

        private UserDtoDown userDtoDown;

        public GenerateJWTToken()
        {
            _algorythm = new HMACSHA256Algorithm();
            _serializer = new JsonNetSerializer();
            _base64UrlEncoder = new JwtBase64UrlEncoder();
            _jwtEncoder = new JwtEncoder(_algorythm, _serializer, _base64UrlEncoder);
        }

        public string IsusingJWT(UserDtoUp user)
        {
            Dictionary<string, object> claims = new Dictionary<string, object>
            {
                {
                    "email",
                    user
                }
            };
            string token = _jwtEncoder.Encode(claims, "your secret security key string");
            return token;
            
        }
    }

}
