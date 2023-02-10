namespace SecurityServer.Data.Repository
{
    using SecurityServer.Data.Context;
    using SecurityServer.Data.Repository.Interface;
    using SecurityServer.Entities;

    public class CodeGrantRepository : BaseRepository<CodeGrantEntity>, ICodeGrantRepository
    {
        SecurityServerDbContext context;

        public CodeGrantRepository(SecurityServerDbContext context) : base(context)
        {
            this.context = context;
        }

        CodeGrantEntity ICodeGrantRepository.Get(string codeGrant)
        {
            CodeGrantEntity grant = this._dbSet.FirstOrDefault(code => code.CodeGrant == codeGrant);
            return grant;
        }

        void ICodeGrantRepository.Delete(int clientId)
        {

        }

        CodeGrantEntity ICodeGrantRepository.Post(CodeGrantEntity codegrant)
        {
            return this.Add(codegrant);
        }
    }
}
