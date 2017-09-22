using System;

namespace CastleGrimtol.Project {
	public class RoomConnection {
		public Room room;
		public string direction;
		public bool isHidden;

		public RoomConnection(Room room, bool isHidden = false) {
			this.room = room;
			this.isHidden = isHidden;
		}
	}
}