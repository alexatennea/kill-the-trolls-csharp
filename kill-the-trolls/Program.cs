using System;
using System.Threading;

namespace kill_the_trolls
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var random = new Random();
            var health = 30;
            var sword = random.Next(1, 5);
            var ironFist = random.Next(2, 5);
            var trollsHealth = 6;
            var trollAttack = random.Next(1, 3);
            var trolls = random.Next(3, 6);
            var playagain = true;

            while (playagain)
            {
                Console.WriteLine($"Your hero enters a room and inside there are {trolls} trolls");
                Thread.Sleep(1300);
                Console.WriteLine("Your hero has 2 attacks, help him use them wisely");
                Thread.Sleep(1300);
                Console.WriteLine("The Sword deals between 1 and 5 damage");
                Thread.Sleep(1300);
                Console.WriteLine("The Iron Fist deals between 2 and 4 damage");
                Thread.Sleep(1300);

                if (trolls > 4)
                {
                    health += 5;
                    Console.WriteLine($"As there are {trolls} trolls, you have been granted 5 extra health");
                    Thread.Sleep(1300);
                }

                Console.WriteLine($"You have {health} health");
                Thread.Sleep(1300);


                while (trolls != 0 && health > 0)
                {
                    Console.WriteLine("What attack should you use? [Enter 1 for Sword or 2 for Iron Fist]");
                    var attack = Console.ReadLine();
                    var attackNumber = int.Parse(attack!);
                    Thread.Sleep(750);

                    switch (attackNumber)
                    {
                        case 1:
                        {
                            trollsHealth -= sword;
                            Console.WriteLine($"You attacked with the Sword, causing {sword} damage.");
                            Thread.Sleep(750);
                            sword = random.Next(1, 5);
                            health -= trollAttack;
                            Console.WriteLine($"The troll dealt {trollAttack} damage in return");
                            Thread.Sleep(750);
                            trollAttack = random.Next(0, 3);
                            Console.WriteLine($"You have {health} health left");
                            Thread.Sleep(750);
                            Console.WriteLine($"Your current target has {trollsHealth} health left");
                            Thread.Sleep(750);
                            if (trollsHealth <= 0)
                            {
                                trolls -= 1;
                                Console.WriteLine($"One troll down! {trolls} trolls left!");
                                Thread.Sleep(750);
                                trollsHealth = 6;
                            }
                            else
                            {
                                Console.WriteLine($"There are {trolls} trolls left");
                                Thread.Sleep(750);
                            }

                            break;
                        }
                        case 2:
                        {
                            trollsHealth -= ironFist;
                            Console.WriteLine($"You used Iron Fist, causing {ironFist} damage.");
                            Thread.Sleep(750);
                            ironFist = random.Next(2, 4);
                            health -= trollAttack;
                            Console.WriteLine($"The troll dealt {trollAttack}  damage in return");
                            Thread.Sleep(750);
                            trollAttack = random.Next(0, 3);
                            Console.WriteLine($"You have {health} health left");
                            Thread.Sleep(750);
                            Console.WriteLine($"Your current target has {trollsHealth} health left");
                            Thread.Sleep(750);
                            if (trollsHealth <= 0)
                            {
                                trolls -= 1;
                                Console.WriteLine($"One troll down! {trolls} trolls left!");
                                Thread.Sleep(750);
                                trollsHealth = 6;
                            }
                            else
                            {
                                Console.WriteLine($"There are {trolls} trolls left");
                                Thread.Sleep(750);
                            }

                            break;
                        }
                        default:
                            Console.WriteLine("That was not a valid attack choice");
                            break;
                    }
                }

                if (trolls == 0 && health <= 0)
                {
                    Console.WriteLine("You killed the trolls but died in the process!");
                    Thread.Sleep(750);
                }
                else if (trolls == 0)
                {
                    Console.WriteLine("You are victorious! You killed all the trolls!");
                    Thread.Sleep(750);
                }
                else
                {
                    Console.WriteLine("You died before killing all the trolls.");
                    Thread.Sleep(750);
                }

                trolls = random.Next(3, 6);
                health = 20;
                trollsHealth = 6;

                Console.WriteLine("Play again? [yes or no] ");
                var wantToPlayAgain = Console.ReadLine();

                playagain = wantToPlayAgain == "yes" || wantToPlayAgain == "y";
            }

            Console.WriteLine("It has been a pleasure slaughtering with you.");
        }
    }
}