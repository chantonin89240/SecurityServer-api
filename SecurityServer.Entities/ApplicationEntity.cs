using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class ApplicationEntity : IApplicationEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string ClientSecret { get; set; }
        public List<UserApplicationEntity> Applications {  get; set; }

        public ApplicationEntity() { }

        public ApplicationEntity(int id, string name, string description, string url, string clientSecret)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.Url = url;
            this.ClientSecret = clientSecret;
        }
    }
}