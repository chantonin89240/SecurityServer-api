﻿using SecurityServer.Data;
using SecurityServer.Data.Repository;
using SecurityServer.Entities;
using SecurityServer.Entities.DtoDown;
using SecurityServer.Service.Interface;

namespace SecurityServer.Service
{
    public class UserService : IUserService
    {
        // initialisation de unit of work
        private IUnitOfWork<SecurityServerDbContext>? unitOfWork;

        private ISalt _salt;
        public UserService(IUnitOfWork<SecurityServerDbContext> unit, ISalt salt)
        {
            this.unitOfWork = unit;
            this._salt = salt;
        }

        bool IUserService.CreateUser(UserEntity user)
        {
            this.unitOfWork.CreateTransaction();
            UserEntity thisUser = this.unitOfWork.UserRepository.Add(user);
            this.unitOfWork.Commit();
            this.unitOfWork.Save();
            var userOk = this.unitOfWork.UserRepository.Get(thisUser);
            if (userOk)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        UserDtoDown IUserService.GetAuthUser(string email, string password)
        {
            var userDto = this.unitOfWork.UserRepository.Get(email);
            bool userAuth = false;

            UserDtoDown user = new UserDtoDown()
            {
                id = userDto.Id,
                email = userDto.Email,
                isAdmin = userDto.IsAdmin
            };

            return user;
        }

        List<UserAppDtoDown> IUserService.GetUsers()
        {
            List<UserEntity> ListUsers = this.unitOfWork.UserRepository.GetAll().ToList();
            List<UserAppDtoDown> usersDto = new List<UserAppDtoDown>();

            foreach(UserEntity user in ListUsers)
            {
                UserAppDtoDown us = new UserAppDtoDown()
                {
                    id = user.Id,
                    email = user.Email,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                };
                usersDto.Add(us);
            }
            
            return usersDto;
        }
    }
}