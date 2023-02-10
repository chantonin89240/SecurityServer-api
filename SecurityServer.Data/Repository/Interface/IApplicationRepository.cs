namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public interface IApplicationRepository : IBaseRepository<Application>
    {
        IEnumerable<Application> Get();
        ApplicationDtoDown Get(int id);
        Application Get(string clientSecret);
        Application Post(Application application);
        Application Update(Application application);
        void Delete(int id);
    }
}
