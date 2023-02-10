namespace SecurityServer.Entities.DtoUp
{
    public class ApplicationUpdateDtoUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public List<UserAppUpdateDtoUp> Users { get; set; }
    }
}
