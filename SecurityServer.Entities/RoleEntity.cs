namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;

    public class RoleEntity : IRoleEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public RoleEntity() { }

        public RoleEntity(int id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}
