using SecurityServer.Entities.DtoDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Service.Interface
{
    public interface IAuthenticationService
    {
        public string IsusingJWT(UserDtoDown user);
        public string CodeGrant(UserDtoDown user);

    }
}
