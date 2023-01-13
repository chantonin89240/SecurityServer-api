namespace SecurityServer.Entities
{
    public class UserApplicationEntity
    {
        public int IdUser { get; set; }
        public int IdApplication { get; set; }


        public UserApplicationEntity() { }

        public UserApplicationEntity(int idUser, int idApplication)
        {
            this.IdUser = idUser;
            this.IdApplication = idApplication;
        }
    }
}
