using System;
using Core.Interfaces

namespace Core
{
	public enum Permission
	{
		Admin, Teacher, Student
	}
    public class User : IUser
    {
        public string Username { get; set; }
        public string Email { get; set; }

        List<Reservation> _reservations = new List<Reservation>();

    }
}
