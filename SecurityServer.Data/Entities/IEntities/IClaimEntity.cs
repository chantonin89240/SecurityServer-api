using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Entities.IEntities
{
    public interface IClaimEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
