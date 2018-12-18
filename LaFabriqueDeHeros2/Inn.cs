using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace TheHeroFactory
{
    [Serializable]
    class Inn
    {
        [XmlText]
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Inn(string _name)
        {
            this.name = _name;
        }
        public Inn(List<Hero> _tabOfHeroe)
        {

        }
        public void Show(List<Hero> _listOfHeroes)
        {
            List<Hero> list = _listOfHeroes;
            foreach (Hero h in list)
            {
                Console.WriteLine(h.Name);
            }

        }
        private void Delete(List<Hero> _listOfHeroes)
        {
            List <Hero> tabOfHero = _listOfHeroes; 
            this.ShowListHero(tabOfHero);
            Console.WriteLine("_____ Saisir le nom du héro à supprimer ______");
            string line = Console.ReadLine();
            int search = this.Compare(line, tabOfHero);

            if (search > tabOfHero.Count())
            {
                Console.WriteLine("Trop grand nombre");
            }

            else
            {
                try
                {
                    Console.Clear();
                    tabOfHero.RemoveAt(search);
                    TextMiddle("Supression effectuée");
                    Console.ReadKey();
                }
                catch (Exception)
                {
                    Console.WriteLine("/!\\ Petit problème");
                }
            }
        }
        public void Serialization(List<Hero> _tabOfHero)
        {
            Stream stream = File.OpenWrite(Environment.CurrentDirectory + "\\mySave.txt");

            XmlSerializer xmlSer = new XmlSerializer(typeof(Save));

            Save save = new Save();
            save.List = _tabOfHero;
            save.NameInn = this.name;

            xmlSer.Serialize(stream, save);

            stream.Close();
        }

        public Hero ChooseYourHero(List<Hero> _tabOfHero)
        {
           
            begin:
            List<Hero> tabOfHero = _tabOfHero;
            Hero heroChoose = new Hero();
            string line = Console.ReadLine();
           
                int search = this.Compare(line, tabOfHero);

                try
                {
                    heroChoose = tabOfHero[search];
                    Console.WriteLine(heroChoose.StatisticAttack);
                }
                catch (Exception)
                {
                    TextMiddle("Pas trouvé :/ ");
                    Console.WriteLine("Alors lequel tu veux utiliser");
                    goto begin;

                }
            return heroChoose;
        }


        public void MenuFight(List<Hero> _tabOfHero)
        {
            List<Hero> tabOfHero = _tabOfHero;
            if (tabOfHero.Count() <= 1)
            {
                Console.WriteLine("Il faut au moins deux héros pour combattre");
                Console.ReadKey();
            }
            this.ShowListHero(tabOfHero);
            TextMiddle("_____Quel héro est le premier combattant ?_____");
                                                    
            Hero hero1 = ChooseYourHero(tabOfHero);
                                                    
            Console.Clear();
            TextMiddle("_____ Choisit le deuxième héro _____");
            this.ShowListHero(tabOfHero);
           
            Hero hero2 = ChooseYourHero(tabOfHero);

            string heroDead = Fight(hero1, hero2);

            if (heroDead == hero1.Name)
            {
                Console.WriteLine(hero1.Name + " est mort ");
                tabOfHero.Remove(hero1);
            }
            else if (heroDead == hero2.Name)
            {
                Console.WriteLine(hero2.Name +" est mort");
                tabOfHero.Remove(hero2);
            }

            Console.WriteLine("Combat Fini");
            Console.ReadKey();
        }

        public bool Verification(string _name, List<Hero> _List)
        {
            bool result = false;
            List<Hero> tabOfHeroes = _List;
            try
            {
                foreach (Hero h in tabOfHeroes)
                {
                    if (h.Name == _name)
                    {
                        result = true;
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("/!\\ Petit problème 404 IDK");
            }
            return result;
        }

        public int Compare(string _name, List<Hero> _list)
        {
            List<Hero> tabOfHeroes = _list;
            int indexHero = 0;
            try
            {
                while (tabOfHeroes[indexHero].Name != (_name))
                {
                    indexHero++;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("/!\\ Petit problème 404 IDK");
            }
            return indexHero;
        }

        public void ShowListHero(List<Hero> _tabOfHeroes)
        {
            List<Hero> tabOfHero = _tabOfHeroes;
            foreach (Hero h in tabOfHero)
            {
                TextMiddle("_____" + h.Name + "____\n");
                Console.WriteLine("Son niveau est " + h.Level);
                Console.WriteLine("Son attaque est " + h.StatisticAttack);
                Console.WriteLine("Sa defense est " + h.StatisticStamina);
                Console.WriteLine("Son endurance est " + h.StatisticDodge);
                Console.WriteLine("Sa vie est : " + h.Health);
            }
        }

        public string Fight(Hero _hero1, Hero _hero2)
        {

            Random rand = new Random();

            Hero fighter1 = _hero1;
            Hero fighter2 = _hero2;
            Console.Clear();
            Console.WriteLine("=== Debut du combat ===");
            string dead = "";
            int turn = 0;
            float dam = 0;
            do
            {
                int NumberRand = rand.Next(30);
                if (turn % 2 == 1)
                {
                    TextMiddle("turn " + turn);
                    Console.WriteLine(fighter1.Name + " Attaque !!");

                    if (NumberRand+fighter2.StatisticStamina >= 30)
                    {
                        TextMiddle(fighter2.Name+" esquive");
                    }
                    else
                    {
                        dam = fighter1.Attack(fighter2);
                        fighter2.TakeDamage(dam);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(fighter2.Name + " prend " + dam + " de degats\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }
                    
                }
                else
                {
                    if (NumberRand + fighter1.StatisticStamina >= 30)
                    {
                        TextMiddle(fighter1.Name + " esquive");
                    }
                    else
                    {
                        TextMiddle("turn " + turn);
                        Console.WriteLine(fighter2.Name + " Attaque !!");

                        dam = fighter2.Attack(fighter1);
                        //string damage1 = damage.ToString();
                        fighter1.TakeDamage(dam);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine(fighter1.Name + " prend " + dam + " de degats\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.ResetColor();
                    }
                }

                turn++;
            
            } while (fighter1.Health > 0 && fighter2.Health > 0);

            if (fighter1.Health <= 0)
            {
                dead = fighter1.Name;
                fighter2.Health = fighter2.Healthmax;

            }
            else if (fighter2.Health <= 0)
            {
                dead = fighter2.Name;
                fighter1.Health = fighter1.Healthmax;
            }

            Console.WriteLine("Fin du combat ");
            return dead;
        }

        public static void TextMiddle(string text)
        {
            int nbspaces = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(nbspaces, Console.CursorTop);
            Console.WriteLine(text);
        }
       
        public void Train(List<Hero> tabOfHero)
        {
        train:
           
            this.ShowListHero(tabOfHero);
            TextMiddle("_____Quel héro entrainer ?_____");
            TextMiddle("Tape quit pour quitter ");
            string line = Console.ReadLine();
            if (line == "quit")
            {
                Console.Clear();
                TextMiddle("Au revoir :'(");
                System.Threading.Thread.Sleep(1500);
            }
            else
            {
                int search = this.Compare(line, tabOfHero);
                if (search > tabOfHero.Count())
                {
                    Console.WriteLine("Petit problème");
                    goto train;
                }
                try
                {
                    Console.WriteLine("Le héro séléctionné est : " + tabOfHero[search].Name);
                    Hero hero = tabOfHero[search];
                    //Train
                    hero.Train(hero.Exp);

                    //Check level up
                    hero.CheckLevel();
                }
                catch (Exception)
                {
                    Console.Clear();
                    TextMiddle("C'est la merde j'ai pas compris recommence");
                    System.Threading.Thread.Sleep(1500);
                    goto train;
                }
            }
            TextMiddle(" Voulez vous recommencer ?! ");
            TextMiddle("o pour oui");
            line = Console.ReadLine();
            if (line == "o" || line == "O")
            {
                Console.Clear();
                goto train;
            }
        }
        public void Hub(List<Hero> _list, string _nameInn)
        {
            string heroName;
            ConsoleKeyInfo choose;
            List<Hero> tabOfHero = _list;
            do
            {
                Console.Clear();
                TextMiddle("===== Bienvenue dans l'auberge de " + _nameInn + "=====");
                TextMiddle("_____________Salut Pelerin_________________");
                TextMiddle("__________Que souhaite tu faires ? ________");
                TextMiddle("___________________Tape____________________");
                TextMiddle("_____1 /-Pour créer un héro _______________");
                TextMiddle("_____2 /-Pour afficher tes héros __________");
                TextMiddle("_____3 /-Pour entrainer un héros __________");
                TextMiddle("_____4 /-Pour faire un duel de héros ______");
                TextMiddle("_____5 /-Pour supprimer un héro ___________");
                TextMiddle("_____6 /-Pour sauvegarder votre partie ____");
                TextMiddle("____________Esc /-Pour quitter ____________");
                choose = Console.ReadKey();

                switch (choose.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        TextMiddle("_____Créer un héros ______");

                        TextMiddle("choisissez le nom de votre héro? ");
                        TextMiddle("Tapez quit pour quitter ");
                        heroName = Console.ReadLine();
                        if (heroName != "quit")
                        {
                            bool verif = this.Verification(heroName, tabOfHero);
                            if (verif == true)
                            {
                                Console.Clear();
                                TextMiddle("Ce nom est déjà attribué ! ");
                                Console.ReadKey();
                                break;
                            }
                            else
                            {
                                Hero bernard = new Hero();
                                bernard.Name = heroName;
                                bernard.Write();
                                tabOfHero.Add(bernard);
                                Console.ReadKey();
                            }
                        }
                        break;

                    case '2':
                        Console.Clear();
                        TextMiddle("_____Afficher les héros _____");
                        this.ShowListHero(tabOfHero);
                        Console.ReadKey();
                        break;

                    case '3': //a changer 
                        Console.Clear();
                        TextMiddle("_____Entrainer un héro_____");
                        Train(tabOfHero);
                        break; 

                    case '4':
                        Console.Clear();
                        TextMiddle("_____ Combat de Heros _____");
                        this.MenuFight(tabOfHero);
                        break;

                    //Tu vas pas supprimer ton héros :'(
                    case '5':
                        Console.Clear();
                        TextMiddle("_____Supprimer des héros ______");
                        this.Delete(tabOfHero);
                        Console.Clear();
                        break;

                    //Sauvagarder c'est important !!!! 
                    case '6':
                        TextMiddle("Sauvegarde");
                        this.Serialization(tabOfHero);
                        Console.Clear();
                        TextMiddle("Sauvegarde Effectué");
                        Console.ReadKey();
                        break;

                    // Ici on cheat nous Monsieur ! 
                    case '9':
                        Console.Clear();
                        Console.WriteLine("Cheat");
                        TextMiddle("_____Ameliorer des héros ______");
                        this.ShowListHero(tabOfHero);
                        string witchOne = Console.ReadLine();
                        try {
                            Hero objet1 = tabOfHero[Compare(witchOne, tabOfHero)];
                            objet1.LevelUp();
                        }
                        catch (Exception) { }
                        
                        Console.ReadKey();
                        break;
                };

            } while (choose.Key != ConsoleKey.Escape);
            //return tabOfHero;
        }
    }
}
