using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RosysNotifications;

namespace Core
{
    class RosysThreads:IObservable 
    {
        private ReservationRepository _reservRepo = ReservationRepository.Instance;
        private List<IObserver> _observers = new List<IObserver>();
        private const int NOTIFICATIONSLEEPTIME = 60000;

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
                        this.Notify();
                    }
                }
                Thread.Sleep(NOTIFICATIONSLEEPTIME);
            }
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            _observers.ForEach(observer => observer.Update());
        }
    }
}
