namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;

    public class ClaimEntity : IClaimEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ClaimEntity() { }

        public ClaimEntity(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
        }
    }
}
