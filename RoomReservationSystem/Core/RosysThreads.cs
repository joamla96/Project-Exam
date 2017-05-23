using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using Core.Interfaces;
using DAL;

namespace Core
{
    class RosysThreads : IObservable 
    {
        private ReservationRepository _reservRepo = ReservationRepository.Instance;
        private RoomRepository _roomRepo = RoomRepository.Instance;
        private UserRepository _userRepo = UserRepository.Instance;
        private Change _changesData = new Change();
        IDALFacade _dalFacade = new DALFacade();
        private List<IObserver> _observers = new List<IObserver>();
        private const int NOTIFICATIONSLEEPTIME = 6000;

        public void NotificationThread()
        {
            List<Reservation> reservations = new List<Reservation>();

            reservations = _reservRepo.Get();

            while (SystemSettings._threadRunning)
            {

                foreach (Reservation reserv in reservations)
                {
                    DateTime timeCheck = reserv.From.AddMinutes(-15);
                    if (timeCheck.Date.Equals(DateTime.Now.Date) && timeCheck.Hour.Equals(DateTime.Now.Hour) && timeCheck.Minute.Equals(DateTime.Now.Minute))
                    {
                        this.Notify(reserv);
                    }
                }
                Thread.Sleep(NOTIFICATIONSLEEPTIME);
            }
        }

        public void CheckChangeTable()
        {
            while (SystemSettings._threadRunning)
            {
                List<Dictionary<string, string>> changesInfo = _changesData.GetAllChangesFromDatabase();
                foreach(Dictionary<string, string> change in changesInfo)
                {
                    switch (Int32.Parse(change["Command"]))
                    {
                        case 0: InsertInformation(change); break;
                        case 1: UpdateInformation(change); break;
                        case 2: DeleteInformation(change); break;
                    }
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
            _userRepo.Add(_dalFacade.GetUser(change["PrimaryKey"]));
        }

        private void AddRoomToRepository(Dictionary<string, string> change)
        {
            char splitter = ';';
            string[] roomPK = change["PrimaryKey"].Split(splitter);
            _roomRepo.Add(_dalFacade.GetRoom(roomPK[0], roomPK[1], roomPK[2]));
        }

        private void AddReservationToRepository(Dictionary<string, string> change)
        {
            _reservRepo.Add(_dalFacade.GetReservation(change["PrimaryKey"]));
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
                case "Reservations": DeleteReservationFromRepositroy(change); break;
            }
        }

        private void DeleteUserFromRepository(Dictionary<string, string> change)
        {
            throw new NotImplementedException();
        }

        private void DeleteRoomFromRepository(Dictionary<string, string> change)
        {
            throw new NotImplementedException();
        }

        private void DeleteReservationFromRepositroy(Dictionary<string, string> change)
        {
            throw new NotImplementedException();
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
