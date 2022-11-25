﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.IEntities
{
    public interface IApplicationEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string? ClientSecret { get; set; }
        public List<UserApplicationEntity> Applications { get; set; }
    }
}
