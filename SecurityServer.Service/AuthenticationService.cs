using JWT;
using JWT.Algorithms;
using JWT.Serializers;
using Newtonsoft.Json.Linq;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities.DtoUp;
using SecurityServer.Service.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtAlgorithm _algorythm;
        private readonly IJsonSerializer _serializer;
        private readonly IBase64UrlEncoder _base64UrlEncoder;
        private readonly IJwtEncoder _jwtEncoder;

        private UserDtoDown userDtoDown;
        private static Random random = new Random();
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

        public AuthenticationService(IUnitOfWork<SecurityServerDbContext> unit)
        {
            _algorythm = new HMACSHA256Algorithm();
            _serializer = new JsonNetSerializer();
            _base64UrlEncoder = new JwtBase64UrlEncoder();
            _jwtEncoder = new JwtEncoder(_algorythm, _serializer, _base64UrlEncoder);
            this.unitOfWork = unit;

        }

        string IAuthenticationService.GenerateJWT(string codeGrant)
        {
            CodeGrantEntity grant = this.unitOfWork.CodeGrantRepository.Get(codeGrant);
            UserEntity user = this.unitOfWork.UserRepository.Get(grant.IdUser);

            if(grant != null)
            {
                Dictionary<string, object> claims = new Dictionary<string, object>
                {
                    {
                        "email",
                        user.Email
                    }
                };
                string token = _jwtEncoder.Encode(claims, "your secret security key string");
                return token;
            }
            else
            {
                return "ptit problème de token ma gueule";
            }
        }


        string IAuthenticationService.CodeGrant(UserDtoDown user, string clientSecret)
        {
            this.unitOfWork.CreateTransaction();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var codegrant = $@"{new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray())}FEUR";
            CodeGrantEntity codeGrant = new CodeGrantEntity
            {
                ClientSecret = clientSecret,
                IdUser = user.id,
                CodeGrant = codegrant

            };
            this.unitOfWork.CodeGrantRepository.Post(codeGrant);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();

            return codegrant;
        }


      //public async Task Main(UserDtoDown user)
      //  {
      //      // Remplacez ces valeurs par celles de votre serveur d'autorisation
      //      string clientId = "YOUR_CLIENT_ID";
      //      string clientSecret = "YOUR_CLIENT_SECRET";
      //      string tokenEndpoint = "https://your-authorization-server.com/oauth2/token";

      //      // Créez une requête POST pour obtenir un jeton d'accès
      //      HttpClient client = new HttpClient();
      //      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, tokenEndpoint);
      //      request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret)));
      //      request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
      //      {
      //          { "grant_type", "client_credentials" }
      //      });

      //      // Envoyez la requête et récupérez le jeton d'accès
      //      HttpResponseMessage response = await client.SendAsync(request);
      //      if (response.IsSuccessStatusCode)
      //      {
      //          string responseText = await response.Content.ReadAsStringAsync();
      //          JObject responseJson = JObject.Parse(responseText);
      //          string accessToken = (string)responseJson["access_token"];
      //          Console.WriteLine("Jeton d'accès obtenu : " + accessToken);

      //          // Extraire les claims du jeton d'accès
      //          JObject claims = JObject.Parse((string)responseJson["id_token"]);
      //          string username = (string)claims["username"];
      //          string email = (string)claims["email"];
      //          string role = (string)claims["role"];
      //          Console.WriteLine("Informations sur l'utilisateur :");
      //          Console.WriteLine("Nom d'utilisateur : " + username);
      //          Console.WriteLine("Adresse email : " + email);
      //          Console.WriteLine("Rôle : " + role);
      //      }
      //      else
      //      {
      //          Console.WriteLine("Erreur lors de la récupération du jeton d'accès : " + response.StatusCode);
      //      }
      //  }   
    }

}
