using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.DtoDown
{
    public class ApplicationDtoDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public List<UserAppDtoDown> Users { get; set; }

        public ApplicationDtoDown()
        {
            Users = new List<UserAppDtoDown>();
        }
    }
}
