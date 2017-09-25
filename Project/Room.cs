using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Room : IRoom {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
		public Dictionary<string, Room> exits = new Dictionary<string, Room>();

        public void UseItem(Item item) {

        }

		public void TakeItem(Item item, Player player) {
			player.Inventory.Add(item.Name, item);
			Items.Remove(item.Name);
			Console.WriteLine("You take the " + item.Name + " and add it to your inventory.");
		}

		public Room(string name, string description) {
			Name = name;
			Description = description;
			Items = new Dictionary<string, Item>();
		}
    }
}