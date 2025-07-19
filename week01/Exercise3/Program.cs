using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        bool playAgain = true;
        int guessCount;

        Console.WriteLine("Welcome to Guess My Number Game!");

        while (playAgain)
        {
            // Generate random number between 1 and 100
            int magicNumber = random.Next(1, 101);
            guessCount = 0;

            Console.WriteLine("\nI've picked a magic number between 1 and 100.");

            int guess = 0;
            while (guess != magicNumber)
            {
                // Get user's guess
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                // Check if guess is higher or lower
                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }

            // Ask if user wants to play again
            Console.Write("\nWould you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }

        Console.WriteLine("\nThanks for playing!");
    }
}