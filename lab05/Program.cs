using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace lab05
{
    /*
     1) К предыдущей лабораторной работе (л.р. 4) добавьте к существующим 
классам перечисление и структуру. 
2) Один из классов сделайте partial и разместите его в разных файлах. 
3) Определить класс-Контейнер (указан в вариантах жирным шрифтом) 
для хранения разных типов объектов (в пределах иерархии) в виде 
списка или массива (использовать абстрактный тип данных). Класс-
контейнер должен содержать методы get и set для управления 
списком/массивом, методы для добавления и удаления объектов в 
список/массив, метод для вывода списка на консоль. 
4) Определить управляющий класс-Контроллер, который управляет 
объектом- Контейнером и реализовать в нем запросы по варианту. При 
необходимости используйте стандартные интерфейсы (IComparable, 
ICloneable,….)  
     */
    internal class Program
    {
        static void Main()
        {
            Tennis player1 = new Tennis("John", 10, 3, 2);
            Tennis player2 = new Tennis("Carl", 7, 3, 5);

            Console.WriteLine(player1.Equals(player2));
            Console.WriteLine();
            player2.GetHashCode();
            Console.WriteLine(player2.ToString());


            ISport bars1 = new Bars(10);
            ISport mats1 = new Mats(30);
            ISport basketball1 = new BasketBall(50);
            ISport volleyball1 = new VolleyBall(45);
            ISport bench1 = new Bench(15);
            Bars bars2 = new Bars(12);
            Inventory mats2 = new Mats(33);
            Inventory basketball2 = new BasketBall(49);
            Inventory volleyball2 = new VolleyBall(48);
            Inventory bench2 = new Bench(19);
            Ball ball1 = new BasketBall(500);

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

            if (basketball1 is Ball)
            {
                Console.WriteLine($"basketball1 is Ball\n");
            }

            ball1.Playing();
            ball1.Shot();
            Printer printer = new Printer();

            Inventory[] arr = { bars2, mats1 as Inventory, basketball2, ball1 };

            foreach (var item in arr)
            {
                Console.WriteLine(printer.IAmPrinting(item));
            }
            Console.WriteLine("----------------------");

            Gym gym = new Gym(500);
            Gym gym1 = new Gym();

            

            gym.Add(volleyball1 as Inventory);
            gym.Add(bench2);
            gym.Add(bars1 as Inventory);
            gym.Add(bars2);
            gym.Add(ball1);
            Controller.Sorting(gym);
            gym.ShowList();

            Console.WriteLine("------");
            
            gym1 = Controller.FindThings(gym, 10, 50);
            gym1.ShowList();
            
        }
    }
}
