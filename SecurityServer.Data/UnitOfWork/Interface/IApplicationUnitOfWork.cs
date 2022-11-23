using SecurityServer.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.UnitOfWork.Interface
{
    public interface IApplicationUnitOfWork
    {
        IApplicationRepository ApplicationRepository { get; }
        

    }
}
