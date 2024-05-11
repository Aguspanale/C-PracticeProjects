using MathGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class program
{
    static void Main()
    {
        Menu menu = new Menu();
        menu.Start();
        menu.readName();

        while (true)
        {
            menu.AskDesiredGame();
            menu.PlaySelectedGame();
        }
    }
}

