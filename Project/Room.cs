using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Room : IRoom {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
		public Dictionary<string, RoomConnection> connectingRooms = new Dictionary<string, RoomConnection>();

        public void UseItem(Item item) {

        }

		public void TakeItem(Item item) {
			
		}

		public void Look(Item item) {

		}

		public void Look(RoomConnection room) {

		}

		public Room(string name, string description) {
			Name = name;
			Description = description;
			Items = new Dictionary<string, Item>();
		}
    }
}