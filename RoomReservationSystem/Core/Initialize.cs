using System;
using System.Collections.Generic;
using Core.Interfaces;
using System.Threading;
using RosysNotifications;

namespace Core {
	public static class Initialize
    {
		private static DALFacade _dal = new DALFacade();

		private static ReservationRepository _repoReserv = ReservationRepository.Instance;
		private static RoomRepository _repoRooms = RoomRepository.Instance;
		private static UserRepository _repoUsers = UserRepository.Instance;

		public static void StartUp() {
            RosysThreads threads = new RosysThreads();
            threads.Subscribe(new ReservationsObserver("Notifications"));

            List<IUser> users = _dal.GetAllUsers();
			List<IRoom> rooms = _dal.GetAllRooms();

			foreach(IUser user in users) {
				_repoUsers.LoadFromDatabase(user);
			}

			foreach(IRoom room in rooms) {
				_repoRooms.LoadFromDatabase(room);
			}

            List<Reservation> reservations = _dal.GetAllReservations();
            foreach(Reservation reservation in reservations)
            {
                _repoReserv.LoadFromDatabase(reservation);
            }

			// Tell the DAL what enviroment we're in
			SystemSettings.UpdateSystemEnvironment();

			Thread notificationThread = new Thread(new ThreadStart(threads.NotificationThread));
			notificationThread.IsBackground = true;
			notificationThread.Start();
        }
	}
}
