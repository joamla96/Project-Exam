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

        public void Add(IUser student)
        {
            throw new NotImplementedException();
        }

        public void Add(string v1, string v2, Permission student)
        {
            throw new NotImplementedException();
        }

        public List<IUser> Get()
        {
            throw new NotImplementedException();
        }

        public IUser Get(IUser student)
        {
            throw new NotImplementedException();
        }

        public List<IUser> Get(IRoom room)
        {
            throw new NotImplementedException();
        }

        public List<IUser> Get(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public void Delete(IUser student)
        {
            throw new NotImplementedException();
        }
    }
}
