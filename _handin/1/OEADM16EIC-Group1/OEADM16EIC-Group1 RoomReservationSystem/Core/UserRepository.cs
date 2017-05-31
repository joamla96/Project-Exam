using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core
{
    public class UserRepository
    {
        private static UserRepository _instance = new UserRepository();
        public static UserRepository Instance { get { return _instance; } }
        private DALFacade _dalFacade = new DALFacade();

        private List<IUser> _userRepository = new List<IUser>();

        public void Clear()
        {
            ReservationRepository.Instance.Clear();
            //foreach(IUser user in _userRepository)
            //{
            //    _dalFacade.DeleteUser(user);
            //}
            _dalFacade.DeleteAllUsers();
            _userRepository.Clear();
        }

        public void Add(IUser user)
        {
            _userRepository.Add(user);
            _dalFacade.InsertUser(user);
        }

        public void Add(string username, string email, Permission permissionlevel)
        {
            IUser user = new User(username, email, permissionlevel);
            this.Add(user);
        }

        public void LoadFromDatabase(IUser user)
        {
            _userRepository.Add(user);
        }

        public void DeleteFromRepository(IUser user)
        {
            _userRepository.Remove(user);
        }

        public List<IUser> Get()
        {
            return _userRepository;
        }

        public IUser Get(IUser checkuser)
        {
            IUser result = null;

            foreach (IUser user in _userRepository)
            {
                if (user.Equals(checkuser))
                {
                    result = user;
                }
            }

            if (result == null)
            {
                throw new IndexOutOfRangeException();
            }

            return result;
        }

        public List<IUser> Get(IRoom checkroom)
        {
            List<IUser> userByRoom = new List<IUser>();

            foreach (IUser user in _userRepository)
            {
                foreach (Reservation reservation in user.GetReservations())
                {
                    if (reservation.Room.Equals(checkroom))
                    {
                        userByRoom.Add(user);
                    }
                }
            }
            return userByRoom;

        }

        public List<IUser> Get(Reservation checkreservation)
        {
            List<IUser> userByReservation = new List<IUser>();

            foreach (IUser user in _userRepository)
            {
                foreach (Reservation reservation in user.GetReservations())
                {
                    if (reservation.Equals(checkreservation))
                    {
                        userByReservation.Add(user);
                    }

                }

            }
            return userByReservation;
        }

        public void Delete(IUser user)
        {
            foreach (Reservation res in user.GetReservations())
            {
                ReservationRepository.Instance.Delete(res);
            }
            _userRepository.Remove(user);
            _dalFacade.DeleteUser(user);
        }
    }
}
