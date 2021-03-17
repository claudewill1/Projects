using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Human
    {
        // member variable
        private string firstName;
        private string lastName;
        private string eyeColor;
        private int age;
        // default constructor
        public Human()
        {
            Console.WriteLine("Constructor Called. Object created.");
        }
        // constructor overloading
        public Human(string firstName)
        {
            this.firstName = firstName;
            
        }
        public Human(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            
        }
        public Human(string firstName, string lastName, string eyeColor)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
        }
        public Human(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        public Human(string firstName, string lastName, string eyeColor, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.eyeColor = eyeColor;
            this.age = age;
        }

        // member method
        public void IntroduceMyself()
        {
            if (age != 0 && lastName != null && eyeColor != null && firstName != null)
                Console.WriteLine($"Hi, I'm {firstName} {lastName} and am {age} years old. My eye color is {eyeColor}");
            else if (age != 0 && firstName != null && lastName != null)
                Console.WriteLine($"Hello I am {firstName} {lastName}. I am {age} years old");
            else if (lastName != null && firstName != null)
                Console.WriteLine($"Hello, I'm {firstName} {lastName}.");
            else if (firstName != null)
                Console.WriteLine($"Hello, I'm {firstName}.");
        }
    }
}
