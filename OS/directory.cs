// use the system
using System;
using System.Text;

// namespace
namespace directory_list
{
    // class
    class Program
    {
        // main function
        static void Main(string[] args)
        {
            Console.WriteLine("List all files in the directory");

            // get the directory
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"PASTE THE PATH HERE");

            foreach(System.IO.FilInfo file in dir.GetFiles("*.*"))
            {
                Console.WriteLine("{0}, {1}", file.Name, file.Length);
            }
            Console.ReadLine();
        }
    }
}
