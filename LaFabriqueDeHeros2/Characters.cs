﻿using System;
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
        protected float statisticAttack;
        protected float statisticDefense;
        protected float statisticDodge;//stamina
        
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
        public float StatisticAttack
        {
            get { return statisticAttack; }
            set { statisticAttack = value; }
        }
        public float StatisticDefense
        {
            get { return statisticDefense; }
            set { statisticDefense = value; }
        }
        public float StatisticDodge
        {
            get { return statisticDodge; }
            set { statisticDodge = value; }
        }


        public float Attack(Characters _FighterOposent)
        {
            float damage = statisticAttack - _FighterOposent.statisticDefense;
            return damage;
        }
        

        public void TakeDamage(float _damage)
        {
            health -= _damage;
        }

    }
}
