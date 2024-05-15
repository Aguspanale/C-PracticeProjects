using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class Menu
    {
        Random random = new Random();

        string userName = "USER NOT SELECTED";
        string selectedGame = "GAME NOT SELECTED";
        int currentFirstNumber = 0;
        int currentSecondNumber = 0;
        int currentMultiple = 0;        
        public void Start(){Console.WriteLine("Welcome to the math game!");}
        
        public void readName()
        {
            Console.Write("please enter your name: ");            
            userName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Hello " + userName + "!");
            Console.WriteLine("");
        }
        public void AskDesiredGame()
        {
            Console.WriteLine("¿What game do you want to play? (Case sensitive)");
            Console.WriteLine("");
            Console.WriteLine("Sum Multiply Divide Substract");
            selectedGame = Console.ReadLine();
            CommunicateCorrectlySelectedGame();
            RegenerateRandomNumbers();
        }

        private void CommunicateCorrectlySelectedGame()
        {
            Console.WriteLine("Game set to " + selectedGame + "!");
            Console.WriteLine("");
        }

        private void RegenerateRandomNumbers()
        {
            currentFirstNumber = random.Next(30);
            currentSecondNumber = 1 + random.Next(29);
            if(selectedGame == "Divide")
            {
                currentMultiple = random.Next(10);
                currentFirstNumber = currentSecondNumber * currentMultiple;
            }
        }

        public void PlaySelectedGame(int firstNumber, int secondNumber)
        {
            if (selectedGame == "Divide") PlayGame(firstNumber, secondNumber, new DividingGame());
            if (selectedGame == "Multiply") PlayGame(firstNumber, secondNumber, new MultiplyingGame());
            if (selectedGame == "Sum") PlayGame(firstNumber, secondNumber, new SummingGame());
            if (selectedGame == "Substract") PlayGame(firstNumber, secondNumber, new SubstractingGame());
        }

        public void PlaySelectedGame(){PlaySelectedGame(currentFirstNumber, currentSecondNumber);}

        private void PlayGame(int firstNumber, int secondNumber, Game game)
        {
            game.Start(firstNumber, secondNumber);
            Console.WriteLine("How much is " + firstNumber + " " + game.Symbol() + " " + secondNumber + "?");
            game.Answer(Convert.ToInt32(Console.ReadLine()));
            game.declareResults(this);
            Console.WriteLine("");
        }

        internal void DeclareGameLost(Game game){Console.WriteLine("Incorrect answer, correct answer was " + game.CorrectAnswer());}

        internal void DeclareGameWon(){Console.WriteLine("That's correct!");}
    }
}
