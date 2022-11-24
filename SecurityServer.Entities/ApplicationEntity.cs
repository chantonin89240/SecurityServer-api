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
        public new int Id { get; set; }
        public new string Name { get; set; }
        public new string Description { get; set; }
        public new string Url { get; set; }
        public new string ClientSecret { get; set; }

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