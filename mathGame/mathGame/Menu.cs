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
        public delegate (int, int) CustomFunction(int x, int y, int z);
        public Dictionary<string, Action<int, int, int, CustomFunction>> ExecuteGameWith;

        public Menu()
        {
            InitializeExecuteGameWith();
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the math game!");
        }
        

        private void InitializeExecuteGameWith()
        {
            ExecuteGameWith = new Dictionary<string, Action<int, int, int, CustomFunction>>();
            ExecuteGameWith["Sum"] = (x, y, multiple, makeValidDivision) => PlayGame(x, y, new SummingGame());
            ExecuteGameWith["Multiply"] = (x, y, multiple, makeValidDivision) => PlayGame(x, y, new MultiplyingGame());
            ExecuteGameWith["Divide"] = (x, y, multiple, makeValidDivision) =>
            {
                (x, y) = makeValidDivision(x, y, multiple);
                DividingGame game = new DividingGame();
                PlayGame(x, y, game);
            };
            ExecuteGameWith["Substract"] = (x, y, multiple, makeValidDivision) => PlayGame(x, y, new SubstractingGame());
        }

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
            Console.WriteLine("Game set to " + selectedGame + "!");
            Console.WriteLine("");
            currentFirstNumber = random.Next(30);
            currentSecondNumber = 1 + random.Next(29);
            currentMultiple = random.Next(10);

        }
        public void PlaySelectedGame(int firstNumber, int secondNumber)
        {
            ExecuteGameWith[selectedGame](firstNumber, secondNumber, currentMultiple, (x, y, z) => (x, y));
        }

        public void PlaySelectedGame()
        {
            ExecuteGameWith[selectedGame](currentFirstNumber, currentSecondNumber, currentMultiple, (x, y, z) => (y * z, y));
        }

        private void PlayGame(int firstNumber, int secondNumber, Game game)
        {
            game.Start(firstNumber, secondNumber);
            Console.WriteLine("How much is " + firstNumber + " " + game.Symbol() + " " + secondNumber + "?");
            game.Answer(Convert.ToInt32(Console.ReadLine()));
            game.declareResults(this);
            Console.WriteLine("");
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
