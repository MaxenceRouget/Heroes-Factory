using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeroFactory
{
    public class Characters
    {
        protected string name;
        protected float health;
        protected float heathMax;
        protected float statisticAttack;
        protected float statisticStamina;
        protected float statisticDodge;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public float Health
        {
            get { return health; }
            set { health = value; }
        }

        public float Healthmax
        {
            get { return heathMax; }
            set { heathMax = value; }
        }

        public float StatisticAttack
        {
            get { return statisticAttack; }
            set { statisticAttack = value; }
        }
        public float StatisticStamina
        {
            get { return statisticStamina; }
            set { statisticStamina = value; }
        }
        public float StatisticDodge
        {
            get { return statisticDodge; }
            set { statisticDodge = value; }
        }


        public float Attack(Characters _FighterOposent)
        {
            float damage = statisticAttack - _FighterOposent.statisticStamina;
            return damage;
        }
        

        public void TakeDamage(float _damage)
        {
            health -= _damage;
        }

    }
}
