using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using lab03;

namespace lab03
{
    /*
	 1) Создать заданный в варианте класс. Определить в классе необходимые 
методы, конструкторы, индексаторы и заданные перегруженные 
операции. Написать программу тестирования, в которой проверяется 
использование перегруженных операций. 
2) Добавьте в свой класс вложенный объект Production, который содержит 
Id, название организации. Проинициализируйте его 
3) Добавьте в свой класс вложенный класс Developer (разработчик – фио, 
id, отдел). Проинициализируйте 

 

4) Создайте статический класс StatisticOperation, содержащий 3 метода для 
работы с вашим классом (по варианту п.1): сумма, разница между 
максимальным и минимальным, подсчет количества элементов. 
5) Добавьте к классу StatisticOperation методы расширения для типа string 
и  вашего типа из задания№1.
	 */
    class Program
	{
		static void Main()
		{
			ListClass<int> spisok1 = new ListClass<int>(new int[] { 2, 7, 11, 9 });
			ListClass<int> spisok2 = new ListClass<int>(1, 2, 3, 4 );
			ListClass<int> spisok3 = new ListClass<int>();
			ListClass<int> spisok4 = new ListClass<int>(new int[] { 1, 2, 3, 4 });

			spisok3 = spisok1 + spisok2;

			foreach (int elem in spisok3.list)
			{
				Console.Write(elem + " ");
			}
			Console.WriteLine();

			spisok3 = spisok3 > spisok1;
			
			foreach(int elem in spisok3.list)
			{
				Console.Write(elem + " ");
			}
			Console.WriteLine();

			Console.WriteLine(spisok1 == spisok4);

			Console.WriteLine(spisok2 != spisok1);

			Console.WriteLine(spisok1[2]);

			Console.WriteLine(spisok1.production.OrganizationName);

			ListClass<int>.Developer devs = new ListClass<int>.Developer("S.I.V.", 143, "FrontEnd");

			Console.WriteLine(spisok2.CountOfElements());
			Console.WriteLine(spisok1.DifferenceMaxMin());
			Console.WriteLine(spisok4.ListSum());

			string str = "Hello";
			Console.WriteLine(StaticOperations.StrTrim(str, 2));
		}
	}
}
