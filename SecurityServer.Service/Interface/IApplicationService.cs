namespace SecurityServer.Service.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;
    using SecurityServer.Entities.DtoUp;

    public interface IApplicationService
    {
        public List<ApplicationEntity> GetApplications();
        public ApplicationEntity GetApplication(int id);
        public ApplicationEntity CreateApplication(ApplicationEntity application);
        public bool DeleteApplication(int id);
        ApplicationEntity UpdateApplication(ApplicationEntity app);
    }
}
