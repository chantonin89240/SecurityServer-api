﻿using SecurityServer.Entities.IEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityServer.Entities
{
    public class CodeGrantEntity : ICodeGrantEntity
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int IdUser { get; set; }
        public string CodeGrant { get; set; }

        public CodeGrantEntity() { }

        public CodeGrantEntity(int id, int clientId, int idUser, string codeGrant)
        {
            this.Id = id;
            this.ClientId = clientId;
            this.IdUser = idUser;
            this.CodeGrant = codeGrant;
        }
    }
}
