//use the system
using System;

//namespace for OHM
namespace OHM
{
    //class for the OHM calculator
    class OHM_program
    {
        //define the datatypes for the I and R
        static double current;
        static double resistance;

        //main function
        static void Main(string[] args)
        {
            // display the title
            Console.WriteLine("This is an application to find the voltage\n------------------------------------------");
            // ask for the current
            Console.WriteLine("Enter the I value:\n------------------");
            current = double.Parse(Console.ReadLine());
            // ask for the resistance
            Console.WriteLine("Enter the R value:\n------------------");
            resistance = double.Parse(Console.ReadLine());
            // display the voltage
            Console.WriteLine("-----------------------------");
            double voltage = current * resistance;
            Console.WriteLine("{1} Ampere * {2} Ohm = {0} Volt", voltage, current, resistance);
        }
    }
}