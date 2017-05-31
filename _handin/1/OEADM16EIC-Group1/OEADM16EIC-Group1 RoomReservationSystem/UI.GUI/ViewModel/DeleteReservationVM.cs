using Core;
using System.Collections.Generic;

namespace UI.GUI.ViewModel
{
	class DeleteReservationVM
	{
		ReservationRepository _reservRepo = ReservationRepository.Instance;

		public List<Reservation> GetReservationList()
		{
			List<Reservation> reservationList = _reservRepo.Get(LoggedIn.User);
			return reservationList;
		}

		public void DeleteReservation(Reservation reservation)
		{
			_reservRepo.Delete(reservation);
		}
	}
}
