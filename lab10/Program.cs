using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace lab10
{
    /*
	1. Задайте массив типа string, содержащий 12 месяцев (June, July, May, 
	December, January ….). Используя LINQ to Object напишите запрос выбирающий 
	последовательность месяцев с длиной строки равной n, запрос возвращающий 
	только летние и зимние месяцы, запрос вывода месяцев в алфавитном порядке, 
	запрос  считающий месяцы содержащие букву «u» и длиной имени не менее 4-х..
	2. Создайте коллекцию List<T> и параметризируйте ее типом (классом) 
	из лабораторной №2 (при необходимости реализуйте нужные интерфейсы). 
	Заполните ее минимум 10 элементами.  
	Если в задании указано свойство, которым ваш класс не обладает, то его 
	нужно расширить, чтобы класс соответствовал условию. Один из запросов 
	реализуйте используя язык LINQ и используя методы расширения LINQ. 
	3. На основе LINQ сформируйте следующие запросы по вариантам. 
	При необходимости добавьте в класс T (тип параметра) свойства. 
	4. Придумайте и напишите свой собственный запрос, в котором было 
	бы не менее 5 операторов из разных категорий: условия, проекций, 
	упорядочивания, группировки, агрегирования, кванторов и разбиения. 
	 */
    class Program
	{
		static void Main()
		{
			var months = new List<string>{ "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

			foreach (string month in months) Console.WriteLine(month);

			Console.Write("Введите количество символов: ");
			var n = Convert.ToInt32(Console.ReadLine());
			var list = from month in months where month.Length == n select month;

			Console.WriteLine($"Слова длиной {n}");
			foreach(string month in list) Console.WriteLine(month);

			Console.ReadKey();
			Console.Clear();

			Console.WriteLine($"Зимние месяцы: ");
			list = from month in months where (month == "December" || month == "January" || month == "February") select month;
			foreach (string month in list) Console.WriteLine(month);
			Console.WriteLine();
			Console.WriteLine($"Летние месяцы: ");
			//list = from month in months where (month == "June" || month == "July" || month == "August") select month;
			list = months.Where(month => (month == "June" || month == "July" || month == "August")).Select(month => month);
			foreach (string month in list) Console.WriteLine(month);

			Console.ReadKey();
			Console.Clear();

			Console.WriteLine("В алфавитном порядке: ");
			list = months.OrderBy(months => months);
			//list = from month in months orderby month select month;
			foreach (string month in list) Console.WriteLine(month);

			Console.ReadKey();
			Console.Clear();

			Console.WriteLine("Содержат букву u: ");
			list = months.Where(month=>month.Contains('u'))
						 .Select(month => month);
			//list = from month in months where month.Contains('u') select month;

			foreach (string month in list) Console.WriteLine(month);
			Console.WriteLine();
			Console.WriteLine("Длина не менее 4 символов: ");
			list = months.Where(month => month.Length > 3)
						 .Select(month => month);
			foreach (string month in list) Console.WriteLine(month);
			Console.ReadKey();
			Console.Clear();
			
			///////////////////////
			var busPark = new List<Bus>();

			busPark.Add(new Bus("Hatchenko", 14, 4, 2001, 782));
			busPark.Add(new Bus("Verchuk", 2, 1, 2020, 125));
			busPark.Add(new Bus("Biba", 1, 3, 1985, 2310));
			busPark.Add(new Bus("Rubin", 11, 5, 2014, 281));
			busPark.Add(new Bus("Boba", 7, 4, 1999, 1420));
			busPark.Add(new Bus("Biber", 6, 5, 2002, 842));
			busPark.Add(new Bus("Dolik", 13, 9, 1991, 1732));

            Console.Write("Автобусы по маршруту: ");
			var number = Convert.ToInt32(Console.ReadLine());

			var buses = from bus in busPark where bus.RouteNumber == number select bus;
			foreach(var bus in buses) Console.WriteLine(bus.ToString() + "\n");

            Console.ReadKey();
            Console.Clear();

            Console.Write("Введите количество лет эксплуатации автобуса: ");
            var years = Convert.ToInt32(Console.ReadLine());
			buses = busPark.FindAll(bus => bus.GetAgeOfBus() > years);
			Console.WriteLine($"Автобусы, которые эксплуатируются дольше заданного срока: ");
            foreach (var bus in buses) Console.WriteLine(bus.ToString() + "\n");

			Console.ReadKey();
            Console.Clear();

			//buses = busPark.OrderByDescending(bus => bus.Mileage).TakeLast(1);
			var obj = busPark.Find(bus => bus.Mileage == busPark.Min(bus => bus.Mileage));
            Console.WriteLine("Минимальный по пробегу автобус: ");
			Console.WriteLine(obj.ToString() + "\n");

            Console.ReadKey();
            Console.Clear();

			buses = busPark.OrderBy(bus => bus.Mileage).TakeLast(2);
            Console.WriteLine("2 максимальные по пробегу автобусы: ");
			foreach (var bus in buses) Console.WriteLine(bus.ToString() + "\n");

            Console.ReadKey();
            Console.Clear();

			buses = from bus in busPark orderby bus.BusNumber select bus;
			Console.WriteLine("Автобусы по номеру: ");
			foreach(var bus in buses) Console.WriteLine(bus.ToString() + "\n");

            Console.ReadKey();
            Console.Clear();
            ///////////////////
			buses = from bus in busPark where bus.StartYear > 2000 orderby bus.BusNumber select bus;

			var list1 = new List<Bus>();

            busPark.Add(new Bus("aaaaa", 1, 1, 2020, 10));

			var busList = busPark
				.Where(bus => bus.StartYear > 2000)
				.OrderByDescending(bus => bus.Mileage)
				.TakeLast(3)
				.Select(bus => bus)
				.Union(list1);

			Console.WriteLine();
			foreach(var bus in busList)
			{
				Console.WriteLine(bus.ToString() + "\n");
			}



        }
    }
}