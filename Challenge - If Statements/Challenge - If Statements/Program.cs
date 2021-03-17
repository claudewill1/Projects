///<summary>
///Challenge - If Statements
///Create a user Login System, where the user can first register and then Login in. The Program should check if the user has entered 
///the correct username and password, wenn login in (so the same ones that he used when registering).
///As we haven't covered storing data yet, just create the program in a way, that registering and logging in, happen in the same execution of it.
///User If statements and User Input and Methods to solve the challenge
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge___If_Statements
{
    class Program
    {
        static string username;
        static string password;
        static void Main(string[] args)
        {
            Register();
            Login();
           
            Console.ReadLine();
        }
        public static void Register()
        {
            Console.Write("Enter a username: ");
            username = Console.ReadLine();
            Console.Write("Enter a password: ");
            password = Console.ReadLine();

            Console.WriteLine("Registration completed!");
        }
        public static void Login()
        {
            Console.Write("Username: ");
            if(username == Console.ReadLine())
            {
                Console.Write("Password :");
                if(password == Console.ReadLine())
                {
                    Console.WriteLine("You have successfully logged in!");
                }
                else
                {
                    Console.WriteLine("Invalid password");
                }
            }
            else
            {
                Console.WriteLine("Username not found");
            }
        }
    }
}
