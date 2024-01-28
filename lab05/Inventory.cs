using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab05
{
    public abstract class Inventory
    {
        static private int countOfThingsInInventory = 0;
        public static int CountOfThingsInInventory { get { return countOfThingsInInventory; } set { countOfThingsInInventory = value; } }
        private int cost;
        public int Cost { get { return cost; } set { cost = value; } }

        //public int Сost { get; internal set; }
        
        public static int GetCountOfThings()
        {
            return countOfThingsInInventory;
        }
    }
}
