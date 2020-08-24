using System;
using System.Threading;
using kill_the_trolls.models;

namespace kill_the_trolls
{
    public class Attack
    {
        private readonly Random _random = new Random();

        public int WithWeapon(Weapon weapon)
        {
            var diceRollTotal = 0;
            
            Console.WriteLine($"Attacking with {weapon.Name}");
            Thread.Sleep(750);
            
            for (var i = 0; i < weapon.Multiplier; i++)
            {
                diceRollTotal += _random.Next(1, (int) weapon.Dice);
            }
            
            var attackDamage = diceRollTotal + weapon.Modifier;

            Console.WriteLine($"{weapon.Multiplier} x d{(int) weapon.Dice} rolled for a total of {diceRollTotal} + modifier of {weapon.Modifier} = {attackDamage}");
            Thread.Sleep(750);
            Console.WriteLine($"{weapon.Name} has caused {attackDamage} damage");
            Thread.Sleep(750);
            
            return attackDamage;
        }  
    }
}