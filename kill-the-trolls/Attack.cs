using System;
using kill_the_trolls.models;

namespace kill_the_trolls
{
    public class Attack
    {
        private readonly Random _random = new Random();

        public int WithWeapon(Weapon weapon, out int attackDamage)
        {
            attackDamage = _random.Next(1, (int) weapon.Dice) + weapon.Modifier;
            return attackDamage;
        }  
    }
}