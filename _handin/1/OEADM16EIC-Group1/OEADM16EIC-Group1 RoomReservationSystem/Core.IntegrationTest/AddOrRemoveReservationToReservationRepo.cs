using Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Core.IntegrationTest
{
    [TestClass]
    public class AddOrRemoveReservationToReservationRepo
    {
        ReservationRepository _repoReserv = ReservationRepository.Instance;
        UserRepository _repoUser = UserRepository.Instance;
        RoomRepository _repoRoom = RoomRepository.Instance;

        IRoom _room1;
        IUser _student;

        DateTime _from;
        DateTime _to;

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
        public void Init()
        {
            _repoReserv.Clear();
            _repoRoom.Clear();
            _repoUser.Clear();

            _room1 = new Room('A', 4, 49, 4, Permission.Student);
            _student = new User("hedv", "hedv@edu.eal.dk", Permission.Student);

            _repoUser.Add(_student);
            _repoRoom.Add(_room1);

            _from = new DateTime(2017, 5, 8, 12, 0, 0);
            _to = new DateTime(2017, 5, 8, 13, 0, 0);
        }

        [TestMethod]
        public void WhenAddingReservationToRepoAddToUserAsWell()
        {
            Reservation testRes = new Reservation(_student, _room1, 4, _from, _to);
            _repoReserv.Add(testRes);

            List<Reservation> UsersReservations = _student.GetReservations();

            Assert.IsTrue(UsersReservations.Contains(testRes));
        }

        [TestMethod]
        public void WhenAddingReservationToRepoAddToRoomAsWell()
        {
            Reservation testRes = new Reservation(_student, _room1, 4, _from, _to);
            _repoReserv.Add(testRes);

            List<Reservation> Reservations = _room1.GetReservations();

            Assert.IsTrue(Reservations.Contains(testRes));
        }

        [TestMethod]
        public void WhenRemoveReservationToRepoRemoveFromUserAsWell()
        {
            Reservation testRes = new Reservation(_student, _room1, 4, _from, _to);
            _repoReserv.Add(testRes);
            _repoReserv.Delete(testRes);

            List<Reservation> UsersReservations = _student.GetReservations();

            Assert.IsFalse(UsersReservations.Contains(testRes));
        }

        [TestMethod]
        public void WhenRemovingReservationToRepoRemoveFromRoomAsWell()
        {
            Reservation testRes = new Reservation(_student, _room1, 4, _from, _to);
            _repoReserv.Add(testRes);
            _repoReserv.Delete(testRes);

            List<Reservation> Reservations = _room1.GetReservations();

            Assert.IsFalse(Reservations.Contains(testRes));
        }
    }

}
