using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class CodeGrantEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int IdUser { get; set; }
        public string? CodeGrant { get; set; }
    }
}
