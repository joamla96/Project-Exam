using System;
using Core;
using System.Collections.Generic;

namespace DAL {
	public static class Initialize {
		private static ReservationRepository _repoReserv = ReservationRepository.Instance;
		private static RoomRepository _repoRoom = RoomRepository.Instance;
		private static UserRepository _repoUser = UserRepository.Instance;
		
		public static void StartUp() {
			// Get all the users, and add them to our repo
			Users UsersData = new Users();
			List<User> users = UsersData.GetAllUsers();

			foreach(User user in users) {
				_repoUser.Add(user);
			}
		}
	}
}
