using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFabriqueDeHeros2
{
    class Program
    {
        static void Main(string[] args)
        {
            int Compteur2 =0;
            string AubergeName, HeroName;
            ConsoleKeyInfo choose;
            Console.WriteLine("Comment s'appelle votre auberge ");
            AubergeName = Console.ReadLine();

            //Création de l'auberge
            Inn inn1 = new Inn(AubergeName);
          

            List<Hero> TableauDeHero = new List<Hero>();

            do
            {
                Console.Clear();

                Console.WriteLine("_____Bienvenue dans l'auberge "+AubergeName+"______");
                Console.WriteLine("_____Salut Pelerin______");
                Console.WriteLine("_____Que souhaite tu faires ? _____");
                Console.WriteLine(" Tape ");
                Console.WriteLine("_____1 /-Pour créer un héro _____");
                Console.WriteLine("_____2 /-Pour afficher tes héros _____");
                Console.WriteLine("_____3 /-Pour entrainer un héros _____");
                Console.WriteLine("_____4 /-Pour faire un duel de héros _____");
                Console.WriteLine("_____5 /-Pour supprimer un héro _____");

                choose = Console.ReadKey();

                switch (choose.KeyChar)
                {

                    case '1':
                        Console.WriteLine("_____Créer un héros ______");

                        Console.WriteLine("choisissez le nom de votre héro? ");
                        HeroName = Console.ReadLine();
                        Hero Bernard = new Hero();
                        Bernard.SetName(HeroName);
                        Bernard.write();

                        TableauDeHero.Add(Bernard);
                        System.Threading.Thread.Sleep(1000);
                        Compteur2++;
                        break;

                    case '2':
                        Console.WriteLine("_____Afficher les héros ______");

                        foreach (Hero h in TableauDeHero)
                        {
                            Console.WriteLine(h.Name);
                            Console.WriteLine(h.StatisticAttack);
                            Console.WriteLine(h.StatisticDefense);
                            Console.WriteLine(h.StatisticEsquive);
                        }
                        System.Threading.Thread.Sleep(1000);
                        break;

                    case '3':
                        Console.WriteLine("case 3");
                        System.Threading.Thread.Sleep(1000);
                        break;



                    case '4':
                     Console.WriteLine("Case 4");
                        Console.Write(Hero.Compteur);
                        System.Threading.Thread.Sleep(2000);
                        break;




                    case '5':
                        Console.WriteLine("_____supprimer des héros ______");
                        int ii = 0;
                        foreach (Hero h in TableauDeHero)
                        {

                                Console.WriteLine("Le Numéro du héro est : " + (ii+1));
                                Console.WriteLine(h.Name);
                                ii++;
                            
                        }
                        Console.WriteLine("_____saisir le numero du héro à supprimer ______");
                        string ligne = Console.ReadLine();
                        int Search =int.Parse(ligne);

                        for (int i = 0; i == Search; i++)
                        {
                            Console.WriteLine(i);
                            TableauDeHero.RemoveAt(i);
                        }
                        System.Threading.Thread.Sleep(1000);
                        
                        break;
                };

            } while (choose.Key != ConsoleKey.Escape);

        }
    }
}
