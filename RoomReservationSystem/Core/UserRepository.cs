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
    }
}
