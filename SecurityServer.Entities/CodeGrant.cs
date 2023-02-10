namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class CodeGrant : ICodeGrant
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientSecret { get; set; }

        [Required]
        public int IdUser { get; set; }

        [Required]
        public string Codegrant { get; set; }

        [JsonIgnore]
        public User User { get; set; }
        public CodeGrant() { }

        public CodeGrant(int id, string clientId, int idUser, string codeGrant)
        {
            this.Id = id;
            this.ClientSecret = clientId;
            this.IdUser = idUser;
            this.Codegrant = codeGrant;
        }
    }
}
