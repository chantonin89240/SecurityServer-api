namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;

    public class UserEntity : IUserEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public string Avatar { get; set; }
        public bool IsAdmin { get; set; }

        public List<ApplicationEntity> Applications {  get; set; }


        public UserEntity() { }

        public UserEntity(int idrole, string firstname, string lastname, string email, string password, string salt, string avatar, bool isAdmin)
        {
            this.Id = idrole;
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Email = email;
            this.Password = password;
            this.Salt = salt;
            this.Avatar = avatar;
            this.IsAdmin = isAdmin;
            this.Applications = new List<ApplicationEntity>();
        }
    }
}
