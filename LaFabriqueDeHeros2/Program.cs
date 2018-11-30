using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TheHeroFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string innName;

            string folder = Directory.GetCurrentDirectory();
             string folderWay = folder+"\\mySave.txt";

                //Console.WriteLine(FolderWay);
             if(File.Exists(folderWay))
             {
                List<Hero> tabOfHeroes = null;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Hero>));
                FileStream stream = File.OpenRead(folderWay);

                tabOfHeroes = (List<Hero>)serializer.Deserialize(stream);
                Inn inn = new Inn("Sauvegarde");
                stream.Dispose();
                inn.Hub(tabOfHeroes); 
            }
             else
             {
                Console.SetCursorPosition(45, 0);
                Inn.TextMiddle("Comment s'appelle votre auberge ");
                 innName = Console.ReadLine();
                 Inn inn = new Inn(innName);
                List<Hero> EmptyList = new List<Hero>();
                 inn.Hub(EmptyList);
             }
                
        }
    }
}
