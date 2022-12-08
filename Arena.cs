using System.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Arena
    {
        private Fighter leonidas;
        private Fighter gandalf;
        private Dice dice;

        public Arena(Fighter leonidas, Fighter gandalf, Dice dice)
        {
            this.leonidas = leonidas;
            this.gandalf = gandalf;
            this.dice = dice;
        }

        private void Draw()
        {
            Console.Clear();
            Console.WriteLine("-------------- Arena -------------- \n");
            Console.WriteLine("Fighters: \n");
            WriteTheFighter(leonidas);
            Console.WriteLine();
            WriteTheFighter(gandalf);
            Console.WriteLine();
        }


        private void WriteTheFighter(Fighter b)
        {
            Console.WriteLine(b);
            Console.Write("Health: ");
            Console.WriteLine(b.GraficLive());
            if (b is Mage)
            {
                Console.Write("MP: ");
                Console.WriteLine(((Mage)b).GraficMana());
            }
        }
        private void ReportMessage(string message)
        {
            Console.WriteLine(message);
            Thread.Sleep(500);
        }

        public void Fight()
        {
            // Original order
            Fighter b1 = leonidas;
            Fighter b2 = gandalf;
            Console.WriteLine("Welcome in arena!");
            Console.WriteLine("Todays fighters are {0} with {1}! \n", leonidas, gandalf);
            // Swapping fighters
            bool beginningFighter2 = (dice.throwDice() <= dice.ReturnNumOfWalls() / 2);
            if (beginningFighter2)
            {
                b1 = gandalf;
                b2 = leonidas;
            }
            Console.WriteLine("The fighter will start is {0}! \nThe match may begin...", b1);
            Console.ReadKey();
            // Cycle with fighter
            while (b1.Alive() && b2.Alive())
            {
                b1.Attack(b2);
                Draw();
                ReportMessage(b1.ReturnLastMessage()); // message about attack
                ReportMessage(b2.ReturnLastMessage()); // message about defence
                if (b2.Alive())
                {
                    b2.Attack(b1);
                    Draw();
                    ReportMessage(b2.ReturnLastMessage()); // message about attack
                    ReportMessage(b1.ReturnLastMessage()); // message about defence
                }
                Console.WriteLine();
            }
        }
    }
}
