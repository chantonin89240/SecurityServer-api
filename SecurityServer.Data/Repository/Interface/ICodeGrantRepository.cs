using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface ICodeGrantRepository
    {
        CodeGrantEntity Get(string codegrant);
        CodeGrantEntity Post(CodeGrantEntity codegrant);
    }
}
