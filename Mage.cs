using Arena;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    class Mage : Fighter
    {
        private int mp;
        private int maxMp;
        private int magicalAttack;

        public Mage(string name, int health, int attack, int defence, Dice dice, int mp, int magicalAttack) : base(name, health, attack, defence, dice)
        {
            this.mp = mp;
            this.maxMp = mp;
            this.magicalAttack = magicalAttack;
        }

        public string GraficMana()
        {
            return GraficIndex(mp, maxMp);
        }

        public override void Attack(Fighter defender)
        {
            // Mana není naplněna
            if (mp < maxMp)
            {
                mp += 10;
                if (mp > maxMp)
                    mp = maxMp;
                base.Attack(defender);
            }
            else // Magický útok
            {
                int hit = magicalAttack + dice.throwDice();
                SetMessage(String.Format("{0} use magical attack for {1} hp", name, hit));
                defender.DefenceYou(hit);
                mp = 0;
            }
        }
    }

}