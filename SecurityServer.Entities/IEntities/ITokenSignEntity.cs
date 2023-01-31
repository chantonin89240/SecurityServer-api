namespace SecurityServer.Entities.IEntities
{
    public interface ITokenSignEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateExpiry { get; set; }
        public ClaimEntity Claim { get; set; }
    }
}
