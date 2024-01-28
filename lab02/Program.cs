using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cars;

namespace Lab02
{
    /*
	 1) Определить класс, указанный в варианте, содержащий: 
 Не менее трех конструкторов (с параметрами и без, а также с 
параметрами по умолчанию ); 
 статический конструктор (конструктор типа); 
 определите закрытый конструктор; предложите варианты его вызова; 
 поле - только для чтения (например, для каждого экземпляра сделайте 
поле только для чтения ID - равно некоторому уникальному номеру 
(хэшу) вычисляемому автоматически на основе инициализаторов 
объекта); 
 поле- константу; 
 свойства (get, set) – для всех поле класса (поля класса должны быть 
закрытыми); Для одного из свойств ограните доступ по set 
 в одном из методов класса для работы с аргументами используйте ref - 
и out-параметры. 
 создайте в классе статическое поле, хранящее количество созданных 
объектов (инкрементируется в конструкторе) и статический 
метод вывода информации о классе. 
 сделайте касс partial 
 переопределяете методы класса Object: Equals, для сравнения объектов, 
GetHashCode; для алгоритма вычисления хэша руководствуйтесь 
стандартными рекомендациями, ToString – вывода строки –
информации об объекте. 
2) Создайте несколько объектов вашего типа. Выполните вызов 
конструкторов, свойств, методов, сравнение объекты, проверьте тип 
созданного объекта и т.п.  
3) Создайте массив объектов вашего типа. И выполните задание, 
выделенное курсивом в таблице. 
4) Создайте и выведите анонимный тип (по образцу вашего класса). 
5) Ответьте на вопросы, приведенные ниже 
	 */
    internal class Program
	{
		static void Main(string[] args)
		{
			Bus bus1 = new Bus(712, 23, 1990, 74, "Hatchenko", "D.V.");
			Bus[] busPark = new Bus[4];
			busPark[0] = bus1;
			busPark[1] = new Bus(7, 5, 2001, 199, "Verchuk", "R.H.", "Mercedes");
			busPark[2] = new Bus(102, 34, 2022, 10, "Rubin", "V.R.");
			busPark[3] = new Bus(87, 5, 2010, 530);

			foreach(Bus bus in busPark)
			{
				Console.WriteLine(bus.ToString());
				Console.WriteLine('\n');
            }

			int currentRoute = 5;
			Console.WriteLine("Автобусы с номером маршрута " + currentRoute);
			Console.WriteLine();
            foreach (Bus bus in busPark)
            {
				if (bus.RouteNumber == currentRoute)
				{
					Console.WriteLine(bus.ToString());
					Console.WriteLine('\n');
				}
            }

			int currentAge = 20;
            Console.WriteLine("Автобусы возрастом более " + currentAge + " лет\n");
            
            foreach (Bus bus in busPark)
            {
                if (bus.GetAgeOfBus() > currentAge)
                {
                    Console.WriteLine(bus.ToString());
                    Console.WriteLine('\n');
                }
            }



        }
	}
}
