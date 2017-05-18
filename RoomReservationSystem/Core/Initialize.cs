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
			List<IUser> users = _dal.GetAllUsers();
			List<IRoom> rooms = _dal.GetAllRooms();

			foreach(IUser user in users) {
				_repoUsers.Add(user);
			}

			foreach(IRoom room in rooms) {
				_repoRooms.Add(room);
			}

            List<Reservation> reservations = _dal.GetAllReservations();
            foreach(Reservation reservation in reservations)
            {
                _repoReserv.Add(reservation);
            }

            //DebugNoDatabase(); // Remove in Prod.
		}

        public static void DebugNoDatabase()
        {
            IRoom room1 = new Room('A', 2, 2, 2, Permission.Student);
            IRoom room2 = new Room('B', 2, 2, 4, Permission.Student);
            IRoom room3 = new Room('B', 2, 2, 6, Permission.Student);

            _repoRooms.Add(room1);
            _repoRooms.Add(room2);
            _repoRooms.Add(room3);
        }
	}
}
