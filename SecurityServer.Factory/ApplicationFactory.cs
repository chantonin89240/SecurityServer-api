using SecurityServer.Data.Entities;

namespace SecurityServer.Factory
{
    public class ApplicationFactory
    {
        public static IEnumerable<ApplicationEntity> CreateApplication()
        {
            return new List<ApplicationEntity>()
            {
                new ApplicationEntity()
                {
                    Id = 1,
                    Name = "Caltech",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },
                new ApplicationEntity()
                {
                    Id = 2,
                    Name = "Outlook",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 3,
                    Name = "Zulip",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 4,
                    Name = "Teams",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 5,
                    Name = "Azure",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 6,
                    Name = "PowerPoint",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 7,
                    Name = "Azure DevOps",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 8,
                    Name = "OneNote",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 9,
                    Name = "Plop",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new ApplicationEntity()
                {
                    Id = 10,
                    Name = "Feur",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },
            };
        }

        public static List<ApplicationEntity> GetApplications()
        {
            List<ApplicationEntity> applications = CreateApplication().ToList();
            return applications;
        }
    }
}