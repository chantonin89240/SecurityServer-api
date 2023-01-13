namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public interface ICodeGrantRepository : IBaseRepository<CodeGrantEntity>
    {
        public CodeGrantEntity Post(CodeGrantEntity codegrant);
        public CodeGrantEntity Get(string codeGrant);
        public void Delete(int clientId);
    }
}
