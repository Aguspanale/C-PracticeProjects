
using MathGame;
namespace MathGameTest
{
    public class GameTests
    {
        SummingGame mySummingGame = new SummingGame();
        MultiplyingGame myMultiplyingGame = new MultiplyingGame();
        DividingGame myDividingGame = new DividingGame();
        SubstractingGame mySubstractingGame = new SubstractingGame();
        int firstNumber;
        int secondNumber;
        [SetUp]
        public void Setup()
        {
            mySummingGame = new SummingGame();
            myMultiplyingGame = new MultiplyingGame();
            myDividingGame = new DividingGame();
            mySubstractingGame = new SubstractingGame();
            firstNumber = 16;
            secondNumber = 4;
        }

        [Test]
        public void Test01SummingGameShouldStartAndWinCorrectly()
        {
            mySummingGame.Start(firstNumber,secondNumber);
            (int, int) numbers = mySummingGame.Question();
            mySummingGame.Answer(numbers.Item1 + numbers.Item2);
            Assert.True(mySummingGame.IsWin());
        }
        [Test]
        public void Test02SummingGameShouldStartAndLoseCorrectly()
        {
            mySummingGame.Start(firstNumber, secondNumber);
            (int, int) numbers = mySummingGame.Question();
            mySummingGame.Answer(numbers.Item1 + numbers.Item2 + 1);
            Assert.False(mySummingGame.IsWin());
        }
        [Test]
        public void Test03SummingGameShouldExceptWhenAskedIfWonWithoutPlaying()
        {
            mySummingGame.Start(firstNumber, secondNumber);
            Exception exception = Assert.Throws<Exception>(()=> mySummingGame.IsWin());
            Assert.True(exception.Message == "Cannot determine a win without playing");
        }
        [Test]
        public void Test04MultiplyingGameShouldStartAndWinCorrectly()
        {
            myMultiplyingGame.Start(firstNumber, secondNumber);
            (int, int) numbers = myMultiplyingGame.Question();
            myMultiplyingGame.Answer(numbers.Item1 * numbers.Item2);
            Assert.True(myMultiplyingGame.IsWin());
        }
        [Test]
        public void Test05DividingGameShouldStartAndWinCorrectly()
        {
            myDividingGame.Start(firstNumber, secondNumber);
            (int, int) numbers = myDividingGame.Question();
            myDividingGame.Answer(numbers.Item1 / numbers.Item2);
            Assert.True(myDividingGame.IsWin());
        }
        [Test]
        public void Test06SubstractingGameShouldStartAndWinCorrectly()
        {
            myDividingGame.Start(firstNumber, secondNumber);
            (int, int) numbers = myDividingGame.Question();
            myDividingGame.Answer(numbers.Item1 / numbers.Item2);
            Assert.True(myDividingGame.IsWin());
        }
    }
}