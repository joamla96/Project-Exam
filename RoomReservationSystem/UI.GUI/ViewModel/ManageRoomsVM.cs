using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Interfaces;

namespace UI.GUI.ViewModel
{

	class ManageRoomsVM
	{
		RoomRepository _repoRoom = RoomRepository.Instance;

		public List<IRoom> GetRoomList()
		{
			List<IRoom> roomList = _repoRoom.Get();
			return roomList;
		}

		public void DeleteRoom(IRoom room)
		{
			_repoRoom.Delete(room);
		}
	}
}
