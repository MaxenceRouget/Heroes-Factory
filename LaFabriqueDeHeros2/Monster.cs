using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeroFactory
{
    class Monster : Characters
    {
        public Monster()
            {
            name = "Monstre";
            health = 5;
            statisticAttack = 1.2f;
            statisticDefense = 0.5f;

            }

        public void LevelMonsterUp()
        {
            this.health *= 1.5f;
            this.statisticAttack *=1.2f;
            this.statisticDefense *= 1.12f;

        }
    }   
}
