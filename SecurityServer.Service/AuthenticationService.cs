namespace SecurityServer.Data
{
    using Azure.Core;
    using Azure.Identity;
    using Azure.Security.KeyVault.Certificates;
    using Azure.Security.KeyVault.Secrets;
    using JWT;
    using JWT.Algorithms;
    using JWT.Serializers;
    using Microsoft.IdentityModel.Tokens;
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Service.Interface;
    using System.Collections;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using Claim = System.Security.Claims.Claim;

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
        AccessToken IAuthenticationService.GenerateJWT(string codeGrant)
        {
            CodeGrantEntity grant = this.unitOfWork.CodeGrantRepository.Get(codeGrant);

            if (grant != null)
            {
                UserDtoDown user = this.unitOfWork.UserRepository.Get(grant.IdUser);
                //ClaimEntity claim = this.unitOfWork.ClaimRepository

                ClaimEntity claim = new ClaimEntity()
                {
                    Id = 1,
                    Name = "test",
                    Description = "test de ouf"
                };

                List<Claim> listeClaims = new List<Claim>() {
                    new Claim("FirstName", user.Firstname),
                    new Claim("LastName", user.Lastname),
                    new Claim("Email", user.Email),
                    new Claim("idClaim", claim.Id.ToString()),
                    new Claim("nameClaim", claim.Name),
                    new Claim("descriptionClaim", claim.Description),
                };

                ClientSecretCredential credential = new ClientSecretCredential(tenantId: "14bc5219-40ca-4d62-a8e4-7c97c1236349", clientId: "af6cf671-0eb1-4685-a294-97b1a7a73325", clientSecret: "aVs8Q~ffrP.e1.tCMaC_AJuSBOVj1lG7SOq4Hda7");

                Uri url = new Uri("https://keyvaultsecuritygcaltest.vault.azure.net/");
                CertificateClient certificat = new CertificateClient(url, credential);

                SecretClient secretClient = new SecretClient(url, credential);

                var certificatAngular = secretClient.GetSecretAsync("CERTIFICAT-ANGULAR");

                KeyVaultSecret keyVaultSecret = certificatAngular.Result.Value;

                RSA rsa = null;

                if (keyVaultSecret != null)
                {
                    var privateKeyBytes = Convert.FromBase64String(keyVaultSecret.Value);

                    var X509 = new X509Certificate2(privateKeyBytes);
                    rsa = X509.GetRSAPrivateKey();

                    RsaSecurityKey rsaSecurityKey = new RsaSecurityKey(rsa);

                    var accessTokenExpiration = DateTime.UtcNow.AddMinutes(15);

                    var securityToken = new JwtSecurityToken
                    (
                        issuer: "SecurityServer",
                        audience: "SecurityServer",
                        claims: listeClaims,
                        expires: accessTokenExpiration,
                        notBefore: DateTime.UtcNow,
                        signingCredentials: new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256)
                    );

                    var handler = new JwtSecurityTokenHandler();
                    var accesToken = handler.WriteToken(securityToken);

                    return new AccessToken(accesToken, accessTokenExpiration);
                }
                else
                {
                    return new AccessToken("problème du certificat angular", DateTime.UtcNow);
                }
            }
            else
            {
                return new AccessToken("Code Grant non valide", DateTime.UtcNow);
            }
        }

        #endregion

        #region RefreshToken()
        //public RefeshToken  
        //var refreshToken = new RefreshToken
        //(
        //        token: _passwordHasher.HashPassword(Guid.NewGuid().ToString()),
        //        expiration: DateTime.UtcNow.AddSeconds(_tokenOptions.RefreshTokenExpiration).Ticks
        //);
        //return refreshToken;
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
