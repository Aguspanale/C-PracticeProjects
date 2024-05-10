
using MathGameNS;
namespace MathGameTest
{
    public class Tests
    {
        SummingGame myGame = new SummingGame();
        [SetUp]
        public void Setup()
        {
            SummingGame myGame = new SummingGame();
        }

        [Test]
        public void Test01GameShouldStartCorrectly()
        {
            myGame.start();
            (int, int) numbers = myGame.summingQuestion();
            myGame.answer(numbers.Item1 + numbers.Item2);
            Assert.True(myGame.isWin);
        }
    }
}