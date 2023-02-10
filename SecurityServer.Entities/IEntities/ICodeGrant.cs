namespace SecurityServer.Entities.IEntities
{
    public interface ICodeGrant
    {
        public int Id { get; set; }
        public string ClientSecret { get; set; }
        public int IdUser { get; set; }
        public string Codegrant { get; set; }
    }
}
