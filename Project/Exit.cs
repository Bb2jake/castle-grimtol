using System;

namespace CastleGrimtol.Project {
	public class Exit {
		public Room room;
		public string direction;
		public bool isHidden;

		public Exit(Room room, bool isHidden = false) {
			this.room = room;
			this.isHidden = isHidden;
		}
	}
}