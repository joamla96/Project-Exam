using Core;
using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace UI.GUI.ViewModel
{
	class ReserveRoomAdminVM
	{
		ReservationRepository _repoReservation = ReservationRepository.Instance;
		UserRepository _repoUser = UserRepository.Instance;

		internal List<IRoom> GetAvailableRooms(string from, string to, string date)
		{
			string dateTimeFrom = date + " " + from;
			DateTime dateFrom = Convert.ToDateTime(dateTimeFrom);
			string dateTimeTo = date + " " + to;
			DateTime dateTo = Convert.ToDateTime(dateTimeTo);

			return _repoReservation.GetAvailableRooms(dateFrom, dateTo, LoggedIn.User);
		}


		
		internal void ReserveRoom(string date, string from, string to, IRoom room, string username)
		{
			IUser dummyUser = new User(username, "", Permission.Student);
			IUser user = _repoUser.Get(dummyUser);

			string dateTimeFrom = date + " " + from;
			DateTime dateFrom = Convert.ToDateTime(dateTimeFrom);
			string dateTimeTo = date + " " + to;
			DateTime dateTo = Convert.ToDateTime(dateTimeTo);

			_repoReservation.Add(user, room, 0, dateFrom, dateTo);
		}
	}
}
