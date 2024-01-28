using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
	/*Класс - однонаправленный список List. Дополнительно 
	перегрузить следующие операции: ! – инверсия элементов; 
	+  -  объединить два списка; == - проверка на равенство; < - 
	добавление одного списка к другому. 
	Методы расширения: 
	1) Усечение строки до заданной длины 
	2) Сумма элементов списка */
	internal class ListClass<T> : List<T>
	{
		public List<T> list = new List<T>();

		public ListClass(params T[] array)
		{
			list.AddRange(array);
		}

		public Production production = new Production("ITBEL");

		public T this[int index]
		{
			get
			{
				if (index >= 0 && index < list.Count)
					return list[index];
				else
					throw new IndexOutOfRangeException("Index is out of range");
			}
			set
			{
				if (index >= 0 && index < list.Count)
					list[index] = value;
				else
					throw new IndexOutOfRangeException("Index is out of range");
			}
		}


		public class Developer
		{
			private string _fio;
			private int _id = 0;
			private string _department;

			public Developer(string fio, int id, string department)
			{
				_id++;
				Fio = fio;
				Department = department;
			}

			public string Fio
			{
				get { return _fio; }
				set { _fio = value; }
			}

			public int Id
			{
				get { return _id; }
			}
			public string Department
			{
				get { return _department; }
				set { _department = value; }
			}
		}

		public static ListClass<T> operator +(ListClass<T> list1, ListClass<T> list2)
		{
			int i = 0;
			T[] array = new T[list1.list.Count + list2.list.Count];

			for (; i < list1.list.Count; i++)
			{
				array[i] = list1.list[i];
			}

            for (int j = 0; i < list2.list.Count + list1.list.Count; i++,j++)
            {
                array[i] = list2.list[j];
            }
			ListClass<T> resultList = new ListClass<T>(array);
			
			return resultList;
		}

		public static ListClass<T> operator <(ListClass<T> list1, ListClass<T> list2)
		{
			foreach(var item in list1.list)
			{
				list2.list.Add(item);
			}

            return list2;
		}
		
		public static ListClass<T> operator >(ListClass<T> list1, ListClass<T> list2)
		{
            foreach (var item in list2.list)
            {
                list1.list.Add(item);
            }

            return list1;
		}
		
		public static bool operator !=(ListClass<T> list1, ListClass<T> list2)
		{
			for (int i = 0; (i < list1.list.Count) || (i < list2.list.Count); i++)
			{
				if (list1[i].Equals(list2[i]))
				{
					return false;
				}
			}
			return true;
		}
		
		public static bool operator ==(ListClass<T> list1, ListClass<T> list2)
		{
            if (list1.list.Count != list2.list.Count)
            {
                return false;
            }

            for (int i = 0; (i < list1.list.Count) || (i < list2.list.Count); i++)
            {
                if (!list1[i].Equals(list2[i]))
                {
                    return false;
                }
            }
			return true;
        }
	}
}

