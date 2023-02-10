namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;

    public interface IApplicationService
    {
        public List<Application> GetApplications();
        public ApplicationDtoDown GetApplication(int id);
        public Application GetSecret(string clientSecret);
        bool CreateApplication(Application application);
        public bool DeleteApplication(int id);
        Application UpdateApplication(ApplicationUpdateDtoUp app);
    }
}
