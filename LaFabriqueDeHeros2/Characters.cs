using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFabriqueDeHeros2
{
    public class Characters
    {
        public string Name{ get; set; }
        public int StatisticAttack;
        public int StatisticDefense;
        public float StatisticEsquive;//stamina
        public int Level;
        public int Exp;
        public int NbExp;

        private int Attack (int _StatisticAttack ,int _StatisticDefense)
        {
            int Damage = StatisticAttack - StatisticDefense; 
            return Damage;
        }

       
    }
}
