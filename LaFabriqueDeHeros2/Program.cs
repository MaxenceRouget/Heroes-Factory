using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TheHeroFactory
{
    public struct Save
    {
        private List<Hero> list;
        private string nameInn;

        public List<Hero> List
        {
            get { return list; }
            set { list = value; }
        }
        public string NameInn
        {
            get { return nameInn; }
            set { nameInn = value; }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string innName;

            string folder = Directory.GetCurrentDirectory();
            string folderWay = folder + "\\mySave.txt";

            //Console.WriteLine(FolderWay);
            if (File.Exists(folderWay))
            {
                Save save = new Save();
                XmlSerializer serializer = new XmlSerializer(typeof(Save));
                FileStream stream = File.OpenRead(folderWay);

                save = (Save)serializer.Deserialize(stream);

                Inn inn = new Inn(save.NameInn);
                stream.Dispose();
                inn.Hub(save.List, save.NameInn);
            }
            else
            {
                Console.SetCursorPosition(45, 0);
                Inn.TextMiddle("Comment s'appelle votre auberge ");
                innName = Console.ReadLine();
                Inn inn = new Inn(innName);
                List<Hero> EmptyList = new List<Hero>();
                inn.Hub(EmptyList, innName);
            }

        }
    }
}
