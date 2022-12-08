using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arena;

namespace Arena
{
    class Fighter
    {
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int attack;
        protected int defense;
        protected Dice dice;
        private string message;

        public Fighter(string name, int health, int attack, int defense, Dice dice)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.attack = attack;
            this.defense = defense;
            this.dice = dice;
        }
        public bool Alive()
        {
            return (health > 0);
        }
        public string GraficIndex(int actual, int maximal)
        {
            string s = "[";
            int total = 20;
            double numbers = Math.Round(((double)actual / maximal) * total);
            if ((numbers == 0) && Alive())
            {
                numbers = 1;
            }
            for (int i = 0; i < numbers; i++) 
            {
                s += "#";
            }
            s = s.PadRight(total + 1);
            s += "]";
            return s;
        }
        public string GraficLive()
        {
            return GraficIndex(health, maxHealth);
        }
        public virtual void Attack(Fighter defender)
        {
            int hit = attack + dice.throwDice();
            SetMessage(String.Format("{0} attacks with hit {1} hp", name, hit));
            defender.DefenceYou(hit);
        }
        public void DefenceYou(int hit)
        {
            int injury = attack - (defense + dice.throwDice());
            if (injury > 0)
            {
                health -= injury;
                message = String.Format("{0} suffered an injury {1} hp", name, injury);
                if (health <= 0)
                {
                    health = 0;
                    message += " a die";
                }
            }
            else
            {
                message = String.Format("{0} repulsed the attack", name);
                SetMessage(message);
            }
        }

        protected void SetMessage(string message)
        {
            this.message = message;
        }
        public string ReturnLastMessage()
        {
            return message;
        }
        public override string ToString()
        {
            return name;
        }
    }
}
