namespace SecurityServer.Entities.IEntities
{
    public interface IClaim
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
