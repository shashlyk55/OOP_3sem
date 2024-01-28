using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

/*
Подготовить Спортзал. Снарядов должно быть 
фиксированное количество в пределах выделенной суммы 
денег. Провести сортировку инвентаря в Спортзале по 
одному из параметров. Найти снаряды, соответствующие 
заданному диапазону цены.  
*/

namespace lab05
{
    partial class Gym : Inventory
    {
        internal List<Inventory> objects = new List<Inventory>();
        public List<Inventory> Objects { get { return objects; } }
        private int amount;
        public int Amount { get { return amount; } set { amount = value; } }
        private int money = 0;
        public int Money { get { return money; } set { money = value; } }
        internal Gym()
        {
            
        }
        public Gym(int Amount = 0)
        {
            this.Amount = Amount;
        }
        
    }
}
