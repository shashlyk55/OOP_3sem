using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace lab09
{
    /*
     Создайте класс по варианту, определите в нем свойства и методы, реализуйте 
    указанный интерфейс и другие при необходимости, соберите объекты класса  в 
    коллекцию (можно сделать специальных класс с вложенной коллекцией и 
    методами ею управляющими), продемонстрируйте работу с ней.

    Создайте универсальную коллекцию в соответствии с вариантом задания и 
    заполнить ее данными встроенного типа .Net (int, char,…).   
    a. Выведите коллекцию на консоль 
    b. Создайте вторую коллекцию (из таблицы выберите другой тип 
    коллекции) и заполните ее данными из первой коллекции.  
    c. Выведите вторую коллекцию на консоль.
    d. Найдите во второй коллекции заданное значение. 

    Создайте объект наблюдаемой коллекции ObservableCollection<T>. Создайте 
    произвольный метод и зарегистрируйте его на событие CollectionChange. 
    Напишите демонстрацию с добавлением и удалением элементов. В качестве 
    типа T используйте  свой класс из таблицы. 
     */


    internal class Program
    {
        static void Main()
        {

            IList<int> numbers = new Collection<int>(1, 4, 5, 6, 8);

            InternetResource<string> webSite = new InternetResource<string>("belstu.by", "conten1");

            IList<InternetResource<string>> webSites = new Collection<InternetResource<string>>(webSite);
            try
            {

                webSites.Add(new InternetResource<string>("belstu.by", "content1"));
                webSites.Add(new InternetResource<string>("bsu.by", "content2"));
                webSites.Add(new InternetResource<string>("rw.by", "content3"));
                webSites.Add(new InternetResource<string>("diskstation.by", "content4"));
                webSites.Add(new InternetResource<string>("bntu.by", "content5"));


                foreach (InternetResource<string> site in webSites)
                    Console.WriteLine(site.Name + " " + site.Content);

                Console.ReadKey();
                Console.Clear();

                for (int i = 1; i < 4; i++)
                {
                    webSites.RemoveAt(i);
                }

                foreach (InternetResource<string> site in webSites)
                    Console.WriteLine(site.Name + " " + site.Content);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }


            ///////////////////////


            ConcurrentDictionary<string, InternetResource<string>> dict = new ConcurrentDictionary<string, InternetResource<string>>();

            foreach (InternetResource<string> site in webSites)
            {
                dict.TryAdd(site.Name, site);
            }
            Console.WriteLine();
            InternetResource<string> res = new InternetResource<string>();

            Console.WriteLine(dict.TryGetValue("bsu.by", out res) ? $"Найдено: {res.Name} {res.Content}" : "Не найдено");

            Console.ReadKey();
            Console.Clear();

            ObservableCollection<InternetResource<string>> observ = new ObservableCollection<InternetResource<string>>();

            observ.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        Console.WriteLine("Объект добавлен: " + (InternetResource<string>)e.NewItems[0]);
                        break;
                    case NotifyCollectionChangedAction.Remove:
                        Console.WriteLine("Объект удален: " + ((InternetResource<string>)e.OldItems[0]));
                        break;
                    default:
                        Console.WriteLine("Список изменен");
                        break;

                }
            };
            observ.Add(res);
            observ.Remove(res);

        }
    }
}