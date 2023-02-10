namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;

    public class CodeGrantRepository : BaseRepository<CodeGrant>, ICodeGrantRepository
    {
        SecurityServerDbContext context;

        public CodeGrantRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        CodeGrant ICodeGrantRepository.Get(string codeGrant)
        {
            CodeGrant grant = this._dbSet.FirstOrDefault(code => code.Codegrant == codeGrant);
            return grant;
        }

        void ICodeGrantRepository.Delete(int clientId)
        {

        }

        CodeGrant ICodeGrantRepository.Post(CodeGrant codegrant)
        {
            return this.Add(codegrant);
        }
    }
}
