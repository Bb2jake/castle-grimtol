using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Room : IRoom {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
		public Dictionary<string, Exit> exits = new Dictionary<string, Exit>();

        public void UseItem(Item item) {

        }

		public void TakeItem(Item item) {
			
		}

		public void Look(Item item) {

		}

		public void Look(Exit exit) {

		}

		public Room(string name, string description) {
			Name = name;
			Description = description;
			Items = new Dictionary<string, Item>();
		}
    }
}