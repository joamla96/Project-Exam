using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace SystemNotifications
{
    public class ReservationsMonitor : IObserver<Reservation>
    {
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Reservation value)
        {
            throw new NotImplementedException();
        }
    }
}
