using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Core.Interfaces;

namespace Core.IntegrationTest {
	[TestClass]
	public class RequestReservations {
		AddOrRemoveReservationToReservationRepo _repoReserv = AddOrRemoveReservationToReservationRepo.Instance;
		UserRepository _repoUser = UserRepository.Instance;
		RoomRepository _repoRoom = RoomRepository.Instance;

		IRoom _room1;
		IRoom _room2;

		IUser _student;

		[TestInitialize]
		public void Init() {
			_repoReserv.Clear();
			_repoUser.Clear();
			_repoRoom.Clear();

			_room1 = new Room('A', 1, 49, 4, Permission.Student);
			_room2 = new Room('B', 2, 23, 6, Permission.Student);

			_student = new User("jona8690", "jona8690@edu.eal.dk", Permission.Student);

			_repoRoom.Add(_room1);
			_repoRoom.Add(_room2);
		}

		[TestMethod]
		public void StudentCanRequestAReservation() {
			//_repoReserv.RequestReservation();
		}
	}
}
