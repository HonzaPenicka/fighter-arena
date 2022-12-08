// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Arena;

namespace Arena
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create objects
            Dice dice = new Dice(10);
            Fighter leonidas = new Fighter("Leonidas", 100, 20, 10, dice);
            Fighter gandalf = new Mage("Gandalf", 60, 15, 12, dice, 30, 45);
            Arena arena = new Arena(leonidas, gandalf, dice);

            // Fight
            arena.Fight();
            Console.ReadKey();
        }
    }
}