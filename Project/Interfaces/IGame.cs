using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public interface IGame {
        Room CurrentRoom { get; set; }
        Player Player { get; set; }

        void Setup();
        void Reset();

        void UseItem(string itemName);
    }
}
