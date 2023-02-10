
namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class User : IUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        [JsonIgnore]
        public List<ApplicationUserRole> ApplicationUserRoles { get; set; }
        [JsonIgnore]
        public CodeGrant CodeGrantEntity { get; set; }

        public User() { }

        public User(int idrole, string firstname, string lastname, string email, string password, string salt, string avatar, bool isAdmin)
        {
            this.Id = idrole;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
            this.Avatar = avatar;
            this.IsAdmin = isAdmin;
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}
