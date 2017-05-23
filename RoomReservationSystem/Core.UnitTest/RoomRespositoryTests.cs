using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;
using System.Collections.Generic;

namespace Core.UnitTest
{
    [TestClass]
    public class RoomRespositoryTests
    {
        RoomRepository _repoRoom = RoomRepository.Instance;

        List<IRoom> _roomList;

        IUser _student;
        IUser _teacher;
        IUser _admin;

        IRoom _room1;
        IRoom _room2;
        IRoom _room3;
        IRoom _room4;
        IRoom _room5;

        Reservation _reservation1;
        Reservation _reservation2;
        Reservation _reservation3;

        DateTime _dateFrom;
        DateTime _dateTo;

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
            _repoRoom.Clear();

            _roomList = new List<IRoom>();

            _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
            _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
            _admin = new User("frje", "frje@eal.dk", Permission.Admin);

            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            _room2 = new Room('A', 2, 15, 6, Permission.Teacher);
            _room3 = new Room('A', 2, 115, 6, Permission.Admin);
            _room4 = new Room('A', 7, 5, 2, Permission.Student);
            _room5 = new Room('B', 7, 5, 10, Permission.Student);

            _repoRoom.Add(_room1);
            _repoRoom.Add(_room2);
            _repoRoom.Add(_room3);
            _repoRoom.Add(_room4);
            _repoRoom.Add(_room5);

            _dateFrom = new DateTime(2016, 4, 29, 8, 0, 0);
            _dateTo = new DateTime(2016, 4, 29, 16, 0, 0);

            _reservation1 = new Reservation(_student, _room1, 6, _dateFrom, _dateTo);
            _reservation2 = new Reservation(_teacher, _room2, 6, _dateFrom, _dateTo);
            _reservation3 = new Reservation(_admin, _room3, 6, _dateFrom, _dateTo);
        }

        [TestMethod]
        public void AddRoomFromText()
        { // Remember, override Equals method
			IRoom testRoom = new Room('A', 3, 9, 7, Permission.Student);
            _repoRoom.Add('A', 3, 9, 7, Permission.Student);
            _roomList = _repoRoom.Get();
            Assert.IsTrue(_roomList.Contains(testRoom));
        }

        [TestMethod]
        public void AddRoomFromObject()
        {
            _roomList = _repoRoom.Get();
            Assert.IsTrue(_roomList.Contains(_room1));
        }

        [TestMethod]
        public void GetAllRooms()
        {
            _roomList = _repoRoom.Get(); 
            Assert.AreEqual(5, _roomList.Count);
        }

		[TestMethod]
		public void GetRoomsByPermissionForStudent() {
			_roomList = _repoRoom.Get(Permission.Student);
			Assert.IsTrue(_roomList.Contains(_room1));
		}

		[TestMethod]
		public void GetRoomsByPermisisonsForStudentDoesentReturnOthers() {
			_roomList = _repoRoom.Get(Permission.Student);
			Assert.IsFalse(_roomList.Contains(_room2));
			Assert.IsFalse(_roomList.Contains(_room3));
		}

		[TestMethod]
        public void GetRoomsByReservation()
        {
            IRoom room = _repoRoom.Get(_reservation1);
            Assert.IsTrue(room.Equals(_room1));
        }

        [TestMethod]
        public void GetRoomsByReservationDoesntReturnOthers()
        {
            IRoom room = _repoRoom.Get(_reservation1);
            Assert.IsFalse(room.Equals(_room2));
            Assert.IsFalse(room.Equals(_room3));
        }

        [TestMethod]
        public void DeleteRoom()
        {
            _repoRoom.Delete(_room1);
            _roomList = _repoRoom.Get();
            Assert.IsFalse(_roomList.Contains(_room1));
        }

        [TestMethod]
        public void DeleteRoomDoesntDeleteOthers()
        {
            _repoRoom.Delete(_room1);
            _roomList = _repoRoom.Get();
            Assert.IsTrue(_roomList.Contains(_room2));
            Assert.IsTrue(_roomList.Contains(_room3));
        }
    }
}
