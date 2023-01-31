namespace SecurityServer.Data
{
    using JWT;
    using JWT.Algorithms;
    using JWT.Serializers;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Service.Interface;
    using Azure.Security.KeyVault.Certificates;
    using System.Text.Json;

    public class AuthenticationService : IAuthenticationService
    {
        #region Variables
        private readonly IJwtAlgorithm _algorythm;
        private readonly IJsonSerializer _serializer;
        private readonly IBase64UrlEncoder _base64UrlEncoder;
        private readonly IJwtEncoder _jwtEncoder;               

        private static Random random = new Random();
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

        public bool IsValid { get; }
        public string Username { get; }
        public string Role { get; }
        #endregion

        #region Initialisation
        public AuthenticationService(IUnitOfWork<SecurityServerDbContext> unit)
        {
            this._algorythm = new HMACSHA256Algorithm();
            this._serializer = new JsonNetSerializer();
            this._base64UrlEncoder = new JwtBase64UrlEncoder();
            this._jwtEncoder = new JwtEncoder(_algorythm, _serializer, _base64UrlEncoder);
            this.unitOfWork = unit;

        }
        #endregion

        #region GenerateJWT(string codeGrant)
        string IAuthenticationService.GenerateJWT(string codeGrant)
        {
            CodeGrantEntity grant = this.unitOfWork.CodeGrantRepository.Get(codeGrant);
           
            if(grant != null)
            {
                UserDtoDown user = this.unitOfWork.UserRepository.Get(grant.IdUser);
                //ClaimEntity claim = this.unitOfWork.ClaimRepository

                ClaimEntity claim = new ClaimEntity()
                {
                    Id = 1,
                    Name = "test",
                    Description = "test de ouf"
                };


                TokenSignEntity payload = new TokenSignEntity()
                {
                    FirstName = user.Firstname,
                    LastName = user.Lastname,
                    Email = user.Email,
                    DateExpiry = DateTime.Now,
                    Claim = claim
                };

                string strJson = JsonSerializer.Serialize<TokenSignEntity>(payload);

                string token = _jwtEncoder.Encode(strJson, "");
                return token;
            }
            else
            {
                return "ptit problème de token ma gueule";
            }
        }
        #endregion

        #region CodeGrant(UserDtoDown user, string clientSecret)
        string IAuthenticationService.CodeGrant(UserAuthDtoDown user, string clientSecret)
        {
            this.unitOfWork.CreateTransaction();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var codegrant = $@"{new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray())}FEUR";
            CodeGrantEntity codeGrant = new CodeGrantEntity
            {
                ClientSecret = clientSecret,
                IdUser = user.Id,
                CodeGrant = codegrant

            };
            this.unitOfWork.CodeGrantRepository.Post(codeGrant);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();

            return codegrant;
        }
        #endregion

    }
}
