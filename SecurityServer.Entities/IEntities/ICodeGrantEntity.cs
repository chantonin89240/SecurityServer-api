﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities.IEntities
{
    public interface ICodeGrantEntity
    {
        public int Client_Id { get; set; }
        public int IdUser { get; set; }
        public string CodeGrant { get; set; }
    }
}
