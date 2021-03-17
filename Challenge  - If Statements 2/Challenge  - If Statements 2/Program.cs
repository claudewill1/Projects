///<summary>
///Create an application with a score, highscore and a highscorePlayer.
///Create a method which has two parameters, one for the score and one for the playerName.
///When ever that method is called, it should be checked if the score of the player is higher than the highscore, 
///if so, "New highscore is + " score" and in another line "New highscore holder is " + playerName - should be written onto the console, if not "
///The old highscore of " + highscore + " could not be broken and is still held by " + highscorePlayer.
///Consider which variables are required globally and which ones locally.
/// </summary>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge____If_Statements_2
{
    class Program
    {
        
        static int highScore = 100;
        static string highscorePlayer = "bob";

        static void Main(string[] args)
        {
            int playerScore;
            Console.Write("Enter the players name: ");
            string name = Console.ReadLine();
            Console.Write("Enter the players score: ");
            int score = Convert.ToInt32(Console.ReadLine());
            CheckScore(name, score);

            Console.ReadLine();
        }
        static void CheckScore(string playerName, int score)
        {
            if(score > highScore)
            {
                highScore = score;
                highscorePlayer = playerName;
                Console.WriteLine($"New highscore holder is {playerName}");
            }
            else
            {
                Console.WriteLine($"The old highscore of {highScore} could not be broken and is still held by {highscorePlayer}.");
            }
        }
    }
}
