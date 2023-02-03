using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class ApplicationRoleEntity : IApplicationRoleEntity
    {
        public int IdApplication { get; set; }
        public int IdRole { get; set; }

        public ApplicationRoleEntity() { }

        public ApplicationRoleEntity(int idApplication, int idRole)
        {
            this.IdApplication = idApplication;
            this.IdRole = idRole;
        }
    }
}
