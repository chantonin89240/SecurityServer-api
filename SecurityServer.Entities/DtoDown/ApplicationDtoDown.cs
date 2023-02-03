namespace SecurityServer.Entities.DtoDown
{
    using System.Collections.Generic;

    public class ApplicationDtoDown
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public List<UserAppDtoDown> Users { get; set; }
        public List<RoleEntity> Roles { get; set; }

        public ApplicationDtoDown()
        {
            Users = new List<UserAppDtoDown>();
            Roles = new List<RoleEntity>();
        }
    }
}
