namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Role : IRole
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }
        [JsonIgnore]
        public List<Application> Applications { get; set; }
        [JsonIgnore]
        public List<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public Role() { }

        public Role(int id, string label)
        {
            this.Id = id;
            this.Label = label;
            this.Applications = new List<Application>();
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}
