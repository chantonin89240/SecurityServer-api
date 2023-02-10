﻿namespace SecurityServer.Entities
{
    using SecurityServer.Entities.IEntities;
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class ClaimEntity : IClaimEntity
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        [JsonIgnore]
        public List<ApplicationUserRole> ApplicationUserRoles { get; set; }

        public ClaimEntity() { }

        public ClaimEntity(int id, string name, string description)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.ApplicationUserRoles = new List<ApplicationUserRole>();
        }
    }
}
