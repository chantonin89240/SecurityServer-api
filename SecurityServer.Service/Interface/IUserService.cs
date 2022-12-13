﻿using SecurityServer.Entities;
using System.Net;

namespace SecurityServer.Service.Interface
{
    public interface IUserService
    {
        public UserEntity GetUser(string password, string mail);
        public bool CreateUser(UserEntity user);
    }
}