namespace SecurityServer.Service.Interface
{
    public interface ISalt
    {
        public string SaltGenerator();
        public string HashPassword(string password, string salt);
        public bool VerifiedPassword(string password, string salt, string verifPassword);
    }
}
