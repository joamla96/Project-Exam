using Core.Interfaces;

namespace Core
{
	public class ReservationsObserver : IObserver
    {
        private static ReservationsObserver _instance = new ReservationsObserver("Notifications");
        public static ReservationsObserver Instance { get { return _instance; } }
        public string Message { get; set; }
        public string ObserverName { get; private set; }
        public ReservationsObserver(string name)
        {
            this.ObserverName = name;
        }
        public void Update(string message)
        {
            Message = message;
        }
    }
}
