
using MathGame;

namespace MathGame
{
    public interface IGame
    {
        public void Start(int firstNumberToSum, int secondNumberToSum);
        public void Answer(int anAnswer);
        public (int, int) Question();
        public bool IsWin();
        public char Symbol();
        public int CorrectAnswer();

    }
    public abstract class Game : IGame
    {
        protected int firstNumber;
        protected int secondNumber;
        internal IGameState state = new UnfinishedGameState();
        protected bool won = false;
        public virtual void Start(int firstNumberToOperate, int secondNumberToOperate)
        {
            firstNumber = firstNumberToOperate;
            secondNumber = secondNumberToOperate;
        }
        public abstract void Answer(int anAnswer);
        public abstract char Symbol();
        public abstract int CorrectAnswer();

        public (int, int) Question()
        {
            return (firstNumber, secondNumber);
        }


        public bool IsWin()
        {
            return state.IsWin(this);
        }
        internal bool IsWinWhenUnfinished()
        {
            throw new Exception("Cannot determine a win without playing");
        }
        internal bool IsWinWhenFinished()
        {
            return won;
        }
        internal void declareResults(Menu aMenu)
        {
            state.declareResults(aMenu,this);
        }
    }
    public class SummingGame : Game
    {
        public override void Answer(int anAnswer)
        {
            bool gameWon = anAnswer == firstNumber + secondNumber;
            state = FinishedGameState.representResult(gameWon);
        }          
        public override char Symbol()
        {
            return '+';
        }
        public override int CorrectAnswer()
        {
            return firstNumber + secondNumber;
        }

    }
    public class MultiplyingGame : Game
    {
        public override void Answer(int anAnswer)
        {
            bool gameWon = anAnswer == firstNumber * secondNumber;
            state = FinishedGameState.representResult(gameWon);
        }
        public override char Symbol()
        {
            return 'x';
        }
        public override int CorrectAnswer()
        {
            return firstNumber * secondNumber;
        }

    }
    public class DividingGame : Game
    {
        public override void Answer(int anAnswer)
        {
            bool gameWon = anAnswer == firstNumber / secondNumber;
            state = FinishedGameState.representResult(gameWon); 
        }
        public override char Symbol()
        {
            return '/';
        }
        public override int CorrectAnswer()
        {
            return firstNumber / secondNumber;
        }

        public override void Start(int firstNumberToOperate, int secondNumberToOperate)
        {
            if (secondNumberToOperate == 0)
            {
                throw new InvalidOperationException("Division by zero");
            }
            else if(firstNumberToOperate % secondNumberToOperate != 0)
            {
                throw new InvalidOperationException("Invalid denominator " + secondNumberToOperate + " for numerator " + firstNumberToOperate);
            }
            else
            {
                firstNumber = firstNumberToOperate;
                secondNumber = secondNumberToOperate;
                
            }
        }

    }

    public class SubstractingGame : Game
    {
        public override void Answer(int anAnswer)
        {
            bool gameWon = anAnswer == firstNumber - secondNumber;
            state = FinishedGameState.representResult(gameWon);
        }
        public override char Symbol()
        {
            return '-';
        }
        public override int CorrectAnswer()
        {
            return firstNumber - secondNumber;
        }

    }
}

