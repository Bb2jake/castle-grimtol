using System;

namespace CastleGrimtol.Project {
	public class RoomConnection {
		public Room room;
		public string direction;
		public bool isHidden;

		public RoomConnection(Room room, string direction, bool isHidden = false) {
			this.room = room;
			this.direction = direction;
			this.isHidden = isHidden;
		}
	}
}