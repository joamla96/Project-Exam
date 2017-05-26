using Core.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Core
{
	class RosysThreads : IObservable 
    {
        private ReservationRepository _repoReservations = ReservationRepository.Instance;
        private RoomRepository _repoRooms = RoomRepository.Instance;
        private UserRepository _repoUsers = UserRepository.Instance;
        private Change _changesData = new Change();
        IDALFacade _dalFacade = new DALFacade();
        private List<IObserver> _observers = new List<IObserver>();
        private const int NOTIFICATIONSLEEPTIME = 60000;
		private const int MAINTSLEEPTIME = 60 * 60 * 24; // Run daily
		 
        public void NotificationThread()
        {
            List<Reservation> reservations = new List<Reservation>();

            reservations = _repoReservations.Get();

            while (SystemSettings._threadRunning)
            {

                foreach (Reservation reserv in reservations)
                {
                    DateTime timeCheck = reserv.From.AddMinutes(-15);
                    if (timeCheck.Date.Equals(DateTime.Now.Date) && timeCheck.Hour.Equals(DateTime.Now.Hour) && timeCheck.Minute.Equals(DateTime.Now.Minute))
                    {
                        this.Notify(reserv);
                        reservations.Remove(reserv);
                    }
                }
                Thread.Sleep(NOTIFICATIONSLEEPTIME);
            }
        }

		public void MaintenanceThread()
		{
			// Check and remove old/outdated reservations
			List<Reservation> resRemove = new List<Reservation>();
			foreach(Reservation res in ReservationRepository.Instance.Get())
			{
				if(res.To < DateTime.Now)
				{
					resRemove.Add(res);
				}
			}

			foreach(Reservation res in resRemove)
			{
				ReservationRepository.Instance.Delete(res);
			}

			// Check and remove old reservations from the Que
			resRemove = new List<Reservation>();
			foreach (Reservation res in ReservationRepository.Instance.GetQueue())
			{
				if (res.To < DateTime.Now)
				{
					resRemove.Add(res);
				}
			}

			foreach (Reservation res in resRemove)
			{
				ReservationRepository.Instance.Delete(res);
			}

			Thread.Sleep(MAINTSLEEPTIME);
		}

        public void CheckChangeTable()
        {
            while (SystemSettings._threadRunning)
            {
                List<Dictionary<string, string>> changesInfo = _changesData.GetAllChangesFromDatabase();
                foreach(Dictionary<string, string> change in changesInfo)
                {
                    switch (int.Parse(change["Command"]))
                    {
                        case 0: InsertInformation(change); break;
                        case 1: UpdateInformation(change); break;
                        case 2: DeleteInformation(change); break;
                    }
                    _changesData.DeleteChangeFromDatabase(int.Parse(change["ID"]));
                }
                Thread.Sleep(100);
            }
        }

        private void InsertInformation(Dictionary<string, string> change)
        {
            switch (change["TableName"])
            {
                case "Users": AddUserToRepository(change); break;
                case "Rooms": AddRoomToRepository(change); break;
                case "Reservations": AddReservationToRepository(change); break;
            }
        }

        private void AddUserToRepository(Dictionary<string, string> change)
        {
            _repoUsers.LoadFromDatabase(_dalFacade.GetUser(change["PrimaryKey"]));
        }

        private void AddRoomToRepository(Dictionary<string, string> change)
        {
            char splitter = ';';
            string[] roomPK = change["PrimaryKey"].Split(splitter);
            _repoRooms.LoadFromDatabase(_dalFacade.GetRoom(roomPK[0], roomPK[1], roomPK[2]));
        }

        private void AddReservationToRepository(Dictionary<string, string> change)
        {
            char splitter = ';';
            string[] reservationPK = change["PrimaryKey"].Split(splitter);
            string id = reservationPK[0];
            _repoReservations.LoadFromDatabase(_dalFacade.GetReservation(id));
        }

        private void UpdateInformation(Dictionary<string, string> change)
        {
            throw new NotImplementedException();
        }

        private void DeleteInformation(Dictionary<string, string> change)
        {
            switch (change["TableName"])
            {
                case "Users": DeleteUserFromRepository(change); break;
                case "Rooms": DeleteRoomFromRepository(change); break;
                case "Reservations": DeleteReservationFromRepository(change); break;
            }
        }

        private void DeleteUserFromRepository(Dictionary<string, string> change)
        {
            IUser dummyUser = new User(change["PrimaryKey"], "", Permission.Student);
            IUser user = _repoUsers.Get(dummyUser);
            _repoUsers.DeleteFromRepository(user);
        }

        private void DeleteRoomFromRepository(Dictionary<string, string> change)
        {
            char splitter = ';';
            string[] roomPK = change["PrimaryKey"].Split(splitter);
            char building = char.Parse(roomPK[0]);
            int floorNr = int.Parse(roomPK[1]);
            int nr = int.Parse(roomPK[2]);
            IRoom dummyRoom = new Room(building, floorNr, nr, 0, Permission.Student);
            IRoom room = _repoRooms.Get(dummyRoom);
            _repoRooms.DeleteFromRepository(room);
        }

        private void DeleteReservationFromRepository(Dictionary<string, string> change)
        {
            char splitter = ';';
            string[] reservationPK = change["PrimaryKey"].Split(splitter);
            string id = reservationPK[0];
            string dateTo = reservationPK[1];
            string dateFrom = reservationPK[2];
            string username = reservationPK[3];
            IUser dummyUser = new User(username, "", Permission.Student);
            IRoom dummyRoom = new Room('A', 1, 1, 0, Permission.Student);
            Reservation dummyReservation = new Reservation(dummyUser, dummyRoom, 1, Convert.ToDateTime(dateFrom), Convert.ToDateTime(dateTo));
            Reservation reservation = _repoReservations.Get(dummyReservation);
            _repoReservations.DeleteFromRepository(reservation);
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify(Reservation reserv)
        {
            string message = "You have a reservation in room " + reserv.Room + " in 15 minutes.";
            _observers.ForEach(observer => observer.Update(message));
        }
    }
}
