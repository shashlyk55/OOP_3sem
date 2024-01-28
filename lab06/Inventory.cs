using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab06
{
    public abstract class Inventory
    {
        static private int countOfThingsInInventory = 0;
        public static int CountOfThingsInInventory { get { return countOfThingsInInventory; } set { countOfThingsInInventory = value; } }
        private int cost;
        public int Cost { get { return cost; } 
            set 
            { 
                if(value < 0)
                {
                    throw new NumberException("Цена не может быть отрицательной!");
                }
                cost = value; 
            } 
        }

        //public int Сost { get; internal set; }

        public static int GetCountOfThings()
        {
            return countOfThingsInInventory;
        }
    }
}
