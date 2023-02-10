namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Application : IApplication
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Url { get; set; }
        [Required]
        public string ClientSecret { get; set; }
        [JsonIgnore]
        public List<Role> Roles { get; set; }
        [JsonIgnore]
        public List<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public Application() { }

        public Application(string name, string description, string url, string clientSecret)
        {
            this.Name = name;
            this.Description = description;
            this.Url = url;
            this.ClientSecret = clientSecret;
            this.Roles = new List<Role>();
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}