using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Player : IPlayer {
        public int Score { get; set; }
        public Item Weapon { get; set; }
        public Dictionary<string, Item> Inventory { get; set; }

        public Player(Item weapon) {
            Weapon = weapon;
            Inventory = new Dictionary<string, Item>();
            Score = 0;
        }
    }
}