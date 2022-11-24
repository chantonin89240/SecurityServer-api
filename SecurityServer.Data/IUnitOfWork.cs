using Microsoft.EntityFrameworkCore;
using SecurityServer.Data.Repository;
using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public interface IUnitOfWork<out Tcontext> where Tcontext : DbContext, new()
    {
        Tcontext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();

        //public IApplicationRepository Application { get; set; }
        //public ClaimRepository Claim { get; set; }
        //public RoleRepository Role { get; set; }
        //public UserRepository User { get; set; }
    }
}
