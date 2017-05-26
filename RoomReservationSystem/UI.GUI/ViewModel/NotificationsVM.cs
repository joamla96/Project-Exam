using Core;
using System.Threading;
using System.Windows;

namespace UI.GUI.ViewModel
{
	public class NotificationsVM
    {
        private ReservationsObserver _reservationsObserver = ReservationsObserver.Instance;

        public NotificationsVM()
        {
            Thread checkReservationNotificationsThread = new Thread(new ThreadStart(this.CheckReservationsNotifications));
            checkReservationNotificationsThread.IsBackground = true;
            checkReservationNotificationsThread.SetApartmentState(ApartmentState.STA);
            checkReservationNotificationsThread.Start();
        }

        public void CheckReservationsNotifications()
        {
            while (SystemSettings._threadRunning)
            {
                if (_reservationsObserver.Message != null)
                {
                    MessageBox.Show(_reservationsObserver.Message);
                    _reservationsObserver.Message = null;

                }
                Thread.Sleep(100);
            }
        }
    }
}
