using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaFabriqueDeHeros2
{
    class Inn
    {
        //variables

        private string Name; 

        //methods

        public Inn(string _Name)
        {
            Name = _Name;
        }
        public void Write()
        {
            Console.WriteLine(Name);
        }
        public void Fight(string _Hero1, string _Hero2)
        {

        }
    }
}
