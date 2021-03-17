/*Enhanced If Statements - Ternary Operator - Challenge

We have studied ternary operators and their usage so here is a small challenge for you. Let's create a small application 
that takes a temperature value as input and checks if the input is an integer or not.

If the input value is not an integer value, it should print to the console "Not a valid Temperature".

And if the input value is the valid integer then it should work as mentioned below.

    If input temperature value is <=15 it should write "it is too cold here" to the console.

    If input temperature value is >= 16 and is <=28 it should write "it is ok" to the console.

    If the input temperature value is > 28 it should write "it is hot here" to the console.

Make sure to use ternary operators and not if statements to check for the three conditions, however you can use if statement 
for the other conditions like to check if the entered value is a valid integer or not.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enhanced_If_Statement___Ternary_Operator___Challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a temperature: ");
            string input = Console.ReadLine();
            bool isInt = int.TryParse(input, out int temp);

            string output = (temp <= 15) ? "it is too cold here" : (temp >= 16 && temp <= 28) ? "it is ok" : "it is hot here";

            Console.WriteLine($"{output}");
            Console.ReadLine();
        }
    }
}
