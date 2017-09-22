using System;

namespace CastleGrimtol.Project {
    /// A list of all the items contained in the game.
    public static class ItemList {
        public static Item dagger = new Item("Dagger", "A rusted dagger with a very dull edge.");
        public static Item skeleton = new Item("Skeleton", "A long dead adventurer propped near the entrance holding a sign.", "You couldn't possibly carry that. Also, why would you want to!?", "The sign simply says 'Death Awaits'... You feel a slight chill.");
        public static Item map = new Item("Map", "A map that reveals hidden secrets.", "You take the map.", "A magical map. What more do you want?");
        public static Item treasureChest1 = new Item("Chest1", "A tempting treasure chest, probably filled with lots of gold!", "You're greeted with nothing but cobwebs.", "No obvious traps. Do eet!");
        public static Item treasureChestMimic = new Item("Chest2", "A tempting treasure chest, probably filled with lots of gold!", "The treasure chest was actually a mimic. Prepare to fight!", "Something seems off about this treasure chest, but you can't tell what.");
    }
}