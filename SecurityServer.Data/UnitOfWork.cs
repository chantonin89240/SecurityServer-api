using SecurityServer.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public class UnitOfWork
    {
        public ApplicationRepository Application { get; set; }
        public UnitOfWork(ApplicationRepository application) 
        {
            this.Application = application;
        }
        public ClaimRepository Claim { get; set; }
        public RoleRepository Role { get; set; }
        public UserRepository User { get; set; }
    }
}
