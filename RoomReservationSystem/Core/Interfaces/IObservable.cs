using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RosysNotifications;

namespace Core.Interfaces
{
    public interface IObservable
    {
        void Subscribe(IObserver observer);
        void Unsubscribe(IObserver observer);
        void Notify();
    }
}
