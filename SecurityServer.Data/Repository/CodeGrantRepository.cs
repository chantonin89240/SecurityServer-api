using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;

namespace SecurityServer.Data.Repository
{
    public class CodeGrantRepository : BaseRepository<CodeGrantEntity>, ICodeGrantRepository
    {
        public CodeGrantRepository(SecurityServerDbContext context) : base(context)
        {

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
