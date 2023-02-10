namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;

    public interface ICodeGrantRepository : IBaseRepository<CodeGrant>
    {
        public CodeGrant Post(CodeGrant codegrant);
        public CodeGrant Get(string codeGrant);
        public void Delete(int clientId);
    }
}
