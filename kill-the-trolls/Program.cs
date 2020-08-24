using System;
using System.Collections.Generic;
using System.Threading;
using kill_the_trolls.models;

namespace kill_the_trolls
{
    internal static class Program
    {
        private static void Main()
        {
            var random = new Random();
            var attack = new Attack();

            var trollsHealth = 10;
            var trolls = random.Next(3, 6);
            var playAgain = true;

            var player = new Player
            {
                Health = 30,
                Weapons = new List<Weapon>()
            };

            var sword = new Weapon
            {
                Name = "Sword",
                Description = "A worn short sword",
                Multiplier = 1,
                Dice = Dice.D6,
                Modifier = 3
            };

            var ironFist = new Weapon
            {
                Name = "Iron Fist",
                Description = "A mighty iron glove",
                Multiplier = 1,
                Dice = Dice.D8,
                Modifier = 1
            };

            var trollSlam = new Weapon
            {
                Name = "Troll Slam",
                Description = "Trolls slam with both fists",
                Multiplier = 2,
                Dice = Dice.D4,
                Modifier = 2
            };
            
            player.Weapons.Add(sword);
            player.Weapons.Add(ironFist);

            while (playAgain)
            {
                Console.WriteLine($"Your hero enters a room and inside there are {trolls} trolls");
                Thread.Sleep(1300);
                Console.WriteLine($"Your hero has {player.Weapons.Count} attacks, help him use them wisely");
                Thread.Sleep(1300);

                foreach (var weapon in player.Weapons)
                {
                    Console.WriteLine(
                        $"The {weapon.Name} deals {weapon.Multiplier}d{(int) weapon.Dice} + {weapon.Modifier} damage");
                    Thread.Sleep(1300);
                }
                
                Console.WriteLine(
                    $"The trolls use {trollSlam.Name} which deals {trollSlam.Multiplier}d{(int) trollSlam.Dice} + {trollSlam.Modifier} damage");
                Thread.Sleep(1300);

                if (trolls > 4)
                {
                    player.Health += 5;
                    Console.WriteLine($"As there are {trolls} trolls, you have been granted 5 extra health");
                    Thread.Sleep(1300);
                }

                Console.WriteLine($"You have {player.Health} health");
                Thread.Sleep(1300);

                while (trolls != 0 && player.Health > 0)
                {
                    Console.WriteLine("What attack should you use? [Enter 1 for Sword or 2 for Iron Fist]");
                    var whatAttack = Console.ReadLine();
                    var attackNumber = int.Parse(whatAttack!);
                    Thread.Sleep(750);

                    switch (attackNumber)
                    {
                        case 1:
                        {
                            trollsHealth -= attack.WithWeapon(sword);
                            Console.WriteLine($"Your current target has {trollsHealth} health left");
                            Thread.Sleep(750);

                            TrollAttack();

                            break;
                        }
                        case 2:
                        {
                            trollsHealth -= attack.WithWeapon(ironFist);
                            Console.WriteLine($"Your current target has {trollsHealth} health left");
                            Thread.Sleep(750);

                            TrollAttack();

                            break;
                        }
                        default:
                            Console.WriteLine("That was not a valid attack choice");
                            break;
                    }
                }

                switch (trolls)
                {
                    case 0 when player.Health <= 0:
                        Console.WriteLine("You killed the trolls but died in the process!");
                        Thread.Sleep(750);
                        break;
                    case 0:
                        Console.WriteLine("You are victorious! You killed all the trolls!");
                        Thread.Sleep(750);
                        break;
                    default:
                        Console.WriteLine("You died before killing all the trolls.");
                        Thread.Sleep(750);
                        break;
                }

                trolls = random.Next(3, 6);
                player.Health = 30;
                trollsHealth = 10;

                Console.WriteLine("Play again? [yes or no] ");
                var wantToPlayAgain = Console.ReadLine();

                playAgain = wantToPlayAgain == "yes" || wantToPlayAgain == "y";
            }

            Console.WriteLine("It has been a pleasure slaughtering with you.");
            
            void TrollAttack()
            {
                if (trollsHealth > 0)
                {
                    player.Health -= attack.WithWeapon(trollSlam);
                }

                Console.WriteLine($"You have {player.Health} health left");
                Thread.Sleep(750);

                if (trollsHealth <= 0)
                {
                    trolls -= 1;
                    Console.WriteLine($"One troll down! {trolls} troll{ (trolls == 1 ? "" : "s") } left!");
                    Thread.Sleep(750);
                    trollsHealth = 10;
                }
                else
                {
                    Console.WriteLine($"There { (trolls == 1 ? "is" : "are") } {trolls} troll{ (trolls == 1 ? "" : "s") } left");
                    Thread.Sleep(750);
                }
            }
        }
    }
}