using SecurityServer.Data.Repository;
using SecurityServer.Data.Repository.Interface;
using SecurityServer.Data.Repository.LocalRepository;
using SecurityServer.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.UnitOfWork
{
    public class ApplicationUnitOfWork : IApplicationUnitOfWork
    {
        private readonly SecurityServerDbContext _context;
        private IApplicationRepository _applicationRepository;

        public ApplicationUnitOfWork(SecurityServerDbContext context)
        {
            _context = context;
        }

        public IApplicationRepository ApplicationRepository { get { return _applicationRepository = _applicationRepository?? new LocalApplicationRepository (_context); } }

    }
}
