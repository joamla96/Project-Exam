using Core;
using Core.Exceptions;
using Core.Interfaces;
using System;

namespace UI.GUI.ViewModel
{
	class ReserveRoomVM
	{
		ReservationRepository _reserveRepo = ReservationRepository.Instance;

		public string ReserveRoom(string date, string from, string to, string peoplenr)
		{
			string message;
			string dateTimeFrom = date + " " + from;
			DateTime dateFrom = Convert.ToDateTime(dateTimeFrom);
			string dateTimeTo = date + " " + to;
			DateTime dateTo = Convert.ToDateTime(dateTimeTo);
			int peopleNR = int.Parse(peoplenr);
			try
			{
				IRoom room = _reserveRepo.RequestReservation(dateFrom, dateTo, peopleNR, LoggedIn.User);
				message = "You have been assigned to room: " + room.ID;
			}
			catch (NoRoomsAvailableException)
			{
				message = "No rooms available, placed in Que";
			}
			catch(UserAlreadyHasRoomException)
			{
				message = "You already have a room booked, at this time.";
			}

			return message;
		}


	}
}
