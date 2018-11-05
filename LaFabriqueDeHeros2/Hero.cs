using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFabriqueDeHeros2
{
    public class Hero : Characters
    {
        public static int Compteur; 
        public Hero()
        {
            Name = "Name";
            StatisticAttack = 10;
            StatisticDefense = 3;
            StatisticEsquive = 1.5F;
            Level = 1;
            Compteur++; 
        }
        public void write()
        {
            Console.WriteLine("Le nom de votre héro est : " + Name);
            Console.WriteLine("Son attaque est de : " + StatisticAttack);
            Console.WriteLine("Sa defense est de : "+ StatisticDefense);
            Console.WriteLine("Son endurence est de : "+ StatisticEsquive);
        }

        public void SetName(string _Name)
        {
            this.Name = _Name;
        }
       
    }
}

