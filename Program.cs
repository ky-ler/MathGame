/*
 * First C# program. Just playing around with the syntax and types.
 * Generates 2 random numbers and a random math operator (currently only addition and subtraction - more info on line 26).
 * User has to provide the correct answer for the next problem to generate.
 * Keeps track of user score (correct and incorrect answers).
 */

namespace MathGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the math game");
            Console.WriteLine("Type 'q' at any time to stop playing.\n");


            Random rnd = new Random();
            int[] nums = { rnd.Next(1, 100), rnd.Next(1, 100) }; // Initialize 2 random numbers

            Dictionary<int, string> op = new Dictionary<int, string>()
            {
                { 0, "+" },
                { 1, "-" },
                /*
                 * Could use multiplication and division
                 * However, for multiplication, I would need to lower the rnd.Next() range,
                 * and for division, the answers would get quite messy.
                 * { 2, "*" },
                 * { 3, "/" },
                */
            };

            int opVal = rnd.Next(2); // Generate a random operator

            int[] score = { 0, 0 }; // Users score. score[0] = correct, score[1] = incorrect

            while (true) // Keep playing the game until the user enters "q".
            {
                int correctAns;

                if (opVal == 0)
                {
                    correctAns = nums[0] + nums[1];
                }
                else
                {
                    correctAns = nums[0] - nums[1];
                }

                Console.WriteLine($"{nums[0]} {op[opVal]} {nums[1]} = ?");
                
                var userAns = Console.ReadLine();

                if (userAns == "q") // Quit playing
                {
                    Console.WriteLine($"Final score: {score[0]}-{score[1]}. Game will close in a few seconds.");
                    Thread.Sleep(5000);
                    break;
                }
                else if (userAns == correctAns.ToString()) // Correct answer - generate new problem
                {
                    score[0]++;
                    Console.WriteLine($"Correct! Your score: {score[0]}-{score[1]}\n");

                    // Generate new numbers and operator
                    nums[0] = rnd.Next(1, 100);
                    nums[1] = rnd.Next(1, 100);
                    opVal = rnd.Next(2);
                }
                else // Wrong answer - Retry
                {
                    score[1]++;
                    Console.WriteLine($"Incorrect! Your score: {score[0]}-{score[1]}\n");
                }
            } 
        }
    }
}