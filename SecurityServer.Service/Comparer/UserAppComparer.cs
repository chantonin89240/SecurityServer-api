namespace SecurityServer.Service.Comparer
{
    using SecurityServer.Entities;
    using System.Diagnostics.CodeAnalysis;

    public class UserAppComparer : IEqualityComparer<ApplicationUserRole>
    {
        public bool Equals(ApplicationUserRole? x, ApplicationUserRole? y)
        {
            return x.IdUser == y.IdUser;
        }

        public int GetHashCode([DisallowNull] ApplicationUserRole obj)
        {
            return obj.IdUser!.GetHashCode();
        }
    }
}
