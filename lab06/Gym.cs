using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Security.Policy;
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
	public class Gym : Inventory
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

		public Inventory Get(int index)
		{
			if (index < 0 || index >= objects.Count)
			{
				throw new ArrayException();
			}
			return Objects[index];
		}
		public void Set(int index, Inventory value)
		{
			if (index < 0 || index >= objects.Count)
			{
				throw new ArrayException();
			}
			objects[index] = value;
		}
		public void Add(Inventory value)
		{
			if(value.Cost < 0)
			{
				throw new NumberException("Бюджет не может быть отрицательным");
				return;
			}
			Money += value.Cost;
			if (Money > Amount)
			{
				Money -= value.Cost;
				throw new NumberException("Недостаточно средств!\nОбъект не был добавлен!");
				return;
			}
			Objects.Add(value);
		}
		public void Delete(int index)
		{
			
			if (index < 0 || index >= objects.Count)
			{
				throw new ArrayException("Выход индекса массива за допустимые пределы");
			}
			objects.Remove(objects[index]);
		}
		public void ShowList()
		{
			foreach (Inventory item in objects)
			{
				Console.WriteLine(item.ToString() + "\n------");
			}
		}
		public bool IsEmpty()
		{
			return objects.Count == 0;
				
		}
	}

}
