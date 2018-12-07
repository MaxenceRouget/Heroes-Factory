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
            this.showListHero(tabOfHero);
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
            List<Hero> tabOfHero = _tabOfHero;
            Hero heroChoose = new Hero();

            string line = Console.ReadLine();
            int search = this.Compare(line, tabOfHero);

            //barrière 
            if (search > tabOfHero.Count)
            {
                Console.WriteLine("Petit problème");
            }

            try
            {
                heroChoose = tabOfHero[search];
                Console.WriteLine(heroChoose.getSetAttack);
            }
            catch (Exception)
            {
                TextMiddle("Pas trouvé :/ ");
            }
            Console.WriteLine(heroChoose.getSetAttack);
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
            this.showListHero(tabOfHero);
            TextMiddle("_____Quel héro est le premier combattant ?_____");

            Hero hero1 = ChooseYourHero(tabOfHero);
        //Deuxième Hero 
        
            Console.Clear();
            TextMiddle("_____ Choisit le deuxième héro _____");
            this.showListHero(tabOfHero);
           
            Hero hero2 = ChooseYourHero(tabOfHero);


            string heroDead = Fight(hero1, hero2);
            //Console.WriteLine(heroDead);

            if (heroDead == hero1.Name)
            {
                Console.WriteLine(hero1.Name + " est mort ");
                tabOfHero.Remove(hero1);
            }
            else
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

        public int Compare(string _name, List<Hero> _List)
        {
            List<Hero> tabOfHeroes = _List;
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

        public void showListHero(List<Hero> _tabOfHeroes)
        {
            List<Hero> tabOfHero = _tabOfHeroes;
            foreach (Hero h in tabOfHero)
            {
                TextMiddle("_____" + h.Name + "____\n");
                Console.WriteLine("Son niveau est " + h.Level);
                Console.WriteLine("Son attaque est " + h.getSetAttack);
                Console.WriteLine("Sa defense est " + h.getSetDefense);
                Console.WriteLine("Son endurance est " + h.getSetDodge);
                Console.WriteLine("Sa vie est : " + h.Health);
            }
        }

        public string Fight(Hero _hero1, Hero _hero2)
        {
            Hero fighter1 = _hero1;
            Hero fighter2 = _hero2;

            Console.WriteLine("=== Debut du combat ===");
            string dead = "";
            do
            {
                int turn = 1;
                Console.WriteLine("Tour numero " + turn);
                Console.WriteLine("C'est " + fighter1.Name + " qui commence ");
                Console.WriteLine(fighter1.Name + " Attaque !!");

                float damage = fighter1.Attack(fighter2);
                string damage1 = damage.ToString();
                fighter2.TakeDamage(damage);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(fighter2.Name + " prend " + damage1 + " de degats\n");
                System.Threading.Thread.Sleep(1000);
                Console.ResetColor();
                if (fighter2.Health <= 0)
                {
                    dead = fighter2.Name;
                    break;
                }
                else
                {
                    Console.WriteLine(fighter2.Name + " Attaque !!");
                    float _damage = fighter2.Attack(fighter1);
                    fighter1.TakeDamage(_damage);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.WriteLine(fighter1.Name + " prend " + damage + " de degats\n");
                    System.Threading.Thread.Sleep(1000);
                    Console.ResetColor();

                    if (fighter1.Health <= 0)
                    {
                        dead = fighter1.Name;
                        break;
                    }

                }

            } while (fighter1.Health > 0 && fighter2.Health > 0);

            Console.WriteLine("Fin du combat ");
            return dead;
        }

        public static void TextMiddle(string text)
        {
            int nbspaces = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(nbspaces, Console.CursorTop);
            Console.WriteLine(text);
        }

        public void Hub(List<Hero> _list, string _nameInn)
        {
            int search = 0;
            int compt2 = 0;
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
                                compt2++;
                            }
                        }
                        break;

                    case '2':
                        Console.Clear();
                        TextMiddle("_____Afficher les héros _____");
                        this.showListHero(tabOfHero);
                        Console.ReadKey();
                        break;

                    case '3': //a changer 

                    train:
                        Console.Clear();
                        TextMiddle("_____Entrainer un héro_____");
                        this.showListHero(tabOfHero);
                        TextMiddle("_____Quel héro entrainer ?_____");
                        TextMiddle("Tape quit pour quitter ");
                        string line = Console.ReadLine();
                        if (line == "quit")
                        {
                            Console.Clear();
                            TextMiddle("Au revoir :'(");
                            System.Threading.Thread.Sleep(1500);
                            break;
                        }
                        else
                        {
                            search = this.Compare(line, tabOfHero);
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
                            goto train;
                        }
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
                        Console.WriteLine("_____Ameliorer des héros ______");
                        this.showListHero(tabOfHero);

                        Console.WriteLine("_____saisir le numero du héro à amelioré ______");
                        line = Console.ReadLine();
                        search = 0;
                        try
                        {
                            search = int.Parse(line);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Problème /!\\ Chiffre entrée incorrect");
                            break;
                        }

                        if (search + 1 > tabOfHero.Count())
                        {
                            Console.WriteLine("Problème /!\\ Chiffre entrée trop grand ");
                            break;
                        }

                        Hero objet1 = tabOfHero[search];
                        objet1.LevelUp();
                        Console.ReadKey();
                        break;
                };

            } while (choose.Key != ConsoleKey.Escape);
            //return tabOfHero;
        }
    }
}
