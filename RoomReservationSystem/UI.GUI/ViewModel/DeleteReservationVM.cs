using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

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
