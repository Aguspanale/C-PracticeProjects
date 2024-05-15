using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathGame
{
    internal interface IGameState
    {
        public bool IsWin(Game aGame);
        public void declareResults(Menu menu, Game aGame);
    }

    internal class UnfinishedGameState : IGameState
    { 
        public bool IsWin(Game aGame){return aGame.IsWinWhenUnfinished();}
        public void declareResults(Menu menu, Game aGame){aGame.IsWinWhenUnfinished();}
    }
    internal abstract class FinishedGameState : IGameState
    {
        public abstract bool IsWin(Game aGame);
        public abstract void declareResults(Menu menu,Game aGame);
        internal static FinishedGameState representResult(bool gameWasWon)
        {
            if(gameWasWon)return new WonGameState();
            return new LostGameState();
        }
    }
    internal class WonGameState : FinishedGameState
    {
        public override bool IsWin(Game aGame){return true;}
        public override void declareResults(Menu aMenu, Game aGame){aMenu.DeclareGameWon();}
    }
    internal class LostGameState : FinishedGameState
    {
        public override bool IsWin(Game aGame){return false;}
        public override void declareResults(Menu aMenu, Game aGame){aMenu.DeclareGameLost(aGame);}
    }
}

