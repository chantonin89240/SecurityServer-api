namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;

    public interface IApplicationService
    {
        public List<ApplicationEntity> GetApplications();
        public ApplicationDtoDown GetApplication(int id);
        public ApplicationEntity GetSecret(string clientSecret);
        bool CreateApplication(ApplicationEntity application);
        public bool DeleteApplication(int id);
        ApplicationEntity UpdateApplication(ApplicationEntity app);
    }
}
