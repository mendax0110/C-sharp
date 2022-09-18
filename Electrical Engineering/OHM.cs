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
            Console.WriteLine("This is an application to find the voltage\n------------------------------------------");
            Console.WriteLine("Enter the I value:\n------------------");
            current = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the R value:\n------------------");
            resistance = double.Parse(Console.ReadLine());
            Console.WriteLine("-----------------------------");
            double voltage = current * resistance;
            Console.WriteLine("{1} Ampere * {2} Ohm = {0} Volt", voltage, current, resistance);
        }
    }
}