// use the system 
using System;

// declare variable and then initialize to zero
int num1 = 0;
int num2 = 0;

    //display title as the C# console calculator app
    Console.WriteLine("Console Calculator in C\r");
    Console.WriteLine("------------------------\n");

    // ask the user to type the first number
    Console.WriteLine("Type a number, and then press Enter");
    num1 = Convert.ToInt32(Console.ReadLine());

    // ask the user to type the second number
    Console.WriteLine("Type another number, and then press Enter");
    num2 = Convert.ToInt32(Console.ReadLine());

    // ask the user to choose an option
    Console.WriteLine("Choose an option from the following list:");
    Console.WriteLine("\ta - Add");
    Console.WriteLine("\ts - Subtract");
    Console.WriteLine("\tm - Multiply");
    Console.WriteLine("\td - Divide");
    Console.Write("Your option? ");

    // use a switch statement to do the math
    switch(Console.ReadLine())
    {
        // if the user chooses to add
        case "a":
            Console.WriteLine($"Your result: {num1} + {num2} = " + (num1 + num2));
            break;
        // if the user chooses to subtract
        case "s":
            Console.WriteLine($"Your result: {num1} - {num2} = " + (num1 - num2));
            break;
        // if the user chooses to multiply
        case "m":
            Console.WriteLine($"Your result: {num1} * {num2} = " + (num1 * num2));
            break;
        // if the user chooses to divide
        case "d":
            Console.WriteLine($"Your result: {num1} / {num2} = " + (num1 / num2));
            break;
    }

    // wait for the user to respond before closing
    Console.Write("Press any key to close the Calculator console app...");
    Console.ReadKey();
    