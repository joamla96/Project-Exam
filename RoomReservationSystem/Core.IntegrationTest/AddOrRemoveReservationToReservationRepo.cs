using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core.IntegrationTest {
	[TestClass]
	public class AddOrRemoveReservationToReservationRepo {
		ReservationRepository repoReserv = ReservationRepository.Instance;
		UserRepository repoUser = UserRepository.Instance;
		RoomRepository repoRoom = RoomRepository.Instance;

		IRoom _room1;
		IUser _user1;

		DateTime _from;
		DateTime _to;

		[TestInitialize]
		public void Init() {
			repoReserv.Clear();
			repoRoom.Clear();
			repoUser.Clear();

			_room1 = new Room('A', 4,49,4,Permission.Student);
			_user1 = new User("hedv", "hedv@edu.eal.dk", Permission.Student);

			_from = new DateTime(2017, 5, 8, 12, 0, 0);
			_to = new DateTime(2017, 5, 8, 13, 0, 0);
		}

		[TestMethod]
		public void WhenAddingReservationToRepoAddToUserAsWell() {
			Reservation testRes = new Reservation(_user1, _room1,4,_from,_to);
			repoReserv.Add(testRes);

			List<Reservation> UsersReservations = _user1.GetReservations();

			Assert.IsTrue(UsersReservations.Contains(testRes));
		}

		[TestMethod]
		public void WhenAddingReservationToRepoAddToRoomAsWell() {
			Reservation testRes = new Reservation(_user1, _room1, 4, _from, _to);
			repoReserv.Add(testRes);

			List<Reservation> Reservations = _room1.GetReservations();

			Assert.IsTrue(Reservations.Contains(testRes));
		}
	}

}
