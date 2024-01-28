using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    /*
     1) Определить иерархию и композицию классов (в соответствии с вариантом), 
реализовать классы. Если необходимо расширьте по своему усмотрению 
иерархию для выполнения всех пунктов л.р.  
Каждый класс должен иметь отражающее смысл название и 
информативный состав. При кодировании должны быть использованы 
соглашения об оформлении кода code convention. 
В одном из классов переопределите все методы, унаследованные от 
Object. 
2) В проекте должен быть минимум один интерфейс и абстрактный класс. 
Использовать виртуальные методы и переопределение. 
3) Сделайте один из классов sealed; 
4) Добавьте в интерфейсы (интерфейс) и абстрактный класс одноименные 
методы.  
Дайте в наследуемом классе им разную реализацию и вызовите эти методы. 
5) Написать демонстрационную программу, в которой создаются объекты 
различных классов. Поработать с объектами через ссылки на абстрактные 
классы и интерфейсы. В этом случае для идентификации типов объектов 
использовать операторы is или as. 
6) Во всех классах (иерархии) переопределить метод ToString(), который 
выводит информацию о типе объекта и его текущих значениях.  
7) Создайте дополнительный класс Printer c полиморфным методом 
IAmPrinting( SomeAbstractClassorInterface someobj). Формальным 
параметром метода должна быть ссылка на абстрактный класс или наиболее 
общий интерфейс в вашей иерархии классов. В методе iIAmPrinting 
определите тип объекта и вызовите ToString(). В демонстрационной 
программе создайте массив, содержащий ссылки на разнотипные объекты 
ваших классов по иерархии, а также объект класса Printer  и последовательно 
вызовите его метод IAmPrinting  со всеми ссылками в качестве аргументов. 
     */
    internal class Program
    {
        static void Main()
        {
            Tennis player1 = new Tennis("John", 10, 3);
            Tennis player2 = new Tennis("Carl", 7, 3);

            Console.WriteLine(player1.Equals(player2));
            Console.WriteLine();
            player2.GetHashCode();
            Console.WriteLine(player2.ToString());


            ISport bars1 = new Bars();
            ISport mats1 = new Mats();
            ISport basketball1 = new BasketBall();
            ISport volleyball1 = new VolleyBall();
            ISport bench1 = new Bench();
            Bars bars2 = new Bars();
            Inventory mats2 = new Mats();
            Inventory basketball2 = new BasketBall();
            Inventory volleyball2 = new VolleyBall();
            Inventory bench2 = new Bench();
            Ball ball1 = new BasketBall();

            Console.WriteLine(Inventory.GetCountOfThings());

            bench1.SetWeight(100);

            Console.WriteLine();

            bars2.SetMaxWeight(200);
            bars2.SetWeight(150);
            Console.WriteLine(bars2.ToString());

            mats1.SetWeight(50);    //из инерфейса
            ball1.SetWeight(20);    //через абстр класс

            Console.WriteLine();

            basketball1 = ball1;
            
            ball1 = basketball1 as Ball;
            
            if(basketball1 is Ball)
            {
                Console.WriteLine($"basketball1 is Ball\n");
            }

            ball1.Playing();
            ball1.Shot();


            Printer printer = new Printer();

            Inventory[] arr = { bars2, mats1 as Inventory, basketball2, ball1};

            foreach(var item in arr)
            {
                Console.WriteLine(printer.IAmPrinting(item));
            }
            
        }
    }
}
