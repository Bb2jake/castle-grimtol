using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Game : IGame {
        public Room CurrentRoom { get; set; }
        public Player Player { get; set; }

        private Room entrance;
        private Room foyer;
        private Room mapRoom;
        private Room hiddenTreasureRoom;

        void ShowHelp() {
            Console.Clear();
            Console.WriteLine("Helpful Commands:");
            Console.WriteLine("Take/T <itemname> to pick up an item that's in the room. ex: Take Map");
            Console.WriteLine("Exit and/or <exitdirection> to go through an exit. ex: Exit W1 or just 'W1'");
            Console.WriteLine("Look/L <itemname/exitname> to look close at an item or exit that's in the room. ex: Look S1");
            Console.WriteLine("Use/U <itemname> to use an item in your inventory. ex: Use Dagger");
            Console.WriteLine("Help/H to show this menu");
            Console.WriteLine("Quit/Q any time to exit the game entirely.\n\n");
        }

        void ShowExits() {
            Console.Write("Room exits: ");
            foreach (var item in CurrentRoom.connectingRooms) {
                Console.Write(item.Key + ", ");
            }
        }

        void ShowItems() {
            if (CurrentRoom.Items.Count > 0) {
                Console.WriteLine("Items:");
                foreach (var item in CurrentRoom.Items) {
                    Console.WriteLine(item.Key + $" : {item.Value.Description}");
                }
            }
        }

        void ShowRoom() {
            Console.WriteLine("Current room: " + CurrentRoom.Name + " - " + CurrentRoom.Description);
            Console.WriteLine("----------------------");
            ShowItems();
            ShowExits();
        }

        void GetUserInput() {
            ShowRoom();
            Console.Write("\nEnter a command: ");
            var input = Console.ReadLine().ToLower();
            var split = input.Split(' ');
            var firstWord = split[0];
            var secondWord = "";
            if (split.Length > 1)
                secondWord = split[1];

            if (input == "help" || input == "h") {
                ShowHelp();
                GetUserInput();
            } else if ((firstWord == "look" || firstWord == "l") && !string.IsNullOrEmpty(secondWord)) {
                Look(secondWord);
            } else if ((firstWord == "use" || firstWord == "u") && !string.IsNullOrEmpty(secondWord)) {
                UseItem(secondWord);
            } else if ((firstWord == "take" || firstWord == "t") && !string.IsNullOrEmpty(secondWord)) {
                TakeItem(secondWord);
            } else if (input == "quit" || input == "q") {
                Console.WriteLine("Logging you out, Shepard");
                Environment.Exit(0);
            } else if ((firstWord == "exit") && !string.IsNullOrEmpty(secondWord)) {
                ExitRoom(secondWord);
            } else if (firstWord == "w" || firstWord == "e" || firstWord == "n" || firstWord == "s") {
                ExitRoom(firstWord);
            } else {
                Console.WriteLine("Unable to recognize command. Please try again.");
                GetUserInput();
            }
        }

        void ExitRoom(string direction) {
            var exit = CurrentRoom.connectingRooms[direction.ToUpper()];
			
            if (exit != null && !exit.isHidden) {
                CurrentRoom = exit.room;
                Console.WriteLine(CurrentRoom.Description);
            }
        }

        void Look(string name) {
            name = char.ToUpper(name[0]) + name.Substring(1);

            if (CurrentRoom.connectingRooms[name] != null) {
                CurrentRoom.Look(CurrentRoom.connectingRooms[name]);
            } else if (CurrentRoom.Items[name] != null) {
                CurrentRoom.Look(CurrentRoom.Items[name]);
            } else {
                Console.WriteLine("No such item by that name or room in that direction");
            }

            GetUserInput();
        }

        public void UseItem(string itemName) {
            itemName = char.ToUpper(itemName[0]) + itemName.Substring(1);

            var item = Player.Inventory[itemName];
            if (item == null) {
                Console.WriteLine("That item doesn't exist. Idjit.");
                GetUserInput();
            } else {
                CurrentRoom.UseItem(item);
            }
        }

        void TakeItem(string itemName) {
            itemName = char.ToUpper(itemName[0]) + itemName.Substring(1);
            var item = CurrentRoom.Items[itemName];

            if (item == null) {
                Console.WriteLine("No such item in this room");
                GetUserInput();
            } else {
                CurrentRoom.TakeItem(item);
            }
        }

        public void Reset() {

        }

        public void Setup() {
            SetupPlayer();
            SetupEntrance();
            SetupFoyer();
            SetupHiddenTreasureRoom();
            SetupMapRoom();
            CurrentRoom = entrance;
            ShowHelp();
            GetUserInput();
        }

        void SetupPlayer() {
            Player = new Player(ItemList.dagger);
        }

        void SetupEntrance() {
            entrance = new Room("Dungeon Entrance", "The entrance to the local dungeon. The air is thick with foreboding.");
            entrance.Items.Add(ItemList.skeleton.Name, ItemList.skeleton);
            entrance.connectingRooms.Add("N", new RoomConnection(new Room("Foyer", "A Foyer")));
        }

        void SetupFoyer() {
            foyer = new Room("Foyer", "An unassuming room with nothing of apparent importance.");
            foyer.connectingRooms.Add("N", new RoomConnection(mapRoom));
            foyer.connectingRooms.Add("E", new RoomConnection(hiddenTreasureRoom, true));
        }

        void SetupHiddenTreasureRoom() {
            hiddenTreasureRoom = new Room("Treasure Room", "A small room, with two treasure chests at the far end, ready for the taking.");
            hiddenTreasureRoom.Items.Add(ItemList.treasureChest1.Name, ItemList.treasureChest1);
            hiddenTreasureRoom.Items.Add(ItemList.treasureChestMimic.Name, ItemList.treasureChestMimic);
            hiddenTreasureRoom.connectingRooms.Add("W", new RoomConnection(foyer));
        }

        void SetupMapRoom() {
            mapRoom = new Room("Map Room", "Another mostly bare room. You have a faint sense of unease, but can't place its source.");
            mapRoom.Items.Add(ItemList.map.Name, ItemList.map);
            mapRoom.connectingRooms.Add("S", new RoomConnection(foyer));
        }
    }
}