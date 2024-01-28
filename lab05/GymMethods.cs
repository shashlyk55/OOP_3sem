using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    partial class Gym
    {
        public Inventory Get(int index)
        {
            if (index < 0 || index >= objects.Count)
            {
                return null;
            }
            return Objects[index];
        }
        public void Set(int index, Inventory value)
        {
            if (index < 0 || index >= objects.Count)
            {
                throw new ArgumentException("Выход индекса за допустимые пределы\n");
            }
            objects[index] = value;
        }
        public void Add(Inventory value)
        {
            Money += value.Cost;
            if (Money > Amount)
            {
                Console.WriteLine($"Недостаточно средств!\nНе добавлен объект:{value}\n");
                Money -= value.Cost;
                return;
            }
            Objects.Add(value);
            Controller.Sorting(this);
        }
        public void Delete(int index)
        {
            objects.Remove(objects[index]);
        }
        public void ShowList()
        {
            foreach (Inventory item in objects)
            {
                Console.WriteLine(item.ToString() + "\n------");
            }
        }
    }
}
