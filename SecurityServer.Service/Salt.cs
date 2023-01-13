namespace SecurityServer.AzureFunction
{
    using SecurityServer.Service.Interface;
    using System.Security.Cryptography;
    using System.Text;

    public class Salt : ISalt
    {
        #region Variables
        private static Random random = new Random();
        #endregion

        #region SaltGenerator
        string ISalt.SaltGenerator()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return $@"{new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray())}FEUR";
        }
        #endregion

        #region HashPassword(string password, string salt)
        string ISalt.HashPassword(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password + salt));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        #endregion
    }
}
