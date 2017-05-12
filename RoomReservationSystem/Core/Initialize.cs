using System;
using System.Collections.Generic;
using Core.Interfaces;

namespace Core {
	public class Initialize {
		private static DALFacade _dal = new DALFacade();

		private static ReservationRepository _repoReserv = ReservationRepository.Instance;
		private static RoomRepository _repoRooms = RoomRepository.Instance;
		private static UserRepository _repoUsers = UserRepository.Instance;

		public static void StartUp() {
			List<IUser> Users = _dal.GetAllUsers();
			List<IRoom> Rooms = _dal.GetAllRooms();

			foreach(IUser user in Users) {
				_repoUsers.Add(user);
			}

			foreach(IRoom room in Rooms) {
				_repoRooms.Add(room);
			}

            List<Reservation> reservations = _dal.GetAllReservations();
            foreach(Reservation reservation in reservations)
            {
                _repoReserv.Add(reservation);
            }
		}
	}
}
