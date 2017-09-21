using System;

namespace CastleGrimtol.Project {
    /// A list of all the items contained in the game.
    public static class ItemList {
        public static Item dagger = new Item("Dagger", "A rusted dagger with a very dull edge.");
        public static Item skeleton = new Item("Skeleton", "A long dead adventurer propped near the entrance holding a sign.", "You couldn't possibly carry that. Also, why would you want to!?", "The sign simply says 'Death Awaits'... You feel a slight chill.", false);

    }
}