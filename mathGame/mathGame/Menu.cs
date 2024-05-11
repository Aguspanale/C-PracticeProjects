using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    public class Menu
    {
        string userName = "USER NOT SELECTED";
        string selectedGame = "GAME NOT SELECTED";
        int currentFirstNumber = 0;
        int currentSecondNumber = 0;
        Random random = new Random();

        public void Start()
        { 
            Console.Write("Welcome to the math game!");
        }
        public void readName()
        {
            Console.WriteLine(" please enter your name: ");
            userName = Console.ReadLine();
            Console.WriteLine("Hello " + userName + "!");
        }
        public void AskDesiredGame() 
        {
            Console.WriteLine("¿What game do you want to play? (Case sensitive)");
            Console.WriteLine("Sum Multiply Divide Substract");
            selectedGame = Console.ReadLine() ;
            Console.WriteLine("Game set to " + selectedGame + "!");
            currentFirstNumber = random.Next(100);
            currentSecondNumber = random.Next(100);
        }
        public void PlaySelectedGame(int firstNumber,int secondNumber)
        {
            Game game;
            switch (selectedGame)
            {
                case "Sum":
                    game = new SummingGame();
                    playGame(firstNumber, secondNumber, game);
                    break;
                case "Multiply":
                    game = new MultiplyingGame();
                    playGame(firstNumber, secondNumber, game);
                    break;
                case "Divide":
                    game = new DividingGame();
                    playGame(firstNumber, secondNumber, game);
                    break;
                case "Substract":
                    game = new SubstractingGame();
                    playGame(firstNumber, secondNumber, game);
                    break;
            }

        }

        public void PlaySelectedGame()
        {
            PlaySelectedGame(currentFirstNumber, currentSecondNumber);
        }

        private void playGame(int firstNumber, int secondNumber, Game game)
        {
            game.Start(firstNumber, secondNumber);
            Console.WriteLine("How much is " + firstNumber + " " + game.Symbol() + " " + secondNumber + "?");
            game.Answer(Convert.ToInt32(Console.ReadLine()));
            game.declareResults(this);
        }

        internal void DeclareGameLost(Game game)
        {
            Console.WriteLine("Incorrect answer, correct answer was " + game.CorrectAnswer());
        }

        internal void DeclareGameWon()
        {
            Console.WriteLine("That's correct!");
        }
    }
}
