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
        IUser testUser;
        IRoom testRoom;
        DateTime testDateFrom;
        DateTime testDateTo;
        UserRepository repoUser;
        RoomRepository repoRooms;
        ReservationRepository repoReservations;

		[ClassInitialize]
		public static void ClassInit(TestContext testContext)
		{
			SystemSettings.Enviroment = Enviroment.Test;
		}

		[ClassCleanup]
		public static void ClassClean()
		{
			SystemSettings.Enviroment = Enviroment.Prod;
		}

		[TestInitialize]
        public void TestInitialize()
        {
            testUser = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
            testRoom = new Room('C', 4, 1000, 20, Permission.Student);
            testDateFrom = new DateTime(2017, 05, 05, 18, 00, 00, 00);
            testDateTo = new DateTime(2017, 05, 05, 19, 00, 00, 00);
            repoUser = UserRepository.Instance;
            repoRooms = RoomRepository.Instance;
            repoReservations = ReservationRepository.Instance;
        }

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

            IRoom expectedRoom = new Room('A', 2, 6, 4, Permission.Student);

            var mock = new Mock<DAL.IRoomsForMocking>();
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

            repoUser.Add(testUser);
            repoRooms.Add(testRoom);

            Reservation expectedReservation = new Reservation(testUser, testRoom, 1, testDateFrom, testDateTo);


            var mock = new Mock<DAL.IReservationsForMocking>();
            mock.Setup(reservationsMock => reservationsMock.GetAllReservationsFromDatabase()).Returns(() => resultdReservationsInfo);

            List<Reservation> returnedReservation = testDALFacade.ConvertFromStringsToReservationObjects(mock.Object.GetAllReservationsFromDatabase());

            Assert.AreEqual(expectedReservation, returnedReservation[0]);
        }

        [TestMethod]
        public void GetAllUsersTestForMultipleUsers()
        {
            DALFacade testDALFacade = new DALFacade();

            string username1 = "hedv0149";
            string email1 = "hedv0149@edu.eal.dk";
            string permissionLevel1 = "0";

            string username2 = "matt2694";
            string email2 = "matt2694@eal.dk";
            string permissionLevel2 = "1";

            string username3 = "jona8690";
            string email3 = "jona8690@eal.dk";
            string permissionLevel3 = "2";

            List<Dictionary<string, string>> resultUsersInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneUser1 = new Dictionary<string, string>();
            Dictionary<string, string> oneUser2 = new Dictionary<string, string>();
            Dictionary<string, string> oneUser3 = new Dictionary<string, string>();

            oneUser1.Add("Username", username1);
            oneUser1.Add("Email", email1);
            oneUser1.Add("PermissionLevel", permissionLevel1);

            oneUser2.Add("Username", username2);
            oneUser2.Add("Email", email2);
            oneUser2.Add("PermissionLevel", permissionLevel2);

            oneUser3.Add("Username", username3);
            oneUser3.Add("Email", email3);
            oneUser3.Add("PermissionLevel", permissionLevel3);

            resultUsersInfo.Add(oneUser1);
            resultUsersInfo.Add(oneUser2);
            resultUsersInfo.Add(oneUser3);

            IUser expectedUser1 = new User(username1, email1, Permission.Student);
            IUser expectedUser2 = new User(username2, email2, Permission.Teacher);
            IUser expectedUser3 = new User(username3, email3, Permission.Admin);

            var mock = new Mock<DAL.IUsersForMocking>();
            mock.Setup(usersMock => usersMock.GetAllUsersFromDatabase()).Returns(() => resultUsersInfo);

            List<IUser> returnedUsers = testDALFacade.ConvertFromStringsToUserObjects(mock.Object.GetAllUsersFromDatabase());
            
            Assert.IsTrue(expectedUser1.Equals(returnedUsers[0]) && expectedUser2.Equals(returnedUsers[1]) && expectedUser3.Equals(returnedUsers[2]));
        }

        [TestMethod]
        public void GetAllRoomsTestForMultipleUsers()
        {
            DALFacade testDALFacade = new DALFacade();

            string building1 = "A";
            string floor1 = "2";
            string nr1 = "6";
            string maxPeople1 = "4";
            string minPermissionLevel1 = "0";

            string building2 = "A";
            string floor2 = "1";
            string nr2 = "15";
            string maxPeople2 = "4";
            string minPermissionLevel2 = "2";

            string building3 = "B";
            string floor3 = "7";
            string nr3 = "5";
            string maxPeople3 = "10";
            string minPermissionLevel3 = "0";

            List<Dictionary<string, string>> resultRoomsInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneRoom1 = new Dictionary<string, string>();
            Dictionary<string, string> oneRoom2 = new Dictionary<string, string>();
            Dictionary<string, string> oneRoom3 = new Dictionary<string, string>();

            oneRoom1.Add("Building", building1);
            oneRoom1.Add("FloorNr", floor1);
            oneRoom1.Add("Nr", nr1);
            oneRoom1.Add("MaxPeople", maxPeople1);
            oneRoom1.Add("MinPermissionLevel", minPermissionLevel1);

            oneRoom2.Add("Building", building2);
            oneRoom2.Add("FloorNr", floor2);
            oneRoom2.Add("Nr", nr2);
            oneRoom2.Add("MaxPeople", maxPeople2);
            oneRoom2.Add("MinPermissionLevel", minPermissionLevel2);

            oneRoom3.Add("Building", building3);
            oneRoom3.Add("FloorNr", floor3);
            oneRoom3.Add("Nr", nr3);
            oneRoom3.Add("MaxPeople", maxPeople3);
            oneRoom3.Add("MinPermissionLevel", minPermissionLevel3);

            resultRoomsInfo.Add(oneRoom1);
            resultRoomsInfo.Add(oneRoom2);
            resultRoomsInfo.Add(oneRoom3);

            IRoom expectedRoom1 = new Room('A', 2, 6, 4, Permission.Student);
            IRoom expectedRoom2 = new Room('A', 1, 15, 4, Permission.Admin);
            IRoom expectedRoom3 = new Room('B', 7, 5, 10, Permission.Student);

            var mock = new Mock<DAL.IRoomsForMocking>();
            mock.Setup(usersMock => usersMock.GetAllRoomsFromDatabase()).Returns(() => resultRoomsInfo);

            List<IRoom> returnedRooms = testDALFacade.ConvertFromStringsToRoomObjects(mock.Object.GetAllRoomsFromDatabase());

            Assert.IsTrue(expectedRoom1.Equals(returnedRooms[0]) && expectedRoom2.Equals(returnedRooms[1]) && expectedRoom3.Equals(returnedRooms[2]));
        }

        [TestMethod]
        public void GetAllReservationsTestForMultipleReservations()
        {
            repoUser.Clear();
            repoRooms.Clear();

            DALFacade testDALFacade = new DALFacade();

            string username1 = "matt2694";
            string building1 = "C";
            string floorNr1 = "4";
            string nr1 = "1000";
            string dateFrom1 = "2017-05-05 18:00:00.00";
            string dateTo1 = "2017-05-05 19:00:00.00";
            string peopleNr1 = "1";

            string username2 = "matt2694";
            string building2 = "C";
            string floorNr2 = "4";
            string nr2 = "1000";
            string dateFrom2 = "2017-05-06 18:00:00.00";
            string dateTo2 = "2017-05-06 19:00:00.00";
            string peopleNr2 = "1";

            string username3 = "matt2694";
            string building3 = "C";
            string floorNr3 = "4";
            string nr3 = "1000";
            string dateFrom3 = "2017-05-07 18:00:00.00";
            string dateTo3 = "2017-05-07 19:00:00.00";
            string peopleNr3 = "1";

            List<Dictionary<string, string>> resultdReservationsInfo = new List<Dictionary<string, string>>();
            Dictionary<string, string> oneReservation1 = new Dictionary<string, string>();
            Dictionary<string, string> oneReservation2 = new Dictionary<string, string>();
            Dictionary<string, string> oneReservation3 = new Dictionary<string, string>();

            oneReservation1.Add("Username", username1);
            oneReservation1.Add("Building", building1);
            oneReservation1.Add("FloorNr", floorNr1);
            oneReservation1.Add("Nr", nr1);
            oneReservation1.Add("DateFrom", dateFrom1);
            oneReservation1.Add("DateTo", dateTo1);
            oneReservation1.Add("PeopleNr", peopleNr1);

            oneReservation2.Add("Username", username2);
            oneReservation2.Add("Building", building2);
            oneReservation2.Add("FloorNr", floorNr2);
            oneReservation2.Add("Nr", nr2);
            oneReservation2.Add("DateFrom", dateFrom2);
            oneReservation2.Add("DateTo", dateTo2);
            oneReservation2.Add("PeopleNr", peopleNr2);

            oneReservation3.Add("Username", username3);
            oneReservation3.Add("Building", building3);
            oneReservation3.Add("FloorNr", floorNr3);
            oneReservation3.Add("Nr", nr3);
            oneReservation3.Add("DateFrom", dateFrom3);
            oneReservation3.Add("DateTo", dateTo3);
            oneReservation3.Add("PeopleNr", peopleNr3);

            resultdReservationsInfo.Add(oneReservation1);
            resultdReservationsInfo.Add(oneReservation2);
            resultdReservationsInfo.Add(oneReservation3);
            
            DateTime testDateFrom1 = new DateTime(2017, 05, 05, 18, 00, 00, 00);
            DateTime testDateTo1 = new DateTime(2017, 05, 05, 19, 00, 00, 00);

            DateTime testDateFrom2 = new DateTime(2017, 05, 06, 18, 00, 00, 00);
            DateTime testDateTo2 = new DateTime(2017, 05, 06, 19, 00, 00, 00);

            DateTime testDateFrom3 = new DateTime(2017, 05, 07, 18, 00, 00, 00);
            DateTime testDateTo3 = new DateTime(2017, 05, 07, 19, 00, 00, 00);

            IUser testUser = new User(username1, "matt2694@edu.eal.dk", Permission.Student);
            IRoom testRoom = new Room('C', 4, 1000, 20, Permission.Student);

            repoUser.Add(testUser);
            repoRooms.Add(testRoom);

            Reservation expectedReservation1 = new Reservation(testUser, testRoom, 1, testDateFrom1, testDateTo1);
            Reservation expectedReservation2 = new Reservation(testUser, testRoom, 1, testDateFrom2, testDateTo2);
            Reservation expectedReservation3 = new Reservation(testUser, testRoom, 1, testDateFrom3, testDateTo3);

            var mock = new Mock<DAL.IReservationsForMocking>();
            mock.Setup(reservationsMock => reservationsMock.GetAllReservationsFromDatabase()).Returns(() => resultdReservationsInfo);

            List<Reservation> returnedReservation = testDALFacade.ConvertFromStringsToReservationObjects(mock.Object.GetAllReservationsFromDatabase());

            Assert.IsTrue(expectedReservation1.Equals(returnedReservation[0]) && expectedReservation2.Equals(returnedReservation[1]) && expectedReservation3.Equals(returnedReservation[2]));
        }

        [TestMethod]
        public void StoreReservationInDatabase()
        {
            Reservation testReservation = new Reservation(testUser, testRoom, 4, testDateFrom, testDateTo);

            var mock = new Mock<IDALFacade>();

            mock.Object.PassReservationToDAL(testReservation);

            mock.Verify(iDALFacadeMock => iDALFacadeMock.PassReservationToDAL(testReservation), Times.Once());
        }

        [TestMethod]
        public void DeleteAllUsers()
        {

        }
    }
}
