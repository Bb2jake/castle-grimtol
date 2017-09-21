using System;
using System.Linq;
using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Game : IGame {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        private Room entrance;
        private Room foyer;

        public void Reset() {

        }

        public void Setup() {

        }

        void SetupPlayer() {

        }

        void SetupEntrance() {
            List<Item> items = new List<Item>() { ItemList.skeleton };
            RoomConnection foyerConnection = new RoomConnection(foyer, "N");
            List<RoomConnection> connectingRooms = new List<RoomConnection>() { foyerConnection };
            entrance = new Room("Dungeon Entrance", "The entrance to the local dungeon. The air is thick with foreboding.", items, connectingRooms);
        }

        public void UseItem(string itemName) {
            Item item = CurrentRoom.Items.Find(i => i.Name.ToLower() == itemName.ToLower());
            if (item == null) {
                Console.WriteLine("That item doesn't exist. Idjit.");
            } else {
                CurrentRoom.UseItem(item);
            }
        }
    }
}