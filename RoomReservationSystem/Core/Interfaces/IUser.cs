using System;
using System.Collections.Generic;

namespace Core.Interfaces
{
	public interface IUser
	{
		string Username { get; }
		string Email { get; }
        Permission PermissionLevel { get; set; }

        void AddReservation(Reservation reservation);
        List<Reservation> GetReservations();
        void DeleteReservation(Reservation reservation);
    }
}
