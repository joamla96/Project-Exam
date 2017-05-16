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


            var mock = new Mock<DAL.IUsers>();
            mock.Setup(m => m.GetAllUsers()).Returns(() => resultUsersInfo);

            List<IUser> returnedUsers = testDALFacade.GetAllUsers(mock.Object.GetAllUsers());

            Assert.AreEqual(expectedUser, returnedUsers[0]);

            //var mockUsers = new Mock<DAL.IUsers>();
            //var mockRooms = new Mock<DAL.IRooms>();
            //var mockReservations = new Mock<DAL.IReservations>();
            //UserRepository repoUsers = UserRepository.Instance;
            //RoomRepository repoRooms = RoomRepository.Instance;
            //DALFacade testDALFacade = new DALFacade(mockUsers, mockRooms, mockReservations, repoUsers, repoRooms);
        }
    }
}
