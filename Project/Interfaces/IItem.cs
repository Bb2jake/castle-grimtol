using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public interface IItem {
        string Name { get; set; }
        string Description { get; set; }
        string TakeResponse { get; set; }
        string ExamineResponse { get; set; }
        // bool Interactable { get; set; }
    }
}