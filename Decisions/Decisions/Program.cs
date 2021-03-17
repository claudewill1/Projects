using System;

namespace Decisions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is the tempature outside: ");
            string temperature = Console.ReadLine();
            int temp;
            bool succss = Int32.TryParse(temperature, out temp);

            if(temp > 80)
            {
                Console.WriteLine("Turn on the AC");
            } else if (temp < 80 && temp > 60)
            {
                Console.WriteLine("Open a window and let the air in");

            } else if (temp < 60 && temp > 50)
            {
                Console.WriteLine("Put on a sweater");
            } else
            {
                Console.WriteLine("Turn on the header");
            }
            Console.ReadLine();
        }
    }
}
