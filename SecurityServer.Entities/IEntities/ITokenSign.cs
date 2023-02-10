namespace SecurityServer.Entities.IEntities
{
    public interface ITokenSign
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateExpiry { get; set; }
        public Claim Claim { get; set; }
    }
}
