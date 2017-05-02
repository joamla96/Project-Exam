using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;

namespace Core.UnitTest
{
    [TestClass]
    public class CreateInstance
    {
        IRoom _room1;
        IRoom _room2;
        IRoom _room3;

        IUser _student;
        IUser _teacher;
        IUser _admin;

        Reservation _reservation1;
        Reservation _reservation2;
        Reservation _reservation3;

        DateTime _dateFrom;
        DateTime _dateTo;

        [TestInitialize]
        public void TestInitialize()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            _room2 = new Room('A', 2, 15, 6, Permission.Teacher);
            _room3 = new Room('A', 2, 115, 6, Permission.Admin);
            _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
            _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
            _admin = new User("frje", "frje@eal.dk", Permission.Admin);
            _dateFrom = new DateTime(2016, 4, 29, 8, 0, 0);
            _dateTo = new DateTime(2016, 4, 29, 16, 0, 0);
            _reservation1 = new Reservation(_student, _room1, 6, _dateFrom, _dateTo);
            _reservation2 = new Reservation(_teacher, _room2, 6, _dateFrom, _dateTo);
            _reservation3 = new Reservation(_admin, _room3, 6, _dateFrom, _dateTo);
        }

        [TestMethod]
        public void CanCreateRoomInstanceID1()
        {
            Assert.AreEqual("A2.9", _room1.ID);
        }

        [TestMethod]
        public void CanCreateRoomInstanceID2()
        {
            Assert.AreEqual("A2.15", _room2.ID);
        }

        [TestMethod]
        public void CanCreateRoomInstanceID3()
        {
            Assert.AreEqual("A2.115", _room3.ID);
        }

        [TestMethod]
        public void CanCreateRoomInstanceBuilding()
        {
            Assert.AreEqual('A', _room1.Building);
        }

        [TestMethod]
        public void CanCreateRoomInstanceFloor()
        {
            Assert.AreEqual(2, _room1.Floor);
        }

        [TestMethod]
        public void CanCreateRoomInstanceNr()
        {
            Assert.AreEqual(9, _room1.Nr);
        }

        [TestMethod]
        public void CanCreateRoomInstanceMaxPeople()
        {
            Assert.AreEqual(6, _room1.MaxPeople);
        }

        [TestMethod]
        public void CanCreateRoomInstanceMinPermissionLevel1()
        {
            Assert.AreEqual(Permission.Student, _room1.MinPermissionLevel);
        }

        [TestMethod]
        public void CanCreateRoomInstanceMinPermissionLevel2()
        {
            Assert.AreEqual(Permission.Teacher, _room2.MinPermissionLevel);
        }

        [TestMethod]
        public void CanCreateRoomInstanceMinPermissionLevel3()
        {
            Assert.AreEqual(Permission.Admin, _room3.MinPermissionLevel);
        }

        [TestMethod]
        public void CanCreateUserInstanceUsername()
        {
            Assert.AreEqual("matt2694", _student.Username);
        }

        [TestMethod]
        public void CanCreateUserInstanceEmail()
        {
            Assert.AreEqual("matt2694@edu.eal.dk", _student.Email);
        }

        [TestMethod]
        public void CanCreateUserInstancePermission1()
        {
            Assert.AreEqual(Permission.Student, _student.PermissionLevel);
        }

        [TestMethod]
        public void CanCreateUserInstancePermission2()
        {
            Assert.AreEqual(Permission.Teacher, _teacher.PermissionLevel);
        }

        [TestMethod]
        public void CanCreateUserInstancePermission3()
        {
            Assert.AreEqual(Permission.Admin, _admin.PermissionLevel);
        }

        [TestMethod]
        public void CanCreateReservationInstanceUser()
        {
            Assert.AreEqual(_student, _reservation1.User);
        }

        [TestMethod]
        public void CanCreateReservationInstanceRoom()
        {
            Assert.AreEqual(_room1, _reservation1.Room);
        }

        [TestMethod]
        public void CanCreateReservationInstancePeopleNr()
        {
            Assert.AreEqual(6, _reservation1.PeopleNr);
        }

        [TestMethod]
        public void CanCreateReservationInstanceFrom()
        {
            Assert.AreEqual(_dateFrom, _reservation1.From);
        }

        [TestMethod]
        public void CanCreateReservationInstanceTo()
        {
            Assert.AreEqual(_dateTo, _reservation1.To);
        }
    }
}
