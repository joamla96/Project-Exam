using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;

namespace Core.UnitTest
{
    [TestClass]
    public class CreateInstance
    {
        IRoom _room1 = new Room('A', 2, 9, 6, Permission.Student);
        IRoom _room2 = new Room('A', 2, 15, 6, Permission.Teacher);
        IRoom _room3 = new Room('A', 2, 115, 6, Permission.Admin);

        IUser _student = new User("matt2694", "matt2694@edu.eal.dk", Permission.Student);
        IUser _teacher = new User("alhe", "alhe@eal.dk", Permission.Teacher);
        IUser _admin = new User("frje", "frje@eal.dk", Permission.Admin);

        DateTime _dateFrom = new DateTime(2016, 4, 29, 8, 0, 0);
        DateTime _dateTo = new DateTime(2016, 4, 29, 16, 0, 0);

        [TestInitialize]
        public void TestInitialize()
        {
            Reservation _reservation1 = new Reservation(_student, _room1, 6, _dateFrom, _dateTo);
            Reservation _reservation2 = new Reservation(_teacher, _room2, 6, _dateFrom, _dateTo);
            Reservation _reservation3 = new Reservation(_admin, _room3, 6, _dateFrom, _dateTo);
        }

        [TestMethod]
        public void CanCreateRoomInstanceID1()
        {
            Assert.AreEqual("A2.09", _room1.ID);
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
    }
}
