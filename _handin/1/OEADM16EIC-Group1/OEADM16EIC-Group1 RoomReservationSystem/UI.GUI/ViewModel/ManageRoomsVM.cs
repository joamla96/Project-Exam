using Core;
using Core.Interfaces;
using System.Collections.Generic;

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
