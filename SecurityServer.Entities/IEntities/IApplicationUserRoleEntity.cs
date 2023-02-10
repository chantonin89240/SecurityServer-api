using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.IEntities
{
    public interface IApplicationUserRoleEntity
    {
        public int IdUser { get; set; }
        public int IdApplication { get; set; }
        public int IdRole { get; set; }
        public int IdClaim { get; set; }

    }
}
