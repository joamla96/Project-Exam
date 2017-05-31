using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Core.IntegrationTest
{
    [TestClass]
    public class RepositoryIntegrationTest
    {
        UserRepository _repoUser = UserRepository.Instance;
        ReservationRepository _repoReservation = ReservationRepository.Instance;
        RoomRepository _repoRoom = RoomRepository.Instance;

        List<IUser> _userList;
        List<Reservation> _reservationList;

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
            _repoUser.Clear();
            _repoReservation.Clear();


            _reservationList = new List<Reservation>();

            _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
            _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
            _admin = new User("frje", "frje@eal.dk", Permission.Admin);

            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            _room2 = new Room('A', 2, 15, 6, Permission.Teacher);
            _room3 = new Room('A', 2, 115, 6, Permission.Admin);
            _room4 = new Room('A', 7, 5, 2, Permission.Student);
            _room5 = new Room('B', 7, 5, 10, Permission.Student);

            _repoUser.Add(_student);
            _repoUser.Add(_teacher);
            _repoUser.Add(_admin);

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

            _repoReservation.Add(_reservation1);
            _repoReservation.Add(_reservation2);
            _repoReservation.Add(_reservation3);
        }

        [TestMethod]
        public void GetReservationsByUser()
        {
            _reservationList = _repoReservation.Get(_student);
            Assert.IsTrue(_reservationList.Contains(_reservation1));
        }

        [TestMethod]
        public void GetReservationsByUserDoesntGetOthers()
        {
            _reservationList = _repoReservation.Get(_student);
            Assert.IsFalse(_reservationList.Contains(_reservation2));
            Assert.IsFalse(_reservationList.Contains(_reservation3));
        }

        [TestMethod]
        public void GetReservationByRoom()
        {
            _reservationList = _repoReservation.Get(_room1);
            Assert.IsTrue(_reservationList.Contains(_reservation1));
        }

        [TestMethod]
        public void GetReservationByRoomDoesntGetOthers()
        {
            _reservationList = _repoReservation.Get(_room1);
            Assert.IsFalse(_reservationList.Contains(_reservation2));
            Assert.IsFalse(_reservationList.Contains(_reservation3));
        }

        [TestMethod]
        public void GetUserByRoom()
        {
            _userList = _repoUser.Get(_room1);
            Assert.IsTrue(_userList.Contains(_student));
        }

        [TestMethod]
        public void GetUserByRoomDoesntReturnOthers()
        {
            _userList = _repoUser.Get(_room1);
            Assert.IsFalse(_userList.Contains(_teacher));
            Assert.IsFalse(_userList.Contains(_admin));
        }

        [TestMethod]
        public void GetUserByReservation()
        {
            _userList = _repoUser.Get(_reservation1);
            Assert.IsTrue(_userList.Contains(_student));
        }

        [TestMethod]
        public void GetUserByReservationDoesntGetOthers()
        {
            _userList = _repoUser.Get(_reservation1);
            Assert.IsFalse(_userList.Contains(_teacher));
            Assert.IsFalse(_userList.Contains(_admin));
        }
    }
}
