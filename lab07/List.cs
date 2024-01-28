using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab07
{
    /*Класс - однонаправленный список List. Дополнительно 
	перегрузить следующие операции: ! – инверсия элементов; 
	+  -  объединить два списка; == - проверка на равенство; < - 
	добавление одного списка к другому. 
	Методы расширения: 
	1) Усечение строки до заданной длины 
	2) Сумма элементов списка */
    internal class Collection<T> : List<T>, ICollection<T> 
    {
        private List<T> list = new List<T>();
        public int Count { get { return list.Count; } }
        public Collection(params T[] array)
        {
            list.AddRange(array);
        }

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

        public void Add(params T[] value)
        {
            list.AddRange(value);
        }
        public void Delete(int index)
        {
            if (index >= 0 && index < list.Count)
                list.RemoveAt(index);
            else
                throw new IndexOutOfRangeException("Index is out of range");
        }
        public void Print()
        {
            if (list.Count > 0)
            {
                foreach (T item in list)
                {
                    Console.WriteLine(item);
                }
            }
            else
                throw new Exception("List is empty!\n");
        }

        public static Collection<T> operator +(Collection<T> list1, Collection<T> list2)
        {
            int i = 0;
            T[] array = new T[list1.list.Count + list2.list.Count];

            for (; i < list1.list.Count; i++)
            {
                array[i] = list1.list[i];
            }

            for (int j = 0; i < list2.list.Count + list1.list.Count; i++, j++)
            {
                array[i] = list2.list[j];
            }
            Collection<T> resultList = new Collection<T>(array);

            return resultList;
        }

        public static Collection<T> operator <(Collection<T> list1, Collection<T> list2)
        {
            foreach (var item in list1.list)
            {
                list2.list.Add(item);
            }

            return list2;
        }

        public static Collection<T> operator >(Collection<T> list1, Collection<T> list2)
        {
            foreach (var item in list2.list)
            {
                list1.list.Add(item);
            }

            return list1;
        }

        public static bool operator !=(Collection<T> list1, Collection<T> list2)
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

        public static bool operator ==(Collection<T> list1, Collection<T> list2)
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

