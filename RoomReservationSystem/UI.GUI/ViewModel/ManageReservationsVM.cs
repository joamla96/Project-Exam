using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

namespace UI.GUI.ViewModel
{
	class ManageReservationsVM
	{
		public List<Reservation> GetReservations(string from, string to, string username)
		{
			DateTime? dateFrom;
			if (from == "")
			{
				dateFrom = null;
			}
			else
			{
				string dateTimeFrom = from;
				dateFrom = Convert.ToDateTime(dateTimeFrom);
			}

			DateTime? dateTo;
			if (to == "")
			{
				dateTo = null;
			}
			else
			{
				string dateTimeTo = to;
				dateTo = Convert.ToDateTime(dateTimeTo);
			}

			IUser dummyUser;
			if (username == "")
			{
				dummyUser = null;
			} else {
				dummyUser = new User(username, "", Permission.Student);
			}

			return ReservationRepository.Instance.Get(dateFrom, dateTo, dummyUser);
		}
	}
}
