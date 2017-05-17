using System;
using System.Collections.Generic;
using Core;
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
            var mockUsers = new Mock<DAL.Users>();
            var mockRooms = new Mock<DAL.Rooms>();
            var mockReservations = new Mock<DAL.Reservations>();
            UserRepository repoUsers = UserRepository.Instance;
            RoomRepository repoRooms = RoomRepository.Instance;
            DALFacade testDALFacade = new DALFacade(mockUsers, mockRooms, mockReservations, repoUsers, repoRooms);
        }
    }
}
