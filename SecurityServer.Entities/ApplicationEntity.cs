namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;

    public class ApplicationEntity : IApplicationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public List<UserEntity> Users {  get; set; }

        public ApplicationEntity() { }

        public ApplicationEntity(string name, string description, string url, string clientSecret)
        {
            this.Name = name;
            this.Description = description;
            this.Url = url;
            this.ClientSecret = clientSecret;
            this.Users = new List<UserEntity>();
        }
    }
}