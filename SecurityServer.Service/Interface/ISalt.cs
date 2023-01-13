namespace SecurityServer.Service.Interface
{
    public interface ISalt
    {
        public string SaltGenerator();
        public string HashPassword(string password, string salt);
    }
}
