using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt for first name
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();

        // Prompt for last name
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        // Display the name in the specified format
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}