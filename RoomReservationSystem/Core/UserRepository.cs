using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class UserRepository
    {
		private static UserRepository _instance = new UserRepository();
		public static UserRepository Instance { get { return _instance; } }

		private List<IUser> _userRepository = new List<IUser>();

		public void Clear() {
			_userRepository.Clear();
		}

        public void Add(IUser user)
        {
            _userRepository.Add(user);
        }

        public void Add(string username, string email, Permission permissionlevel)
        {
            IUser user = new User(username, email, permissionlevel);
            _userRepository.Add(user);
        }

        public List<IUser> Get()
        {
            return _userRepository;
        }

        public IUser Get(IUser checkuser)
        {
            IUser result=null;

            foreach (IUser user in _userRepository)
            {
                if (user.Equals(checkuser))
                {
                    result = user;
                }
            }
            return result;
        }

        //public List<IUser> Get(IRoom checkroom)
        //{
        //    List<IUser> result = new List<IUser>();

        //    foreach (IUser user in _userRepository)
        //    {
        //        foreach(Reservation reservation in )
        //    }
        //}

        public List<IUser> Get(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void Delete(IUser user)
        {
            _userRepository.Remove(user);
        }
    }
}
