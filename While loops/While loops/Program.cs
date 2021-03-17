using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace While_loops
{
    class Program
    {
        // increase counter while the user input is empty until they enter characters and press enter
        static void Main(string[] args)
        {
            var counter = 0;

            var input = "";

            while(input.Equals(""))
            {
                Console.Write("Press enter to keep counting or 1 to end");
                input = Console.ReadLine();
                Console.WriteLine($"{counter} students on the bus");

                counter++;
            }
            Console.WriteLine("All of the students are present");
            Console.ReadLine();
        }
    }
}
