using System.Collections.Generic;

namespace kill_the_trolls.models
{
    public class Player
    {
        public int Health { get; set; }
        public string Name { get; set; }
        public List<Weapon> Weapons { get; set; }
    }
}