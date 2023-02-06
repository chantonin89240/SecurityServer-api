using Microsoft.VisualStudio.TestTools.UnitTesting;
using SecurityServer.Entities;
using SecurityServer.Service.Interface;
using System.Collections.Generic;
using Moq;
using SecurityServer.AzureFunction;
using SecurityServer.Entities.DtoDown;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SecurityServer.Test
{
    [TestClass]
    public class ApplicationTest
    {

        public Mock<IApplicationService> mock = new Mock<IApplicationService>();

        //[TestMethod]
        //public void CreateApplicationTest()
        //{
        //    var application = new ApplicationEntity()
        //    {
        //        Name = "Cultura",
        //        Description = "Site commercial de culture",
        //        Url = "cultura.com",
        //        ClientSecret = "wugflwessjbvfugbxjg"
        //    };
        //    mock.Setup(e => e.CreateApplication(application)).Returns(true);
        //    ApplicationFunction appFunction = new ApplicationFunction(mock.Object);
        //    Assert.AreEqual(true, appFunction);
        //}


        [TestMethod]
        public void GetApplicationTest()
        {
            var user1 = new UserAppDtoDown()
            {
                Id = 1,
                Firstname = "Aurelien",
                Lastname = "BISSEY",
                Email = "Aurelien.BISSEY@gmail.com"
            };
            var user2 = new UserAppDtoDown()
            {
                Id = 2,
                Firstname = "JC",
                Lastname = "POUZIN",
                Email = "JC.POUZIN@gmail.com"
            };
            List<UserAppDtoDown> users = new List<UserAppDtoDown>
            {
                user1,
                user2
            };

            var application = new ApplicationDtoDown()
            {
                Id = 15,
                Name = "Cultura",
                Description = "Site commercial de culture",
                Url = "cultura.com",
                ClientSecret = "wugflwessjbvfugbxjg",
                Users = users
            };

            mock.Setup(e => e.GetApplication(15)).Returns(application);
            ApplicationFunction appFunction = new ApplicationFunction(mock.Object);
            
            Assert.IsNotNull(appFunction);
            
            //string result = appFunction.GetApplication(15);
            //Assert.AreEqual(application, result);

        }
    }
}
