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


            var mock = new Mock<DAL.IUsersForMocking>();
            mock.Setup(usersMock => usersMock.GetAllUsersFromDatabase()).Returns(() => resultUsersInfo);

            List<IUser> returnedUsers = testDALFacade.ConvertFromStringsToUserObjects(mock.Object.GetAllUsersFromDatabase());

            Assert.AreEqual(expectedUser, returnedUsers[0]);

        }

        [TestMethod]
        public void GetAllRoomsTest()
        {
            DALFacade testDALFacade = new DALFacade();
            string building = "A";
            string floor = "2";
            string nr = "6";
            string maxPeople = "4";
            string minPermissionLevel = "0";
            List<Dictionary<string, string>> resultRoomsInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneRoom = new Dictionary<string, string>();
            oneRoom.Add("Building", building);
            oneRoom.Add("FloorNr", floor);
            oneRoom.Add("Nr", nr);
            oneRoom.Add("MaxPeople", maxPeople);
            oneRoom.Add("MinPermissionLevel", minPermissionLevel);
            resultRoomsInfo.Add(oneRoom);

            IRoom expectedRoom = new Room('A', 2, 6, 4, 0);

            var mock = new Mock<DAL.Rooms>();
            mock.Setup(roomsMock => roomsMock.GetAllRoomsFromDatabase()).Returns(() => resultRoomsInfo);

            List<IRoom> returnedRooms = testDALFacade.ConvertFromStringsToRoomObjects(mock.Object.GetAllRoomsFromDatabase());

            Assert.AreEqual(expectedRoom, returnedRooms[0]);


        }

        [TestMethod]
        public void GetAllReservationsTest()
        {
            UserRepository repoUser = UserRepository.Instance;
            RoomRepository repoRooms = RoomRepository.Instance;

            repoUser.Clear();
            repoRooms.Clear();

            DALFacade testDALFacade = new DALFacade();

            string username = "matt2694";
            string building = "C";
            string floorNr = "4";
            string nr = "1000";
            string dateFrom = "2017-05-05 18:00:00.00";
            string dateTo = "2017-05-05 19:00:00.00";
            string peopleNr = "1";

            List<Dictionary<string, string>> resultdReservationsInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneReservation = new Dictionary<string, string>();

            oneReservation.Add("Username", username);
            oneReservation.Add("Building", building);
            oneReservation.Add("FloorNr", floorNr);
            oneReservation.Add("Nr", nr);
            oneReservation.Add("DateFrom", dateFrom);
            oneReservation.Add("DateTo", dateTo);
            oneReservation.Add("PeopleNr", peopleNr);

            resultdReservationsInfo.Add(oneReservation);

            DateTime testDateFrom = new DateTime( 2017, 05, 05, 18, 00, 00, 00);
            DateTime testDateTo = new DateTime(2017, 05, 05, 19, 00, 00, 00);

            IUser testUser = new User(username , "matt2694@edu.eal.dk", Permission.Student);
            IRoom testRoom = new Room('C', 4, 1000, 20, Permission.Student);

            repoUser.Add(testUser);
            repoRooms.Add(testRoom);

            Reservation expectedReservation = new Reservation(testUser, testRoom, 1, testDateFrom, testDateTo);


            var mock = new Mock<DAL.IReservationsForMocking>();
            mock.Setup(reservationsMock => reservationsMock.GetAllReservationsFromDatabase()).Returns(() => resultdReservationsInfo);

            List<Reservation> returnedReservation = testDALFacade.ConvertFromStringsToReservationObjects(mock.Object.GetAllReservationsFromDatabase());

            Assert.AreEqual(expectedReservation, returnedReservation[0]);

        }
    }
}
