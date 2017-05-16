using System;
using System.Collections.Generic;
using Core;
using Core.Interfaces;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.UnitTest
{
    [TestClass]
    public class DALFacadeTests
    {
        [TestMethod]
        public void GetAllUsersTest()
        {
            DALFacade testDALFacade = new DALFacade();
            string username = "hedv0149";
            string email = "hedv0149@edu.eal.dk";
            string permissionLevel = "0";
            List<Dictionary<string, string>> resultUsersInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneUser = new Dictionary<string, string>();
            oneUser.Add("Username", username);
            oneUser.Add("Email", email);
            oneUser.Add("PermissionLevel", permissionLevel);
            resultUsersInfo.Add(oneUser);
            IUser expectedUser = new User(username, email, Permission.Student);


            var mock = new Mock<DAL.Users>();
            mock.Setup(m => m.GetAllUsersFromDatabase()).Returns(() => resultUsersInfo);

            List<IUser> returnedUsers = testDALFacade.GetAllUsers(mock.Object.GetAllUsersFromDatabase());

            Assert.AreEqual(expectedUser, returnedUsers[0]);

        }
    }
}
