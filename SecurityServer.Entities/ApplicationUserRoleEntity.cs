using SecurityServer.Entities.IEntities;

namespace SecurityServer.Entities
{
    public class ApplicationUserRoleEntity : IApplicationUserRoleEntity
    {
        public int IdUser { get; set; }
        public int IdApplication { get; set; }
        public int IdRole { get; set; }
        public int IdClaim { get; set; }

        public ApplicationUserRoleEntity() { }

        public ApplicationUserRoleEntity(int idUser, int idApplication, int idRole, int idClaim)
        {
            this.IdUser = idUser;
            this.IdApplication = idApplication;
            this.IdRole = idRole;
            this.IdClaim = idClaim;
        }
    }
}
