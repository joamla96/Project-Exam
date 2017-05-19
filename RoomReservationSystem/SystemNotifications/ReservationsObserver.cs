using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

namespace SystemNotifications
{
    public class ReservationsObserver : IObserver
    {
        public string ObserverName { get; private set; }
        public ReservationsObserver(string name)
        {
            this.ObserverName = name;
        }
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
