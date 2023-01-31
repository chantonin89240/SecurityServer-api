namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System;

    public class TokenSignEntity : ITokenSignEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateExpiry { get; set; }
        public ClaimEntity Claim { get; set; }
    }
}
