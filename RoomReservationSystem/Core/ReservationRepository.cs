using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class ReservationRepository
    {
        List<Reservation> _reservationRepository = new List<Reservation>();

        private static ReservationRepository _instance = new ReservationRepository();
        public static ReservationRepository Instance { get { return _instance; } }

        public void Clear()
        {
            _reservationRepository.Clear();
        }

        public void Add(Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
