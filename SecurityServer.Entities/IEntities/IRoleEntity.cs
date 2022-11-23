using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.IEntities
{
    public interface IRoleEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
