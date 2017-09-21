using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Room : IRoom {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
		public List<RoomConnection> connectingRooms = new List<RoomConnection>();

        public void UseItem(Item item) {

        }

		public Room(string name, string description, List<Item> items, List<RoomConnection> connectingRooms) {
			Name = name;
			Description = description;
			Items = items;
			this.connectingRooms = connectingRooms;
		}
    }
}