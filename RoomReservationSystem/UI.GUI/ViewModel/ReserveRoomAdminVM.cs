using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core;

namespace UI.GUI.ViewModel
{
	class ReserveRoomAdminVM
	{
		ReservationRepository _repoReservation = ReservationRepository.Instance;

		internal List<IRoom> GetAvailableRooms(string from, string to, string date)
		{
			string dateTimeFrom = date + " " + from;
			DateTime dateFrom = Convert.ToDateTime(dateTimeFrom);
			string dateTimeTo = date + " " + to;
			DateTime dateTo = Convert.ToDateTime(dateTimeTo);

			return _repoReservation.GetAvailableRooms(dateFrom, dateTo, LoggedIn.User);
		}
		
	}
}
