using System;
using Core.Interfaces;
using System.Collections.Generic;

namespace Core
{
	public enum Permission
	{
		Student, Teacher, Admin
	}
    public class User : IUser
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public Permission PermissionLevel { get; set; }

        List<Reservation> _reservations = new List<Reservation>();
        

        public User(string username, string email, Permission premissionLevel)
        {
            this.Username = username;
            this.Email = email;
            this.PermissionLevel = premissionLevel;
        }

        public override bool Equals(object obj)
        {
            bool thesame = false;
            if (obj is IUser)
            {
                IUser Other = (IUser)obj;

                if (this.Username.Equals(Other.Username)) thesame = true;
            }

            return thesame;
        }

        public List<Reservation> GetReservations()
        {
            return _reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            _reservations.Add(reservation);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _reservations.Remove(reservation);
        }
    }
}
