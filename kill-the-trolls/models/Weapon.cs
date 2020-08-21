using System;

namespace kill_the_trolls.models
{
    public class Weapon
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dice Dice { get; set; }
        public int Modifier { get; set; }
        public int Multiplier { get; set; }
    }
}