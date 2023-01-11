using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.DtoDown
{
    public class ApplicationDtoDown
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<UserAppDtoDown> Userdto { get; set; }

        public ApplicationDtoDown()
        {
            Userdto = new List<UserAppDtoDown>();
        }
    }
}
