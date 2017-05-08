using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Exceptions;
using Core.Interfaces;

namespace UI.GUI.ViewModel
{
    class ReserveRoomVM
    {
        ReservationRepository reserveRepo = ReservationRepository.Instance; 
        public string ReserveRoom(string date, string from, string to, string peopleNr)
        {
            string message;
            string dateTimeFrom = date + " " + from;
            DateTime dateFrom = Convert.ToDateTime(dateTimeFrom);
            string dateTimeTo = date + " " + to;
            DateTime dateTo = Convert.ToDateTime(dateTimeTo);
            int peopleNR = int.Parse(peopleNr);
            try
            {
                IRoom room = reserveRepo.RequestReservation(dateFrom, dateTo, peopleNR);
                message = "You have been assigned to room: " + room.ID;
            }
            catch(NoRoomsAvailable)
            {
                message = "No rooms available";
            }
           
            return message;
        }
    }
}
