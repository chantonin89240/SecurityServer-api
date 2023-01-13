namespace SecurityServer.Data.Repository.Interface
{
    using SecurityServer.Entities;
    using SecurityServer.Entities.DtoDown;

    public interface IApplicationRepository : IBaseRepository<ApplicationEntity>
    {
        IEnumerable<ApplicationEntity> Get();
        ApplicationDtoDown Get(int id);
        ApplicationEntity Get(string clientSecret);
        ApplicationEntity Post(ApplicationEntity application);
        ApplicationEntity Update(ApplicationEntity application);
        void Delete(int id);
    }
}
