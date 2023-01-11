using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface ICodeGrantRepository : IBaseRepository<CodeGrantEntity>
    {
        public CodeGrantEntity Post(CodeGrantEntity codegrant);
        public CodeGrantEntity Get(string codeGrant);
        public void Delete(int clientId);
    }
}
