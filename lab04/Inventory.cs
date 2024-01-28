using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public abstract class Inventory
    {
        static protected int countOfThings = 0;

        public static int GetCountOfThings()
        {
            return countOfThings;
        }
        

    }
}
