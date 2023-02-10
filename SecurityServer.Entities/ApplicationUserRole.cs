namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class ApplicationUserRole : IApplicationUserRole
    {
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int IdApplication { get; set; }
        [Required]
        public int IdRole { get; set; }
        [Required]
        public int IdClaim { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        [JsonIgnore]
        public Application Application { get; set; }
        [JsonIgnore]
        public Role Role { get; set; }
        [JsonIgnore]
        public Claim Claim { get; set; }

        public ApplicationUserRole() { }

        public ApplicationUserRole(int idUser, int idApplication, int idRole, int idClaim)
        {
            this.IdUser = idUser;
            this.IdApplication = idApplication;
            this.IdRole = idRole;
            this.IdClaim = idClaim;
        }
    }
}
