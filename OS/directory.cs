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

            // get the files
            foreach(System.IO.FilInfo file in dir.GetFiles("*.*"))
            {
                // print the file name
                Console.WriteLine("{0}, {1}", file.Name, file.Length);
            }
            // read the input
            Console.ReadLine();
        }
    }
}
