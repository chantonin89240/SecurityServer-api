namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;

    public class CodeGrantEntity : ICodeGrantEntity
    {
        public int Id { get; set; }
        public string ClientSecret { get; set; }
        public int IdUser { get; set; }
        public string CodeGrant { get; set; }

        public CodeGrantEntity() { }

        public CodeGrantEntity(int id, string clientId, int idUser, string codeGrant)
        {
            this.Id = id;
            this.ClientSecret = clientId;
            this.IdUser = idUser;
            this.CodeGrant = codeGrant;
        }
    }
}
