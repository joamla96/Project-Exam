using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;

namespace Core.UnitTest
{
    [TestClass]
    public class CreateInstance
    {
        IRoom _room1 = new Room('A', 2, 9, 6, Permission.Student);
        IRoom _room2 = new Room('A', 2, 15, 6, Permission.Student);
        IRoom _room3 = new Room('A', 2, 115, 6, Permission.Student);

        IUser _student;
        IUser _teacher;
        IUser _admin;

        Reservation _reservation1;
        Reservation _reservation2;
        Reservation _reservation3;

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
        public void CanCreateRoomInstanceMinPermissionLevel()
        {
            Assert.AreEqual(Permission.Student, _room1.MinPermissionLevel);
        }
    }
}
