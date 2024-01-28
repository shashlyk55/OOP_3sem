using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

/*
Подготовить Спортзал. Снарядов должно быть 
фиксированное количество в пределах выделенной суммы 
денег. Провести сортировку инвентаря в Спортзале по 
одному из параметров. Найти снаряды, соответствующие 
заданному диапазону цены.  
*/

namespace lab06
{
    public static class Controller
    {
        internal static void Sorting(Gym list)
        {
            if (list.Objects.Count == 1)
            {
                return; 
            }
            if (list.IsEmpty())
            {
                throw new SortException("Нельзя сортировать пустой список!");
            }
            list.Objects.Sort((obj1, obj2) => obj1.Cost.CompareTo(obj2.Cost));
        }

        internal static Gym FindThings(Gym list, int min, int max)
        {
            Gym result = new Gym();
            foreach (Inventory item in list.Objects)
            {
                if (item.Cost < max && item.Cost > min)
                {
                    result.Objects.Add(item);
                }
            }
            return result;
        }
    }
}
