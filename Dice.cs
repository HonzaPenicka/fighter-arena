using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Dice
    {
        private Random random;
        private int faceNumbers;

        public Dice()
        {
            faceNumbers = 6;
            random = new Random();
        }
        public Dice(int faceNumbers)
        {
            this.faceNumbers = faceNumbers;
            random = new Random();
        }
        public int ReturnNumOfWalls()
        {
            return faceNumbers;
        }

        public int throwDice()
        {
            return random.Next(1, faceNumbers + 1);
        }

        public override string ToString()
        {
            return String.Format("Dice with {0} faces", faceNumbers);
        }
    }
}
