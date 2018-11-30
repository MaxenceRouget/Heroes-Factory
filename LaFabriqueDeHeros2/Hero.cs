using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheHeroFactory
{
    public class Hero : Characters
    {
        //Variables en plus 

        private int level;
        private float exp;
        private float nbExpMax; 
        //private static int compt; 

        //Constructeur 
        public Hero()
        {
            name = "Name";
            health = 15;
            statisticAttack = 5;
            statisticDefense = 3;
            statisticDodge = 1;
            level = 1;
            exp = 0;
            nbExpMax = 100;
        }

        //Méthodes 
        public int Level
        {
            get { return level; }
            set { level = value; }
        }
        public float Exp
        {
            get { return exp; }
            set { exp = value; }
        }
        public float getSetNbExpMax
        {
            get { return nbExpMax; }
            set { nbExpMax = value; }
        }
        public void Write()
        {
            Console.WriteLine("Le nom de votre héro est : " + name);
            Console.WriteLine("Son Niveau est : " + level+"\n");
            Console.WriteLine("Son attaque est de : " + statisticAttack);
            Console.WriteLine("Sa defense est de : "+ statisticDefense);
            Console.WriteLine("Son endurence est de : "+ statisticDodge);
        }

        public void Train(float _Exp)
        {
            int comptLvlMonster = 0; 
            Console.WriteLine("Debut de l'entrainement");
            Monster monster = new Monster();
            for(int i = 0; i < this.level; i++)
            {
                monster.levelMonsterUp();
                comptLvlMonster = i; 
                
            }
            //debut du combat 
            int turn = 1;
            do
            {
                Console.WriteLine("Tour numero " + turn);
                Console.WriteLine("C'est " + this.Name + " qui commence ");
                Console.WriteLine(this.Name + " Attaque !!");

                float damage = this.Attack(monster);
                monster.TakeDamage(this.Attack(monster));
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(monster.Name + " prend " + damage + " de degats\n");
                System.Threading.Thread.Sleep(1000);
                Console.ResetColor();
                if (monster.Health <= 0)
                {
                    Console.WriteLine("Combat terminer, Vous avez battu le monstre");
                    break;
                }
                else
                {
                    Console.WriteLine(monster.Name + " Attaque !!");
                    float _damage = monster.Attack(this);
                    this.TakeDamage(_damage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(_damage);
                    System.Threading.Thread.Sleep(1000);
                    Console.ResetColor();

                    if (this.Health <= 0)
                    {
                        Console.WriteLine("Vous êtes mort");

                        Console.Clear();
                        Inn.TextMiddle("Ressurection de votre héro");
                        break;
                    }
                }

            } while (this.Health > 0 && monster.Health > 0);

            Console.WriteLine("Fin du combat ");

            Console.WriteLine("Nombre d'exp précédent "+ _Exp); 
            Random Random = new Random();
           // comptLvlMonster *= 100;
            float Rand = Random.Next(0,this.Level*100);
            exp += Rand;
            Console.WriteLine("Nombre d'exp après l'entrainement" + exp);

        }
        public int LevelUp()
        {
            health *= 1.2f;
            statisticAttack *= 1.5f;
            statisticDefense *=1.3f;
            statisticDodge *= 1.1f;
            level++;
            exp = 0;
            nbExpMax *= 1.5F;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Passage au Niveau " +level);
            Console.ResetColor();
            return 0;
        }

        public void CheckLevel()
        {
            if (exp >= nbExpMax)
            {
                LevelUp();
            }
            else
            {
               Console.WriteLine("Pas de passage de Niveau");
            }
        }
       

    }
}

