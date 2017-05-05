using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Core;
using Core.Interfaces;

namespace Core.IntegrationTest {
	[TestClass]
	public class RequestReservations {
		ReservationRepository _repoReserv = ReservationRepository.Instance;
		UserRepository _repoUser = UserRepository.Instance;
		RoomRepository _repoRoom = RoomRepository.Instance;

		IRoom _room1;

		[TestInitialize]
		public void Init() {
			_repoReserv.Clear();
			_repoUser.Clear();
			_repoRoom.Clear();
		}
	}
}
