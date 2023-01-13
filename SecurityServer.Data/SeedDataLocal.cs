namespace SecurityServer.Data
{
    using SecurityServer.Entities;
    using SecurityServer.Factory;

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
