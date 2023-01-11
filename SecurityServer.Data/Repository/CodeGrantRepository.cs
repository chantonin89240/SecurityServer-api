using SecurityServer.Data.Repository.Interface;
using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository
{
    public class CodeGrantRepository : BaseRepository<CodeGrantEntity>, ICodeGrantRepository
    {
        public CodeGrantRepository(SecurityServerDbContext context) : base(context)
        {

        }

        public CodeGrantEntity Get(string codegrant)
        {
            return this.Get(codegrant);
        }

        public CodeGrantEntity Post(CodeGrantEntity codegrant)
        {
            return this.Add(codegrant);
        }
    }
}
