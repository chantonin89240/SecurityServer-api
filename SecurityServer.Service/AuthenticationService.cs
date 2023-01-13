namespace SecurityServer.Data
{
    using JWT;
    using JWT.Algorithms;
    using JWT.Serializers;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Service.Interface;

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
        #endregion

        #region CodeGrant(UserDtoDown user, string clientSecret)
        string IAuthenticationService.CodeGrant(UserDtoDown user, string clientSecret)
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
