namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class CodeGrantEntity : ICodeGrantEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public string CodeGrant { get; set; }
        [JsonIgnore]
        public UserEntity User { get; set; }
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
