using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathGame;
namespace MathGameTests
{
    
    internal class MenuTest
    {
        private StringWriter _consoleOutput;
        private StringReader _consoleInput;
        private TextWriter _originalConsoleOutput;
        private TextReader _originalConsoleInput;
        private Menu menu = new Menu();
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Starting Test");
            _consoleOutput = new StringWriter();
            _originalConsoleOutput = Console.Out;
            _originalConsoleInput = Console.In;
            Console.SetOut(_consoleOutput);
            menu = new Menu();
        }
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Finishing Test");
            Console.SetOut(_originalConsoleOutput);
            Console.SetIn(_originalConsoleInput);
            _consoleOutput.Dispose();
        }
        [Test]
        public void test01MenuAsksName()
        {
            string expectedOutput = startAndDefineStartingOutputWith("Agus");
            string actualOutput = _consoleOutput.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void test02MenuAsksGame()
        {
            ExpectedOutputFromTestingSelectingGame("Sum");

        }
        [Test]
        public void test03MenuAsksDifferentGame()
        {
            ExpectedOutputFromTestingSelectingGame("Substract");

        }

        [Test]
        public void test04PlaySumGameAndWin() 
        {
            string expectedOutput = ExpectedOutputFromTestingSelectingGame("Sum") +
                "How much is 3 + 4?" +
                "\r\n" +
                "That's correct!" +
                "\r\n";
            _consoleInput = new StringReader("7");
            Console.SetIn(_consoleInput);

            menu.PlaySelectedGame(3,4);

            string actualOutput = _consoleOutput.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);

        }
        [Test]
        public void test05PlaySumGameAndLose()
        {
            string expectedOutput = ExpectedOutputFromTestingSelectingGame("Sum") +
                "How much is 4 + 6?" +
                "\r\n" +
                "Incorrect answer, correct answer was 10" +
                "\r\n";
            _consoleInput = new StringReader("120");
            Console.SetIn(_consoleInput);

            menu.PlaySelectedGame(4, 6);

            string actualOutput = _consoleOutput.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [Test]
        public void test06PlayMultiplyGameAndWin()
        {
            string expectedOutput = ExpectedOutputFromTestingSelectingGame("Multiply") +
                "How much is 4 x 6?" +
                "\r\n" +
                "That's correct!" +
                "\r\n";
            _consoleInput = new StringReader("24");
            Console.SetIn(_consoleInput);

            menu.PlaySelectedGame(4, 6);

            string actualOutput = _consoleOutput.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        private string ExpectedOutputFromTestingSelectingGame(string game)
        {
            string expectedOutput =
                            "¿What game do you want to play? (Case sensitive)" +
                            "\r\n" +
                            "Sum Multiply Divide Substract" +
                            "\r\n" +
                            "Game set to "+ game + "!" +
                            "\r\n";
            _consoleInput = new StringReader(game);
            Console.SetIn(_consoleInput);
            menu.AskDesiredGame();
            string actualOutput = _consoleOutput.ToString();
            Assert.AreEqual(expectedOutput, actualOutput);
            return expectedOutput;
        }

        private string startAndDefineStartingOutputWith(string name)
        {
            string expectedOutput =
                            "Welcome to the math game! please enter your name: " +
                            "\r\n" +
                            "Hello " + name + "!" +
                            "\r\n";
            _consoleInput = new StringReader(name);
            Console.SetIn(_consoleInput);
            menu.Start();
            menu.readName();
            return expectedOutput;
        }
    }
}
