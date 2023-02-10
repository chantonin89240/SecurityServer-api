namespace SecurityServer.Service.Comparer
{
    using SecurityServer.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class UserAppComparer : IEqualityComparer<ApplicationUserRoleEntity>
    {
        public bool Equals(ApplicationUserRoleEntity? x, ApplicationUserRoleEntity? y)
        {
            return x.IdUser == y.IdUser;
        }

        public int GetHashCode([DisallowNull] ApplicationUserRoleEntity obj)
        {
            return obj.IdUser!.GetHashCode();
        }
    }
}
