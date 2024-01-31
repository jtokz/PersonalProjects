using System;

namespace GuessTheNumber
{
    class Program
    {
        // Declaring an object type Random because we need to access to the properties of Random object
        static Random random = new Random();
        // static in order to use it in different methods
        static int randomNumber;
        static int counter;
        static void Main(string[] args)
        {
            PlayGame();
        }
        static void PlayGame()
        {
            GenerateRandom();
            while (true)
            {
                counter++;
                Console.WriteLine("Guess the number between 1 & 100");
                if (int.TryParse(Console.ReadLine(), out int inputNumber))
                {
                    // if these conditions are met, print a message and repeat the loop
                    if (inputNumber < randomNumber)
                    {
                        Console.WriteLine("Try again, write a higher number");
                    }
                    else if (inputNumber > randomNumber)
                    {
                        Console.WriteLine("Try again, write a lower number");
                    }
                    // when you guess the number, print a message, ask and break the loop
                    else
                    {
                        Console.WriteLine("·································");
                        Console.WriteLine("Congrats! you win in {0} attemps", counter);
                        PlayAgain();
                        break;
                    }
                }
                else { Console.WriteLine("Invalid number, try again"); }
            }
        }
        static void GenerateRandom()
        {
            // Generating a new random number by Random.Next method
            randomNumber = random.Next(1, 100);
        }
        static void PlayAgain()
        {
            counter = 0;
            Console.WriteLine("Do you want to play again? (y/n)");
            Console.WriteLine("·································");
            string response = Console.ReadLine();
            if (response.ToLower() == "y")
            {
                PlayGame();
            }
            Console.WriteLine("bye bye n.n");
        }
    }
}