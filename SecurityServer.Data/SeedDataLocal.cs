using SecurityServer.Entities;
using SecurityServer.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Data
{
    public class SeedDataLocal
    {
        private static IEnumerable<ApplicationEntity> Applications;

        public static void Initialisation(SecurityServerDbContext dbContext)
        {
            int defaultamount = 20;
            Applications = ApplicationFactory.GetApplications();
            dbContext.AddRange(Applications.ToList());
            dbContext.SaveChanges();
        }
    }
}
