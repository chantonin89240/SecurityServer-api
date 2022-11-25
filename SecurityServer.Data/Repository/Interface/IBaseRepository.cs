using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data.Repository.Interface
{
    public interface IBaseRepository<Tentity> where Tentity : class
    {
        IEnumerable<Tentity> GetAll();
        Tentity Get(int id);
        Tentity Add(Tentity entity);
        Tentity Update(Tentity entity);
        void Delete(int id);
    }
}
