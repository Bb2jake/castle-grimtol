using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Game : IGame {
        public Room CurrentRoom { get; set; }
        public Player Player { get; set; }
		bool showHiddenRoom = false;

        void ShowHelp() {
            // Console.Clear();
            Console.WriteLine("Helpful Commands:");
            Console.WriteLine("Take/T <itemname> to pick up an item that's in the room. ex: Take Map");
            Console.WriteLine("Exit and/or <exitdirection> to go through an exit. ex: Exit W1 or just 'W1'");
            Console.WriteLine("Use/U <itemname> to use an item in your inventory. ex: Use Dagger");
            Console.WriteLine("Help/H to show this menu");
            Console.WriteLine("Quit/Q any time to exit the game entirely.\n\n");
        }

        void ShowExits() {
            Console.Write("Room exits: ");
            foreach (var exit in CurrentRoom.exits) {
				if (exit.Value.Name == "Treasure Room" && !showHiddenRoom)
					continue;
                Console.Write(exit.Key + ", ");
			}
        }

        void ShowItems() {
            if (CurrentRoom.Items.Count > 0) {
                Console.WriteLine("Items:");
                foreach (var item in CurrentRoom.Items) {
                    Console.WriteLine(item.Key + $" : {item.Value.Description}");
                }
            }
            Console.WriteLine("----------------------");
        }

		void ShowInventory() {
			Console.WriteLine();
			Console.Write("Items in inventory: ");
			foreach (var item in Player.Inventory) {
				Console.WriteLine(item.Key);
			}
			Console.WriteLine();
		}

        void ShowRoom() {
            Console.WriteLine("Current room: " + CurrentRoom.Name + " - " + CurrentRoom.Description);
            Console.WriteLine("----------------------");
            ShowItems();
            ShowExits();
			ShowInventory();
        }

        void GetUserInput() {
			Player.Score--;
            ShowRoom();
			Console.WriteLine("Current Score: " + Player.Score);
            Console.Write("\nEnter a command: ");
            var input = Console.ReadLine().ToLower();
            var split = input.Split(' ');
            var firstWord = split[0];
            var secondWord = "";
            if (split.Length > 1)
                secondWord = split[1];

			Console.Clear();

            if (input == "help" || input == "h") {
                ShowHelp();
                GetUserInput();
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
            var exit = CurrentRoom.exits.ContainsKey(direction.ToUpper()) ? CurrentRoom.exits[direction.ToUpper()] : null;

			if (exit == null || (exit.Name == "Treasure Room" && !showHiddenRoom)) {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Beep();
                Console.Write("You faceplant into a wall. ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("There's no exit in that direction.");
			} else {
                CurrentRoom = exit;
			}

			if (CurrentRoom.Name == "Treasure Room") {
				Console.WriteLine("You found the hidden treasure room. You win! Final score: " + Player.Score);
				Environment.Exit(0);
			}

            GetUserInput();
        }

        public void UseItem(string itemName) {
            itemName = char.ToUpper(itemName[0]) + itemName.Substring(1);

            if (!Player.Inventory.ContainsKey(itemName)) {
                Console.WriteLine("That item doesn't exist. Idjit.");
                GetUserInput();
            } else {
				if (CurrentRoom.Name == "Foyer" && !showHiddenRoom) {
					showHiddenRoom = true;
					Console.WriteLine("The map flashes and reveals a heretofore hidden room to the east.");
					GetUserInput();
				} else {
					Console.ForegroundColor = ConsoleColor.Red;
					Console.Beep();
					Console.WriteLine("The map summons a black hole. You are sucked in and probably die.");
					Console.ForegroundColor = ConsoleColor.White;
				}
            }
        }

        void TakeItem(string itemName) {
            itemName = char.ToUpper(itemName[0]) + itemName.Substring(1);

            if (!CurrentRoom.Items.ContainsKey(itemName)) {
                Console.WriteLine("No such item in this room");
                GetUserInput();
            } else {
                CurrentRoom.TakeItem(CurrentRoom.Items[itemName], Player);
            }

			GetUserInput();
        }

        public void Reset() {

        }

        public void Setup() {
            SetupPlayer();
            SetupRooms();
            ShowHelp();
            GetUserInput();
        }

        void SetupPlayer() {
            Player = new Player();
        }

        void SetupRooms() {
            // Create rooms
            var entrance = new Room("Dungeon Entrance", "The entrance to the local dungeon. The air is thick with foreboding.");
            var foyer = new Room("Foyer", "An unassuming room with nothing of apparent importance.");
            var hiddenTreasureRoom = new Room("Treasure Room", "A small room, filled to the brim with gold and other treasures, ready for the taking.");
            var mapRoom = new Room("Map Room", "Another mostly bare room. You have a faint sense of unease, but can't place its source.");

            // Add Items
            // entrance.Items.Add(ItemList.skeleton.Name, ItemList.skeleton);
            // hiddenTreasureRoom.Items.Add(ItemList.treasureChest1.Name, ItemList.treasureChest1);
            // hiddenTreasureRoom.Items.Add(ItemList.treasureChestMimic.Name, ItemList.treasureChestMimic);
            mapRoom.Items.Add(ItemList.map.Name, ItemList.map);

            // Add Exits
            entrance.exits.Add("N", foyer);
            foyer.exits.Add("N", mapRoom);
            foyer.exits.Add("E", hiddenTreasureRoom);
            hiddenTreasureRoom.exits.Add("W", foyer);
            mapRoom.exits.Add("S", foyer);

            CurrentRoom = entrance;
        }
    }
}