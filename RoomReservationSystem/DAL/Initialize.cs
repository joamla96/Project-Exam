using System;
using Core;

namespace DAL {
	public static class Initialize {
		private static ReservationRepository _repoReserv = ReservationRepository.Instance;
		private static RoomRepository _repoRoom = RoomRepository.Instance;
		private static UserRepository _repoUser = UserRepository.Instance;
		
		public static void StartUp() {

		}
	}
}
