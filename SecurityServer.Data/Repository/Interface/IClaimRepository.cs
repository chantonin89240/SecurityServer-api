using SecurityServer.Entities.DtoDown;
using SecurityServer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface IClaimRepository
    {
        IEnumerable<Claim> Get();
    }
}
