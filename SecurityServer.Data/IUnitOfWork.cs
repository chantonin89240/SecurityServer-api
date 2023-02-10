namespace SecurityServer.Data
{
    using Microsoft.EntityFrameworkCore;
    using SecurityServer.Data.Repository.Interface;

    public interface IUnitOfWork<out Tcontext> where Tcontext : DbContext
    {
        Tcontext Context { get; }
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();

        public IApplicationRepository ApplicationRepository { get; }
        //public ClaimRepository Claim { get; set; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }
        public ICodeGrantRepository CodeGrantRepository { get; }
        public IApplicationUserRoleRepository ApplicationUserRoleRepository { get; }
    }
}
