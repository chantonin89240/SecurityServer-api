using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class ApplicationRoleEntity
    {
        public int IdApplication { get; set; }
        public int IdRole { get; set; }

        public ApplicationRoleEntity(int idApplication, int idRole)
        {
            IdApplication = idApplication;
            IdRole = idRole;
        }
    }
}
