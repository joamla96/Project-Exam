using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core.Interfaces;
using Core;
using System.Collections.Generic;

namespace Core.UnitTest
{
    [TestClass]
    public class ClientCreateReservation
    {

        IRoom _room1;
        IRoom _room2;
        IRoom _room3;
        IRoom _room4;

        IUser _student;
        IUser _teacher;
        IUser _admin;

        RoomRepository RepoRoom = RoomRepository.Instance; // Singletons
        ReservationRepository RepoReserv = ReservationRepository.Instance;

        [TestInitialize]
        public void TestsInitialize() {
            RepoRoom.Clear();
            RepoReserv.Clear();

            _room1 = new Room('A', 1, 2, 4, Permission.Student);
            _room2 = new Room('A', 1, 99, 8, Permission.Student);
            _room3 = new Room('B', 1, 45, 2, Permission.Student);



            RepoRoom.Add(_room1);
            RepoRoom.Add(_room2);
            RepoRoom.Add(_room3);

            _student = new User("roxa0198", "roxa0188@edu.eal.dk", Permission.Student);
        }

        [TestMethod]
        public void SortRoomsByMaxPeopleIntoFILOStack() {
            Stack<IRoom> StackRooms = RepoRoom.GetPossible(Permission.Student, 4);

            Assert.AreEqual(StackRooms.Pop(), _room1);
            Assert.AreEqual(StackRooms.Pop(), _room2);
        }
        [TestMethod][ExpectedException(typeof (System.NoAvailableRoomException))]
        public void SortRoomsByMaxPeopleIntoFILOStackOutOfRooms()
        {
            Stack<IRoom> StackRooms = RepoRoom.GetPossible(Permission.Student, 4);

            StackRooms.Pop();
            StackRooms.Pop();
            StackRooms.Pop();
        }
        [TestMethod]
        public void RoomIsAvailable()
        {
            DateTime from = new DateTime(2017, 05, 01, 13, 0, 0);
            DateTime to = new DateTime(2017, 05, 01, 14, 0, 0);
            bool roomAvailable = _room1.IsAvailable(from,to);
            Assert.IsTrue(roomAvailable);
        }
        [TestMethod]
        public void RoomIsNotAvailable()
        {
            DateTime from = new DateTime(2017, 05, 01, 13, 0, 0);
            DateTime to = new DateTime(2017, 05, 01, 14, 0, 0);
            Reservation res = new Reservation(_student, _room1, 3, from, to);
            RepoReserv.Add(res);
            bool roomAvailable = _room1.IsAvailable(from, to);
            Assert.IsFalse(roomAvailable);
        }
        
    }
}
