using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class RoleEntity : IRoleEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public RoleEntity() { }

        public RoleEntity(int id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}
