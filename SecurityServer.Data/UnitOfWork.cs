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
    public class UnitOfWork<Tcontext> : IUnitOfWork<Tcontext>, IDisposable where Tcontext : DbContext, new()
    {
        public IApplicationRepository Application { get; set; }
        public ClaimRepository Claim { get; set; }
        public RoleRepository Role { get; set; }
        public UserRepository User { get; set; }

        public Tcontext Context => throw new NotImplementedException();

        public UnitOfWork()
        {
            
        }

        public void CreateTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Rollback()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        // IDisposable est un mécanisme pour libérer des ressources non gérées.
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
