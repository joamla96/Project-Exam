using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;

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

        [TestMethod]
        public void CanCreateRoomInstanceID()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual("A2.09", _room1.ID);
        }
        [TestMethod]
        public void CanCreateRoomInstanceBuilding()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual('A', _room1.Building);
        }
        [TestMethod]
        public void CanCreateRoomInstanceFloor()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual(2, _room1.Floor);
        }
        [TestMethod]
        public void CanCreateRoomInstanceNr()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual(9, _room1.Nr);
        }
        [TestMethod]
        public void CanCreateRoomInstanceMaxPeople()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual(6, _room1.MaxPeople);
        }
        [TestMethod]
        public void CanCreateRoomInstanceMinPermissionLevel()
        {
            _room1 = new Room('A', 2, 9, 6, Permission.Student);
            Assert.AreEqual(Permission.Student, _room1.MinPermissionLevel);
        }
    }
}
