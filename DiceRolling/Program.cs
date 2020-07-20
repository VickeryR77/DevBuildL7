using System;
using System.Runtime.CompilerServices;

namespace DiceRolling
{
    class Program
    {
        public static bool CheckRolls(int die1, int die2, int total)
        {
            if (total == 12)
            {
                Console.WriteLine($"You rolled Box Cars with 2 {die1}s");
                Console.WriteLine($"You rolled Craps as well with a total of {total}.");
                return true;
            }
            if(total == 11 || total == 7)
            {
                Console.WriteLine($"You rolled a win with a total of {total}!");
                return true;
            }
            if(total == 3)
            {
                Console.WriteLine($"You rolled an Ace Deuce with that {die1} and {die2}!");
                Console.WriteLine($"...that means you also rolled Craps with a total of {total}!");
                return true;
            }
            if(total == 2)
            {
                Console.WriteLine($"You rolled Snake Eyes with that {die1} and {die2}.");
                Console.WriteLine($"...that means you also rolled Craps with a total of {total}!");
                return true;
            }
            return false;    
        }

        public static void GetGamePlay(int sides, int num1, int num2, int total, int rolls) 
        {
            bool running = true;
            while (running) {
            rolls++;
            Console.Clear();
            Console.WriteLine($"Roll #{rolls}");
            Console.WriteLine("");
            Console.WriteLine($"The first die reads... {num1}");
            Console.WriteLine($"The second die reads... {num2}");
            Console.WriteLine($"You rolled {total}!");
            Console.WriteLine("");
            if (sides == 6)
            {
                Console.WriteLine("");
                CheckRolls(num1, num2, total);
            }
            bool isAsking = true;
            while (isAsking)
            {
                Console.WriteLine("");
                Console.WriteLine("Would you like to roll again? (Y/N)");
                string entry = Console.ReadLine();
                string lowerEntry = entry.ToLower();
                if (lowerEntry == "y")
                {
                    total = GetDiceRoll(sides, out num1, out num2);
                    break;
                }
                else if (lowerEntry == "n")
                {
                    Build();
                }
                else
                {
                    continue;
                }
                }
            }            
        }

        public static int GetDiceRoll(int sides, out int num1, out int num2)
        {
                Random roll = new Random();
                num1 = roll.Next(1, sides+1);
                num2 = roll.Next(1, sides+1);
                int total = num1 + num2;
                return total;
        }

        public static int GetValidNumbers()
        {            
            Console.WriteLine("How many sides would you like your dice to have?");
            bool isValid = int.TryParse(Console.ReadLine(), out int number);
            while (!isValid)
            {
                Console.WriteLine("Please enter a valid number.");
                isValid = int.TryParse(Console.ReadLine(), out number);
            }
            return number;
        }

        static void Main(string[] args)
        {
            Build();
        }
        public static void Build()
        {
            Console.Clear();
            bool runningProgram = true;
            while (runningProgram)
            {
                int rolls = 0;
                int sides = GetValidNumbers();
                bool runningGame = true;
                while (runningGame)
                {
                    int total = GetDiceRoll(sides, out int num1, out int num2);
                    GetGamePlay(sides, num1, num2, total, rolls);
                }
            }
        }
    }
}
