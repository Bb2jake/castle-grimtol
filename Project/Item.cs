using System.Collections.Generic;

namespace CastleGrimtol.Project {
    public class Item : IItem {
        public string Name { get; set; }
        public string Description { get; set; }
        public string TakeResponse { get; set; }
        public string ExamineResponse { get; set; }
        public bool Interactable { get; set; }

        public Item(string name, string description, string takeResponse = "", string examineResponse = "", bool interactable = false) {
            Name = name;
            Description = description;
			TakeResponse = takeResponse;
			ExamineResponse = examineResponse;
            Interactable = interactable;
        }
    }
}