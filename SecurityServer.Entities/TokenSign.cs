namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System;

    public class TokenSign : ITokenSign
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateExpiry { get; set; }
        public Claim Claim { get; set; }
    }
}
