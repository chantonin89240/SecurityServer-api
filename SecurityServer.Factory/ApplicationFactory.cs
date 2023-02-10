

using SecurityServer.Entities;

namespace SecurityServer.Factory
{
    public class ApplicationFactory
    {
        public static IEnumerable<Application> CreateApplication()
        {
            return new List<Application>()
            {
                new Application()
                {
                    Id = 1,
                    Name = "Caltech",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },
                new Application()
                {
                    Id = 2,
                    Name = "Outlook",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 3,
                    Name = "Zulip",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 4,
                    Name = "Teams",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 5,
                    Name = "Azure",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 6,
                    Name = "PowerPoint",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 7,
                    Name = "Azure DevOps",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 8,
                    Name = "OneNote",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 9,
                    Name = "Plop",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },new Application()
                {
                    Id = 10,
                    Name = "Feur",
                    Description = "ceci est une application",
                    Url = "labelleurl",
                    ClientSecret = "jesuissecret"
                },
            };
        }

        public static List<Application> GetApplications()
        {
            List<Application> applications = CreateApplication().ToList();
            return applications;
        }
    }
}