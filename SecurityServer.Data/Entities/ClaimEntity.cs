using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Entities
{
    public class ClaimEntity
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public ClaimEntity() { }

        public ClaimEntity(int id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}
