using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* <summary>
 Challenge - Loops 1 - Average

Imagine you are a developer and get a job in which you need to create a program for a teacher. He needs a program written in c# that calculates the average score of his students. So he 
wants to be able to enter each score individually and then get the final average score once he enters -1.
So the tool should check if the entry is a number and should add that to the sum. Finally once he is done entering scores, the program should write onto the console what the 
average score is.
The numbers entered should only be between 0 and 20. Make sure the program doesn't crash if the teacher enters an incorrect value.
Test your program thoroughly.
*/
namespace Loops_Challenge_Average
{
    class Program
    {
        static void Main(string[] args)
        {
            var grade = 0;
            var gradesSum = 0;
            var average = 0.0;
            var counter = 0;
            while(grade >= 0 && grade <= 20)
            {
                Console.Write("Enter the next grade between 0 to 20 or -1 to Calculate average: ");
                grade = Convert.ToInt32(Console.ReadLine());
                if(grade >= 0 && grade <= 20)
                {
                    if (grade == -1)
                    {
                        break;
                    }
                    gradesSum += grade;
                    counter++;
                } else
                {
                    Console.WriteLine("Enter a grade between 0 and 20 or -1 to calcuate average");
                }
                
                
            }
            average = gradesSum / counter;

            Console.WriteLine($"The average grade is {average}");
        }
    }
}
